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
    /// Логика взаимодействия для PageOrder.xaml
    /// </summary>
    /// 

    public partial class PageOrder : Page
    {
        List<DataBase.Product> listOrder;
        decimal totalPrice;
        decimal totalPriceWithoutDiscount;

        public PageOrder()
        {
            InitializeComponent();

            listOrder = new List<DataBase.Product>(); 

            List<DataBase.OrderProduct> listOrderProduct = Classes.Base.EM.OrderProduct.Where(x => x.OrderID == 54).ToList();


            foreach (var item in listOrderProduct)
            {
                listOrder.Add(Classes.Base.EM.Product.FirstOrDefault(x => x.ProductArticleNumber == item.ProductArticleNumber));
            }   

            listView.ItemsSource = listOrder;

            if(Classes.GlobalValues.isFirstEnterIntoPageOrder)
                getTotalPrice();
            else
            {
                totalPriceWithoutDiscount = Classes.GlobalValues.totalPriceWithoutDiscount;
                totalPrice = Classes.GlobalValues.totalPrice;

                tbTotalPrice.Text = "Общая стоимость: " + string.Format("{0:F}", Classes.GlobalValues.totalPrice) + " руб.";
                tbDiscountOrder.Text = "Скидка: " + string.Format("{0:F}", (Classes.GlobalValues.totalPriceWithoutDiscount - Classes.GlobalValues.totalPrice)) + " руб.";
            }

            cbPoint.ItemsSource = Classes.Base.EM.PickupPoint.ToList();

            cbPoint.DisplayMemberPath = "PickupPointNumber";
            cbPoint.SelectedValuePath = "PickupPointNumberID";

            cbPoint.SelectedIndex = 0;

            DataBase.User user = Classes.Base.EM.User.FirstOrDefault(x => x.UserID == Classes.GlobalValues.idUser);
            if (user != null)
                tbUser.Text = user.UserSurname + " " + user.UserName + " " + user.UserPatronymic + ", ";
        }

        // получить итоговую цену
        private void getTotalPrice()
        {

            totalPrice = listOrder.Sum(x => x.ProductCostWithDiscount);

            var li = listOrder.FindAll(x => x.ProductActualDiscount == null).ToList();

            totalPrice += li.Sum(x => x.ProductCost);

            totalPriceWithoutDiscount = listOrder.Sum(x => x.ProductCost);

            tbTotalPrice.Text = "Общая стоимость: " + string.Format("{0:F}", totalPrice) + " руб.";
            tbDiscountOrder.Text = "Скидка: " + string.Format("{0:F}", (totalPriceWithoutDiscount - totalPrice)) + " руб.";

        }

        // подгрузить цену
        private void tbCost_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;

            if (tb.Uid != null)
            {
                tb.TextDecorations = TextDecorations.Strikethrough;
            }
        }

        // подгрузить цену со скидкой
        private void tbCostWithDiscount_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;
            showTextBlock(textBlock);
        }

        // отобразить текстовый блок
        private void showTextBlock(TextBlock tb)
        {
            if (tb.Uid != null)
            {
                tb.Visibility = Visibility.Visible;
            }
            else
            {
                tb.Visibility = Visibility.Hidden;
            }
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            showTextBlock(tb);
        }

        // удалить из заказа
        private void btnDropFromOrder_Click(object sender, RoutedEventArgs e)
        {          
            Button btn = (Button)sender;
            try
            {

                List<DataBase.OrderProduct> listOrderProduct = Classes.Base.EM.OrderProduct.Where(x => x.OrderID == 54).ToList();

                DataBase.OrderProduct orderProduct = listOrderProduct.FirstOrDefault(x => x.ProductArticleNumber == btn.Uid);


                Classes.Base.EM.OrderProduct.Remove(orderProduct);
                Classes.Base.EM.SaveChanges();
                Classes.GlobalValues.isFirstEnterIntoPageOrder = false;

                Classes.GlobalValues.totalPrice = totalPrice;
                Classes.GlobalValues.totalPriceWithoutDiscount = totalPriceWithoutDiscount;

                NavigationService.Navigate(new PageOrder());
            }
            catch
            {

            }
        }

        // уменьшить кол-во
        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            try
            {
                

                List<DataBase.OrderProduct> listOrderProduct = Classes.Base.EM.OrderProduct.Where(x => x.OrderID == 54).ToList();

                DataBase.OrderProduct orderProduct = listOrderProduct.FirstOrDefault(x => x.ProductArticleNumber == btn.Uid);

                if (orderProduct.OrderCount == 1)
                {
                    try
                    {

                        List<DataBase.OrderProduct> listOrderProductDel = Classes.Base.EM.OrderProduct.Where(x => x.OrderID == 54).ToList();

                        DataBase.OrderProduct orderProductDel = listOrderProductDel.FirstOrDefault(x => x.ProductArticleNumber == btn.Uid);


                        Classes.Base.EM.OrderProduct.Remove(orderProductDel);
                        Classes.Base.EM.SaveChanges();

                        DataBase.Product product1 = Classes.Base.EM.Product.FirstOrDefault(x => x.ProductArticleNumber == btn.Uid);
                        totalPrice -= product1.ProductCostWithDiscount;
                        totalPriceWithoutDiscount -= product1.ProductCost;

                        Classes.GlobalValues.totalPrice = totalPrice;
                        Classes.GlobalValues.totalPriceWithoutDiscount = totalPriceWithoutDiscount;

                        Classes.GlobalValues.isFirstEnterIntoPageOrder = false;

                    }
                    catch
                    {

                    }

                }
                else
                {
                    try
                    {
                        List<DataBase.OrderProduct> listOrderProduct2 = Classes.Base.EM.OrderProduct.Where(x => x.OrderID == 54).ToList();

                        DataBase.OrderProduct orderProduct2 = listOrderProduct2.FirstOrDefault(x => x.ProductArticleNumber == btn.Uid);
                        orderProduct2.OrderCount--;

                        Classes.Base.EM.SaveChanges();

                        DataBase.Product product1 = Classes.Base.EM.Product.FirstOrDefault(x => x.ProductArticleNumber == btn.Uid);
                        totalPrice -= product1.ProductCostWithDiscount;
                        totalPriceWithoutDiscount -= product1.ProductCost;

                        Classes.GlobalValues.totalPrice = totalPrice;
                        Classes.GlobalValues.totalPriceWithoutDiscount = totalPriceWithoutDiscount;

                        Classes.GlobalValues.isFirstEnterIntoPageOrder = false;

                    }
                    catch
                    {

                    }
                }

            }
            catch
            {

            }

            NavigationService.Navigate(new PageOrder());            
        }

        // увеличить кол-во
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            try
            {
                List<DataBase.OrderProduct> listOrderProduct = Classes.Base.EM.OrderProduct.Where(x => x.OrderID == 54).ToList();

                DataBase.OrderProduct orderProduct = listOrderProduct.FirstOrDefault(x => x.ProductArticleNumber == btn.Uid);
                orderProduct.OrderCount++;

                Classes.Base.EM.SaveChanges();

                DataBase.Product product1 = Classes.Base.EM.Product.FirstOrDefault(x => x.ProductArticleNumber == btn.Uid);
                totalPrice += product1.ProductCostWithDiscount;
                totalPriceWithoutDiscount += product1.ProductCost;

                Classes.GlobalValues.totalPrice = totalPrice;
                Classes.GlobalValues.totalPriceWithoutDiscount = totalPriceWithoutDiscount;

                Classes.GlobalValues.isFirstEnterIntoPageOrder = false;

            }
            catch
            {

            }

            NavigationService.Navigate(new PageOrder());

        }

        // вернуться назад
        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageProduct());
        }

        // сформировать заказ
        private void btnFormOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int maxCode = 1;

                List<DataBase.Order> maxOrderList = Classes.Base.EM.Order.ToList();
                foreach (var item in maxOrderList)
                {
                    if (Convert.ToInt32(item.Code) > maxCode)
                        maxCode = Convert.ToInt32(item.Code);
                }

                DataBase.Order order = new DataBase.Order();

                order.OrderDate = DateTime.Now;
                order.OrderDeliveryDate = DateTime.Now;
                order.PickupPointID = 1;
                if(Classes.GlobalValues.idUser == 0)
                    order.UserID = 1;
                else
                    order.UserID = Classes.GlobalValues.idUser;
                order.Code = Convert.ToString(maxCode + 1);

                Classes.Base.EM.Order.Add(order);
                Classes.Base.EM.SaveChanges();

                MessageBox.Show("Заказ успешно сформирован", "Формирование заказа", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new PageProduct());
            }
            catch
            {
                MessageBox.Show("Заказ не сформирован, попробуйте позже", "Формирование заказа", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new PageProduct());
            }
        }
    }
}
