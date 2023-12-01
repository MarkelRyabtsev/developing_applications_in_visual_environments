using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace lab_work_9;

public partial class ColorMixer : Window
{
    public ColorMixer()
    {
        InitializeComponent();
        UpdateColor();
    }

    private void UpdateColor()
    {
        try
        {
            var rColorValue = RColorControlCheckBox.IsChecked == true ? int.Parse(RValueTextBox.Text) : 0;
            var gColorValue = GColorControlCheckBox.IsChecked == true ? int.Parse(GValueTextBox.Text) : 0;
            var bColorValue = BColorControlCheckBox.IsChecked == true ? int.Parse(BValueTextBox.Text) : 0;

            var newColor = Color.FromRgb(
                r: (byte)rColorValue,
                g: (byte)gColorValue,
                b: (byte)bColorValue
            );
            ColorPreviewStackPanel.Background = new SolidColorBrush(newColor);
        }
        catch (Exception e)
        {
            ColorPreviewStackPanel.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }
    }

    private void RValueSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        ((Slider)sender).SelectionEnd = e.NewValue;
        RValueTextBox.Text = ((int)e.NewValue).ToString();
        UpdateColor();
    }

    private void GValueSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        ((Slider)sender).SelectionEnd = e.NewValue;
        GValueTextBox.Text = ((int)e.NewValue).ToString();
        UpdateColor();
    }

    private void BValueSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        ((Slider)sender).SelectionEnd = e.NewValue;
        BValueTextBox.Text = ((int)e.NewValue).ToString();
        UpdateColor();
    }

    private void RColorControlCheckBox_OnChecked(object sender, RoutedEventArgs e)
    {
        UpdateColor();
    }

    private void RColorControlCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
    {
        UpdateColor();
    }

    private void GColorControlCheckBox_OnChecked(object sender, RoutedEventArgs e)
    {
        UpdateColor();
    }

    private void GColorControlCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
    {
        UpdateColor();
    }

    private void BColorControlCheckBox_OnChecked(object sender, RoutedEventArgs e)
    {
        UpdateColor();
    }

    private void BColorControlCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
    {
        UpdateColor();
    }

    private void RValueTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            RValueSlider.Value = double.Parse(((TextBox)sender).Text);
            UpdateColor();
        }
        catch (Exception exception)
        {
        }
    }

    private void GValueTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            GValueSlider.Value = double.Parse(((TextBox)sender).Text);
            UpdateColor();
        }
        catch (Exception exception)
        {
        }
    }

    private void BValueTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            BValueSlider.Value = double.Parse(((TextBox)sender).Text);
            UpdateColor();
        }
        catch (Exception exception)
        {
        }
    }
}