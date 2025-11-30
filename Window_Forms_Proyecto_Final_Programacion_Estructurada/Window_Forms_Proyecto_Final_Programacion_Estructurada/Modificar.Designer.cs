namespace Window_Forms_Proyecto_Final_Programacion_Estructurada
{
    partial class Modificar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            comboBox1 = new ComboBox();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox4 = new TextBox();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            button1.Location = new Point(495, 356);
            button1.Name = "button1";
            button1.Size = new Size(102, 33);
            button1.TabIndex = 0;
            button1.Text = "<< Regresar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            label3.Location = new Point(54, 226);
            label3.Name = "label3";
            label3.Size = new Size(203, 19);
            label3.TabIndex = 3;
            label3.Text = "Titulo Modificado del Libro: ";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            label4.Location = new Point(54, 258);
            label4.Name = "label4";
            label4.Size = new Size(216, 19);
            label4.TabIndex = 4;
            label4.Text = "Nombre del Autor Modificado: ";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            label5.Location = new Point(54, 290);
            label5.Name = "label5";
            label5.Size = new Size(211, 19);
            label5.TabIndex = 5;
            label5.Text = "Genero Modificado del Libro: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            label6.Location = new Point(54, 323);
            label6.Name = "label6";
            label6.Size = new Size(241, 19);
            label6.TabIndex = 6;
            label6.Text = "Puntuacion Modificada del Libro: ";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            textBox1.Location = new Point(291, 219);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(306, 26);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            textBox2.Location = new Point(307, 251);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(290, 26);
            textBox2.TabIndex = 8;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            textBox3.Location = new Point(291, 283);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(306, 26);
            textBox3.TabIndex = 9;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            comboBox1.Location = new Point(307, 315);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(45, 27);
            comboBox1.TabIndex = 10;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            button2.Location = new Point(54, 356);
            button2.Name = "button2";
            button2.Size = new Size(97, 34);
            button2.TabIndex = 11;
            button2.Text = "Modificar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label1.Location = new Point(196, 9);
            label1.Name = "label1";
            label1.Size = new Size(270, 31);
            label1.TabIndex = 13;
            label1.Text = "TODOS LOS LIBROS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            label2.Location = new Point(54, 194);
            label2.Name = "label2";
            label2.Size = new Size(287, 19);
            label2.TabIndex = 14;
            label2.Text = "Introduzca el titulo del libro a modificar: ";
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            textBox4.Location = new Point(352, 187);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(245, 26);
            textBox4.TabIndex = 15;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(54, 53);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(543, 98);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Modificar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 405);
            Controls.Add(textBox4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button1);
            Name = "Modificar";
            Text = "Form3";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private ComboBox comboBox1;
        private Button button2;
        private Label label1;
        private Label label2;
        private TextBox textBox4;
        private DataGridView dataGridView1;
    }
}