using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorna6
{
    public class Rates
    {
        public string Sport { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Ratings1 { get; set; }
        public string Ratings2 { get; set; }
        public string ratCount1 { get; set; }
        public string ratCount2 { get; set; }
        public string Koef { get; set; }
        public string Payments { get; set; }
        public bool Win { get; set; }
        public int Count { get; set; }

        public Rates()
        {

        }

        public Rates(string name, string team1, string ratings1,string team2, string ratings2, string koef, string payments, bool win)
        {
            Sport = name; 
            Ratings1 = ratings1; 
            Koef = koef; 
            Payments = payments; 
            Win = win;
            Team1 = team1; 
            Team2 = team2; 
            Ratings2 = ratings2;
        }
        public Rates(string name, string team1, string ratings1, string team2, string ratings2, string koef, string payments, bool win, string ratcount1, string ratcount2)
        {
            ratCount1 = ratcount1;
            ratCount2 = ratcount2;
            Sport = name;
            Ratings1 = ratings1;
            Koef = koef;
            Payments = payments;
            Win = win;
            Team1 = team1;
            Team2 = team2;
            Ratings2 = ratings2;
        }


    }
}
