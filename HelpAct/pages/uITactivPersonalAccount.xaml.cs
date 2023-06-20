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
    /// Логика взаимодействия для uITactivPersonalAccount.xaml
    /// </summary>
    public partial class uITactivPersonalAccount : Page
    {
        public uITactivPersonalAccount()
        {
            InitializeComponent();
        }

        private void mAdd_Click(object sender, RoutedEventArgs e)
        {
            new formITactivAddTechnic().ShowDialog();
        }

        private void mDel_Click(object sender, RoutedEventArgs e)
        {
            new formITactivDeleteTechnic().ShowDialog();
        }

        private void mMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new uITactivMainPage());
        }

        private void mSuarch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new uITactivSearch());
        }

        private void mExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Autorization());
        }
    }
}
