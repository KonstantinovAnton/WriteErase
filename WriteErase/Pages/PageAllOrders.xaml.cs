﻿using System;
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
    /// Логика взаимодействия для PageAllOrders.xaml
    /// </summary>
    public partial class PageAllOrders : Page
    {
        public PageAllOrders()
        {
            InitializeComponent();

            List<DataBase.Order> listOrder = Classes.Base.EM.Order.ToList(); 
            listView.ItemsSource = listOrder;
        }

        // Открыть заказ
        private void btnOpenOrder_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Classes.GlobalValues.orderID = Convert.ToInt32(btn.Uid);
            NavigationService.Navigate(new PageEditOrder());
        }

        private void btnEditOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        // Вернуться назад
        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageProduct());
        }
    }
}
