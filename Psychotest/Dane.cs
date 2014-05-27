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

        public void SetDane_treningowe(int[,] dane)//zakładam że tablica wysyłana do tej metody jest tej samej wielkości co nasza tablica dane_treningowe
        {
            for (int i = 0; i < this.wier; i++)
                for (int j = 0; j < this.kol + 1; j++)
                    this.dane_treningowe[i, j] = dane[i, j];
        }

        public int GetAtrybutIndex(int kolumna,string wartosc)//Ważna metoda użyteczna przy wypełnianiu danych treningowych
        {
            return this.atrybuty[kolumna].GetIndex(wartosc);
        }

        public void AddDane_treningowe(int wiersz, int kolumna, int wartosc)//tej metody używaj do pojedyńczego wypełniania tabeli do danych treningowych
        {
            this.dane_treningowe[wiersz, kolumna] = wartosc;
        }

        public void AddAtrybut(Atrybut atr)//tą metodą dodawaj pojedyńczo atrybuty
        {
            this.atrybuty.Add(atr);
        }

        public void AddOdpowiedz(string odp)//tą metodą dodawaj pojedyńczo odpowiedzi
        {
            this.odpowiedzi.Add(odp);
        }

        Dane(int kolumny, int wiersze)
        {
            this.kol = kolumny;
            this.wier = wiersze;
            this.dane_treningowe = new int[wier, kol + 1];
        }
        Dane(int kolumny, int wiersze,List<Atrybut> attr,List<string> odp)
        {
            this.kol = kolumny;
            this.wier = wiersze;
            this.dane_treningowe = new int[wier, kol + 1];
            for (int i = 0; i < attr.Count(); i++)
                this.atrybuty[i].Coppy(attr[i]);
            for (int i = 0; i < odp.Count(); i++)
                this.odpowiedzi[i] = odp[i];
        }
        Dane(int kolumny, int wiersze, List<string> odp)
        {
            this.kol = kolumny;
            this.wier = wiersze;
            this.dane_treningowe = new int[wier, kol + 1];
            for (int i = 0; i < odp.Count(); i++)
                this.odpowiedzi[i] = odp[i];
        }
        Dane(int kolumny, int wiersze, string[] odp)
        {
            this.kol = kolumny;
            this.wier = wiersze;
            this.dane_treningowe = new int[wier, kol + 1];
            for (int i = 0; i < odp.Length; i++)
                this.odpowiedzi[i] = odp[i];
        }
    }
}
