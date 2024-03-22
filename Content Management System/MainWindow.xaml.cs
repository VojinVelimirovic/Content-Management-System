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
using Content_Management_System.Helpers;
using Content_Management_System.Classes;

namespace Content_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NotificationManager notificationManager;
        enum UserRole { Visitor, Admin };
        readonly string AdminUsername = "admin";
        readonly string AdminPassword = "admin";
        readonly string VisitorUsermane = "visitor";
        readonly string VisitorPassword = "visitor";
        UserRole userRole { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            notificationManager = new NotificationManager();
        }
        public void ShowToastNotification(ToastNotification toastNotification)
        {
            notificationManager.Show(toastNotification.Title, toastNotification.Message, toastNotification.Type, "WindowNotificationArea");
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
                UsernameTextBox.Text = String.Empty;
                PasswordTextBox.Password = String.Empty;
            }
            else if (UsernameTextBox.Text.Equals(VisitorUsermane) && PasswordTextBox.Password.Equals(VisitorPassword))
            {
                User user = new User(User.UserRole.Visitor, UsernameTextBox.Text, PasswordTextBox.Password);
                TableWindow tableWindow = new TableWindow(user, this);
                tableWindow.Show();
                this.Hide();
                UsernameTextBox.Text = String.Empty;
                PasswordTextBox.Password = String.Empty;
            }
            else
            {
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.ShowToastNotification(new ToastNotification("Login Error", "Invalid username/password.", NotificationType.Error));
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
