using System.Windows;

namespace lab_work_6.utils;

public static class DialogExtension
{
    public static string? SaveFile()
    {
        var fileName = string.Empty;
        var dialog = new Microsoft.Win32.SaveFileDialog();
        dialog.FileName = "Employees";
        dialog.DefaultExt = ".json";
        dialog.Filter = "JSON file (.json)|*.json";

        if (dialog.ShowDialog() == true)
        {
            fileName = dialog.FileName;
        }
        else
        {
            return null;
        }

        return fileName;
    }
    
    public static string? OpenFile()
    {
        var fileName = string.Empty;
        var dialog = new Microsoft.Win32.OpenFileDialog();
        dialog.DefaultExt = ".json";
        dialog.Filter = "JSON file (.json)|*.json";
        
        if (dialog.ShowDialog() == true)
        {
            fileName = dialog.FileName;
        }
        else
        {
            return null;
        }

        return fileName;
    }

    public static void ShowError(string message)
    {
        var caption = "Error";
        var button = MessageBoxButton.OK;
        var icon = MessageBoxImage.Error;
        MessageBoxResult result;

        result = MessageBox.Show(message, caption, button, icon, MessageBoxResult.Yes);
    }
}