using System.Text;
using System.Text.Json;

namespace Window_Forms_Proyecto_Final_Programacion_Estructurada
{
    public class Libro
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
                int comp = string.Compare(titulo.ToLower(), actual.Dato.Titulo.ToLower(), true);

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

    class Principal
    {
        static Arbol arbol = new Arbol();
        static string archivo = "libros.dat";
        public static List<Libro> lis = new List<Libro>();

        public static void InsertarLibro(string t, string a, string g, int p)
        {
            arbol.Insertar(new Libro(t, a, g, p));
        }

        public static Libro BuscarLibro(string titulo)
        {
            Libro libro = arbol.Buscar(titulo);
            return libro;
        }

        public static string MostrarLibros()
        {
            List<Libro> lista = new List<Libro>();
            ObtenerListaStatic(arbol.Raiz, lista);

            if (lista.Count == 0)
            {
                return "La lista esta vacia";
            }

            StringBuilder sb = new StringBuilder();
            foreach (var libro in lista)
            {
                sb.AppendLine(libro.ToString());
            }

            return sb.ToString();
        }

        public static void form()
        {
            List<Libro> lista = new List<Libro>();
            ObtenerListaStatic(arbol.Raiz, lista);

            foreach(var libro in lista)
            {
                lis.Add(libro);
            }
        }

        public static bool EliminarLibro(string titulo)
        {
            bool eliminado = arbol.Eliminar(titulo);
            return eliminado;
        }

        public static void Guardar()
        {
            List<Libro> lista = new List<Libro>();
            ObtenerListaStatic(arbol.Raiz, lista);

            string json = JsonSerializer.Serialize(lista);
            File.WriteAllText(archivo, json);
        }

        public static void Cargar()
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

}
