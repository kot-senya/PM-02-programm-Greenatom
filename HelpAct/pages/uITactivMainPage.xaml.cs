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
    /// Логика взаимодействия для uITactivMainPage.xaml
    /// </summary>
    public partial class uITactivMainPage : Page
    {
        Users meme;
        public uITactivMainPage(Users user)
        {
            meme = user;
            InitializeComponent();
        }

        private void mUserProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new uITactivPersonalAccount(meme));
        }

        private void mSuarch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new uITactivSearch(meme));
        }

        private void mAdd_Click(object sender, RoutedEventArgs e)
        {
            new formITactivAddTechnic().ShowDialog();
        }

        private void mDel_Click(object sender, RoutedEventArgs e)
        {
            new formITactivDeleteTechnic().ShowDialog();
        }
    }
}
