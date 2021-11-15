using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace l4p2
{
    public partial class Form5 : Form
    {
        //Kon kon;
        public static int a = -1;            //zmienna a okresla numer konia na liscie
        public Form5()
        {
            InitializeComponent();
        }
        //public static int dodaja()
        //{
        //    return a += 1;
        //}
        private void Form5_Load(object sender, EventArgs e)
        {

        }

        //Nastepny obiekt
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                a += 1;
                if (a + 1 <= Kon.Lista_Koni.Count)
                {
                    listBox1.Items.Clear();
                    pictureBox1.Image = new Bitmap(Kon.Lista_Zdjec_Koni[a]);
                    Kon.Lista_Koni[a].Wypisz(listBox1, pictureBox1);
                }
                else
                    a -= 1;
            }
            catch (Exception)
            { }
        }

        //poprzedni obiekt
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                a -= 1;
                if (a >= 0)
                {
                    listBox1.Items.Clear();    
                    if (pictureBox1 == null)
                        pictureBox1.Image = new Bitmap("C:\\Users\\m_war\\Desktop\\s2\\programowanie 2\\biale.jpg");
                    else
                        pictureBox1.Image = new Bitmap(Kon.Lista_Zdjec_Koni[a]);
                    Kon.Lista_Koni[a].Wypisz(listBox1, pictureBox1);
                }
                else
                    a += 1;
            }
            catch(Exception)
            { }
        }

        //Zapisz do pliku
        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\m_war\\Desktop\\s2\\programowanie 2\\plik.txt");
            try
            {
                foreach (Kon s in Kon.Lista_Koni)
                    s.ZapiszDoPliku(sw);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił wyjątek: " + ex.Message);
            }
            finally 
            {
                if ( sw != null)
                {
                    sw.Close();
                }
            }
        }

        //Odczytaj z pliku
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\m_war\\Desktop\\s2\\programowanie 2\\plik.txt");
                Kon_wyscigowy kw;
                Kon_pociagowy kp;
                while (!sr.EndOfStream)
                {
                    string nazwaKlasy = sr.ReadLine();
                    if (nazwaKlasy == "l4p2.Kon_wyscigowy")
                    {
                        kw = new Kon_wyscigowy();
                        kw.OdczytajZPliku(sr);
                        Kon kon = kw;
                       // Kon.Lista_Koni.Add(kw);    //odkomentujemy jesli chcemy dodac do listy
                       // Form2.Lista_Koni_w.Add(kon);
                    }
                    else
                    {
                        kp = new Kon_pociagowy();
                        kp.OdczytajZPliku(sr);
                       // Kon kon = kp;
                       // Kon.Lista_Koni.Add(kp);
                    }
                }
                sr.Close();
                
                foreach (Kon k in Kon.Lista_Koni)
                    k.Wypisz(listBox1, pictureBox1);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Wystąpił wyjątek: " + ex.Message);
            }
            finally
            {
                
            }
        }

        //usuwanie konia
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Kon.Lista_Koni.RemoveAt(a);
                Kon.Lista_Zdjec_Koni.RemoveAt(a);          

            listBox1.Items.Clear();
            pictureBox1.Image = null;

            if (a == Kon.Lista_Koni.Count)
                a -= 1;
            if (a == -1)
            {
                listBox1 = null;
                pictureBox1 = null;
            }
            else
            {
                pictureBox1.Image = new Bitmap(Kon.Lista_Zdjec_Koni[a]);
                Kon.Lista_Koni[a].Wypisz(listBox1, pictureBox1);
            }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("brak konia do usuniecia");
            }
        }

        //Obliczanie sredniej wagi koni
        private void button6_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Items.Add(Kon.Srednia_waga_konia());
        }
    }
}
