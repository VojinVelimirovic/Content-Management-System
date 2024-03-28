using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;

namespace Content_Management_System.Classes
{
    [Serializable]
    public class Figure : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string name;
        private int reignStart;
        private int reignEnd;
        private string image;
        private string description;
        private DateTime dateAdded;
        private bool isChecked;


        public Figure() { }

        public Figure(string name, int reignStart, int reignEnd, string image, DateTime dateAdded)
        {
            this.Name = name;
            this.ReignStart = reignStart;
            this.ReignEnd = reignEnd;
            this.Image = image;
            this.Description = createRtfPath();
            this.DateAdded = dateAdded;
            this.IsChecked = false;
        }

        private string createRtfPath()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rtfFiles");
            Directory.CreateDirectory(folderPath);
            string fileName = $"Figure_{RemoveInvalidPathChars(this.Name)}.rtf";
            string filePath = Path.Combine(folderPath, fileName);
            if (!File.Exists(filePath))
            {
                return filePath;
            }
            else
            {
                string uniqueFilePath = filePath;
                int count = 1;
                while (File.Exists(uniqueFilePath))
                {
                    fileName = Path.GetFileNameWithoutExtension(fileName);
                    string suffix = "_" + count;
                    uniqueFilePath = Path.Combine(folderPath, $"{fileName}{suffix}.rtf");
                    count++;
                    if (count > 1000)
                    {
                        throw new Exception("Unable to generate a unique file path.");
                    }
                }
                return uniqueFilePath;
            }
        }

        private string RemoveInvalidPathChars(string path)
        {
            string invalidChars = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            foreach (char invalidChar in invalidChars)
            {
                path = path.Replace(invalidChar.ToString(), "");
            }
            return path;
        }

        public string Name { get => name; set => name = value; }
        public int ReignStart { get => reignStart; set => reignStart = value; }
        public int ReignEnd { get => reignEnd; set => reignEnd = value; }
        public string Image { get => image; set => image = value; }
        public string Description { get => description; set => description = value; }
        public DateTime DateAdded { get => dateAdded; set => dateAdded = value; }
        public string ReignFormat => $"({ReignStart} - {ReignEnd})";
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    OnPropertyChanged(nameof(IsChecked));
                }
            }
        }
    }
}
