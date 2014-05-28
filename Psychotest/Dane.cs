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

        public Dane(int kolumny, int wiersze)
        {
            this.odpowiedzi = new List<string>();
            this.atrybuty = new List<Atrybut>();
            this.kol = kolumny;
            this.wier = wiersze;
            this.dane_treningowe = new int[wier, kol + 1];
        }
        public Dane(int kolumny, int wiersze, List<Atrybut> attr, List<string> odp)
        {
            this.odpowiedzi = new List<string>();
            this.atrybuty = new List<Atrybut>();
            this.kol = kolumny;
            this.wier = wiersze;
            this.dane_treningowe = new int[wier, kol + 1];
            for (int i = 0; i < attr.Count(); i++)
                this.atrybuty[i].Coppy(attr[i]);
            for (int i = 0; i < odp.Count(); i++)
                this.odpowiedzi[i] = odp[i];
        }
        public Dane(int kolumny, int wiersze, List<string> odp)
        {
            this.odpowiedzi = new List<string>();
            this.atrybuty = new List<Atrybut>();
            this.kol = kolumny;
            this.wier = wiersze;
            this.dane_treningowe = new int[wier, kol + 1];
            for (int i = 0; i < odp.Count(); i++)
                this.odpowiedzi[i] = odp[i];
        }
        public Dane(int kolumny, int wiersze, string[] odp)
        {
            this.odpowiedzi = new List<string>();
            this.atrybuty = new List<Atrybut>();
            this.kol = kolumny;
            this.wier = wiersze;
            this.dane_treningowe = new int[wier, kol + 1];
            for (int i = 0; i < odp.Length; i++)
                this.odpowiedzi[i] = odp[i];
        }


        public void SetDane_treningowe(int[,] dane)//zakładam że tablica wysyłana do tej metody jest tej samej wielkości co nasza tablica dane_treningowe
        {
            for (int i = 0; i < this.wier; i++)
                for (int j = 0; j < this.kol + 1; j++)
                    this.dane_treningowe[i, j] = dane[i, j];
        }

        private int GetAtrybutIndex(int kolumna, string wartosc)//Ważna metoda użyteczna przy wypełnianiu danych treningowych
        {
            return this.atrybuty[kolumna].GetIndex(wartosc);
        }

        public double GetEntropy()
        {
            int[] ilosci_wystapien = new int[this.odpowiedzi.Count()];
            for (int i = 0; i < this.odpowiedzi.Count(); i++)
                ilosci_wystapien[i] = 0;
            for (int i = 0; i < this.wier; i++)
                ilosci_wystapien[dane_treningowe[i, this.kol]]++;
            //bardzo ważne jest żeby w tabeli dane_treningowe ostatnia kolumna (kolumna odpowiedzi) miała wartości zaczynające się od zera
            //czyli żeby kolejne możliwe odpowiedzi były zamienione na 0, 1, 2... 
            double wynik = 0;
            for (int i = 0; i < ilosci_wystapien.Length; i++)
            {
                double p = (double)ilosci_wystapien[i] / (double)wier;
                wynik += p * Math.Log(p);
            }
            return -wynik;
        }

        public double info(int atrybut)
        {
            double wynik=0;
            //double split = 0;
            for (int i = 0; i < this.atrybuty[atrybut].mozliwosci.Count(); i++)
            {
                int wystapienia = 0;//ilość wystąpień wartości atrybutu "atrybut" w danych treningowych
                int[] wystapienia_na = new int[this.odpowiedzi.Count];//tablica przechowywująca ile z danej wartośi atrybutu było na przy jakiej odpowiedzi
                //przy odpowiedzi tak/nie ta tablica będzie maiła długość 2 i będzie przechowywała ilość wierszy z daną wartością atrybutu z odpowiedzią na "tak" w jednej komórce i na "nie" w drugiej
                for (int j = 0; j < wystapienia_na.Length; j++)
                    wystapienia_na[j] = 0;
                for (int j = 0; j < this.wier; j++)
                {
                    if (this.dane_treningowe[j, atrybut] == i)
                    {
                        wystapienia_na[this.dane_treningowe[j,this.kol]]++;
                        wystapienia++;
                    }
                }
                double wynik_posredni = 0;
                for (int j = 0; j < wystapienia_na.Length; j++)
                {
                    double p=(double)wystapienia_na[j]/(double)wystapienia;
                    if (p != 0)
                        wynik_posredni += p * Math.Log(p);
                }
                //split -= (wystapienia / this.wier) * Math.Log(wystapienia / this.wier);
                wynik += ((double)wystapienia / (double)this.wier) * (-wynik_posredni);
            }
            return wynik;///split;
        }

        public double split(int atrybut)
        {
            double wynik = 0;
            for(int i=0;i<this.atrybuty[atrybut].mozliwosci.Count;i++)
            {
                int wystapienia=0;
                for (int j = 0; j < this.wier; j++)
                {
                    if (this.dane_treningowe[j, atrybut] == i)
                        wystapienia++;
                }
                wynik -= ((double)wystapienia / (double)this.wier) * Math.Log((double)wystapienia / (double)this.wier);
            }
            return wynik;
        }

        public double gain(int atrybut)
        {
            return (GetEntropy() - info(atrybut))/split(atrybut);
        }


        public void AddDane_treningowe(int wiersz, int kolumna, string wartosc)//tej metody używaj do pojedyńczego wypełniania tabeli do danych treningowych
        {
            this.dane_treningowe[wiersz, kolumna] = GetAtrybutIndex(kolumna, wartosc);
        }

        public void AddAtrybut(Atrybut atr)//tą metodą dodawaj pojedyńczo atrybuty
        {

            try
            {
                this.atrybuty.Add(atr);
            }
            catch (Exception)
            {
                return;
                throw;
            }
        }

        public void AddOdpowiedz(string odp)//tą metodą dodawaj pojedyńczo odpowiedzi
        {
            try
            {
                this.odpowiedzi.Add(odp);
            }
            catch (Exception)
            {
                return;
                throw;
            }
        }

        
    }
}
