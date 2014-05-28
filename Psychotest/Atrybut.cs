using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychotest
{
    class Atrybut
    {
        public string nazwa;//nazwa atrybutu np.:outlook albo windy
        public List<string> mozliwosci;//lista możliwości np.:[sunny, overcast, rain]

        public Atrybut()
        {
            this.mozliwosci = new List<string>();
        }
        public Atrybut(string n)
        {
            this.nazwa = n;
            this.mozliwosci=new List<string>();
        }
        public Atrybut(string n, string[] m)
        {
            this.nazwa = n;
            this.mozliwosci = new List<string>();
            for (int i = 0; i < m.Length; i++)
                this.mozliwosci.Add(m[i]);
        }
        public Atrybut(string n, List<string> m)
        {
            this.nazwa = n;
            this.mozliwosci = new List<string>();
            for (int i = 0; i < m.Count; i++)
                this.mozliwosci.Add(m[i]);
        }


        public void AddMozliwosc(string m)//tej metody możesz użyć żeby dodawać kolejne możliwości jedna po drugiej 
        {
            try
            {
                this.mozliwosci.Add(m);
            }
            catch (Exception)
            {
                return;
                throw;
            }
        }
        public void Coppy(Atrybut kopiuj_z)
        {
            this.nazwa = kopiuj_z.nazwa;
            for (int i = 0; i < kopiuj_z.mozliwosci.Count; i++)
                this.mozliwosci[i] = kopiuj_z.mozliwosci[i];
        }

        public int GetIndex(string wartosc)
        {
            for (int i = 0; i < this.mozliwosci.Count; i++)
            {
                if (this.mozliwosci[i].Equals(wartosc))
                {
                    return i;
                }
            }
            return -1;//błąd
        }

        
    }
}
