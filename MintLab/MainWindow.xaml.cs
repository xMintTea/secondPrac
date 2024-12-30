using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MintLab {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow(string role) {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            MainFrame.Navigate(new HomePage(role));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) {
            if (Manager.MainFrame.CanGoBack)
            {
                Manager.MainFrame.GoBack();
            }
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e) {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }
    }
}