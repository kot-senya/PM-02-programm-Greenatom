using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
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
using Microsoft.Win32;

namespace HelpAct
{
    /// <summary>
    /// Логика взаимодействия для uUserMainPage.xaml
    /// </summary>
    public partial class uUserMainPage : Page
    {
        Users meme;
        public uUserMainPage(Users user)
        {
            meme = user;
            InitializeComponent();
        }
        private void fullNullVisibility()
        {
            pageMain.Visibility = Visibility.Hidden;
            pageUserProfile.Visibility = Visibility.Hidden;
            pageAddRequest.Visibility = Visibility.Hidden;
            pageAllRequest.Visibility = Visibility.Hidden;
        }
        private void mMain_Click(object sender, RoutedEventArgs e)
        {
            fullNullVisibility();
            pageMain.Visibility = Visibility.Visible;
        }

        private void mUserProfile_Click(object sender, RoutedEventArgs e)
        {
            fullNullVisibility();
            pageUserProfile.Visibility = Visibility.Visible;
        }

        private void mAddRequest_Click(object sender, RoutedEventArgs e)
        {
            fullNullVisibility();
            pageAddRequest.Visibility = Visibility.Visible;
        }

        private void mAllRequest_Click(object sender, RoutedEventArgs e)
        {
            fullNullVisibility();
            pageAllRequest.Visibility = Visibility.Visible;
        }

        private void mExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Autorization());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                aImage.Source = new BitmapImage(fileUri);
            }
        }
    }
}
