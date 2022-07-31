using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using MovieBankApp.Views;

namespace MovieBankApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Thread.Sleep(5000);
            foreach (UIElement child in DpMovieList.Children)
            {
                child.MouseDown += Child_MouseDown;
                child.MouseWheel += Child_MouseWheel;
            }
        }

        private void Child_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                ScrollViewerMovieList.LineLeft();
            }
            else
            {
                ScrollViewerMovieList.LineRight();
            }
        }

        private void Child_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var uc = (UserControl)sender;
            if (uc.Content is Border border)
            {
                MessageBox.Show($"Tag Value: {border.Tag}");
            }
        }

        private void RecTop_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }

            if (e.MiddleButton == MouseButtonState.Released)
            {
                this.WindowState = this.WindowState == WindowState.Maximized
                    ? WindowState.Normal
                    : WindowState.Maximized;
            }

        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMinus_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnMoveRight_OnClick(object sender, RoutedEventArgs e)
        {
            ScrollViewerMovieList.LineRight();
        }

        private void BtnMoveLeft_OnClick(object sender, RoutedEventArgs e)
        {
            ScrollViewerMovieList.LineLeft();
        }

        private void BtnAddMovie_OnClick(object sender, RoutedEventArgs e)
        {
            var vw = new vwAddOrEditMovie()
            {
                Owner = this
            };
            vw.ShowDialog();
        }
    }
}
