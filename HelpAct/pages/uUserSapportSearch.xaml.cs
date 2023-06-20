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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelpAct
{
    /// <summary>
    /// Логика взаимодействия для uUserSapportSearch.xaml
    /// </summary>
    public partial class uUserSapportSearch : Page
    {
        public uUserSapportSearch()
        {
            InitializeComponent();
        }

        private void mMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new uUserSapportMainPage());
        }

        private void mAdd_Click(object sender, RoutedEventArgs e)
        {
            new formUserSupportAddUser().ShowDialog();
        }

        private void mDel_Click(object sender, RoutedEventArgs e)
        {
            new formUserSupportDeleteUser().ShowDialog();
        }

        private void mNew_Click(object sender, RoutedEventArgs e)
        {
            new formUserSupportRequest().ShowDialog();
        }

        private void mUserProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new uUserSapportPersonalAccount());
        }
    }
}
