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

namespace WriteErase.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        public PageAuthorization()
        {
            InitializeComponent();
        }

        private void btnAuthorizate_Click(object sender, RoutedEventArgs e)
        {
            var user = Classes.Base.EM.User.FirstOrDefault(x => x.UserLogin == textBoxLogin.Text && x.UserPassword == passBox.Password);

            if (user != null)
            {
             //   MessageBox.Show("Hello");
                Classes.GlobalValues.isFirstEnterIntoPageOrder = true;
                NavigationService.Navigate(new PageProduct());
            }
            else
            {
                MessageBox.Show("Not Hello");
            }
        }
    }
}
