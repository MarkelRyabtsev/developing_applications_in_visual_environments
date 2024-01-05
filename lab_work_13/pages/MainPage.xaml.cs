using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using lab_work_13.model;

namespace lab_work_13.pages;

public partial class MainPage : Page
{
    public event EventHandler<bool> NavigationButtonsStateChanged;
    
    public List<double> DataX = new List<double>();
    public List<double> DataFunc = new List<double>();
    public List<ResultData> Results = new List<ResultData>();
    
    public MainPage()
    {
        InitializeComponent();
        YValueTextBox.Text = "2.2";
        ZValueTextBox.Text = "3.3";
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

            for (var i = xFrom; i <= xTo; i = i + step)
            {
                var funcResult = SolveFunction(i, y, z);
                    
                DataX.Add(i);
                DataFunc.Add(funcResult);
                Results.Add(new ResultData(i, funcResult));
            }
            NavigationButtonsStateChanged.Invoke(null, true);
        }
        catch (Exception exception)
        {
            MessageBox.Show("Fill in all the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            NavigationButtonsStateChanged.Invoke(null, false);
        }
    }
    
    private double SolveFunction(double x, double y, double z)
    {
        var firstPart = Math.Sqrt(10 * (Math.Pow(x, 1/3) + Math.Pow(x, y + 2)));
        var secondPart = Math.Asinh(z) * Math.Asinh(z) - Math.Abs(x - y);
        return firstPart * secondPart;
    }
    
    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (NavigationButtonsStateChanged != null)
            NavigationButtonsStateChanged.Invoke(null, false);
        DataX.Clear();
        DataFunc.Clear();
        Results.Clear();
    }
}