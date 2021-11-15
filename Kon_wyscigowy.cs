using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


namespace l4p2
{
    class Kon_wyscigowy : Kon
    {
        double dzielnosc;
        int szybkosc;
        string chod;
        int dlugosc_odnozy;
        protected Bitmap zdj;
        

        public Kon_wyscigowy():base()
        {
            //dzielnosc = 6.6;
            //szybkosc = 85;             // ile czasu zajmuje przebieg najpopularniejszej trasy 2400m         //1m 25s
            //chod = "cwal"; // lub stęp 
            //dlugosc_odnozy = 150;
        }

        public Kon_wyscigowy(string imie, string umaszczenie, string rasa, string plec, string pochodzenie, 
            string hodowla, int wysokosc_w_klebie, int waga, int wiek, int obwod_klatki_piersiowej, double dzielnosc,
            int szybkosc, string chod, int dlugosc_odnozy, DateTime dataUr, Bitmap zdjecie) : 
            base(imie, umaszczenie, rasa, plec, pochodzenie, hodowla, wysokosc_w_klebie, waga, wiek, obwod_klatki_piersiowej, dataUr, zdjecie)
        {
            this.dzielnosc = dzielnosc;
            this.szybkosc = szybkosc;
            this.chod = chod;
            this.dlugosc_odnozy = dlugosc_odnozy;
        }

        public Kon_wyscigowy(Kon_wyscigowy k):base()
        {
            dzielnosc = k.dzielnosc;
            szybkosc = k.szybkosc;
            chod = k.chod;
            dlugosc_odnozy = k.dlugosc_odnozy;
        }

        ~Kon_wyscigowy()
        {

        }
        override public void Wypisz(ListBox lb, PictureBox pb)
        {
            base.Wypisz(lb,pb);

            lb.Items.Add("Wyścigi: " + Uczestnictwo());
            lb.Items.Add("Prędkość: " + Predkosc()+"km/h");
            lb.Items.Add("Chód: " + chod);
            lb.Items.Add("Długość odnóży: " + dlugosc_odnozy);
            lb.Items.Add("");
        }

        //Metoda obliczająca szybkosc
        int Predkosc() 
        {
            int predkosc=0;
            try
            {
                predkosc = 2400 / 1000 * 3600 / szybkosc;
            }
            catch(DivideByZeroException)
            {
                MessageBox.Show("nie dziel prze zero");
            }
                return predkosc;
        }
        
        string Uczestnictwo() 
        {
            if (dzielnosc >= 6.5)
                return ("Może brać udział w zawodach");
            else
                return ("Nie może startować w zawodach");
        }

        //Zapisanie do pliku
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
            sw.WriteLine(dzielnosc);
            sw.WriteLine(szybkosc);
            sw.WriteLine(chod);
            sw.WriteLine(dlugosc_odnozy);
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
            dzielnosc = Convert.ToDouble(sr.ReadLine());
            szybkosc = Convert.ToInt32(sr.ReadLine());
            chod = sr.ReadLine();
            dlugosc_odnozy = Convert.ToInt32(sr.ReadLine());
            //zdj = new Bitmap("C:\\Users\\m_war\\Desktop\\s2\\programowanie 2\\biale.jpg");
            //Kon.Lista_Zdjec_Koni.Add(zdj);
        }        
    }
}

