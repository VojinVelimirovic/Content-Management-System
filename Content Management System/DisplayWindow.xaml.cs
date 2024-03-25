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
using System.Windows.Shapes;
using Content_Management_System.Classes;
using Figure = Content_Management_System.Classes.Figure;

namespace Content_Management_System
{
    /// <summary>
    /// Interaction logic for DisplayWindow.xaml
    /// </summary>
    public partial class DisplayWindow : Window
    {
        public DisplayWindow(Figure figure)
        {
            InitializeComponent();
            BasicInfoTextBlock.Text = figure.Name + " (" + figure.ReignStart + "-" + figure.ReignEnd + ")";
            DisplayImage.Source = new BitmapImage(new Uri(figure.Image, UriKind.RelativeOrAbsolute));
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
