using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychotest
{
    class Atrybut
    {
        string nazwa;
        List<string> wartosci = new List<string>();

        public Atrybut(string n, List<string> w)
        {
            this.nazwa = n;
            this.wartosci = w;
        }
        public Atrybut(string n, string[] w)
        {
            this.nazwa = n;
            for (int i = 0; i < w.Length; i++)
                this.wartosci.Add(w[i]);
        }
    }
}
