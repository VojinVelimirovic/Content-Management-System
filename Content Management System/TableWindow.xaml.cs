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
using System.Collections.ObjectModel;
using Notification.Wpf;
using Content_Management_System.Helpers;

namespace Content_Management_System
{
    /// <summary>
    /// Interaction logic for TableWindow.xaml
    /// </summary>
    public partial class TableWindow : Window
    {
        private MainWindow mainWindow;
        private NotificationManager notificationManager;
        public ObservableCollection<Figure> figures { get; set; }
        public TableWindow(User user, MainWindow mainWindow)
        {
            InitializeComponent();
            DataContext = this;
            notificationManager = new NotificationManager();
            figures = new ObservableCollection<Figure>();
            figures.Add(new Figure("Stefan Nemanja", 1168, 1196, "Images/Stefan_Nemanja.jpg", ""));
            figures.Add(new Figure("Stefan Nemanjić", 1196, 1227, "Images/Stefan_Nemanjic.jpg", ""));
            figures.Add(new Figure("Stefan Radoslav", 1227, 1234, "Images/Stefan_Radoslav.jpg", ""));
            figures.Add(new Figure("Stefan Vladislav", 1234, 1243, "Images/Stefan_Vladislav.jpg", ""));
            figures.Add(new Figure("Stefan Uroš I", 1243, 1276, "Images/Stefan_Uros_I.jpg", ""));
            figures.Add(new Figure("Stefan Dragutin", 1276, 1282, "Images/Stefan_Dragutin.jpg", ""));
            figures.Add(new Figure("Stefan Milutin", 1282, 1321, "Images/Stefan_Milutin.jpg", ""));
            figures.Add(new Figure("Stefan Vladislav II", 1321, 1324, "Images/Stefan_Vladislav_II.jpg", ""));
            figures.Add(new Figure("Stefan Uroš III", 1322, 1331, "Images/Stefan_Decanski.jpg", ""));
            figures.Add(new Figure("Stefan Dušan", 1331, 1355, "Images/Stefan_Dusan.jpg", ""));
            figures.Add(new Figure("Stefan Uroš V", 1355, 1371, "Images/Stefan_Uros_V.jpg", ""));
            AdjustPage(user);
            this.mainWindow = mainWindow;
        }

        private void AdjustPage(User user) 
        {
            if (user.UsersRole == User.UserRole.Visitor)
            {
                AddButton.IsEnabled = false;
                RemoveButton.IsEnabled = false;
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public void ShowToastNotification(ToastNotification toastNotification)
        {
            notificationManager.Show(toastNotification.Title, toastNotification.Message, toastNotification.Type, "TableWindowNotificationArea");
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            bool anyChecked = false;
            foreach(Figure figure in figures)
            {
                if (figure.IsChecked)
                {
                    anyChecked = true;
                }
            }
            if (anyChecked)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to remove the selected item(s)?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    for (int i = figures.Count - 1; i >= 0; i--)
                    {
                        if (figures[i].IsChecked)
                        {
                            figures.RemoveAt(i);
                        }
                    }
                    FiguresDataGrid.Items.Refresh();
                    this.ShowToastNotification(new ToastNotification("Successful removal", "Successfully removed item(s)", NotificationType.Success));
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
}
