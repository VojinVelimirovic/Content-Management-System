using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Content_Management_System.Classes
{
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

        public Figure(string name, int reignStart, int reignEnd, string image, string description)
        {
            this.Name = name;
            this.ReignStart = reignStart;
            this.ReignEnd = reignEnd;
            this.Image = image;
            this.Description = description;
            this.DateAdded = DateTime.Now.Date;
            this.IsChecked = false;
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
