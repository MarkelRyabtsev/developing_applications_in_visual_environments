using System.Collections.Generic;
using System.Windows.Controls;

namespace lab_work_13.pages;

public partial class ChartPage : Page
{
    public ChartPage(List<double> dataX, List<double> dataFunc)
    {
        InitializeComponent();
        
        ResultPlot.Configuration.Quality = ScottPlot.Control.QualityMode.High;
        ResultPlot.Plot.XLabel("x value");
        ResultPlot.Plot.YLabel("function value");
        
        ResultPlot.Plot.Clear();
        ResultPlot.Plot.AddScatter(dataX.ToArray(), dataFunc.ToArray());
        ResultPlot.Refresh();
    }
}