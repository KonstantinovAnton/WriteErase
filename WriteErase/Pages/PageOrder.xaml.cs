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

        public PageOrder()
        {
            InitializeComponent();

            listOrder = new List<DataBase.Product>(); 

            //listOrder = Classes.GlobalValues.listOrder;

            List<DataBase.OrderProduct> listOrderProduct = Classes.Base.EM.OrderProduct.Where(x => x.OrderID == 54).ToList();

            foreach (var item in listOrderProduct)
            {
                listOrder.Add(Classes.Base.EM.Product.FirstOrDefault(x => x.ProductArticleNumber == item.ProductArticleNumber));
            }   

            listView.ItemsSource = listOrder;

            getTotalPrice();

            tbTotalPrice.Text = "Общая стоимость: " + string.Format("{0:F}", totalPrice) + " руб.";

        }

        private void getTotalPrice()
        {
            totalPrice = listOrder.Sum(x => x.ProductCostWithDiscount);

            var li = listOrder.FindAll(x => x.ProductActualDiscount == null).ToList();

            totalPrice += li.Sum(x => x.ProductCost);
        }

        private void tbCost_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;

            if (tb.Uid != null)
            {
                tb.TextDecorations = TextDecorations.Strikethrough;
            }
        }

        private void tbCostWithDiscount_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;
            showTextBlock(textBlock);
        }

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

        private void btnDropFromOrder_Click(object sender, RoutedEventArgs e)
        {          
            Button btn = (Button)sender;
            try
            {

                List<DataBase.OrderProduct> listOrderProduct = Classes.Base.EM.OrderProduct.Where(x => x.OrderID == 54).ToList();

                DataBase.OrderProduct orderProduct = listOrderProduct.FirstOrDefault(x => x.ProductArticleNumber == btn.Uid);


                Classes.Base.EM.OrderProduct.Remove(orderProduct);
                Classes.Base.EM.SaveChanges();
                NavigationService.Navigate(new PageOrder());
            }
            catch
            {

            }
        }

        private void tbCount_TextChanged(object sender, TextChangedEventArgs e)
        {

            TextBox tb = (TextBox)sender;
            DataBase.Product product = listOrder.FirstOrDefault(x => x.ProductArticleNumber == tb.Uid);


            try
            {
                int count = Convert.ToInt32(tb.Text);

                if(count < 0)
                {
                    MessageBox.Show("Отрицательное кол-во не подойдет. Введите положительное число", "Отрицательное число",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    return;
                }

                if(product.ProductActualDiscount == null)
                {
                    totalPrice = totalPrice - product.ProductCost + count * product.ProductCost;
                }
                else
                {
                    totalPrice = totalPrice - product.ProductCostWithDiscount + count * product.ProductCostWithDiscount;
                }

                
                tbTotalPrice.Text = "Общая стоимость: " + string.Format("{0:F}", totalPrice) + " руб.";
            }
            catch
            {

            }
        }

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
                        NavigationService.Navigate(new PageOrder());
                    }
                    catch
                    {

                    }

                }

                orderProduct.OrderCount--;

                Classes.Base.EM.SaveChanges();

              
            }
            catch
            {

            }

            NavigationService.Navigate(new PageOrder());

            
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            try
            {
                List<DataBase.OrderProduct> listOrderProduct = Classes.Base.EM.OrderProduct.Where(x => x.OrderID == 54).ToList();

                DataBase.OrderProduct orderProduct = listOrderProduct.FirstOrDefault(x => x.ProductArticleNumber == btn.Uid);
                orderProduct.OrderCount++;

                Classes.Base.EM.SaveChanges();
            }
            catch
            {

            }

            NavigationService.Navigate(new PageOrder());

        }

        
    }
}
