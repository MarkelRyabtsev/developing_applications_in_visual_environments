using System;
using System.Collections.Generic;
using System.IO;
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
using lab_work_6.model;
using lab_work_6.utils;
using Newtonsoft.Json;

namespace lab_work_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Employee> _employees = new ();
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateFields();
        }
        
        private void OnTextChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidateFields();
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        
        private void Open_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var fileName = DialogExtension.OpenFile();
                if (string.IsNullOrEmpty(fileName))
                {
                    DialogExtension.ShowError("ERRRRRRROR");
                    return;
                }
                
                using (var r = new StreamReader(fileName))
                {
                    var json = r.ReadToEnd();
                    _employees = JsonExtension.ToObject<EmployeeDto[]>(json)
                        .ToList()
                        .ToEmployeeList();
                    ResultGrid.ItemsSource = _employees;
                }
            }
            catch (Exception exception)
            {
                DialogExtension.ShowError(exception.Message);
            }
        }
        
        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var fileName = DialogExtension.SaveFile();
                if (string.IsNullOrEmpty(fileName))
                {
                    DialogExtension.ShowError("ERRRRRRROR");
                    return;
                }
                
                using (var r = new StreamWriter(fileName))
                {
                    var json = _employees.ToEmployeeDtoList().ToJson();
                    r.Write(json);
                }
            }
            catch (Exception exception)
            {
                DialogExtension.ShowError(exception.Message);
            }
        }

        private void ValidateFields()
        {
            var fullName = FullNameTextBox.Text;
            var number = NumberTextBox.Text;
            var workHours = WorkHoursTextBox.Text;
            var tariff = TariffComboBox.SelectedValue.ToString();

            var isValid = !string.IsNullOrEmpty(fullName) && 
                          !string.IsNullOrEmpty(number) &&
                          !string.IsNullOrEmpty(workHours) && 
                          !string.IsNullOrEmpty(tariff);
            AddButton.IsEnabled = isValid;
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            var item = ResultGrid.SelectedItem as Employee;
            if (item != null)
            {
                _employees.Remove(item);
                ResultGrid.Items.Refresh();
            }
        }
    }
}