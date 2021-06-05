using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laboratorna6
{
    public class RequestWins
    {
        public string name; 
        public string rating; 
        public string koef; 
        public string payments; 
        public string win;
        
        public double count = 0, sum = 0;
        public RequestWins(string Name, string Rating, string Koef, string Payments, string Win, double Count)
        {
            Name = name;
            Rating = rating;
            Koef = koef; Payments = payments; Win = win; Count = count;
        }
        BindingSource bs1 = new BindingSource();
        public virtual void request(DataGridView dg1)
        {
            for (int i = 0; i < dg1.RowCount; i++)
            {
                if (Convert.ToBoolean(dg1[7, i].Value) == true)
                {
                    count++;
                    sum = sum + Convert.ToDouble(dg1[6, i].Value);
                    bs1.Add(new Rates(dg1[0, i].Value.ToString(), dg1[1, i].Value.ToString(), dg1[2, i].Value.ToString(), dg1[3, i].Value.ToString(), dg1[4, i].Value.ToString(), dg1[5, i].Value.ToString(), dg1[6, i].Value.ToString(), Convert.ToBoolean(dg1[7, i].Value)));
                }
            }
            dg1.DataSource = bs1;
        }

        public RequestWins() { }

    }
}
