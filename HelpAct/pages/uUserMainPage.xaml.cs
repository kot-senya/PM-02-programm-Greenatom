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

namespace HelpAct
{
    /// <summary>
    /// Логика взаимодействия для uUserMainPage.xaml
    /// </summary>
    public partial class uUserMainPage : Page
    {
        public uUserMainPage()
        {
            InitializeComponent();
        }
        private void fullNullVisibility()
        {
            pageMain.Visibility = Visibility.Hidden;
            pageUserProfile.Visibility = Visibility.Hidden;
            pageAddRequest.Visibility = Visibility.Hidden;
            pageFullRequest.Visibility = Visibility.Hidden;
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

        private void mFullRequest_Click(object sender, RoutedEventArgs e)
        {
            fullNullVisibility();
            pageFullRequest.Visibility = Visibility.Visible;
        }

        private void mExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Autorization());
        }
    }
}
