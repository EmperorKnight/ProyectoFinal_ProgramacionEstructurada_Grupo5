namespace Window_Forms_Proyecto_Final_Programacion_Estructurada
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Principal.Cargar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            Form2 v = new Form2();
            v.Owner = this;
            v.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Principal.Guardar();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mostrar_Libros ml = new Mostrar_Libros();
            ml.Owner = this;
            ml.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string titulo = textBox1.Text;
            textBox1.Clear();
            Libro actual = Principal.BuscarLibro(titulo);
            if (actual == null)
            {
                MessageBox.Show("Libro no encontrado", "Error");
                return;
            }
            else
            {
                Buscar B = new Buscar(titulo);

                B.Owner = this;
                B.Show();
                this.Hide();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            EliminarLibro el = new EliminarLibro();
            el.Owner = this;
            el.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Modificar u = new Modificar("");
            u.Owner = this;
            u.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Recomendaciones rec = new Recomendaciones();
            rec.Owner = this;
            rec.Show();
            this.Hide();
        }
    }
}
