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
using lab_work_13.pages;

namespace lab_work_13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainPage _mainPage = new MainPage();
        
        public MainWindow()
        {
            InitializeComponent();
            _mainPage.NavigationButtonsStateChanged += (sender, IsEnabled) => SetButtonsEnabled(IsEnabled);
            MainFrame.NavigationService.Navigate(_mainPage);
        }

        private void SetButtonsEnabled(bool IsEnabled)
        {
            TablePageButton.IsEnabled = IsEnabled;
            ChartPageButton.IsEnabled = IsEnabled;
        }

        private void MainPageButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(_mainPage);
        }

        private void TablePageButton_OnClick(object sender, RoutedEventArgs e)
        {
            var tablePage = new TablePage(_mainPage.Results);
            MainFrame.NavigationService.Navigate(tablePage);
        }

        private void ChartPageButton_OnClick(object sender, RoutedEventArgs e)
        {
            var chartPage = new ChartPage(_mainPage.DataX, _mainPage.DataFunc);
            MainFrame.NavigationService.Navigate(chartPage);
        }
    }
}