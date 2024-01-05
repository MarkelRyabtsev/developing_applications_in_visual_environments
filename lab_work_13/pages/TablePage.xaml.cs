using System.Collections.Generic;
using System.Windows.Controls;
using lab_work_13.model;

namespace lab_work_13.pages;

public partial class TablePage : Page
{
    public TablePage(List<ResultData> results)
    {
        InitializeComponent();
        ResultGrid.ItemsSource = results;
    }
}