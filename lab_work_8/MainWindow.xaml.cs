using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
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
using lab_work_8.model;
using ScottPlot;

namespace lab_work_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            YValueTextBox.Text = "2.2";
            ZValueTextBox.Text = "3.3";
            
            ConfigPlot();
        }

        private void ConfigPlot()
        {
            ResultPlot.Configuration.Quality = ScottPlot.Control.QualityMode.High;
            ResultPlot.Plot.XLabel("x value");
            ResultPlot.Plot.YLabel("function value");
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ClearResults();
        }

        private void CalculateOnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var xFrom = double.Parse(XFromValueTextBox.Text, CultureInfo.InvariantCulture);
                var xTo = double.Parse(XToValueTextBox.Text, CultureInfo.InvariantCulture);
                var step = double.Parse(StepValueTextBox.Text, CultureInfo.InvariantCulture);
                var y = double.Parse(YValueTextBox.Text, CultureInfo.InvariantCulture);
                var z = double.Parse(ZValueTextBox.Text, CultureInfo.InvariantCulture);

                var dataX = new List<double>();
                var dataFunc = new List<double>();
                var results = new List<ResultData>();

                for (var i = xFrom; i <= xTo; i = i + step)
                {
                    var funcResult = SolveFunction(i, y, z);
                    
                    dataX.Add(i);
                    dataFunc.Add(funcResult);
                    results.Add(new ResultData(i, funcResult));
                }
                
                ResultGrid.ItemsSource = results;
                ResultPlot.Plot.Clear();
                ResultPlot.Plot.AddScatter(dataX.ToArray(), dataFunc.ToArray());
                ResultPlot.Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Fill in all the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                ClearResults();
            }
        }

        private double SolveFunction(double x, double y, double z)
        {
            var firstPart = Math.Sqrt(10 * (Math.Pow(x, 1/3) + Math.Pow(x, y + 2)));
            var secondPart = Math.Asinh(z) * Math.Asinh(z) - Math.Abs(x - y);
            return firstPart * secondPart;
        }

        private void ClearResults()
        {
            ResultGrid.ItemsSource = null;
            ResultPlot.Plot.Clear();
            ResultPlot.Refresh();
        }
    }
}