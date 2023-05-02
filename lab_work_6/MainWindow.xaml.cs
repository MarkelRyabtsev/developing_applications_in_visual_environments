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

        private List<SortType> _sortTypes = new List<SortType>
        {
            new SortType(SortType.SortTypes.BY_FULL_NAME),
            new SortType(SortType.SortTypes.BY_NUMBER),
            new SortType(SortType.SortTypes.BY_WORK_HOURS)
        };

        public MainWindow()
        {
            InitializeComponent();
            ResultGrid.ItemsSource = _employees;
            SortComboBox.ItemsSource = _sortTypes;
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
            try
            {
                var fullName = FullNameTextBox.Text.ToString();
                var number = long.Parse(NumberTextBox.Text.ToString());
                var workHours = int.Parse(WorkHoursTextBox.Text.ToString());
                var tariff = int.Parse(TariffComboBox.GetSelectedValue());
                var employee = new Employee(fullName, number, workHours, tariff);
                
                _employees.Add(employee);
                UpdateAndRefreshList();
            }
            catch (Exception exception)
            {
                DialogExtension.ShowError(exception.ToString());
                return;
            }
            
        }
        
        private void Open_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var fileName = DialogExtension.OpenFile();
                
                if (fileName == null)
                {
                    return;
                }
                
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
                    UpdateAndRefreshList();
                    ResetSortType();
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
                
                if (fileName == null)
                {
                    return;
                }
                
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
            var fullName = FullNameTextBox.Text.ToString();
            var number = NumberTextBox.Text.ToString();
            var workHours = WorkHoursTextBox.Text.ToString();
            var tariff = TariffComboBox.GetSelectedValue();

            var isValid = !string.IsNullOrEmpty(fullName) && 
                          !string.IsNullOrEmpty(number) &&
                          !string.IsNullOrEmpty(workHours) && 
                          !string.IsNullOrEmpty(tariff);
            
            if (AddButton != null)
            {
                AddButton.IsEnabled = isValid;
            }
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            var item = ResultGrid.SelectedItem as Employee;
            if (item != null)
            {
                _employees.Remove(item);
                UpdateAndRefreshList();
            }
        }

        private void SortTypeChanged(object sender, SelectionChangedEventArgs e)
        {
            var sortType = (SortType)((ComboBox)e.Source)?.SelectedItem;
            if (sortType != null)
            {
                _employees.SortBy(sortType.SortTypeValue);
                UpdateAndRefreshList();
            }
        }

        private void UpdateAndRefreshList()
        {
            ResultGrid.ItemsSource = _employees;
            ResultGrid.Items.Refresh();
        }

        private void ResetSortType()
        {
            SortComboBox.SelectedItem = null;
        }
    }
}