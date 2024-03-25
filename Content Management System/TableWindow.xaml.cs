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
using System.IO;

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
        private User user;
        public TableWindow(User user, MainWindow mainWindow)
        {
            InitializeComponent();
            DataContext = this;
            notificationManager = new NotificationManager();
            figures = new ObservableCollection<Figure>();
            figures.Add(new Figure("Stefan Nemanja", 1168, 1196, "Images/Stefan_Nemanja.jpg", DateTime.Now));
            figures.Add(new Figure("Stefan Nemanjić", 1196, 1227, "Images/Stefan_Nemanjic.jpg", DateTime.Now));
            figures.Add(new Figure("Stefan Radoslav", 1227, 1234, "Images/Stefan_Radoslav.jpg", DateTime.Now));
            figures.Add(new Figure("Stefan Vladislav", 1234, 1243, "Images/Stefan_Vladislav.jpg", DateTime.Now));
            figures.Add(new Figure("Stefan Uroš I", 1243, 1276, "Images/Stefan_Uros_I.jpg", DateTime.Now));
            figures.Add(new Figure("Stefan Dragutin", 1276, 1282, "Images/Stefan_Dragutin.jpg", DateTime.Now));
            figures.Add(new Figure("Stefan Milutin", 1282, 1321, "Images/Stefan_Milutin.jpg", DateTime.Now));
            figures.Add(new Figure("Stefan Vladislav II", 1321, 1324, "Images/Stefan_Vladislav_II.jpg", DateTime.Now));
            figures.Add(new Figure("Stefan Uroš III", 1322, 1331, "Images/Stefan_Decanski.jpg", DateTime.Now));
            figures.Add(new Figure("Stefan Dušan", 1331, 1355, "Images/Stefan_Dusan.jpg", DateTime.Now));
            figures.Add(new Figure("Stefan Uroš V", 1355, 1371, "Images/Stefan_Uros_V.jpg", DateTime.Now));
            this.user = user;
            AdjustPage(user);
            this.mainWindow = mainWindow;
        }

        private void AdjustPage(User user)
        {
            if (user.UsersRole == User.UserRole.Visitor)
            {
                AddButton.IsEnabled = false;
                AddButton.Visibility = Visibility.Hidden;
                RemoveButton.IsEnabled = false;
                RemoveButton.Visibility = Visibility.Hidden;
                CheckBoxColumn.Visibility = Visibility.Hidden;
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
            foreach (Figure figure in figures)
            {
                if (figure.IsChecked)
                {
                    anyChecked = true;
                    if (File.Exists(figure.Description))
                    {
                        File.Delete(figure.Description);
                    }
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
                    this.ShowToastNotification(new ToastNotification("Success", "Successfully removed item(s)", NotificationType.Success));
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddFigureWindow addWindow = new AddFigureWindow();
            addWindow.Show();
            this.Hide();
            addWindow.Closing += (senderClosing, args) =>
            {
                if (args.Cancel)
                {
                    return;
                }
                else
                {
                    this.Show();
                    string name = addWindow.NameTextBox.Text;
                    int reignStart, reignEnd;
                    if (int.TryParse(addWindow.ReignStartTextBox.Text, out reignStart) &&
                        int.TryParse(addWindow.ReignEndTextBox.Text, out reignEnd))
                    {
                        string portrait = addWindow.ImagePreview.Source.ToString();
                        Figure figure = new Figure(name, reignStart, reignEnd, portrait, DateTime.Now);
                        SaveRtfContent(figure, addWindow);
                        figures.Add(figure);
                        FiguresDataGrid.Items.Refresh();
                        this.ShowToastNotification(new ToastNotification("Success", "Successfully added item(s)", NotificationType.Success));
                    }
                }
            };
        }
        private void SaveRtfContent(Figure figure, AddFigureWindow addWindow)
        {
            if (string.IsNullOrEmpty(figure.Description))
            {
                File.WriteAllText(figure.Description, "-");
            }
            else
            {
                using (FileStream fs = new FileStream(figure.Description, FileMode.Create))
                {
                    TextRange description = new TextRange(addWindow.EditorRichTextBox.Document.ContentStart, addWindow.EditorRichTextBox.Document.ContentEnd);
                    description.Save(fs, DataFormats.Rtf);
                }
            }
        }
        private void LoadRtfContent(string filePath, System.Windows.Controls.RichTextBox richTextBox)
        {
            string rtfContent = string.Empty;

            if (File.Exists(filePath))
            {
                rtfContent = File.ReadAllText(filePath);
                if (string.IsNullOrEmpty(rtfContent.Trim()))
                {
                    rtfContent = "-";
                }
            }
            else
            {
                rtfContent = "-";
            }
            TextRange range = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(rtfContent)))
            {
                range.Load(stream, DataFormats.Rtf);
            }
        }

        private void NameTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var textBlock = sender as TextBlock;
            if (textBlock != null)
            {
                var figure = textBlock.DataContext as Figure;
                if (figure != null)
                {
                    if (this.user.UsersRole == User.UserRole.Admin)
                    {
                        AddFigureWindow editWindow = new AddFigureWindow();
                        editWindow.NameTextBox.Text = figure.Name;
                        editWindow.ReignStartTextBox.Text = figure.ReignStart.ToString();
                        editWindow.ReignEndTextBox.Text = figure.ReignEnd.ToString();
                        editWindow.ImagePreview.Source = new BitmapImage(new Uri(figure.Image, UriKind.RelativeOrAbsolute));
                        LoadRtfContent(figure.Description, editWindow.EditorRichTextBox);
                        editWindow.AddFigureButtonContent.Text = "Edit Figure";
                        editWindow.Show();
                        this.Hide();
                        editWindow.Closing += (senderClosing, args) =>
                        {
                            if (args.Cancel)
                            {
                                return;
                            }
                            else
                            {
                                this.Show();
                                string name = editWindow.NameTextBox.Text;
                                int reignStart, reignEnd;
                                if (int.TryParse(editWindow.ReignStartTextBox.Text, out reignStart) &&
                                    int.TryParse(editWindow.ReignEndTextBox.Text, out reignEnd))
                                {
                                    string portrait = editWindow.ImagePreview.Source.ToString();
                                    figure.Name = name;
                                    figure.ReignStart = reignStart;
                                    figure.ReignEnd = reignEnd;
                                    figure.Image = portrait;
                                    SaveRtfContent(figure, editWindow);
                                    int index = figures.IndexOf(figure);
                                    figures[index] = figure;
                                    FiguresDataGrid.Items.Refresh();
                                    this.ShowToastNotification(new ToastNotification("Success", "Successfully edited item", NotificationType.Success));
                                }
                            }
                        };
                    }
                    else
                    {
                        DisplayWindow displayWindow = new DisplayWindow(figure);
                        LoadRtfContent(figure.Description, displayWindow.DisplayRichTextBox);
                        displayWindow.Show();
                        this.Hide();
                        displayWindow.Closed += (senderClosed, args) =>
                        {
                            this.Show();
                            displayWindow.Hide();
                        };

                    }
                }
            }
        }
    }
}
