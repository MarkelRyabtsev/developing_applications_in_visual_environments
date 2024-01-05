using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Color = System.Drawing.Color;

namespace lab_work_11;

public partial class ShapeWindow : Window
{
    private Color _color = Color.Black;
    private ShapeType _shapeType = ShapeType.CIRCLE;

    public ShapeWindow()
    {
        InitializeComponent();
        DrawShape();
    }

    private void ColorButton_OnClick(object sender, RoutedEventArgs e)
    {
        switch ((sender as Button).Name)
        {
            case "BlackButton":
                _color = Color.Black;
                break;
            case "PurpleButton":
                _color = Color.Purple;
                break;
            case "GreenButton":
                _color = Color.Green;
                break;
            case "BlueButton":
                _color = Color.Blue;
                break;
            case "RedButton":
                _color = Color.Red;
                break;
            case "YellowButton":
                _color = Color.Yellow;
                break;
            case "WhiteButton":
                _color = Color.GhostWhite;
                break;
        }
        
        DrawShape();
    }

    private void ShapeRadioButton_OnChecked(object sender, RoutedEventArgs e)
    {
        switch ((sender as RadioButton).Name)
        {
            case "CircleRadioButton":
                _shapeType = ShapeType.CIRCLE;
                break;
            case "RoundRectRadioButton":
                _shapeType = ShapeType.ROUND_RECT;
                break;
            case "EllipseRadioButton":
                _shapeType = ShapeType.ELLIPSE;
                break;
            case "SquareRadioButton":
                _shapeType = ShapeType.SQUARE;
                break;
            case "RoundSquareRadioButton":
                _shapeType = ShapeType.ROUND_SQUARE;
                break;
            case "RectangleRadioButton":
                _shapeType = ShapeType.RECTANGLE;
                break;
        }

        DrawShape();
    }

    private void DrawShape()
    {
        var solidColorBrush = new SolidColorBrush(
            System.Windows.Media.Color.FromArgb(_color.A, _color.R, _color.G, _color.B)
        );
        UIElement shape = null;
        switch (_shapeType)
        {
            case ShapeType.CIRCLE:
                shape = new Ellipse();
                (shape as Ellipse).Width = PreviewStackPanel.Width * 0.9;
                (shape as Ellipse).Height = PreviewStackPanel.Height * 0.9;
                (shape as Ellipse).Fill = solidColorBrush;
                break;
            case ShapeType.ROUND_RECT:
                shape = new Rectangle();
                (shape as Rectangle).Width = PreviewStackPanel.Width * 0.5;
                (shape as Rectangle).Height = PreviewStackPanel.Height * 0.9;
                (shape as Rectangle).RadiusX = 10;
                (shape as Rectangle).RadiusY = 10;
                (shape as Rectangle).Fill = solidColorBrush;
                break;
            case ShapeType.ELLIPSE:
                shape = new Ellipse();
                (shape as Ellipse).Width = PreviewStackPanel.Width * 0.5;
                (shape as Ellipse).Height = PreviewStackPanel.Height * 0.9;
                (shape as Ellipse).Fill = solidColorBrush;
                break;
            case ShapeType.SQUARE:
                shape = new Rectangle();
                (shape as Rectangle).Width = PreviewStackPanel.Width * 0.9;
                (shape as Rectangle).Height = PreviewStackPanel.Height * 0.9;
                (shape as Rectangle).Fill = solidColorBrush;
                break;
            case ShapeType.ROUND_SQUARE:
                shape = new Rectangle();
                (shape as Rectangle).Width = PreviewStackPanel.Width * 0.9;
                (shape as Rectangle).Height = PreviewStackPanel.Height * 0.9;
                (shape as Rectangle).RadiusX = 10;
                (shape as Rectangle).RadiusY = 10;
                (shape as Rectangle).Fill = solidColorBrush;
                break;
            case ShapeType.RECTANGLE:
                shape = new Rectangle();
                (shape as Rectangle).Width = PreviewStackPanel.Width * 0.5;
                (shape as Rectangle).Height = PreviewStackPanel.Height * 0.9;
                (shape as Rectangle).Fill = solidColorBrush;
                break;
        }
        PreviewStackPanel.Children.Clear();
        PreviewStackPanel.Children.Add(shape);
    }

    private enum ShapeType
    {
        CIRCLE,
        ROUND_RECT,
        ELLIPSE,
        SQUARE,
        ROUND_SQUARE,
        RECTANGLE
    }
}