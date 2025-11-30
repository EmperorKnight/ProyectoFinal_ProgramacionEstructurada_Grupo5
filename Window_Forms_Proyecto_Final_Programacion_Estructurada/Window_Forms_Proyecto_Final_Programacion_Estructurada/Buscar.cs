using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Window_Forms_Proyecto_Final_Programacion_Estructurada
{
    public partial class Buscar : Form
    {

        private string libro1;
        private Libro libro;

        public Buscar(string libro2)
        {
            InitializeComponent();
            libro1 = libro2;
            libro = Principal.BuscarLibro(libro1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            dataGridView1.Columns.Add("Titulo", "Título");
            dataGridView1.Columns.Add("Autor", "Autor");
            dataGridView1.Columns.Add("Genero", "Género");
            dataGridView1.Columns.Add("Puntuacion", "Puntuación");

            dataGridView1.Rows.Add(libro.Titulo, libro.Autor, libro.Genero, libro.Puntuacion);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Principal.EliminarLibro(libro.Titulo);
            MessageBox.Show("Libro eliminado correctamente.", "EXITO");
            Owner.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modificar m = new Modificar(libro.Titulo);
            m.Owner = this;
            m.Show();
            this.Hide();
        }
    }
}
