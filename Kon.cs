using System;
using System.Collections.Generic;
using System.Collections;
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
    public abstract class Kon : IComparable<Kon>

    {

        public string imie, umaszczenie, rasa, plec, pochodzenie, hodowla;
        public int wysokosc_w_klebie, rok_ur,waga, obwod_klatki_piersiowej;
        protected DateTime dataUr;
        public Bitmap zdjecie;
        public static List<Kon> Lista_Koni = new List<Kon>();

        public static List<Bitmap> Lista_Zdjec_Koni = new List<Bitmap>();


        public string WypiszKrotko()
        {
            return hodowla + " " + imie + " " + rasa;
        }

        public static int Srednia_waga_konia()
        {
            int wkonia = 0;
            int liczba_koni = 0;
            foreach (Kon s in Lista_Koni)
            {
                wkonia += s.waga;
                liczba_koni += 1;
            }

            try
            {
                wkonia = wkonia / liczba_koni;
            }
            catch(DivideByZeroException)
            {
                MessageBox.Show("nie ma sredniej bez koni");
            }

            return wkonia;
        }

        //Konstruktor bezargumentowy (domyślny)
        //public Kon() { }
        public Kon()
        {
            //imie = "";
            //umaszczenie = "Gniady";
            //rasa = "Mustang";
            //plec = "Ogier";
            //pochodzenie = "Polska";
            //hodowla = "Nowaklacz";
            //wysokosc_w_klebie = 142;
            //waga = 550;
            //rok_ur = 2015;
            //obwod_klatki_piersiowej = 193;
        }


        //Konstruktor wieloargumentowy
        public Kon(string imie, string umaszczenie, string rasa, string plec, string pochodzenie, string hodowla, int wysokosc_w_klebie,
            int waga, int rok_ur, int obwod_klatki_piersiowej, DateTime dataUr, Bitmap zdjecie)

        {
            this.imie = imie;
            this.umaszczenie = umaszczenie;
            this.rasa = rasa;
            this.plec = plec;
            this.pochodzenie = pochodzenie;
            this.hodowla = hodowla;
            this.wysokosc_w_klebie = wysokosc_w_klebie;
            this.waga = waga;
            this.rok_ur = rok_ur;
            this.obwod_klatki_piersiowej = obwod_klatki_piersiowej;
            this.dataUr = dataUr;
            this.zdjecie = zdjecie;
        }

        //Konstruktor kopiujący

        public Kon(Kon k)
        {
            imie = k.imie;
            umaszczenie = k.umaszczenie;
            rasa = k.rasa;
            plec = k.plec;
            pochodzenie = k.pochodzenie;
            hodowla = k.hodowla;
            wysokosc_w_klebie = k.wysokosc_w_klebie;
            waga = k.waga;
            rok_ur = k.rok_ur;
            obwod_klatki_piersiowej = k.obwod_klatki_piersiowej;
            dataUr = k.dataUr;
            zdjecie = k.zdjecie;
        }

        //Destruktor
        ~Kon()
        {

        }

        public virtual void ZapiszDoPliku(StreamWriter sw)
        {

        }

        //Metoda wypisująca podstawowe informacje - publiczna

        public virtual void Wypisz(ListBox lb,PictureBox pb)
        {
            try
            {
                //lb.Items.Clear();
                lb.Items.Add("Imię: " + imie);
                lb.Items.Add("Umaszczenie: " + umaszczenie);
                lb.Items.Add("Rasa: " + rasa);
                lb.Items.Add("Płeć: " + plec);
                lb.Items.Add("Pochodzenie: " + pochodzenie);
                lb.Items.Add("Hodowla: " + hodowla);
                lb.Items.Add("Wys w kłębie: " + wysokosc_w_klebie + "cm " + Dorosly());
                lb.Items.Add("Waga: " + waga + "kg");
                lb.Items.Add("Wiek: " + Wiek());
                lb.Items.Add("Obwód_klatki_piersiowej: " + obwod_klatki_piersiowej + "cm");
            }
            catch(InvalidCastException)
            {
                MessageBox.Show("Blad");

            }
            finally
            {

            }

        }

        //Metoda obliczająca wiek osoby- prywatna
        int Wiek()
        {
            int wiek = 2020 - rok_ur;
            return wiek;
        }


        string Dorosly()
        {
         if (wysokosc_w_klebie > 140)
            return "Dorosły koń";
         else
            return "";
        }
        public int CompareTo(Kon kon)
        {
            if (kon == null)
                return 1;

            if (String.Compare(this.hodowla, kon.hodowla) == 1)
                return 1;
            else if (String.Compare(this.hodowla, kon.hodowla) == 1)
                return -1;
            else
            {
                if (String.Compare(this.imie, kon.imie) == 1)
                    return 1;
                else if (String.Compare(this.imie, kon.imie) == 1)
                    return -1;
                else
                    return 0;
            }
        }

    }
}
