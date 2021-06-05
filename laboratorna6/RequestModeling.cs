using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laboratorna6
{
    class RequestModeling : RequestWins
    {
        List<String> lv1 = new List<string>();
        List<String> lv2 = new List<string>();
        public void findSameNames(DataGridView dg1)
        {
            for(int i = 0; i < dg1.RowCount - 1; i++)
            {
                if(lv1.Contains(dg1[1, i].Value.ToString()))
                {
                    continue;
                }
                else
                {
                    lv1.Add(dg1[1, i].Value.ToString());
                }
                if (lv2.Contains(dg1[3, i].Value.ToString()))
                {
                    continue;
                }
                else
                {
                    lv2.Add(dg1[3, i].Value.ToString());
                }
            }
        }
        public override void request(DataGridView dg1)
        {
            findSameNames(dg1);
            int btrue = 0, bfalse = 0; string result = ""; string posneg;
            for (int i = 0; i < dg1.RowCount; i++)
            {
                if(lv1.Contains(dg1[1, i].Value.ToString()) && lv2.Contains(dg1[3, i].Value.ToString()))
                {
                    for(int j = 0; j < dg1.RowCount; j++)
                    {
                        if(dg1[1, j].Value.ToString() == dg1[1, i].Value.ToString() && dg1[3, j].Value.ToString() == dg1[3, i].Value.ToString())
                        {
                            if(Convert.ToBoolean(dg1[7, j].Value) == true)
                            {
                                btrue++;
                            }
                            else { bfalse++;  }
                        }
                    }
                    double res = (double)btrue / bfalse;
                    if (res >= 1) { posneg = "Позитивний"; } else { posneg = "Негативний"; }
                    result = result + "\nКоманда 1: " + dg1[1, i].Value.ToString() + " || Команда 2: " + dg1[3, i].Value.ToString() + " \nКількість перемог: " + btrue + " || Кількість поразок: " + bfalse + " || Коефіцієнт перемог: " + res + "\nПрогноз: " + posneg + "\n----------------------";

                    lv1.Remove(dg1[1, i].Value.ToString());
                    btrue = 0; bfalse = 0; 
                }
            }
            MessageBox.Show(result);
        }
    }
}
