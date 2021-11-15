using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace l4p2
{
    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                var a = new Przeciazenie(Kon.Lista_Koni[0]);
                var c = new Przeciazenie(Kon.Lista_Koni[1]);
                var b = new Przeciazenie(Kon.Lista_Koni[2]);

                //listBox1.Items.Add("a=5/4 b=5/4 c=4/2");
                listBox1.Items.Add(c + b);
                listBox1.Items.Add(a + c == b + c);
                listBox1.Items.Add(a + b != b + a);
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Za malo koni do porownania");
            }
        }

    }
        
}