using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EO.Wpf.Demo.Data
{
    //A celebrity with a name and a picture
    internal class Celebrity : INotifyPropertyChanged
    {
        private string m_szName;
        private string m_szImageUri;
        public event PropertyChangedEventHandler PropertyChanged;

        public Celebrity(string name, string imageUri)
        {
            m_szName = name;
            m_szImageUri = imageUri;
        }

        public string Name
        {
            get { return m_szName; }
            set
            {
                if (m_szName != value)
                {
                    m_szName = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string ImageUri
        {
            get { return m_szImageUri; }
        }

        public ImageSource Image
        {
            get
            {
                Uri uri = new Uri("pack://application:,,,/Images/Celebrities/" + m_szImageUri);
                return new BitmapImage(uri);
            }
        }

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    //A celebrity category with a name, an icon and a list of celebrities
    internal class CelebrityCategory : INotifyPropertyChanged
    {
        private string m_szName;
        private string m_szImageUri;
        private Celebrity[] m_Celebrities;
        public event PropertyChangedEventHandler PropertyChanged;        

        public CelebrityCategory(string name, string imageUri, Celebrity[] celebrities)
        {
            m_szName = name;
            m_szImageUri = imageUri;
            m_Celebrities = celebrities;
        }

        public string Name
        {
            get { return m_szName; }
            set
            {
                if (m_szName != value)
                {
                    m_szName = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string ImageUri
        {
            get { return m_szImageUri; }
            set { m_szImageUri = value; }
        }

        public ImageSource Image
        {
            get
            {
                Uri uri = new Uri("pack://application:,,,/Images/" + m_szImageUri);
                return new BitmapImage(uri);
            }
        }

        public Celebrity[] Celebrities
        {
            get
            {
                return m_Celebrities;
            }
        }

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}