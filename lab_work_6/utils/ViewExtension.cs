using System;
using System.Windows.Controls;

namespace lab_work_6.utils;

public static class ViewExtension
{
    public static string GetSelectedValue(this ComboBox comboBox)
    {
        try
        {
            var selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            return ((TextBlock)selectedItem.Content).Text.ToString();
        }
        catch (Exception e)
        {
            return string.Empty;
        }
    }
}