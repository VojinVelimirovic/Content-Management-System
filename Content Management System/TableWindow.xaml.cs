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

namespace Content_Management_System
{
    /// <summary>
    /// Interaction logic for TableWindow.xaml
    /// </summary>
    public partial class TableWindow : Window
    {
        private MainWindow mainWindow;
        public ObservableCollection<Figure> figures { get; set; }
        public TableWindow(User user, MainWindow mainWindow)
        {
            InitializeComponent();
            DataContext = this;
            figures = new ObservableCollection<Figure>();
            figures.Add(new Figure("Stefan Nemanja", 1168, 1196, "Images/Stefan_Nemanja.jpg", "", DateTime.Now.Date));
            figures.Add(new Figure("Stefan Nemanjić", 1196, 1227, "Images/Stefan_Nemanjic.jpg", "", DateTime.Now.Date));
            figures.Add(new Figure("Stefan Radoslav", 1227, 1234, "Images/Stefan_Radoslav.jpg", "", DateTime.Now.Date));
            figures.Add(new Figure("Stefan Vladislav", 1234, 1243, "Images/Stefan_Vladislav.jpg", "", DateTime.Now.Date));
            figures.Add(new Figure("Stefan Uroš I", 1243, 1276, "Images/Stefan_Uros_I.jpg", "", DateTime.Now.Date));
            figures.Add(new Figure("Stefan Dragutin", 1276, 1282, "Images/Stefan_Dragutin.jpg", "", DateTime.Now.Date));
            figures.Add(new Figure("Stefan Milutin", 1282, 1321, "Images/Stefan_Milutin.jpg", "", DateTime.Now.Date));
            figures.Add(new Figure("Stefan Vladislav II", 1321, 1324, "Images/Stefan_Vladislav_II.jpg", "", DateTime.Now.Date));
            figures.Add(new Figure("Stefan Uroš III", 1322, 1331, "Images/Stefan_Decanski.jpg", "", DateTime.Now.Date));
            figures.Add(new Figure("Stefan Dušan", 1331, 1355, "Images/Stefan_Dusan.jpg", "", DateTime.Now.Date));
            figures.Add(new Figure("Stefan Uroš V", 1355, 1371, "Images/Stefan_Uros_V.jpg", "", DateTime.Now.Date));
            AdjustPage(user);
            this.mainWindow = mainWindow;
        }

        private void AdjustPage(User user) 
        {
            if (user.UsersRole == User.UserRole.Visitor)
            {
                AddButton.IsEnabled = false;
                RemoveButton.IsEnabled = false;
                HideCheckboxes();
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

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = figures.Count - 1; i >= 0; i--)
            {
                if (figures[i].IsChecked)
                {
                    figures.RemoveAt(i);
                }
            }
            FiguresDataGrid.Items.Refresh();
        }

        private void HideCheckboxes()
        {
            foreach (var item in FiguresDataGrid.Items)
            {
                if (item is Figure figure)
                {
                    var row = FiguresDataGrid.ItemContainerGenerator.ContainerFromItem(figure) as DataGridRow;
                    if (row != null)
                    {
                        var checkBox = FindVisualChild<CheckBox>(row);
                        if (checkBox != null)
                        {
                            checkBox.Visibility = Visibility.Collapsed;
                        }
                    }
                }
            }
        }

        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }
            return null;
        }
    }
}
