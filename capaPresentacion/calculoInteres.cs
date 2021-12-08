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
    public partial class calculoInteres : Form
    {
        public calculoInteres()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int interes, montoI, tasaInteres, Tiempo;

            montoI=int.Parse(textBox4.Text);
            tasaInteres = int.Parse(textBox3.Text);
            Tiempo = int.Parse(textBox2.Text);

            textBox1.Visible = true;
            interes = montoI * tasaInteres/100 * Tiempo;
            textBox1.Text = interes.ToString();

          if (interes==0|| interes<0)
            {
               Form error = new Error();
                error.Show();
            }
       

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void calculoInteres_Load(object sender, EventArgs e)
        {

        }
    }
}
