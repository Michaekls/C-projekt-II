using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace l4p2
{
    class Kon_pociagowy : Kon
    {
        //protected int sila;
        //Form3 form3;
        public int[] osoby = new int[6];  //masa ludzi podana w kg
        public string usposobienie;
        public int grubosc_odnozy;
        public string wyt_na_temperature;
        private readonly int obciazenie;
        protected Bitmap zdj;


        public Kon_pociagowy() : base()
        {
            //osoby = new int[]{ 20, 20, 10, 20, 30, 50};  //kg
            //usposobienie = "łagodny";
            //grubosc_odnozy = 50;  //cm
            //wyt_na_temperature = "duża";
        }

        public Kon_pociagowy(string imie, string umaszczenie, string rasa, string plec, string pochodzenie, string 
        hodowla, int wysokosc_w_klebie, int waga, int wiek, int obwod_klatki_piersiowej, string 
        usposobienie, int grubosc_odnozy, string wyt_na_temperature, DateTime dataUr, Bitmap zdjecie,int[] osoby) : base(imie, umaszczenie, rasa, plec, pochodzenie, hodowla, 
        wysokosc_w_klebie, waga, wiek, obwod_klatki_piersiowej, dataUr, zdjecie)
        {
            //this.sila = sila;
            this.usposobienie = usposobienie;
            this.grubosc_odnozy = grubosc_odnozy;
            this.wyt_na_temperature = wyt_na_temperature;
            for (int i = 0; i < osoby.Length; i++) 
                this.osoby[i] = Convert.ToInt32(osoby[i]);
        }

        public Kon_pociagowy(Kon_pociagowy k):base()
        {
            osoby = k.osoby;
            usposobienie = k.usposobienie;
            grubosc_odnozy = k.grubosc_odnozy;
            wyt_na_temperature = k.wyt_na_temperature;
         }

        ~Kon_pociagowy()
        {

        }

        override public void Wypisz(ListBox lb,PictureBox pb)
        {
            base.Wypisz(lb,pb);

            lb.Items.Add("Obciążenie: " + Obciazenie() +"kg");
            lb.Items.Add("Usposobienie: " + usposobienie);
            lb.Items.Add("Grubość odnóży: " + grubosc_odnozy+"cm");
            lb.Items.Add("dlugosc pracy: " + Dlugosc_pracy() + "godz");
            lb.Items.Add("Wyt na temperature: " + wyt_na_temperature);
            string s = "";
            for (int i = 0; i < osoby.Length; i++)
                s = s + osoby[i] + ", ";
            lb.Items.Add(s);
            lb.Items.Add("");
        }

        

        int Obciazenie() 
        {
            int obciazenie = 0;
            for (int i = 0; i < osoby.Length; i++)
            {
                obciazenie += osoby[i];
            }
            return obciazenie;
        }

        int Dlugosc_pracy()
        {
            if (obciazenie < 120)
                return 6;
            else if (obciazenie < 500)
                return 3;
            else
                return 1;     
        }
        public override void ZapiszDoPliku(StreamWriter sw)
        {
            base.ZapiszDoPliku(sw);

            sw.WriteLine(this.ToString());

            sw.WriteLine(imie);
            sw.WriteLine(umaszczenie);
            sw.WriteLine(rasa);
            sw.WriteLine(plec);
            sw.WriteLine(pochodzenie);
            sw.WriteLine(hodowla);
            sw.WriteLine(wysokosc_w_klebie);
            sw.WriteLine(waga);
            sw.WriteLine(rok_ur);
            sw.WriteLine(obwod_klatki_piersiowej);
            sw.WriteLine(usposobienie);
            sw.WriteLine(wyt_na_temperature);
            for (int i = 0; i < 6; i++)
            {
                sw.Write(osoby[i]);
                if (i<4)
                    sw.Write(",");
            }
            sw.WriteLine("");

        }

        //Odczytanie z pliku
        public void OdczytajZPliku(StreamReader sr)
        {
            imie = sr.ReadLine();
            umaszczenie = sr.ReadLine();
            rasa = sr.ReadLine();
            plec = sr.ReadLine();
            pochodzenie = sr.ReadLine();
            hodowla = sr.ReadLine();
            wysokosc_w_klebie = Convert.ToInt32(sr.ReadLine());
            waga = Convert.ToInt32(sr.ReadLine());
            rok_ur = Convert.ToInt32(sr.ReadLine());
            obwod_klatki_piersiowej = Convert.ToInt32(sr.ReadLine());
            usposobienie = sr.ReadLine();
            wyt_na_temperature = sr.ReadLine();
            String[] numbers = sr.ReadLine().Split(',');
            for (int i = 0; i < numbers.Length; i++)
                osoby[i] = Int32.Parse(numbers[i]);
            //zdj = new Bitmap("C:\\Users\\m_war\\Desktop\\s2\\programowanie 2\\biale.jpg");
            //Kon.Lista_Zdjec_Koni.Add(zdj);
        }
    }
}
