using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Real_investment_app
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        { // create variables 
            double yearlyInvestment, yearlyGrowth, investment = 0;
            int years;
            double.TryParse(investmentTextBox.Text, out yearlyInvestment);
            double.TryParse(growthTextBox.Text, out yearlyGrowth);
            int.TryParse(yearsTextBox.Text, out years);

            // print heading in the list box
            string formatCode = "{0,7}{1,20}";
            investmentListBox.Items.Add(string.Format(formatCode, "Years",
                                                     "Investment Value"));
            investmentListBox.Items.Add("");
            int year = 0; // set year to 0 
            // create formula to calculate the investment using 'for' statement
            for (year = 1; year <= years; year = year + 1)
            {
                investment = (investment + yearlyInvestment) * (1 + yearlyGrowth / 100);
                investmentListBox.Items.Add(string.Format(formatCode, year,
               investment.ToString("C2")));
            }
         }
        // create an exit button 
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void investmentTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') // allows only numbers and periods to be entered 
            {
                e.Handled = true;
                return;
            }

        }

        private void growthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') // allows only numbers and periods to be entered
            {
                e.Handled = true;
                return;
            }

        }

        private void yearsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' ) // allows only numbers and periods to be entered
            {
                e.Handled = true;
                return;
            }

        }

        private void investmentTextBox_TextChanged(object sender, EventArgs e) // clears the list box when input is changed
        {
            investmentListBox.Items.Clear(); 
        }

        private void growthTextBox_TextChanged(object sender, EventArgs e) // clears the list box when input is changed
        {
            investmentListBox.Items.Clear();
        }

        private void yearsTextBox_TextChanged(object sender, EventArgs e) // clears the list box when input is changed 
        {
            investmentListBox.Items.Clear();
        }

        private void investmentTextBox_Click(object sender, EventArgs e)
        {
            investmentTextBox.SelectAll(); // selects all input when user clicks the text box
        }

        private void growthTextBox_Click(object sender, EventArgs e)
        {
            growthTextBox.SelectAll(); // selects all input when the user clicks the text box
        }

        private void yearsTextBox_Click(object sender, EventArgs e)
        {
            yearsTextBox.SelectAll(); // selects all input when the user clicks the text box
        }

    }
}
