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
        List<string> mozliwosci;//lista możliwości np.:[sunny, overcast, rain]

        public void AddMozliwosc(string m)//tej metody możesz użyć żeby dodawać kolejne możliwości jedna po drugiej 
        {
            this.mozliwosci.Add(m);
        }
        public void Coppy(Atrybut kopiuj_z)
        {
            this.nazwa = kopiuj_z.nazwa;
            for (int i = 0; i < kopiuj_z.mozliwosci.Count; i++)
                this.mozliwosci[i] = kopiuj_z.mozliwosci[i];
        }

        Atrybut(string n)
        {
            this.nazwa = n;
        }
        Atrybut(string n,string[] m)
        {
            this.nazwa = n;
            for (int i = 0; i < m.Length; i++)
                this.mozliwosci.Add(m[i]);
        }
        Atrybut(string n, List<string> m)
        {
            this.nazwa = n;
            for (int i = 0; i < m.Count; i++)
                this.mozliwosci.Add(m[i]);
        }
    }
}
