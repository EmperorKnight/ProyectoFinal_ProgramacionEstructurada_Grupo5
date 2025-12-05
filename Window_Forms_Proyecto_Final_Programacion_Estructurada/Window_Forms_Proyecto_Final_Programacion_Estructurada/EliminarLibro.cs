using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Window_Forms_Proyecto_Final_Programacion_Estructurada
{
    public partial class EliminarLibro : Form
    {
        private List<Libro> lib = Principal.lis;

        public EliminarLibro()
        {
            InitializeComponent();
        }

        private void EliminarLibro_Load(object sender, EventArgs e)
        {
            ModificarDataGridView();
        }

        private void ModificarDataGridView()
        {
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Count() == 0)
            {
                MessageBox.Show("Ingrese el título del libro a eliminar", "Error");
            }
            else
            {
                Principal.form();
                bool encontrado = Principal.EliminarLibro(textBox1.Text);
                if (encontrado)
                {
                    MessageBox.Show("El libro ha sido eliminado exitosamente", "Éxito");
                    ModificarDataGridView();
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("No se encontró un libro con ese título", "Error");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
