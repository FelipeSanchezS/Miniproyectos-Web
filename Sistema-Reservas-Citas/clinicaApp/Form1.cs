using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinicaApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formulario = new FPacientes();
            this.Hide(); // Oculta la ventana actual
            formulario.FormClosed += (s, args) => this.Close(); // Cierra la ventana actual cuando Form1 se cierre
            formulario.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form formulario1 = new FMedicos();
            this.Hide(); // Oculta la ventana actual
            formulario1.FormClosed += (s, args) => this.Close(); // Cierra la ventana actual cuando Form1 se cierre
            formulario1.Show(); ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form formulario2 = new ACitas();
            this.Hide(); // Oculta la ventana actual
            formulario2.FormClosed += (s, args) => this.Close(); // Cierra la ventana actual cuando Form1 se cierre
            formulario2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form formulario3 = new VCitas();
            this.Hide(); // Oculta la ventana actual
            formulario3.FormClosed += (s, args) => this.Close(); // Cierra la ventana actual cuando Form1 se cierre
            formulario3.Show();
        }
    }
}
