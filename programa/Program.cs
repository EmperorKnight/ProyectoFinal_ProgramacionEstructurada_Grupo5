using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Genero { get; set; }
    public int Puntuacion { get; set; }

    public Libro() { }

    public Libro(string t, string a, string g, int p)
    {
        Titulo = t;
        Autor = a;
        Genero = g;
        Puntuacion = p;
    }

    public override string ToString()
    {
        return $"Título: {Titulo}\nAutor: {Autor}\nGénero: {Genero}\nPuntuación: {Puntuacion}\n";
    }
}

class Nodo
{
    public Libro Dato;
    public Nodo Izq;
    public Nodo Der;

    public Nodo(Libro l)
    {
        Dato = l;
    }
}

class Arbol
{
    public Nodo Raiz;

    public void Insertar(Libro libro)
    {
        Raiz = InsertarRec(Raiz, libro);
    }

    private Nodo InsertarRec(Nodo nodo, Libro libro)
    {
        if (nodo == null)
        {
            return new Nodo(libro);
        }

        if (string.Compare(libro.Titulo, nodo.Dato.Titulo, true) < 0)
        {
            nodo.Izq = InsertarRec(nodo.Izq, libro);
        }
        else
        {
            nodo.Der = InsertarRec(nodo.Der, libro);
        }

        return nodo;
    }

    public Libro Buscar(string titulo)
    {
        Nodo actual = Raiz;

        while (actual != null)
        {
            int comp = string.Compare(titulo, actual.Dato.Titulo.ToLower(), true);

            if (comp == 0)
                return actual.Dato;

            actual = comp < 0 ? actual.Izq : actual.Der;
        }

        return null;
    }

    public bool Eliminar(string titulo)
    {
        bool eliminado = false;
        Raiz = Eliminar(Raiz, titulo.ToLower(), ref eliminado);
        return eliminado;
    }

    private Nodo Eliminar(Nodo nodo, string titulo, ref bool eliminado)
    {
        if (nodo == null)
            return null;
        int comp = string.Compare(titulo, nodo.Dato.Titulo.ToLower(), true);
        if (comp < 0)
        {
            nodo.Izq = Eliminar(nodo.Izq, titulo, ref eliminado);
        }
        else if (comp > 0)
        {
            nodo.Der = Eliminar(nodo.Der, titulo, ref eliminado);
        }
        else
        {
            eliminado = true;
            if (nodo.Izq == null)
            {
                return nodo.Der;
            }
            else if (nodo.Der == null)
            {
                return nodo.Izq;
            }
            Nodo sucesor = Minimo(nodo.Der);
            nodo.Dato = sucesor.Dato;
            nodo.Der = Eliminar(nodo.Der, sucesor.Dato.Titulo.ToLower(), ref eliminado);
        }
        return nodo;
    }

    private Nodo Minimo(Nodo actual)
    {
        while (actual.Izq != null)
            actual = actual.Izq;

        return actual;
    }

    public void MostrarInorden()
    {
        InordenRec(Raiz);
    }

    private void InordenRec(Nodo nodo)
    {
        if (nodo == null)
        {
            return;
        }

        InordenRec(nodo.Izq);
        if (nodo.Dato.Titulo != null)
            Console.WriteLine(nodo.Dato);
        InordenRec(nodo.Der);
    }

    public Libro Recomendar(string genero, string autor)
    {
        List<Libro> lista = new List<Libro>();
        ObtenerLista(Raiz, lista);

        Libro mejor = null;
        int mejorScore = -1;

        foreach (var l in lista)
        {
            int score = 0;

            if (l.Genero.Equals(genero, StringComparison.OrdinalIgnoreCase))
            {
                score += 2;
            }

            if (l.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase))
            {
                score += 1;
            }

            if (score > mejorScore)
            {
                mejorScore = score;
                mejor = l;
            }
        }

        return mejor;
    }

    private void ObtenerLista(Nodo nodo, List<Libro> lista)
    {
        if (nodo == null)
        {
            return;
        }

        ObtenerLista(nodo.Izq, lista);
        lista.Add(nodo.Dato);
        ObtenerLista(nodo.Der, lista);
    }
}

class Program
{
    static string archivo = "libros.dat";

    static string DeterminarCadenaVaciaOConNumero(string mensaje, ref Arbol arbol, string ta)
    {
        Console.Write(mensaje);
        string dato = Console.ReadLine()?.Trim();

        Libro h;

        if (mensaje.Contains("nuevo") || mensaje.Contains("nueva"))
        {
            if (string.IsNullOrEmpty(dato) || string.IsNullOrWhiteSpace(dato))
            {
                if (mensaje.Contains("titulo") && ta != "")
                {
                    h = arbol.Buscar(ta);
                    dato = h.Titulo;
                    return dato;
                }
                if (mensaje.Contains("autor") && ta != "")
                {
                    h = arbol.Buscar(ta);
                    dato = h.Autor;
                    return dato = h.Autor;
                }
                if (mensaje.Contains("genero") && ta != "")
                {
                    h = arbol.Buscar(ta);
                    dato = h.Genero;
                    return dato;
                }
                if (mensaje.Contains("puntuacion") && ta != "")
                {
                    h = arbol.Buscar(ta);
                    dato = Convert.ToString(h.Puntuacion);
                    return dato;
                }
            }
            else
            {
                if (mensaje.Contains("titulo") && ta != "")
                {
                    return dato;
                }
                if (mensaje.Contains("autor") && ta != "")
                {
                    return dato;
                }
                if (mensaje.Contains("genero") && ta != "")
                {
                    return dato;
                }
                if (mensaje.Contains("puntuacion") && ta != "")
                {
                    return dato;
                }
            }
        }

        if (!mensaje.Contains("modificar"))
        {
            if (string.IsNullOrEmpty(dato) || string.IsNullOrWhiteSpace(dato))
            {
                Console.WriteLine("Entrada inválida. Inténtelo de nuevo.\n");
                return DeterminarCadenaVaciaOConNumero(mensaje, ref arbol, "");
            }
        }

        if (mensaje != "Titulo: ")
        {
            foreach (char c in dato)
            {
                if (char.IsDigit(c))
                {
                    Console.WriteLine("Esta parte no debe contener números. Inténtelo de nuevo.\n");
                    return DeterminarCadenaVaciaOConNumero(mensaje, ref arbol, "");
                }
            }
        }

        return dato;
    }

    static int ValidarEntero(string mensaje)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(entrada) || string.IsNullOrWhiteSpace(entrada))
        {
            Console.WriteLine("No debe dejar en blanco esta parte. Inténtelo de nuevo.\n");
            return ValidarEntero(mensaje);
        }

        foreach(char c in entrada)
        {
            if (!char.IsDigit(c))
            {
                Console.WriteLine("Entrada inválida. Inténtelo de nuevo.\n");
                return ValidarEntero(mensaje);
            }
        }

        int numero = Convert.ToInt32(entrada);

        if(mensaje == "Puntuación (1-10): ")
        {
            if (numero < 1 || numero > 10)
            {
                Console.WriteLine("La puntuación debe estar entre 1 y 10. Inténtelo de nuevo.\n");
                return ValidarEntero(mensaje);
            }
        }

        return numero;
    }

    static void Esperar()
    {
        Console.Write("\nPresione ENTER para continuar.....");
        Console.ReadKey();
        Console.Clear();
    }

    static void Main()
    {
        Arbol arbol = new Arbol();
        Cargar(arbol);
        int opcion;

        do
        {
            Console.WriteLine("===== SISTEMA DE LIBROS (ABB + Archivo) =====");
            Console.WriteLine("1. Agregar libro");
            Console.WriteLine("2. Buscar libro");
            Console.WriteLine("3. Mostrar todos (inorden)");
            Console.WriteLine("4. Recomendación IA");
            Console.WriteLine("5. Guardar y salir");
            Console.WriteLine("6. Eliminar Libro");
            Console.WriteLine("7. Modificar informacion de un libro");
            opcion = ValidarEntero("\nIntroduzca su decision: ");

            Console.Clear();

            switch (opcion)
            {
                case 1:
                    {
                        string t = DeterminarCadenaVaciaOConNumero("Titulo: ", ref arbol, "");
                        string a = DeterminarCadenaVaciaOConNumero("Autor: ", ref arbol, "");
                        string g = DeterminarCadenaVaciaOConNumero("Genero: ", ref arbol, "");
                        int p = ValidarEntero("Puntuación (1-10): ");

                        arbol.Insertar(new Libro(t, a, g, p));
                        Console.WriteLine("Libro agregado!\n");
                        Esperar();
                        break;
                    }

                case 2:
                    {
                        string tituloBusca = DeterminarCadenaVaciaOConNumero("Titulo a buscar: ", ref arbol, "");
                        var libro = arbol.Buscar(tituloBusca.ToLower());

                        if (libro == null)
                        {
                            Console.WriteLine("No encontrado.\n");
                        }
                        else
                        {
                            Console.WriteLine(libro);
                        }
                        Esperar();
                        break;
                    }

                case 3:
                    {
                        Console.WriteLine("Listado de libros:\n");
                        arbol.MostrarInorden();
                        Esperar();
                        break;
                    }

                case 4:
                    {
                        string gPref = DeterminarCadenaVaciaOConNumero("Género preferido: ", ref arbol, "");
                        string aPref = DeterminarCadenaVaciaOConNumero("Autor preferido: ", ref arbol, "");
                        var rec = arbol.Recomendar(gPref, aPref);

                        if (rec == null)
                        {
                            Console.WriteLine("No hay libros para recomendar.\n");
                        }
                        else
                        {
                            Console.WriteLine("Recomendación IA:\n");
                            Console.WriteLine(rec);
                        }
                        Esperar();
                        break;
                    }

                case 5:
                    {
                        Guardar(arbol);
                        Console.WriteLine("Datos guardados. Saliendo...");
                        break;
                    }

                case 6:
                    {
                        string tituloEliminar = DeterminarCadenaVaciaOConNumero("Titulo a eliminar: ", ref arbol, "");
                        bool eliminado = arbol.Eliminar(tituloEliminar.ToLower());
                        if (eliminado)
                        {
                            Console.WriteLine("Libro eliminado.\n");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró el libro.\n");
                        }
                        Esperar();
                        break;
                    }
                case 7:
                    {
                        string t_m = DeterminarCadenaVaciaOConNumero("Titulo del libro a modificar: ", ref arbol, "");

                        Libro h = arbol.Buscar(t_m);
                        if (h == null)
                        {
                            Console.WriteLine("Libro no encontrado.\n");
                        }
                        else
                        {
                            Console.WriteLine("Informacion actual del libro\n");
                            Console.WriteLine(h.ToString());

                            string new_t = DeterminarCadenaVaciaOConNumero("Introduzca el nuevo titulo del libro: ", ref arbol, t_m);
                            string new_a = DeterminarCadenaVaciaOConNumero("Introduzca el nuevo nombre del autor del libro: ", ref arbol, t_m);
                            string new_g = DeterminarCadenaVaciaOConNumero("Introduzca el nuevo genero del libro: ", ref arbol, t_m);
                            int new_p = Convert.ToInt32(DeterminarCadenaVaciaOConNumero("Introduzca la nueva puntuacion del libro (1-10): ", ref arbol, t_m));

                            arbol.Eliminar(t_m);
                            arbol.Insertar(new Libro(new_t, new_a, new_g, new_p));
                            Libro h1 = arbol.Buscar(new_t);
                            Console.WriteLine("\nInformacion modificada del libro\n");
                            Console.WriteLine(h1.ToString());

                        }
                        Esperar();
                        break;
                    }

                default:
                    {
                        Console.WriteLine("No disponemos de esta opcion. Inténtelo de nuevo.\n");
                        Esperar();
                        break;
                    }
            }

        } while (opcion != 5);
    }

    static void Guardar(Arbol arbol)
    {
        List<Libro> lista = new List<Libro>();
        ObtenerListaStatic(arbol.Raiz, lista);

        string json = JsonSerializer.Serialize(lista);
        File.WriteAllText(archivo, json);
    }

    static void Cargar(Arbol arbol)
    {
        if (!File.Exists(archivo))
            return;

        try
        {
            string json = File.ReadAllText(archivo);

            // Si el archivo no empieza con { o [
            // es 99% seguro que NO es JSON válido.
            if (json.Length == 0 ||
                !(json.TrimStart().StartsWith("{") ||
                  json.TrimStart().StartsWith("[")))
            {
                Console.WriteLine(">>> Archivo inválido. Se ignorará y se reemplazará por uno nuevo.\n");
                return;
            }

            var opciones = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true
            };

            var lista = JsonSerializer.Deserialize<List<Libro>>(json, opciones);

            if (lista != null)
            {
                foreach (var libro in lista)
                    arbol.Insertar(libro);

                Console.WriteLine(">>> Archivo cargado correctamente.\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(">>> Error al cargar archivo: " + ex.Message);
        }
    }

    static void ObtenerListaStatic(Nodo nodo, List<Libro> lista)
    {
        if (nodo == null) return;

        ObtenerListaStatic(nodo.Izq, lista);
        lista.Add(nodo.Dato);
        ObtenerListaStatic(nodo.Der, lista);
    }
}