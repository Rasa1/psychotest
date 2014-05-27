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
    }
}
