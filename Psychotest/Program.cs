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
            Atrybut atr = new Atrybut("outlook");
            atr.AddMozliwosc("sunny");
            atr.AddMozliwosc("overcast");
            atr.AddMozliwosc("rain");
            Dane dane = new Dane(2, 14);
            dane.AddAtrybut(atr);
            atr = new Atrybut("windy");
            atr.AddMozliwosc("false");
            atr.AddMozliwosc("true");
            dane.AddOdpowiedz("play");
            dane.AddOdpowiedz("dont");

            return;
        }
    }


    
    
}
