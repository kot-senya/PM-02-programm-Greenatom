using HelpAct.pages;
using Microsoft.Win32;
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
        Users meme;
        public uITactivPersonalAccount(Users user)
        {
            meme = user;
            InitializeComponent();
            initUser();
            
        }

        private void initUser()
        {
            txt_FIO.Text = meme.Surname + " " + meme.Name + " " + meme.Patronymic;
            txt_db.Text = Convert.ToString(meme.Birthday).Split(' ')[0];
            txt_Email.Text = meme.Email;
            txt_phonr.Text = meme.Phone;
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
            NavigationService.Navigate(new uITactivMainPage(meme));
        }

        private void mSuarch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new uITactivSearch(meme));
        }

        private void mExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Autorization());
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

        private void bChange_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangeProfile(meme, "ИТ - актив"));
        }
    }
}
