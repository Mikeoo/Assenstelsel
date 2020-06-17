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
        public MainWindow()
        {
            InitializeComponent();
        }



        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Point pointToWindow = Mouse.GetPosition(this);
            Point pointToScreen = PointToScreen(pointToWindow);
            LiveCords.Text = $"Live information\nWiskundigecoördinaten: ({pointToWindow})\nMiddelpunt:\nBeelschermcoördinaten: ({pointToScreen})";
        }

        private void LeftClick(object sender, MouseButtonEventArgs e)
        {
            Point pointToWindow = Mouse.GetPosition(this);
            Point pointToScreen = PointToScreen(pointToWindow);
            LockedCords.Text = $"Locked information\nWiskundigecoördinaten: ({pointToWindow})\nMiddelpunt:\nBeelschermcoördinaten: ({pointToScreen})";

            // https://docs.microsoft.com/en-us/dotnet/framework/wpf/graphics-multimedia/how-to-create-a-line-using-a-linegeometry
            LineGeometry VerticalLine = new LineGeometry();
            VerticalLine.StartPoint = new Point(pointToWindow.X,0);
            VerticalLine.EndPoint = new Point(pointToWindow.X, MainCanvas.ActualHeight);
           
            Path VerticalPath = new Path();
            VerticalPath.Stroke = Brushes.Red;
            VerticalPath.StrokeThickness = 1;
            VerticalPath.Data = VerticalLine;

            LineGeometry HorizontalLine = new LineGeometry();
            HorizontalLine.StartPoint = new Point(0, pointToWindow.Y);
            HorizontalLine.EndPoint = new Point(MainCanvas.ActualWidth, pointToWindow.Y);

            Path HorizontalPath = new Path();
            HorizontalPath.Stroke = Brushes.Red;
            HorizontalPath.StrokeThickness = 1;
            HorizontalPath.Data = HorizontalLine;


            // clear lines if exists
            MainCanvas.Children.Clear();
            // add lines to canvas
            MainCanvas.Children.Add(VerticalPath);
            MainCanvas.Children.Add(HorizontalPath);
        }
    }
}
