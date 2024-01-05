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
using Microsoft.Win32;

namespace lab_work_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        public ImageWindow()
        {
            InitializeComponent();
            
            var shapeWindow = new ShapeWindow();
            shapeWindow.Show();
            
            var canvasWindow = new CanvasWindow();
            canvasWindow.Show();
        }
        
        private void SelectImageButton_OnClick(object sender, RoutedEventArgs e)
        {
            var op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                PreviewImage.Source = new BitmapImage(new Uri(op.FileName));
                HandlePlaceholder(isShow: false);
            }
        }
        
        private void ClearImageButton_OnClick(object sender, RoutedEventArgs e)
        {
            HandlePlaceholder(isShow: true);
        }
        
        private void HandlePlaceholder(bool isShow)
        {
            SelectImageButton.Visibility = isShow ? Visibility.Visible : Visibility.Collapsed;
            
            if (isShow)
            {
                PreviewImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/placeholder.png"));
            }
            PreviewImage.Stretch = isShow ? Stretch.None : Stretch.Uniform;
            PreviewImage.UpdateLayout();
        }
    }
}