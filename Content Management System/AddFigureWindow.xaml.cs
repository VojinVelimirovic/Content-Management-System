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
using Microsoft.Win32;
using System.IO;

namespace Content_Management_System
{
    /// <summary>
    /// Interaction logic for AddFigureWindow.xaml
    /// </summary>
    public partial class AddFigureWindow : Window
    {
        public AddFigureWindow()
        {
            InitializeComponent();
            DataContext = this;
            FontFamilyComboBox.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            InitializeFontSizes();
        }
        private void InitializeFontSizes()
        {
            List<double> fontSizes = new List<double>();
            for (double size = 8; size <= 72; size += 2)
            {
                fontSizes.Add(size);
            }
            FontSizeComboBox.ItemsSource = fontSizes;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string imagePath = openFileDialog.FileName;
                    ImagePreview.Source = new BitmapImage(new Uri(imagePath));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void FontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontFamilyComboBox.SelectedItem != null && !EditorRichTextBox.Selection.IsEmpty)
            {
                EditorRichTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, FontFamilyComboBox.SelectedItem);
            }
        }

        private void FontSizeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontSizeComboBox.SelectedItem != null && !EditorRichTextBox.Selection.IsEmpty)
            {
                EditorRichTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, FontSizeComboBox.SelectedItem);
            }
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (ColorPicker.SelectedColor != null && !EditorRichTextBox.Selection.IsEmpty)
            {
                Color selectedColor = ColorPicker.SelectedColor.Value;
                SolidColorBrush brush = new SolidColorBrush(selectedColor);
                EditorRichTextBox.Selection.ApplyPropertyValue(Inline.ForegroundProperty, brush);
                ColorTextBlock.Text = brush.Color.ToString();
                ColorTextBlock.Foreground = brush;
            }
        }

        private void EditorRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = new TextRange(EditorRichTextBox.Document.ContentStart, EditorRichTextBox.Document.ContentEnd).Text;
            string[] words = text.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            WordCountTextBox.Text = $"{words.Length} words";
        }

        private void EditorRichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object fontWeight = EditorRichTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            BoldToggleButton.IsChecked = (fontWeight != DependencyProperty.UnsetValue) && (fontWeight.Equals(FontWeights.Bold));

            object fontStyle = EditorRichTextBox.Selection.GetPropertyValue(Inline.FontStyleProperty);
            ItalicToggleButton.IsChecked = (fontStyle != DependencyProperty.UnsetValue) && (fontStyle.Equals(FontStyles.Italic));

            object textDecorations = EditorRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            UnderlineToggleButton.IsChecked = (textDecorations != DependencyProperty.UnsetValue) &&
                                               (textDecorations.Equals(TextDecorations.Underline));

            object fontFamily = EditorRichTextBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            FontFamilyComboBox.SelectedItem = fontFamily;

            object fontSizeObj = EditorRichTextBox.Selection.GetPropertyValue(Inline.FontSizeProperty);
            if (fontSizeObj != null && fontSizeObj is double fontSize)
            {
                FontSizeComboBox.SelectedItem = fontSize;
            }

            var foreground = EditorRichTextBox.Selection.GetPropertyValue(Inline.ForegroundProperty);
            if (foreground is SolidColorBrush solidColorBrush)
            {
                ColorPicker.SelectedColor = solidColorBrush.Color;
                ColorTextBlock.Text = solidColorBrush.Color.ToString();
                ColorTextBlock.Foreground = solidColorBrush;
            }
            else if (foreground is Color color)
            {
                ColorPicker.SelectedColor = color;
                ColorTextBlock.Text = color.ToString();
                ColorTextBlock.Foreground = new SolidColorBrush(color);
            }
        }

        private bool ValidateAdd()
        {
            bool isValid = true;

            if (NameTextBox.Text.Trim().Equals(string.Empty))
            {
                isValid = false;
                NameErrorLabel.Content = "Field cannot be left empty!";
                NameTextBox.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                NameErrorLabel.Content = string.Empty;
                NameTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
            }

            if (ReignStartTextBox.Text.Trim().Equals(string.Empty))
            {
                isValid = false;
                ReignStartErrorLabel.Text = "Field cannot be left empty!";
                ReignStartTextBox.BorderBrush = Brushes.DarkRed;
            }
            else if(!int.TryParse(ReignStartTextBox.Text, out _))
            {
                isValid = false;
                ReignStartErrorLabel.Text = "Must be integer!";
                ReignStartTextBox.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                ReignStartErrorLabel.Text = string.Empty;
                ReignStartTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
            }

            if (ReignEndTextBox.Text.Trim().Equals(string.Empty))
            {
                isValid = false;
                ReignEndErrorLabel.Text = "Field cannot be left empty!";
                ReignEndTextBox.BorderBrush = Brushes.DarkRed;
            }
            else if (!int.TryParse(ReignEndTextBox.Text, out _))
            {
                isValid = false;
                ReignEndErrorLabel.Text = "Must be integer!";
                ReignEndTextBox.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                ReignEndErrorLabel.Text = string.Empty;
                ReignEndTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
            }

            if (new TextRange(EditorRichTextBox.Document.ContentStart, EditorRichTextBox.Document.ContentEnd).Text.Trim().Equals(string.Empty))
            {
                isValid = false;
                RichBoxErrorLabel.Content = "Field cannot be left empty!";
                EditorRichTextBox.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                RichBoxErrorLabel.Content = string.Empty;
                EditorRichTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
            }

            return isValid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateAdd())
            {
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}
