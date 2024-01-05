using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using lab_work_10.ini_file;

namespace lab_work_10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly string IntegersPattern = @"[+-]?\d+";

        private IniManager _iniManager = new IniManager("C:\\Settings.ini");

        public MainWindow()
        {
            InitializeComponent();
            TextBox.Text = GetSavedValue();
            //TextBox.Text = "hdfh6s++43++dd44-79654+-437d4d 9d dfsdf6654 +464d";
        }
        
        protected override void OnClosing(CancelEventArgs e)
        {
            SaveValue();
            base.OnClosing(e);
        }

        private void SaveValue()
        {
            _iniManager.SetParam(IniSection.MAIN, IniKey.LAST_VALUE, TextBox.Text);
        }

        private string GetSavedValue()
        {
            return _iniManager.GetParam(IniSection.MAIN, IniKey.LAST_VALUE);
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