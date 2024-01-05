using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Color = System.Drawing.Color;

namespace lab_work_11;

public partial class CanvasWindow : Window
{
    private Color _color = Color.Black;
    private ShapeType _shapeType = ShapeType.LINE;

    private Point _initialPoint;

    private Line _line;
    private Rectangle _rectangle;
    private Ellipse _ellipse;

    public CanvasWindow()
    {
        InitializeComponent();
    }

    private void ShapeRadioButton_OnChecked(object sender, RoutedEventArgs e)
    {
        switch ((sender as RadioButton).Name)
        {
            case "LineRadioButton":
                _shapeType = ShapeType.LINE;
                break;
            case "RectangleRadioButton":
                _shapeType = ShapeType.RECTANGLE;
                break;
            case "EllipseRadioButton":
                _shapeType = ShapeType.ELLIPSE;
                break;
        }
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
    }

    private void PreviewCanvas_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        _line = null;
        _rectangle = null;
        _ellipse = null;
    }

    private void PreviewCanvas_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var strokeColorBrush = new SolidColorBrush(
            System.Windows.Media.Color.FromArgb(_color.A, _color.R, _color.G, _color.B)
        );
        _initialPoint = e.MouseDevice.GetPosition(PreviewCanvas);

        switch (_shapeType)
        {
            case ShapeType.LINE:
                _line = new Line
                {
                    Stroke = strokeColorBrush,
                    StrokeThickness = 2,
                    StrokeStartLineCap = PenLineCap.Round,
                    StrokeEndLineCap = PenLineCap.Round,
                    StrokeDashCap = PenLineCap.Round,
                    X1 = _initialPoint.X,
                    Y1 = _initialPoint.Y
                };
                PreviewCanvas.Children.Add(_line);
                break;
            case ShapeType.RECTANGLE:
                _initialPoint = e.GetPosition(PreviewCanvas);
                _rectangle = new Rectangle
                {
                    Stroke = strokeColorBrush,
                    StrokeThickness = 2
                };
                Canvas.SetLeft(_rectangle, _initialPoint.X);
                Canvas.SetTop(_rectangle, _initialPoint.Y);
                PreviewCanvas.Children.Add(_rectangle);
                break;
            case ShapeType.ELLIPSE:
                _ellipse = new Ellipse
                {
                    Stroke = strokeColorBrush,
                    StrokeThickness = 2
                };
                Canvas.SetLeft(_ellipse, _initialPoint.X);
                Canvas.SetTop(_ellipse, _initialPoint.Y);
                PreviewCanvas.Children.Add(_ellipse);
                break;
        }
    }

    private void PreviewCanvas_OnMouseMove(object sender, MouseEventArgs e)
    {
        if (
            e.LeftButton == MouseButtonState.Released ||
            (_shapeType == ShapeType.LINE && _line == null) ||
            (_shapeType == ShapeType.RECTANGLE && _rectangle == null) ||
            (_shapeType == ShapeType.ELLIPSE && _ellipse == null)
        )
            return;

        var currentPosition = e.GetPosition(PreviewCanvas);

        var x = Math.Min(currentPosition.X, _initialPoint.X);
        var y = Math.Min(currentPosition.Y, _initialPoint.Y);

        var w = Math.Max(currentPosition.X, _initialPoint.X) - x;
        var h = Math.Max(currentPosition.Y, _initialPoint.Y) - y;

        switch (_shapeType)
        {
            case ShapeType.LINE:
                _line.X2 = e.GetPosition(PreviewCanvas).X;
                _line.Y2 = e.GetPosition(PreviewCanvas).Y;
                break;
            case ShapeType.RECTANGLE:
                _rectangle.Width = w;
                _rectangle.Height = h;

                Canvas.SetLeft(_rectangle, x);
                Canvas.SetTop(_rectangle, y);
                break;
            case ShapeType.ELLIPSE:
                _ellipse.Width = w;
                _ellipse.Height = h;

                Canvas.SetLeft(_ellipse, x);
                Canvas.SetTop(_ellipse, y);
                break;
        }
    }

    private enum ShapeType
    {
        LINE,
        RECTANGLE,
        ELLIPSE
    }
}