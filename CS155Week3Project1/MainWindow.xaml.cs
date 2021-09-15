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


namespace CS155Week3Project1
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const double INTEREST_RATE = 6.39;
        public MainWindow()
        {
            InitializeComponent();

            this.Title = "Mortage Calculator";
            lbl_InterestRate.Content = INTEREST_RATE;
            txtBox_Principal.Focus();
        }

        private void txtPrincipal_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBox_Principal.SelectAll();
        }

        private void txtMonthlyPayment__GotFocus(object sender, RoutedEventArgs e)
        {
            txtbox_MonthlyPayment.SelectAll();
        }

        private void cmdCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            double dPrin, dMonthly, dRate;
            bool bResult;

            bResult = Double.TryParse(txtBox_Principal.Text, out dPrin);
            if (!bResult)
            {
                MessageBox.Show("Please enter a valid Principal Due amount!");
                return;
            }
            else 
            {
                if (dPrin < 0.0)
                {
                    MessageBox.Show("Please enter a valid Principal Due amount!");
                    return;
                }
            }

            bResult = Double.TryParse(lbl_InterestRate.Content.ToString(), out dRate);
            if (!bResult)
            {
                MessageBox.Show("Please enter a valid Interest Rate!");
                return;
            }
            else
            {
                if (dRate < 0.0)
                {
                    MessageBox.Show("Please enter a valid Interest Rate!");
                    return;
                }
            }

            bResult = Double.TryParse(txtbox_MonthlyPayment.Text, out dMonthly);
            if (!bResult)
            {
                MessageBox.Show("Please enter a valid Monthly Payment amount!");
                return;
            }
            else
            {
                if (dMonthly < 0.0)
                {
                    MessageBox.Show("Please enter a valid Monthly Payment amount!");
                    return;
                }
            }

            double dIntrPortion = dPrin * dRate / 12.0 / 100.0;
            double dPrinPortion = dMonthly - dIntrPortion;
            lbl_InterestPortion.Content = string.Format("{0:0.00}", Math.Round(dIntrPortion*100.0)/100.0);
            lbl_PrincipalPortion.Content = string.Format("{0:0.00}", Math.Round(dPrinPortion * 100.0) / 100.0);
        }
    }
}
