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

namespace Content_Management_System
{
    /// <summary>
    /// Interaction logic for TableWindow.xaml
    /// </summary>
    public partial class TableWindow : Window
    {
        private MainWindow mainWindow;
        public TableWindow(User user, MainWindow mainWindow)
        {
            InitializeComponent();
            AdjustPage(user);
            this.mainWindow = mainWindow;
        }

        private void AdjustPage(User user) 
        {
            if (user.UsersRole == User.UserRole.Visitor)
            {
                TestTextBlock.Text = "Visitor";
            }
            else if(user.UsersRole == User.UserRole.Admin)
            {
                TestTextBlock.Text = "Admin";
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }
    }
}
