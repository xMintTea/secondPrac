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

namespace MintLab
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private string userRole;

        public HomePage(string role)
        {
            InitializeComponent();
            userRole = role; // Сохраняем роль пользователя
            SetButtonVisibility();
        }

        private void BtnMaterials_Click(object sender, RoutedEventArgs e) {

        }

        private void SetButtonVisibility() {
            var allowedRoles = new List<string> { "manager" };
            bool isSupplierButtonEnabled = allowedRoles.Contains(userRole);
            BtnSuppliers.IsEnabled = isSupplierButtonEnabled;

            if (isSupplierButtonEnabled)
            {
                BtnSuppliers.Style = (Style)Application.Current.Resources["SupplierButtonStyle"];
            }
            else
            {
                BtnSuppliers.Style = (Style)Application.Current.Resources["ButtonNo"];
                BtnSuppliers.Background = System.Windows.Media.Brushes.Gray;
            }
        }

    }


}
