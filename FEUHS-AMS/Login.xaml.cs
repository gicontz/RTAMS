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
using System.Windows.Shapes;
using System.Net.Http;

namespace FEUHS_AMS
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private static readonly HttpClient client = new HttpClient();
        private static string responseString = "";
        private XDLINE xdl = new XDLINE();

        public Login()
        {
            InitializeComponent();
        }

        private async void login(object sender, RoutedEventArgs e)
        {
            string pass = password.Password;
            string un = username.Text;
            responseString = await client.GetStringAsync("http://localhost/rtams-portal/lib/decrypt-pass.php?pw=" + pass);
            List<string>[] credentials = xdl.selectItems("users_table", "username", new string[] { "username" }, "username = \"" +
                un + "\" and password = \"" + responseString + "\" and account_type = 'admin'");
            try
            {
                if(credentials[0].ElementAt(0) == un) {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong Username or Password!", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void saveSettings(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_clear(object sender, RoutedEventArgs e)
        {
            if (username.Text == "Username")
            {
                TextBox t = sender as TextBox;
                t.Clear();
            }
            string p = password.Password;
            if (p == "")
            {
                password.Password = "Password";
            }
        }

        private void PassWord_clear(object sender, RoutedEventArgs e)
        {
            if (password.Password == "Password")
            {
                PasswordBox t = sender as PasswordBox;
                t.Clear();
            }


            string user = username.Text;
            if (user == "")
            {
                username.Text = "Username";
            }
        }
    }
}

