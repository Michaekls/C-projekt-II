using System;
using System.Drawing;
using System.Windows.Forms;
//using System.Windows.Forms.FileDialog;

namespace l4p2
{

    public partial class Form3 : Form
    {
        //Form3 : Kon_pociagowy
        private string imie, umaszczenie, rasa, plec, pochodzenie, hodowla;
        private int wysokosc_w_klebie, waga, rok_ur, obwod_klatki_piersiowej;
        public int[] osoby = new int[6];  //masa ludzi podana w kg
        public string usposobienie;
        public int grubosc_odnozy;
        public string wyt_na_temperature;
        Kon_pociagowy kon_pociagowy;
        Bitmap zdj;
        public DateTime Value { get; set; }

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        //Dodaj obiekt
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime czas = dateTimePicker1.Value;
            try
            {
                imie = textBox2.Text;
                rasa = textBox3.Text;
                umaszczenie = textBox4.Text;
                plec = textBox5.Text;
                pochodzenie = textBox6.Text;
                hodowla = textBox7.Text;
                wysokosc_w_klebie = Convert.ToInt32(textBox8.Text);
                waga = Convert.ToInt32(textBox9.Text);
                rok_ur = Convert.ToInt32(textBox10.Text);
                obwod_klatki_piersiowej = Convert.ToInt32(textBox11.Text);
                usposobienie = textBox12.Text;
                grubosc_odnozy = Convert.ToInt32(textBox13.Text);
                wyt_na_temperature = textBox14.Text;
                String[] numbers = textBox1.Text.Split(',');
                for (int i = 0; i < numbers.Length; i++)
                    osoby[i] = Int32.Parse(numbers[i]);

                if (pictureBox1.Image == null)
                {
                    zdj = new Bitmap("C:\\Users\\m_war\\Desktop\\s2\\programowanie 2\\biale.jpg");
                    pictureBox1.Image = zdj;
                }
                else
                {
                    pictureBox2.Image = zdj;
                }
                kon_pociagowy = new Kon_pociagowy(imie, umaszczenie, rasa,
                                plec, pochodzenie, hodowla, wysokosc_w_klebie, waga, rok_ur,
                                obwod_klatki_piersiowej, usposobienie, grubosc_odnozy, wyt_na_temperature, czas, zdj, osoby);

                Kon kon = kon_pociagowy;

                Kon.Lista_Koni.Add(kon);
                Kon.Lista_Zdjec_Koni.Add(zdj);
                listBox1.Items.Clear();
                kon.Wypisz(listBox1, pictureBox1);
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
            catch (FormatException)
            {
                MessageBox.Show("nieprawidlowe dane");
            }
            catch(IndexOutOfRangeException)
            {
                MessageBox.Show("nie wiecej niz 6");
            }

        }

        //dodanie zdjecia
        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //Wczytanie obrazka z wybranego pliku (OpenFileDialog) i wyświetlenie go
                openFileDialog.InitialDirectory = "C:\\Users\\m_war\\Desktop\\s2\\programowanie 2";
                openFileDialog.Filter = "image files (*.jpeg)|*.jpeg|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    zdj = new Bitmap(openFileDialog.FileName);
                }
                pictureBox1.Image = zdj;
            }
        }

        //Uzupelnienie pustych pól sensownymi wartościami
        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "")
                textBox2.Text = "Strzała";
            if (textBox3.Text == "")
                textBox3.Text = "Biały";
            if (textBox4.Text == "")
                textBox4.Text = "Rumak";
            if (textBox5.Text == "")
                textBox5.Text = "Ogier";
            if (textBox6.Text == "")
                textBox6.Text = "Rumunia";
            if (textBox7.Text == "")
                textBox7.Text = "Zielony dąb";
            if (textBox8.Text == "")
                textBox8.Text = 150.ToString();
            if (textBox9.Text == "")
                textBox9.Text = 450.ToString();
            if (textBox10.Text == "")
                textBox10.Text = 2010.ToString();
            if (textBox11.Text == "")
                textBox11.Text = 190.ToString();
            if (textBox12.Text == "")
                textBox12.Text = "Łagodne";
            if (textBox13.Text == "")
                textBox13.Text = 45.ToString(); ;
            if (textBox14.Text == "")
                textBox14.Text = "duża";
            if (textBox1.Text == "")
                textBox1.Text = 0.ToString(); ;
            if (zdj == null)
            {
                zdj = new Bitmap("C:\\Users\\m_war\\Desktop\\s2\\programowanie 2\\zdj.jpeg");
                pictureBox1.Image = zdj;
            }
        }

    }

}
