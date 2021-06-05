using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace laboratorna6
{
    public partial class fRates : Form
    {
        public static Rates selectedTablet { get; set; }

        public fRates()
        {
            InitializeComponent();
            selectedTablet = new Rates();
        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        /*
         * Sport = name; 
            Ratings1 = ratings1; 
            Koef = koef; 
            Payments = payments; 
            Win = win;
            Team1 = team1; 
            Team2 = team2; 
            Ratings2 = ratings2;
        */
        public fRates(ref Rates current)
        {
            InitializeComponent();
            selectedTablet = current;
            name_tb.Text = current.Sport;
            team1_tb.Text = current.Team1;
            team2_tb.Text = current.Team2;
            ratings1.Text = current.Ratings1;
            ratings2.Text = current.Ratings2;
            count1.Text = current.ratCount1;
            count2.Text = current.ratCount2;
            checkBox1.Checked = current.Win;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            selectedTablet.Sport = name_tb.Text;
            selectedTablet.Team1 = team1_tb.Text;
            selectedTablet.Team2 = team2_tb.Text;
            selectedTablet.Ratings1 = ratings1.Text + " (" + count1.Text + "грн)";
            selectedTablet.Ratings2 = ratings2.Text + " (" + count2.Text + "грн)";
            selectedTablet.Koef = Convert.ToString(Convert.ToDouble(ratings1.Text) / Convert.ToDouble(ratings2.Text));
            selectedTablet.ratCount1 = count1.Text;
            selectedTablet.ratCount2 = count2.Text;
            if(checkBox1.Checked == true)
            {
                selectedTablet.Payments = Convert.ToString(Convert.ToDouble(selectedTablet.Koef) * Convert.ToDouble(count1.Text));
            }
            else
            {
                selectedTablet.Payments = Convert.ToString(Convert.ToDouble(selectedTablet.Koef) * Convert.ToDouble(count2.Text));
            }
            selectedTablet.Win = checkBox1.Checked;
            button1.DialogResult = DialogResult.OK;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
