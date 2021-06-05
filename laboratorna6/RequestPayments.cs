using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laboratorna6
{
    class RequestPayments :  RequestWins
    {
        public override void request(DataGridView dg1)
        {
            double sum = 0;
            for (int i = 0; i < dg1.RowCount; i++)
            {
                name = name + dg1[0, i].Value.ToString() + ": " +dg1[6, i].Value.ToString() + "\t\t";
                payments = payments  + "\t\t";
                sum = sum + Convert.ToDouble(dg1[6, i].Value);
            }
            show(sum);
        }
        public void show(double sum)
        {
            MessageBox.Show("Назва: \n" + name + "\nЗагальна кількість виплат: " + sum);
        }
    }
}
