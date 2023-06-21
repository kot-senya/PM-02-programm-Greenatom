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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void bAuth_Click(object sender, RoutedEventArgs e)
        {
            if(aLogin.Text == "1")
            {
                NavigationService.Navigate(new uUserMainPage());
            }
            else if(aLogin.Text == "2")
            {
                NavigationService.Navigate(new uITactivMainPage());
            }
            else if(aLogin.Text == "3")
            {
                NavigationService.Navigate(new uUserSapportMainPage());
            }
        }
    }
}
