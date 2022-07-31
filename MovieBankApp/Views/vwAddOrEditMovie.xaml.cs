using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using MovieBankApp.Models;

namespace MovieBankApp.Views
{
    /// <summary>
    /// Interaction logic for vwAddOrEditMovie.xaml
    /// </summary>
    public partial class vwAddOrEditMovie : Window
    {
        public Movies Movie = new Movies();
        private readonly MovieBank_DBEntities _db = new MovieBank_DBEntities();
        private OpenFileDialog _dialog = new OpenFileDialog();
        public vwAddOrEditMovie()
        {
            InitializeComponent();
            this.DataContext = Movie;
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtPosterName.Content.ToString()))
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + @"\\Images\\Movie\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var imageName = Guid.NewGuid().ToString().Replace("_", "");
                var ext = Path.GetExtension(_dialog.SafeFileName);
                var fullImageName = imageName + ext;
                File.Copy(_dialog.FileName, path + fullImageName);
                Movie.Poster = fullImageName;
            }
            Movie.CreateDate = DateTime.Now;
            _db.Movies.Add(Movie);
            _db.SaveChanges();
        }

        private void VwAddOrEditMovie_OnLoaded(object sender, RoutedEventArgs e)
        {
            CmbDirector.ItemsSource = _db.Directors.ToList();
            CmbDirector.SelectedIndex = 0;
            //CmbDirector.DisplayMemberPath = "FullName";
            //CmbDirector.SelectedValuePath = "DirectorId";
        }

        private void BtnPoster_OnClick(object sender, RoutedEventArgs e)
        {
            _dialog.Filter = "Jpg file(*.jpg)| *.jpg| Png file(*.png)|*.png";
            if (_dialog.ShowDialog() == true)
            {
                TxtPosterName.Content = _dialog.FileName;
                ImgPoster.Source = new BitmapImage(new Uri(_dialog.FileName));
            }
        }
    }
}
