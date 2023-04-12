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

namespace lab_work_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsDataValid => string.IsNullOrEmpty(XValueTextBox.Text) &&
                                    string.IsNullOrEmpty(YValueTextBox.Text);

        private FuncType _funcType;
        
        private FuncType _mainFuncType;

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
                var funcTypeString = _funcType switch
                {
                    FuncType.FIRST => $"sh({XValueTextBox.Text})",
                    FuncType.SECOND => $"{XValueTextBox.Text}^2",
                    FuncType.THIRD => $"e^{XValueTextBox.Text}"
                };
                var mainFuncTypeString = _mainFuncType switch
                {
                    FuncType.FIRST => "e^(f(x) - |y|)",
                    FuncType.SECOND => "sqrt(|f(x) + y|)",
                    FuncType.THIRD => "2 * f(x)^2"
                };
                var x = double.Parse(XValueTextBox.Text, CultureInfo.InvariantCulture);
                
                ResultTextBlock.Text = $"X = {XValueTextBox.Text}\n" +
                                       $"Y = {YValueTextBox.Text}\n" +
                                       $"f(x) = {funcTypeString} = {x}\n" +
                                       $"Main function = {mainFuncTypeString}\n" +
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
            var funcValue = GetFuncResult(x);
            _mainFuncType = (x > 0.5 && x < 10.0) && (y > 0.5 && y < 10.0) ? FuncType.FIRST :
                (x > 0.1 && x < 0.5) && (y > 0.1 && y < 0.5) ? FuncType.SECOND :
                FuncType.THIRD;


            var result = Solve(funcValue);
            return Math.Round(result, 2);

            double Solve(double funcValue)
            {
                return _mainFuncType switch
                {
                    FuncType.FIRST => Math.Pow(Math.E, funcValue - Math.Abs(y)),
                    FuncType.SECOND => Math.Sqrt(Math.Abs(funcValue + y)),
                    FuncType.THIRD => 2 * Math.Pow(funcValue, 2)
                };
            }
        }

        private double GetFuncResult(double x)
        {
            return _funcType switch
            {
                FuncType.FIRST => Math.Sinh(x),
                FuncType.SECOND => Math.Pow(x, 2),
                FuncType.THIRD => Math.Pow(Math.E, x)
            };
        }

        private void RadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            if (FirstFuncRadioButton?.IsChecked == true)
                _funcType = FuncType.FIRST;
            else if (SecondFuncRadioButton?.IsChecked == true)
                _funcType = FuncType.SECOND;
            else
                _funcType = FuncType.THIRD;
        }

        private enum FuncType
        {
            FIRST,
            SECOND,
            THIRD
        }
    }
}