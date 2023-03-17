using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using WriteErase.Classes;

namespace WriteErase.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        private int time = 10;
        private DispatcherTimer timer;

        public PageAuthorization()
        {
            InitializeComponent();
            if(GlobalValues.attemp > 0)
                loadCaptcha();
            else
            {
                captchaImage.Visibility = Visibility.Collapsed;
                tbCaptcha.Visibility = Visibility.Collapsed;
            }

            if (GlobalValues.attemp > 1)
            {
                btnAuthorizate.Visibility = Visibility.Hidden;
                timerStart();
            }
        }

        // Проверка данных авторизации
        private void btnAuthorizate_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxLogin.Text == "" || textBoxLogin.Text == " ")
            {
                MessageBox.Show("Введите логин", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (passBox.Password == "" || passBox.Password == " ")
            {
                MessageBox.Show("Введите пароль", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (GlobalValues.attemp > 0)
            {
                if (tbCaptcha.Text == "" || tbCaptcha.Text == " ")
                {
                    MessageBox.Show("Введите Captcha", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }             
            }

            var user = Classes.Base.EM.User.FirstOrDefault(x => x.UserLogin == textBoxLogin.Text && x.UserPassword == passBox.Password);

            if (user != null)
            {
             
                Classes.GlobalValues.isFirstEnterIntoPageOrder = true;
                Classes.GlobalValues.idUser = user.UserID;
                Classes.GlobalValues.role = user.RoleID;


                MainWindow SetWindow = Window.GetWindow(this) as MainWindow;
                SetWindow.Topmost = true;

                switch (user.RoleID)
                {
                    case 1:
                        SetWindow.tbRole.Text = "Клиент";
                        break;
                    case 2:
                        SetWindow.tbRole.Text = "Администратор";
                        break;
                    case 3:
                        SetWindow.tbRole.Text = "Менеджер";
                        break;
                }


                if (GlobalValues.attemp > 0)
                {
                    if (tbCaptcha.Text == GlobalValues.captchaText)
                    {
                        NavigationService.Navigate(new PageProduct());
                    }
                    else
                    {
                        MessageBox.Show("Captcha не подходит", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                        Classes.GlobalValues.attemp++;
                        NavigationService.Navigate(new PageAuthorization());
                    }
                }
                else
                {
                    NavigationService.Navigate(new PageProduct());
                }

               
            }
            else
            {
                MessageBox.Show("Не нашли вас", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Information);
                Classes.GlobalValues.attemp++;
                NavigationService.Navigate(new PageAuthorization());
            }
        }

        
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Classes.GlobalValues.isFirstEnterIntoPageOrder = true;
            Classes.GlobalValues.role = 1;

            MainWindow SetWindow = Window.GetWindow(this) as MainWindow;
            SetWindow.Topmost = true;
            SetWindow.tbRole.Text = "Клиент";
            NavigationService.Navigate(new PageProduct());
        }

        // загрузка каптчи
        private void loadCaptcha()
        {
            captchaImage.Visibility = Visibility.Visible;
            tbCaptcha.Visibility = Visibility.Visible;

            int width = 230;
            int height = 80;
            var captchaCode = Captcha.generateCaptcha();
            var result = Captcha.GetCaptchaImage(width, height, captchaCode);

            Stream stream = new MemoryStream(result.captchaByteCode);

            captchaImage.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

        }

        // запуск таймера
        private void timerStart()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        // трекер таймера
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (time == 0)
            {
                timer.Stop();
                btnAuthorizate.Visibility = Visibility.Visible;
            }
            else
            {               
                time--;
            }
        }
    }
}
