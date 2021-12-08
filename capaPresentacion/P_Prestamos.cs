using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class P_Prestamos : Form
    {
        public P_Prestamos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form agregar = new form2();
            agregar.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form menu = new Menu();
            menu.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form calculoInteres = new calculoInteres();
            calculoInteres.Show();
        }
    }
}
