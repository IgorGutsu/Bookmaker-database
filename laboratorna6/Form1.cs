using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laboratorna6
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }
        public static DataGridViewColumn column = new DataGridViewTextBoxColumn();
        public static BindingSource bscr;
        private void fMain_Load(object sender, EventArgs e)
        {
            column.DataPropertyName = "Sport"; column.Name = "Вид Спорту"; gvBukmeker.Columns.Add(column);
            column = new DataGridViewTextBoxColumn(); column.DataPropertyName = "Team1"; column.Name = "Команда 1"; gvBukmeker.Columns.Add(column);
            column = new DataGridViewTextBoxColumn(); column.DataPropertyName = "Ratings1"; column.Name = "Ставки"; gvBukmeker.Columns.Add(column);
            column = new DataGridViewTextBoxColumn(); column.DataPropertyName = "Team2"; column.Name = "Команда 2"; gvBukmeker.Columns.Add(column);
            column = new DataGridViewTextBoxColumn(); column.DataPropertyName = "Ratings2"; column.Name = "Ставки"; gvBukmeker.Columns.Add(column);
            column = new DataGridViewTextBoxColumn(); column.DataPropertyName = "Koef"; column.Name = "Коефіцієнти"; gvBukmeker.Columns.Add(column);
            column = new DataGridViewTextBoxColumn(); column.DataPropertyName = "Payments"; column.Name = "Заробіток"; gvBukmeker.Columns.Add(column);
            column = new DataGridViewTextBoxColumn(); column.DataPropertyName = "Win"; column.Name = "Виграш"; gvBukmeker.Columns.Add(column);
            bindSrcBokmeker.Add(new Rates("Футбол",  "Англія", "30 (25000)", "Україна", "11 (14000)", "2,7", " 4000", false));
            bindSrcBokmeker.Add(new Rates("Баскетбол", "Німеччина", "10 (25000)", "Франція", "5 (14000)", "2", "33100", false));
            bindSrcBokmeker.Add(new Rates("Футбол", "Англія", "30 (25000)", "Україна", "11 (14000)", "2,7", " 4000", true));
            bindSrcBokmeker.Add(new Rates("Баскетбол", "Німеччина", "10 (25000)", "Франція", "5 (14000)", "2", "33100", false));
            bindSrcBokmeker.Add(new Rates("Футбол", "Англія", "30 (25000)", "Україна", "11 (14000)", "2,7", " 4000", true));
            bindSrcBokmeker.Add(new Rates("Баскетбол", "Німеччина", "10 (25000)", "Франція", "5 (14000)", "2", "33100", true));

            bscr = bindSrcBokmeker;
            EventArgs args = new EventArgs(); OnResize(args);
        }
        
        bool filter = true;
        

        private void button1_Click(object sender, EventArgs e)
        {
            fRequests rq1 = new fRequests();
            rq1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RequestModeling r1 = new RequestModeling();
            r1.request(gvBukmeker);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RequestPayments r1 = new RequestPayments();
            r1.request(gvBukmeker);
        }

        private void долатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rates nBike = new Rates();

            fRates ft = new fRates(ref nBike);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcBokmeker.Add(nBike);
            }
        }

        private void редагуватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rates nBike = (Rates)bindSrcBokmeker.List[bindSrcBokmeker.Position];

            fRates ft = new fRates(ref nBike);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcBokmeker.List[bindSrcBokmeker.Position] = nBike;
            }
        }

        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Видалити поточний запис?", "Видалення запису", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bindSrcBokmeker.RemoveCurrent();
            }
        }

        private void очиститиВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
    "Очистити таблицю?\n\nВсі дані будуть втрачені", "Очищення даних", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bindSrcBokmeker.Clear();
            }
        }

        private void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрити застосунок?", "Вихід з програми", MessageBoxButtons.OKCancel,
MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Sort(0);
                    break;
                case 1:
                    Sort(1);
                    break;
                case 2:
                    Sort(2);
                    break;
                case 3:
                    Sort(3);
                    break;
                case 4:
                    Sort(4);
                    break;
                case 5:
                    Sort(5);
                    break;
                case 6:
                    Sort(6);
                    break;
                case 7:
                    Sort(7);
                    break;
               
            }
        }
        private void Sort(int num)
        {
            string sport;
            string team1;
            string team2;
            string ratings1, ratings2;
            double koef;
            double payments, r1, r2;
            bool win;
            for (int i = 0; i < gvBukmeker.RowCount; i++)
            {
                for (int j = i + 1; j < gvBukmeker.RowCount; j++)
                {
                    
                    if(num == 2 || num == 4)
                    {
                        r1 = Convert.ToDouble(gvBukmeker[num, i].Value.ToString().Substring(0, gvBukmeker[num, i].Value.ToString().IndexOf(" ")));
                        r2 = Convert.ToDouble(gvBukmeker[num, j].Value.ToString().Substring(0, gvBukmeker[num, j].Value.ToString().IndexOf(" ")));
                        if (r1 > r2)
                        {
                            sport = gvBukmeker[0, i].Value.ToString();
                            team1 = gvBukmeker[1, i].Value.ToString();
                            ratings1 = gvBukmeker[2, i].Value.ToString();
                            team2 = gvBukmeker[3, i].Value.ToString();
                            ratings2 = gvBukmeker[4, i].Value.ToString();
                            koef = Convert.ToDouble(gvBukmeker[5, i].Value);
                            payments = Convert.ToDouble(gvBukmeker[6, i].Value);
                            win = Convert.ToBoolean(gvBukmeker[7, i].Value);

                            gvBukmeker[0, i].Value = gvBukmeker[0, j].Value;
                            gvBukmeker[1, i].Value = gvBukmeker[1, j].Value;
                            gvBukmeker[2, i].Value = gvBukmeker[2, j].Value;
                            gvBukmeker[3, i].Value = gvBukmeker[3, j].Value;
                            gvBukmeker[4, i].Value = gvBukmeker[4, j].Value;
                            gvBukmeker[5, i].Value = gvBukmeker[5, j].Value;
                            gvBukmeker[6, i].Value = gvBukmeker[6, j].Value;
                            gvBukmeker[7, i].Value = gvBukmeker[7, j].Value;

                            gvBukmeker[0, j].Value = sport;
                            gvBukmeker[1, j].Value = team1;
                            gvBukmeker[2, j].Value = ratings1;
                            gvBukmeker[3, j].Value = team2;
                            gvBukmeker[4, j].Value = ratings2;
                            gvBukmeker[5, j].Value = koef;
                            gvBukmeker[6, j].Value = payments;
                            gvBukmeker[7, j].Value = win;
                        }
                    }
                    else
                    {
                        if (string.Compare(gvBukmeker[num, i].Value.ToString(), gvBukmeker[num, j].Value.ToString()) > 0)
                        {
                            sport = gvBukmeker[0, i].Value.ToString();
                            team1 = gvBukmeker[1, i].Value.ToString();
                            ratings1 = gvBukmeker[2, i].Value.ToString();
                            team2 = gvBukmeker[3, i].Value.ToString();
                            ratings2 = gvBukmeker[4, i].Value.ToString();
                            koef = Convert.ToDouble(gvBukmeker[5, i].Value);
                            payments = Convert.ToDouble(gvBukmeker[6, i].Value);
                            win = Convert.ToBoolean(gvBukmeker[7, i].Value);

                            gvBukmeker[0, i].Value = gvBukmeker[0, j].Value;
                            gvBukmeker[1, i].Value = gvBukmeker[1, j].Value;
                            gvBukmeker[2, i].Value = gvBukmeker[2, j].Value;
                            gvBukmeker[3, i].Value = gvBukmeker[3, j].Value;
                            gvBukmeker[4, i].Value = gvBukmeker[4, j].Value;
                            gvBukmeker[5, i].Value = gvBukmeker[5, j].Value;
                            gvBukmeker[6, i].Value = gvBukmeker[6, j].Value;
                            gvBukmeker[7, i].Value = gvBukmeker[7, j].Value;

                            gvBukmeker[0, j].Value = sport;
                            gvBukmeker[1, j].Value = team1;
                            gvBukmeker[2, j].Value = ratings1;
                            gvBukmeker[3, j].Value = team2;
                            gvBukmeker[4, j].Value = ratings2;
                            gvBukmeker[5, j].Value = koef;
                            gvBukmeker[6, j].Value = payments;
                            gvBukmeker[7, j].Value = win;
                        }

                    }

                }
            }
        }
        public void Filter(string contains, string contains2)
        {
            if (filter == true)
            {
                BindingSource bs1 = new BindingSource();
                for (int i = 0; i < gvBukmeker.RowCount; i++)
                {
                    if (gvBukmeker[0, i].Value.ToString().Contains(contains) && gvBukmeker[1, i].Value.ToString().Contains(contains2) || gvBukmeker[3, i].Value.ToString().Contains(contains2))
                    {

                        bs1.Add(new Rates(gvBukmeker[0, i].Value.ToString(), gvBukmeker[1, i].Value.ToString(), gvBukmeker[2, i].Value.ToString(), gvBukmeker[3, i].Value.ToString(), gvBukmeker[4, i].Value.ToString(), gvBukmeker[5, i].Value.ToString(), gvBukmeker[6, i].Value.ToString(), Convert.ToBoolean(gvBukmeker[7, i].Value)));
                    }
                }
                gvBukmeker.DataSource = bs1;
                MessageBox.Show("Щоб повернути повний список, натисніть на цю кнопку ще раз. Додавання та видалення даних також стане доступним після повернення повного списку");
                filter = false;
            }
            else
            {
                gvBukmeker.DataSource = bindSrcBokmeker;
                filter = true;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string s1 = "", s2 = "";
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    s1 = "Футбол";
                    break;
                case 1:
                    s1 = "Баскетбол";
                    break;
                case 2:
                    s1 = "Хоккей";
                    break;
                case 3:
                    s1 = "Теніс";
                    break;
            }
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    s2 = "Англія";
                    break;
                case 1:
                    s2 = "Німеччина";
                    break;
                case 2:
                    s2 = "Україна";
                    break;
                case 3:
                    s2 = "Росія";
                    break;
                case 4:
                    s2 = "Канада";
                    break;
                case 5:
                    s2 = "Бельгія";
                    break;
                case 6:
                    s2 = "Італія";
                    break;
            }
            if (s1 != "" && s2 != "") { Filter(s1, s2); } else { MessageBox.Show("Оберіть усі необхідні критерії фільтрації"); }
        }
    }
}
