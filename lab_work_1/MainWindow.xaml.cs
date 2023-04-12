using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace lab_work_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsDataValid => string.IsNullOrEmpty(XValueTextBox.Text) &&
                                    string.IsNullOrEmpty(YValueTextBox.Text) &&
                                    string.IsNullOrEmpty(ZValueTextBox.Text);
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetResultButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsDataValid)
                ShowError();
            else
            {
                var result = SolveEquation();
                ResultTextBlock.Text = $"X = {XValueTextBox.Text}\n" +
                                       $"Y = {YValueTextBox.Text}\n" +
                                       $"Z = {ZValueTextBox.Text}\n" +
                                       $"Result = {result}";
            }
        }

        private void ShowError()
        {
            MessageBox.Show("Fill in all the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private double SolveEquation()
        {
            var x = double.Parse(XValueTextBox.Text, CultureInfo.InvariantCulture);
            var y = double.Parse(YValueTextBox.Text, CultureInfo.InvariantCulture);
            var z = double.Parse(ZValueTextBox.Text, CultureInfo.InvariantCulture);
            
            var firstPart = Math.Sqrt(10 * (Math.Pow(x, 1/3) + Math.Pow(x, y + 2)));
            var secondPart = Math.Asinh(z) * Math.Asinh(z) - Math.Abs(x - y);
            return Math.Round(firstPart * secondPart, 2);
        }
    }
}