using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CS155Week3Project2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Title = "Vending machine change calculator";
            txtbox_CostofItem.Focus();

        }

        private void cmdCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            int dCost, dChange;
            bool bResult;
            String s;
            int nQuarters = 0,
                nDimes = 0,
                nNickels = 0,
                nPennnies = 0;

            lblTotalChangeDue.Focus();

            bResult = Int32.TryParse(txtbox_CostofItem.Text, out dCost);
            if (!bResult)
            {
                MessageBox.Show("Please enter a valid cost of item!");
                txtbox_CostofItem.Focus();
                return;
            }
            else
            {
                if (dCost < 0 || dCost < 25 || dCost > 100)
                {
                    MessageBox.Show("Please enter a valid cost of item!");
                    txtbox_CostofItem.Focus();
                    return;
                }

                dChange = 100 - dCost; // $1 bill used every time
                if ( ((int)(dChange) % 5) != 0) 
                {
                    MessageBox.Show("Please enter a valid cost of item!\n\nItems cost 25c to 100c, in increments of 5c!");
                    txtbox_CostofItem.Focus();
                    return;
                }
            }

            s = dChange.ToString() + " cents";
            lblTotalChangeDue.Content = s;



            if (dChange == 0)
            {
                lblQuarters.Content = "0";
                lblDimes.Content = "0";
                lblNickels.Content = "0";
                lblPennies.Content = "0";
            }
            else
            {
                nQuarters = dChange / 25;
                dChange %= 25;  //remainder after 25c division
                if (dChange > 0)
                {
                    nDimes = dChange / 10;
                    dChange %= 10; //remainer after 10c division

                    if (dChange > 0)
                    {
                        nNickels = dChange / 5;
                        nPennnies %= 5; //remainer after 5c division - this problem won't have # of pennies (input cost is in increment of 5c), but just a generalization

                    }
                }

                lblQuarters.Content = nQuarters;
                lblDimes.Content = nDimes;
                lblNickels.Content = nNickels;
                lblPennies.Content = nPennnies;
            }

            txtbox_CostofItem.Focus();

        }

        private void txtboxCostofItem_GotFocus(object sender, RoutedEventArgs e)
        {
            txtbox_CostofItem.SelectAll();

        }

        private void txtbox_CostofItem_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            {
                if (lblTotalChangeDue != null) lblTotalChangeDue.Content = " ";
                if (lblQuarters != null) lblQuarters.Content = "";
                if (lblDimes != null) lblDimes.Content = "";
                if (lblNickels != null) lblNickels.Content = "";
                if (lblPennies != null) lblPennies.Content = "";
            }
        }
    }
}
