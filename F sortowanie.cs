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
    public partial class Form6 : Form
    {
        //Kon kon;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        //Wypisanie koni wyscigowych
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Kon_wyscigowy kw in Form2.Lista_Koni_w)
                listBox1.Items.Add(kw.WypiszKrotko());
        }


        //Posortowanie Koni wyscigowych i ich wypisanie
        private void button2_Click(object sender, EventArgs e)
        {

            Form2.Lista_Koni_w.Sort();

            listBox1.Items.Clear();
            foreach (Kon_wyscigowy k in Form2.Lista_Koni_w)
                listBox1.Items.Add(k.WypiszKrotko());
        }
    }
}
