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
    /// Логика взаимодействия для uITactivSearch.xaml
    /// </summary>
    public partial class uITactivSearch : Page
    {
        public uITactivSearch()
        {
            InitializeComponent();
        }

        private void mMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new uITactivMainPage());
        }

        private void mAdd_Click(object sender, RoutedEventArgs e)
        {
            new formITactivAddTechnic().ShowDialog();
        }

        private void mDel_Click(object sender, RoutedEventArgs e)
        {
            new formITactivDeleteTechnic().ShowDialog();
        }

        private void mUserProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new uITactivPersonalAccount());
        }

        private void tb_info_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            Random rnd = new Random();
            for(int i = 0; i < 100; i ++)
            {
                list.Add(Convert.ToString(rnd.Next(100,145)));
            }
            tb_info.ItemsSource = list;
        }
    }
}
