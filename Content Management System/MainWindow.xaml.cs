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
using Content_Management_System.Helpers;
using System.Collections.ObjectModel;

namespace Content_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum UserRole { Visitor, Admin };
        public ObservableCollection<User> users { get; set; }
        readonly string usersXmlFilePath = "users.xml";
        private DataIO serializer = new DataIO();
        public MainWindow()
        {
            InitializeComponent();
            users = serializer.DeSerializeObject<ObservableCollection<User>>(usersXmlFilePath);
            if (users == null)
            {
                users = new ObservableCollection<User>();
            }
        }
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            HandleLogIn();
        }

        private void HandleLogIn()
        {
            bool validLogin = false;
            User user = null;
            foreach (User u in users)
            {
                if (u.Username == UsernameTextBox.Text && u.Password == PasswordTextBox.Password)
                {
                    validLogin = true;
                    user = u;
                    break;
                }
            }
            if (validLogin)
            {
                TableWindow tableWindow = new TableWindow(user, this);
                tableWindow.Show();
                this.Hide();
                UsernameTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
                UsernameTextBox.Text = String.Empty;
                UsernameErrorTextBlock.Text = "";
                PasswordTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
                PasswordTextBox.Password = String.Empty;
                PasswordErrorTextBlock.Text = "";
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
            serializer.SerializeObject(users, usersXmlFilePath);
            Application.Current.MainWindow.Close();
        }
    }
}
