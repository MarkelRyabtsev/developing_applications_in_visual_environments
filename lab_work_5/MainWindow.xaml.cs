using System;
using System.Collections.Generic;
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

namespace lab_work_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly string IntegersPattern = @"[+-]?\d+";

        public MainWindow()
        {
            InitializeComponent();
            TextBox.Text = "hdfh6s++43++dd44-79654+-437d4d 9d dfsdf6654 +464d";
        }

        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ShowIntegers();
        }

        private void ShowIntegers()
        {
            var integers = FindIntegers(TextBox.Text);
            var text = string.Join("", integers.Select(s => s + '\n'));
            TextBlock.Text = text;
        }

        private List<string> FindIntegers(string text)
        {
            var pureIntegers = new List<string>();
            var regex = new Regex(IntegersPattern);
            var matches = regex.Matches(text);
            pureIntegers.AddRange(matches.Select(s => s.Value));

            return pureIntegers;
        }
    }
}