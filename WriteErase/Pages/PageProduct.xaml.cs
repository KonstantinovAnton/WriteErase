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
      
        public PageProduct()
        {
            InitializeComponent();


            listView.ItemsSource = Classes.Base.EM.Product.ToList();
            comboBoxSort.SelectedIndex = 0;
            comboBoxDiscount.SelectedIndex = 0;

            textBlockCountShow.Text = Classes.Base.EM.Product.ToList().Count.ToString();
            textBlockAllCount.Text = Classes.Base.EM.Product.ToList().Count.ToString();
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
            List<DataBase.Product> listProduct = new List<DataBase.Product>();
           

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
         
            sortData();
        }

        private void textBoxSearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            sortData();
        }
        private void comboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sortData();
        }
    }

}
