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
    public partial class Form2 : Form
    {
        Kon_wyscigowy kon_wyscigowy;
        private string imie, umaszczenie, rasa, plec, pochodzenie, hodowla;
        private int wysokosc_w_klebie, waga, rok_ur, obwod_klatki_piersiowej;
        double dzielnosc;
        int szybkosc;
        string chod;
        int dlugosc_odnozy;
        protected Bitmap zdj;
        public static List<Kon> Lista_Koni_w = new List<Kon>();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        //Utworzenie obiektu
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime czas = dateTimePicker1.Value;
            try
            {
                imie = textBox1.Text;
                rasa = textBox2.Text;
                umaszczenie = textBox3.Text;
                plec = textBox4.Text;
                pochodzenie = textBox5.Text;
                hodowla = textBox6.Text;
                wysokosc_w_klebie = Convert.ToInt32(textBox7.Text);
                waga = Convert.ToInt32(textBox8.Text);
                rok_ur = Convert.ToInt32(textBox9.Text);
                obwod_klatki_piersiowej = Convert.ToInt32(textBox10.Text);
                dzielnosc = Convert.ToInt32(textBox11.Text);
                szybkosc = Convert.ToInt32(textBox12.Text);
                chod = textBox13.Text;
                dlugosc_odnozy = Convert.ToInt32(textBox14.Text);
                if(pictureBox1.Image == null)
                {
                    zdj = new Bitmap("C:\\Users\\m_war\\Desktop\\s2\\programowanie 2\\biale.jpg");
                    pictureBox1.Image = zdj;
                }
                else
                {
                    pictureBox2.Image = zdj;
                }

                kon_wyscigowy = new Kon_wyscigowy(imie, umaszczenie, rasa,
                                plec, pochodzenie, hodowla, wysokosc_w_klebie, waga, rok_ur,
                                obwod_klatki_piersiowej, dzielnosc, szybkosc, chod, dlugosc_odnozy, czas, zdj);

                Kon kon = kon_wyscigowy;

                Kon.Lista_Koni.Add(kon);
                Lista_Koni_w.Add(kon);
                Kon.Lista_Zdjec_Koni.Add(zdj);
                listBox1.Items.Clear();
                kon.Wypisz(listBox1, pictureBox1);

            }
            catch(FormatException)
            {
                MessageBox.Show("nieprawidlowe dane");
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            pictureBox1.Image = null;
            zdj = null;
        }

        //Utworzenie obiektu
        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //Wczytanie obrazka z wybranego pliku(OpenFileDialog) i wyświetlenie go

                 openFileDialog.InitialDirectory = "C:\\Users\\m_war\\Desktop\\s2\\programowanie 2";
                openFileDialog.Filter = "image files (*.jpeg)|*.jpeg|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    zdj = new Bitmap(openFileDialog.FileName);
                pictureBox1.Image = zdj;

            }
        }

        //Uzupeninie pustych pól sensownymi wartościami
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "Marcin";
            if (textBox2.Text == "")
                textBox2.Text = "Kary";
            if (textBox3.Text == "")
                textBox3.Text = "Zimnokrwisty";
            if (textBox4.Text == "")
                textBox4.Text = "klacz";
            if (textBox5.Text == "")
                textBox5.Text = "Polska";
            if (textBox6.Text == "")
                textBox6.Text = "Stara Stajnia";
            if (textBox7.Text == "")
                textBox7.Text = 150.ToString();
            if (textBox8.Text == "")
                textBox8.Text = 500.ToString();
            if (textBox9.Text == "")
                textBox9.Text = 2010.ToString();
            if (textBox10.Text == "")
                textBox10.Text = 190.ToString();
            if (textBox11.Text == "")
                textBox11.Text = 7.ToString();
            if (textBox12.Text == "")
                textBox12.Text = 85.ToString();;
            if (textBox13.Text == "")
                textBox13.Text = "cwał";
            if (textBox14.Text == "")
                textBox14.Text = Convert.ToString(150);
            if (zdj == null)
            {
                zdj = new Bitmap("C:\\Users\\m_war\\Desktop\\s2\\programowanie 2\\kon_wys.jpg");
                pictureBox1.Image = zdj;
            }

        }

    }
}
