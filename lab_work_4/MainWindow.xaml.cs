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

namespace lab_work_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<List<int>> _matrix = new();
        
        public MainWindow()
        {
            InitializeComponent();
            WidthTextBox.Text = "4";
            HeightTextBox.Text = "4";
            CreateRandomMatrix();
        }

        private void CreateRandomMatrix()
        {
            try
            {
                var width = int.Parse(WidthTextBox.Text);
                var height = int.Parse(HeightTextBox.Text);
            
                _matrix.Clear();
                for (var i = 0; i < height; i++)
                {
                    _matrix.Add(new List<int>());
                    for (var j = 0; j < width; j++)
                    {
                        _matrix[i].Add(new Random().Next(1, 20));
                    }
                }
                CountUniqValues();
                Matrix.ItemsSource = _matrix;
                Matrix.Items.Refresh();
                HandleError(showError: false);
            }
            catch (Exception e)
            {
                HandleError(showError: true);
            }
        }

        private void CountUniqValues()
        {
            var elementCounts = new Dictionary<int, int>();
            for (var i = 0; i < _matrix.Count; i++)
            {
                for (var j = 0; j < _matrix[i].Count; j++)
                {
                    var element = _matrix[i][j];
                    if (elementCounts.ContainsKey(element))
                        elementCounts[element]++;
                    else
                        elementCounts[element] = 1;
                }
            }
            ShowCountsInfo(elementCounts);
        }

        private void ShowCountsInfo(Dictionary<int, int> elements)
        {
            var stringBuilder = new StringBuilder();
            foreach (var pair in elements)
            {
                stringBuilder.Append($"[{pair.Key}] - {pair.Value}\n");
            }

            ElementsCountsLabel.Content = stringBuilder.ToString().Trim();
            UniqItemsCount.Content = $"Uniq items count = {elements.Count}";
        }

        private void HandleError(bool showError)
        {
            if (showError)
            {
                ErrorLabel.Visibility = Visibility.Visible;
                Matrix.Visibility = Visibility.Collapsed;
                ElementsCountsGroupBox.Visibility = Visibility.Collapsed;
                UniqItemsCount.Visibility = Visibility.Collapsed;
            }
            else
            {
                ErrorLabel.Visibility = Visibility.Collapsed;
                Matrix.Visibility = Visibility.Visible;
                ElementsCountsGroupBox.Visibility = Visibility.Visible;
                UniqItemsCount.Visibility = Visibility.Visible;
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            CreateRandomMatrix();
        }
    }
}