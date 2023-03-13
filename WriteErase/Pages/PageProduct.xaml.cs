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
    /// Логика взаимодействия для PageProduct.xaml
    /// </summary>
    public partial class PageProduct : Page
    {
        int f = 0;
        List<DataBase.Product> listProduct;
        List<DataBase.Product> korzina;
    
        public PageProduct()
        {
    
            InitializeComponent();
            korzina = new List<DataBase.Product>();


            comboBoxSort.SelectedIndex = 0;
            comboBoxDiscount.SelectedIndex = 0;

            listView.ItemsSource = Classes.Base.EM.Product.ToList();
           
            textBlockCountShow.Text = Classes.Base.EM.Product.ToList().Count.ToString();
            textBlockAllCount.Text = Classes.Base.EM.Product.ToList().Count.ToString();

            btnGotoOrder.Visibility = Visibility.Hidden;

            clearTable();
            
        }

        private void clearTable()
        {
            List<DataBase.OrderProduct> orderProducts = Classes.Base.EM.OrderProduct.Where(x => x.OrderID == 54).ToList();

            try
            {
                foreach (var item in orderProducts)
                {
                    Classes.Base.EM.OrderProduct.Remove(item);
                }

                Classes.Base.EM.SaveChanges();
            }
            catch
            {

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

        private void tbCost_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;

            if (tb.Uid != null)
            {
                tb.TextDecorations = TextDecorations.Strikethrough;   
            }
          
        }
        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            showTextBlock(tb);
        }

        private void sortData()
        {
            listProduct = new List<DataBase.Product>();
           

              // Фильтрация по скидке

              switch (comboBoxDiscount.SelectedIndex)
              {
                  case 0:
                      listProduct = Classes.Base.EM.Product.ToList();
                      break;
                  case 1:
                      listProduct =  Classes.Base.EM.Product.Where(x => x.ProductActualDiscount >= 0 && x.ProductActualDiscount < 10).ToList();
                      break;
                  case 2:
                      listProduct = Classes.Base.EM.Product.Where(x => x.ProductActualDiscount >= 10 && x.ProductActualDiscount < 15).ToList();
                      break;
                  case 3:
                        listProduct = Classes.Base.EM.Product.Where(x => x.ProductActualDiscount >= 15).ToList();
                      break;
              }

           

              // Фильтрация по имени

              if (textBoxSearchName.Text != " " && textBoxSearchName.Text != "")
              {
                  listProduct = listProduct.Where(x => x.ProductName.ToLower().Contains(textBoxSearchName.Text.ToLower())).ToList();
              }
            /*

           // Фильтрация по описанию

           if (textBoxSearchDescription.Text != " " && textBoxSearchDescription.Text != "")
           {
               listProduct = listProduct.Where(x => x.Title.ToLower().Contains(textBoxSearchDescription.Text.ToLower())).ToList();
           }
         */

            // Сортировка по возрастанию и убыванию
            if (comboBoxSort.SelectedIndex == 1)
            {

                listProduct.Sort((x, y) => x.ProductCostWithDiscount.CompareTo(y.ProductCostWithDiscount));

            }
            else if (comboBoxSort.SelectedIndex == 2)
            {
                listProduct.Sort((x, y) => x.ProductCostWithDiscount.CompareTo(y.ProductCostWithDiscount));
                listProduct.Reverse();
            }


            // Отображение листа в ListView

            listView.ItemsSource = listProduct;

            // Вывод кол-ва туров
            

            textBlockCountShow.Text = listProduct.Count.ToString();
            textBlockAllCount.Text = Classes.Base.EM.Product.ToList().Count.ToString();

            if (listProduct.Count == 0)
            {
                 MessageBox.Show("Мы не нашли таких товаров. Попробуйте поискать что-то ещё", "Нет товаров",
                   MessageBoxButton.OK, MessageBoxImage.Information);
            }      
        }

        private void comboBoxDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (f < 2)
                f++;
            else
                sortData();
        }

        private void textBoxSearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            sortData();
        }
        private void comboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (f != 0)
                sortData();
            else f++;
        }

       

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            DataBase.Product product = (DataBase.Product) listView.SelectedItem;
            //DataBase.Product product = Classes.Base.EM.Product.FirstOrDefault(x => x.)
            btnGotoOrder.Visibility = Visibility.Visible;

            korzina.Add(product);


            DataBase.OrderProduct orderProduct = new DataBase.OrderProduct();

            orderProduct.OrderID = 54;
            orderProduct.ProductArticleNumber = product.ProductArticleNumber;
            orderProduct.OrderCount = 1;

            try
            { 
                Classes.Base.EM.OrderProduct.Add(orderProduct);
                Classes.Base.EM.SaveChanges();
            }
            catch
            {

            }
            tbKorzina.Text = "В заказе " +  korzina.Count.ToString() + " товара";
        }


        private void btnGotoOrder_Click(object sender, RoutedEventArgs e) // Перейти к заказу
        {        
            Classes.GlobalValues.listOrder = korzina;
            NavigationService.Navigate(new PageOrder());
        }

        private void btnGotoAllOrders_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAllOrders());
        }
    }

}
