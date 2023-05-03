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
using lab_work_7_func_module;
using lab_work_7_func_module.functions;
using lab_work_7.model;

namespace lab_work_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _xStart;
        private double _xEnd;
        private int _counter;
        private double _step;

        private List<Function> _functions = MathFunctionList.GetFunctionList();

        public MainWindow()
        {
            InitializeComponent();
            XStartValueTextBox.Text = "0.1";
            XEndValueTextBox.Text = "1.0";
            CounterValueTextBox.Text = "8";
            FunctionComboBox.ItemsSource = _functions;
            CalculateStep();
        }
        
        private void GetResultButton_OnClick(object sender, RoutedEventArgs e)
        {
            var func = (Function)FunctionComboBox.SelectedItem;
            var results = new List<Result>();
            for (var x = _xStart; x <= _xEnd; x = x + _step)
            {
                results.Add(new Result(x, _counter, func));
            }
            ResultGrid.ItemsSource = results;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var hasValues = !string.IsNullOrEmpty(XStartValueTextBox.Text) &&
                            !string.IsNullOrEmpty(XEndValueTextBox.Text) &&
                            !string.IsNullOrEmpty(CounterValueTextBox.Text);
            GetResultButton.IsEnabled = hasValues;
            CalculateStep();
            ResultGrid.ItemsSource = null;
        }

        private void CalculateStep()
        {
            try
            {
                _xStart = Convert.ToDouble(Math.Round(decimal.Parse(XStartValueTextBox.Text, CultureInfo.InvariantCulture), 4));
                _xEnd = Convert.ToDouble(Math.Round(decimal.Parse(XEndValueTextBox.Text, CultureInfo.InvariantCulture), 4));
                _counter = int.Parse(CounterValueTextBox.Text);

                _step = Convert.ToDouble(Math.Round((_xEnd - _xStart) / _counter, 4));
                StepLabel.Content = $"h = (x2 - x1)/n = {_step}";
            }
            catch (Exception e)
            {
                StepLabel.Content = "h = (x2 - x1)/n = Error";
            }
        }
    }
}