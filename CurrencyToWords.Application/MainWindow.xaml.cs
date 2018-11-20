using CurrencyToWords.ClientApplication.CurrencyToWordsService;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace CurrencyToWords.ClientApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrencyAmount.Text))
            {
                MessageBox.Show("Please enter the amount!", "Information", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                var culture = new CultureInfo(((ListBoxItem)ddlCulture.SelectedItem).Content.ToString());
                var validatedNumber = IsValidNumber(txtCurrencyAmount.Text, culture);
                if (validatedNumber.Item1)
                {
                    var serviceClient = new CurrencyToWordsServiceClient();
                    var response = serviceClient.Convert(validatedNumber.Item2, culture);
                    if (response?.Status == ServiceResultStatus.Success)
                    {
                        lblAmountInWords.Text = response.AmountInWords;
                    }
                    else if (response.Status == ServiceResultStatus.Warning)
                    {
                        MessageBox.Show(response.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else if (response.Status == ServiceResultStatus.Failed)
                    {
                        MessageBox.Show(response.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid number or number formate based on the selected number culture!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private Tuple<bool, double> IsValidNumber(string numberString, CultureInfo culture)
        {
            double number = 0;
            bool isValidNumber = double.TryParse(numberString, NumberStyles.Float, culture, out number);
            return new Tuple<bool, double>(isValidNumber, number);
        }
    }
}
