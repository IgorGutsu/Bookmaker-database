using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laboratorna6
{
    public partial class fRequests : Form
    {
        public fRequests()
        {

            InitializeComponent();

        }
        public static BindingSource s1 = new BindingSource();

        private void fRequests_Load(object sender, EventArgs e)
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            RequestWins rq1 = new RequestWins();
            column.DataPropertyName = "Name";
            column.DataPropertyName = "Sport"; column.Name = "Вид Спорту"; dataGridView1.Columns.Add(column);
            column = new DataGridViewTextBoxColumn(); column.DataPropertyName = "Team1"; column.Name = "Команда 1"; dataGridView1.Columns.Add(column);
            column = new DataGridViewTextBoxColumn(); column.DataPropertyName = "Ratings1"; column.Name = "Ставки"; dataGridView1.Columns.Add(column);
            column = new DataGridViewTextBoxColumn(); column.DataPropertyName = "Team2"; column.Name = "Команда 2"; dataGridView1.Columns.Add(column);
            column = new DataGridViewTextBoxColumn(); column.DataPropertyName = "Ratings2"; column.Name = "Ставки"; dataGridView1.Columns.Add(column);
            column = new DataGridViewTextBoxColumn(); column.DataPropertyName = "Koef"; column.Name = "Коефіцієнти"; dataGridView1.Columns.Add(column);
            column = new DataGridViewTextBoxColumn(); column.DataPropertyName = "Payments"; column.Name = "Заробіток"; dataGridView1.Columns.Add(column);
            column = new DataGridViewTextBoxColumn(); column.DataPropertyName = "Win"; column.Name = "Виграш"; dataGridView1.Columns.Add(column);
            dataGridView1.DataSource = fMain.bscr; 
            rq1.request(dataGridView1);
            EventArgs args = new EventArgs(); OnResize(args);
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
