using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Window_Forms_Proyecto_Final_Programacion_Estructurada
{
    public partial class Recomendaciones : Form
    {
        public Recomendaciones()
        {
            InitializeComponent();
        }

        private void Recomendaciones_Load(object sender, EventArgs e)
        {
            // Cargar recomendaciones cuando se abra la ventana
            MostrarRecomendaciones();
        }

        private void MostrarRecomendaciones()
        {
            // Carga la lista de libros desde tu sistema principal (JSON)
            Principal.form();
            List<Libro> libros = Principal.lis;

            if (libros == null || libros.Count == 0)
            {
                MessageBox.Show("No hay libros registrados para generar recomendaciones.");
                return;
            }

            // IA LOCAL → Genera recomendaciones sencillas por género
            List<Libro> recomendaciones = GenerarRecomendacionesIA(libros);

            // Mostrar resultados en un DataGridView
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            dataGridView1.Columns.Add("Titulo", "Título");
            dataGridView1.Columns.Add("Autor", "Autor");
            dataGridView1.Columns.Add("Genero", "Género");
            dataGridView1.Columns.Add("Puntuacion", "Puntuación");

            foreach (var libro in recomendaciones)
            {
                dataGridView1.Rows.Add(libro.Titulo, libro.Autor, libro.Genero, libro.Puntuacion);
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            libros.Clear();
            recomendaciones.Clear();
        }

        // ------------------------------------------------------------
        //  IA LOCAL – recomendación basada en similitud por género
        // ------------------------------------------------------------
        private List<Libro> GenerarRecomendacionesIA(List<Libro> libros)
        {
            if (libros.Count == 0)
                return new List<Libro>();

            // Agrupar por género → obtener el más frecuente
            string generoMasComun = libros
                .GroupBy(l => l.Genero.ToLower())
                .OrderByDescending(g => g.Count())
                .First()
                .Key;

            // Seleccionar libros del mismo género y mejor puntuados
            List<Libro> recomendados = libros
                .Where(l => l.Genero.ToLower() == generoMasComun)
                .OrderByDescending(l => l.Puntuacion)
                .Take(5)
                .ToList();

            return recomendados;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}