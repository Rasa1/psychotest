using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychotest
{
    class Dane
    {
        List<string> odpowiedzi;//możliwe odpowiedzi np.: "pedał" "nie pedał"
        public List<Atrybut> atrybuty;//atrybuty i ich możliwe wartości
        public int kol, wier;//ilość kolumn i wierszy danych treningowych
        public int[,] dane_treningowe;//dane do treningu z dodatkową kolumną na odpowiedź

        Dane(int k, int w)
        {
            this.kol = k;
            this.wier = w;
            this.dane_treningowe = new int[wier, kol + 1];
        }
        Dane(int k, int w,List<Atrybut> attr,List<string> odp)
        {
            this.kol = k;
            this.wier = w;
            this.dane_treningowe = new int[wier, kol + 1];
            for(int i=0;i<attr.Count();i++)
                
        }
    }
}
