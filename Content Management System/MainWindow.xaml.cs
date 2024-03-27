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
using Notification.Wpf;
using Content_Management_System.Classes;

namespace Content_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum UserRole { Visitor, Admin };
        readonly string AdminUsername = "admin";
        readonly string AdminPassword = "admin";
        readonly string VisitorUsermane = "visitor";
        readonly string VisitorPassword = "visitor";
        UserRole userRole { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            HandleLogIn();
        }

        private void HandleLogIn()
        {
            if (UsernameTextBox.Text.Equals(AdminUsername) && PasswordTextBox.Password.Equals(AdminPassword))
            {
                User user = new User(User.UserRole.Admin, UsernameTextBox.Text, PasswordTextBox.Password);
                TableWindow tableWindow = new TableWindow(user, this);
                tableWindow.Show();
                this.Hide();
                UsernameTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
                UsernameTextBox.Text = String.Empty;
                UsernameErrorTextBlock.Text = "";
                PasswordTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
                PasswordTextBox.Password = String.Empty;
                PasswordErrorTextBlock.Text = "";
            }
            else if (UsernameTextBox.Text.Equals(VisitorUsermane) && PasswordTextBox.Password.Equals(VisitorPassword))
            {
                User user = new User(User.UserRole.Visitor, UsernameTextBox.Text, PasswordTextBox.Password);
                TableWindow tableWindow = new TableWindow(user, this);
                tableWindow.Show();
                this.Hide();
                UsernameTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
                UsernameTextBox.Text = String.Empty;
                UsernameErrorTextBlock.Text = "";
                PasswordTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
                PasswordTextBox.Password = String.Empty;
                PasswordErrorTextBlock.Text = "";
            }
            else
            {
                UsernameTextBox.BorderBrush = Brushes.DarkRed;
                PasswordTextBox.BorderBrush = Brushes.DarkRed;
                if (UsernameTextBox.Text.Equals(string.Empty))
                {
                    UsernameErrorTextBlock.Text = "Field cannot be left empty!";
                }
                else
                {
                    UsernameErrorTextBlock.Text = "Invalid username/password!";
                }
                if (PasswordTextBox.Password.Equals(string.Empty))
                {
                    PasswordErrorTextBlock.Text = "Field cannot be left empty!";
                }
                else
                {
                    PasswordErrorTextBlock.Text = "Invalid username/password!";
                }
                return;
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
