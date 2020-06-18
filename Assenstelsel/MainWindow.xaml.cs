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

namespace Assenstelsel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point clickPoint;
        public MainWindow()
        {
            InitializeComponent();
            clickPoint = new Point(0, 0);
        }



        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Point pointToWindow = Mouse.GetPosition(MainCanvas);
            Point pointToScreen = PointToScreen(pointToWindow);
            

            double newX = pointToWindow.X - clickPoint.X ;
            double newY = clickPoint.Y - pointToWindow.Y;

            
            LiveCords.Text = $"Live information\nWiskundigecoördinaten: ({pointToWindow})\nMiddelpunt: ({newX},{newY})\nBeelschermcoördinaten: ({pointToScreen})";
            
        }

        private void LeftClick(object sender, MouseButtonEventArgs e)
        {
            // tracking cords
            Point pointToWindow = Mouse.GetPosition(MainCanvas);

            // https://docs.microsoft.com/en-us/dotnet/framework/wpf/graphics-multimedia/how-to-create-a-line-using-a-linegeometry

            // Vertical line
            LineGeometry VerticalLine = new LineGeometry
            {
                StartPoint = new Point(pointToWindow.X, 0),
                EndPoint = new Point(pointToWindow.X, MainCanvas.ActualHeight)
            };

            Path VerticalPath = new Path
            {
                Stroke = Brushes.Red,
                StrokeThickness = 3,
                Data = VerticalLine
            };

            // Horizontal line
            LineGeometry HorizontalLine = new LineGeometry
            {
                StartPoint = new Point(0, pointToWindow.Y),
                EndPoint = new Point(MainCanvas.ActualWidth, pointToWindow.Y)
            };

            Path HorizontalPath = new Path
            {
                Stroke = Brushes.Red,
                StrokeThickness = 3,
                Data = HorizontalLine
            };

            // clear lines if exists
            MainCanvas.Children.Clear();
            // add lines to canvas
            MainCanvas.Children.Add(VerticalPath);
            MainCanvas.Children.Add(HorizontalPath);
            clickPoint = pointToWindow;
        }
    }
}
