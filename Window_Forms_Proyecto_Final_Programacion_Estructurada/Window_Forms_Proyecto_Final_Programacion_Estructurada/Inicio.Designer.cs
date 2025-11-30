namespace Window_Forms_Proyecto_Final_Programacion_Estructurada
{
    partial class Inicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            button1.Location = new Point(239, 143);
            button1.Name = "button1";
            button1.Size = new Size(139, 48);
            button1.TabIndex = 0;
            button1.Text = "Agregar Libro";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            button2.ForeColor = SystemColors.MenuHighlight;
            button2.Location = new Point(457, 340);
            button2.Name = "button2";
            button2.Size = new Size(99, 42);
            button2.TabIndex = 1;
            button2.Text = "Salir";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            button3.Location = new Point(430, 221);
            button3.Name = "button3";
            button3.Size = new Size(126, 50);
            button3.TabIndex = 2;
            button3.Text = "Ver todos los libros";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 177);
            label1.Location = new Point(14, 59);
            label1.Name = "label1";
            label1.Size = new Size(168, 19);
            label1.TabIndex = 3;
            label1.Text = "Buscar Libro por Titulo";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            textBox1.Location = new Point(208, 56);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(257, 26);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button4
            // 
            button4.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            button4.Location = new Point(485, 40);
            button4.Name = "button4";
            button4.Size = new Size(100, 53);
            button4.TabIndex = 5;
            button4.Text = "Mostrar Libro";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // button5
            // 
            button5.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            button5.Location = new Point(43, 221);
            button5.Name = "button5";
            button5.Size = new Size(139, 50);
            button5.TabIndex = 6;
            button5.Text = "Modificar Libro";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            button6.Location = new Point(239, 298);
            button6.Name = "button6";
            button6.Size = new Size(139, 51);
            button6.TabIndex = 7;
            button6.Text = "Eliminar Libro";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic);
            button7.Location = new Point(239, 221);
            button7.Name = "button7";
            button7.Size = new Size(139, 50);
            button7.TabIndex = 8;
            button7.Text = "Recomendacion IA";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 416);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Inicio";
            Text = "Inicio";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private TextBox textBox1;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}
