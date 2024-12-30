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

namespace MintLab
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }


        private string GetUserPermissions(string username, string password) {
            var users = new Dictionary<string, (string Password, string Role)>
            {
                { "manager", ("1", "manager") },
                { "user", ("1", "user") },
            };

            if (users.TryGetValue(username, out var userInfo))
            {
                if (userInfo.Password == password)
                {
                    return userInfo.Role;
                }
            }

            return "unknown";
        }


        private void Autorized_Click(object sender, RoutedEventArgs e) {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(LoginText.Text))
            {
                errors.AppendLine("Укажите логин");
            }
            if (string.IsNullOrWhiteSpace(PasswordText.Text))
            {
                errors.AppendLine("Укажите пароль");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            string username = LoginText.Text;
            string password = PasswordText.Text;

            string userRole = GetUserPermissions(username, password);

            if (userRole != "unknown")
            {
                MessageBox.Show("Пользователь авторизован");


                MainWindow mainWindow = new MainWindow(userRole);

                mainWindow.Show();
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }


    }
}
