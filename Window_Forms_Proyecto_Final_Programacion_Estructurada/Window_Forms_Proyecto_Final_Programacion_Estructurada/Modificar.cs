using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Window_Forms_Proyecto_Final_Programacion_Estructurada
{
    public partial class Modificar : Form
    {
        private List<Libro> lib = Principal.lis;
        private string titulo;

        public Modificar(string titulo)
        {
            InitializeComponent();
            this.titulo=titulo;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ModificarDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (titulo.Count() != 0)
            {
                string tituloBuscado = textBox4.Text;
                Libro book = Principal.BuscarLibro(tituloBuscado);

                if (book == null)
                {
                    MessageBox.Show("Libro no encontrado", "Error");
                    return;
                }

                // Tomar los valores actuales por defecto
                string nt = book.Titulo;
                string na = book.Autor;
                string ng = book.Genero;
                int np = book.Puntuacion;

                // Solo reemplazar si el usuario escribió algo
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    nt = textBox1.Text;
                }

                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    na = textBox2.Text;
                }

                if (!string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    ng = textBox3.Text;
                }

                if (!string.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    np = Convert.ToInt32(comboBox1.Text);
                }

                // Muy importante: eliminar primero
                Principal.EliminarLibro(tituloBuscado);

                // Insertar el nuevo libro modificado
                Principal.InsertarLibro(nt, na, ng, np);

                // Actualizar tabla
                lib.Clear();
                MessageBox.Show("Libro modificado correctamente", "Éxito");
                ModificarDataGridView();
                LimpiarCajasDeTexto();
            }
            else
            {
                if (!VerificarCampoVacio())
                {
                    string tituloBuscado = textBox4.Text;
                    Libro book = Principal.BuscarLibro(tituloBuscado);

                    if (book == null)
                    {
                        MessageBox.Show("Libro no encontrado", "Error");
                        return;
                    }

                    // Tomar los valores actuales por defecto
                    string nt = book.Titulo;
                    string na = book.Autor;
                    string ng = book.Genero;
                    int np = book.Puntuacion;

                    // Solo reemplazar si el usuario escribió algo
                    if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        nt = textBox1.Text;
                    }

                    if (!string.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        na = textBox2.Text;
                    }

                    if (!string.IsNullOrWhiteSpace(textBox3.Text))
                    {
                        ng = textBox3.Text;
                    }

                    if (!string.IsNullOrWhiteSpace(comboBox1.Text))
                    {
                        np = Convert.ToInt32(comboBox1.Text);
                    }

                    // Muy importante: eliminar primero
                    Principal.EliminarLibro(tituloBuscado);

                    // Insertar el nuevo libro modificado
                    Principal.InsertarLibro(nt, na, ng, np);

                    // Actualizar tabla
                    lib.Clear();
                    MessageBox.Show("Libro modificado correctamente", "Éxito");
                    ModificarDataGridView();
                    LimpiarCajasDeTexto();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ModificarDataGridView()
        {
            if(titulo.Count() != 0)
            {
                textBox4.Text = titulo;
            }
            
            lib.Clear();
            Principal.form();

            // Limpiar por si el form se abre más de una vez
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            // Configuración: SOLO lectura total
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            // Agregar columnas
            dataGridView1.Columns.Add("N", "N");
            dataGridView1.Columns.Add("Titulo", "Título");
            dataGridView1.Columns.Add("Autor", "Autor");
            dataGridView1.Columns.Add("Genero", "Género");
            dataGridView1.Columns.Add("Puntuacion", "Puntuación");

            // Mostrar libros sin permitir edición
            for (int i = 0; i < lib.Count; i++)
            {
                dataGridView1.Rows.Add(i + 1, lib[i].Titulo, lib[i].Autor, lib[i].Genero, lib[i].Puntuacion);
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            lib.Clear();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void LimpiarCajasDeTexto()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private bool VerificarCampoVacio()
        {
            if (textBox4.Text.Count() == 0)
            {
                MessageBox.Show("Ingrese el título del libro a modificar", "Error");
                LimpiarCajasDeTexto();
                return true;
            }
            return false;
        }
    }
}
