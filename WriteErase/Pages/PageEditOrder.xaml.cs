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
    /// Логика взаимодействия для PageEditOrder.xaml
    /// </summary>
    public partial class PageEditOrder : Page
    {
        public PageEditOrder()
        {
            InitializeComponent();

            DataBase.Order order = Classes.Base.EM.Order.FirstOrDefault(x => x.OrderID == Classes.GlobalValues.orderID);


            tbOrderNomer.Text = order.OrderNumber.ToString();
            tbOrderCode.Text = order.Code.ToString();

       
            tbOrderDate.Text = order.OrderDate.ToString("dd.MM.yyyy");
            tbDelDate.Text = order.OrderDeliveryDate.ToString("dd.MM.yyyy");

            DataBase.User user = Classes.Base.EM.User.FirstOrDefault(x => x.UserID == order.UserID);

            if (user != null)
                tbUser.Text = user.UserSurname + " " + user.UserName + " " + user.UserPatronymic; 

            List<DataBase.OrderProduct> listOrderProduct = Classes.Base.EM.OrderProduct.Where(x => x.OrderID == Classes.GlobalValues.orderID).ToList();

            listViewProductsInOrder.ItemsSource = listOrderProduct;

            decimal totalPrice = 0;
            decimal totalPriceWithoutDiscount = 0;

            foreach (var item in listOrderProduct)
            {
                DataBase.Product product = Classes.Base.EM.Product.FirstOrDefault(x => x.ProductArticleNumber == item.ProductArticleNumber);
                if(product.ProductActualDiscount != null)
                {
                    totalPrice += (product.ProductCost - product.ProductCost * (decimal)(product.ProductActualDiscount * 0.01)) * item.OrderCount;
                }
                else
                {
                    totalPrice += product.ProductCost * item.OrderCount;
                }
                totalPriceWithoutDiscount += product.ProductCost * item.OrderCount;


            }

            tbItogo.Text = totalPrice.ToString("F") + " руб.";
            tbPriceWithouDisc.Text = (totalPriceWithoutDiscount - totalPrice).ToString("F") + " руб.";

            //255 140

            bool isMore3Count = true;
            bool isNone = false;

            foreach (var item in listOrderProduct)
            {
                DataBase.Product product = Classes.Base.EM.Product.FirstOrDefault(x => x.ProductArticleNumber == item.ProductArticleNumber);
                if (product.ProductQuantityInStock <= 3)
                {
                    isMore3Count = false;
                    break;
                }
                if (product.ProductQuantityInStock == 0)
                {
                    isNone = true;
                    break;
                }

            }
            if(isMore3Count)
            {
                stackPanelOrder.Background =  new SolidColorBrush(Color.FromRgb(32, 178, 170));
            }
            if(isNone)
            {
                stackPanelOrder.Background = new SolidColorBrush(Color.FromRgb(255, 140, 0));
            }

            if(order.OrderStatusID == 1)
            {
                cbStatus.SelectedIndex = 0;
            }
            else
            {
                cbStatus.SelectedIndex = 1;
            }




        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAllOrders());
        }

       
    }
}
