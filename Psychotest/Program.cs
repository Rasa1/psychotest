using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychotest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cycki （ 。 ㅅ  。）
            Dane dane = new Dane(2, 14);

            Atrybut atr = new Atrybut("outlook");
            atr.AddMozliwosc("sunny");
            atr.AddMozliwosc("overcast");
            atr.AddMozliwosc("rain");
            
            dane.AddAtrybut(atr);

            atr = new Atrybut("windy");
            atr.AddMozliwosc("false");
            atr.AddMozliwosc("true");
            dane.AddAtrybut(atr);

            dane.AddOdpowiedz("play");
            dane.AddOdpowiedz("dont");
            int[,] tab = { 
                         {0,0,1 }, 
                         {0,1,1 }, 
                         {1,0,0 }, 
                         {2,0,0 }, 
                         {2,0,0}, 
                         {2,1,1 }, 
                         {1,1,0 }, 
                         {0,0,1 }, 
                         {0,0,0 }, 
                         {2,0,0}, 
                         {0,1,0}, 
                         {1,1,0}, 
                         {1,0,0}, 
                         {2,1,1} };
            dane.SetDane_treningowe(tab);

            Console.Out.WriteLine(dane.GetEntropy());
            Console.Out.WriteLine(dane.info(0));
            return;
        }
    }


    
    
}
