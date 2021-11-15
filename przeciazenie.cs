using System;

namespace l4p2
{
    class Przeciazenie : Kon
    {
        private readonly int w2;
        public Przeciazenie(Kon a)
        {
            w2 = a.waga;
        }
        public static int operator +(Przeciazenie c, Przeciazenie d)
        {
            return c.w2 + d.w2;
        }
        public static bool operator ==(Przeciazenie c, Przeciazenie d)
        {
            if (c.w2 == d.w2)
                return true;
            else
                return false;
        }

        public static bool operator !=(Przeciazenie c, Przeciazenie d)
        {
            return !(c == d);
        }

        public override bool Equals(object o)
        {
            if (!(o is Przeciazenie))
            {
                return false;
            }
            return this == (Przeciazenie)o;
        }
        public override int GetHashCode()
        {
            return 0;
        }
        //public override string ToString() => $"{num} / {den}";
    }
}
