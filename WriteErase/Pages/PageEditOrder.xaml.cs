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
            tbOrderDate.Text =  order.OrderDate.ToString();
            tbDelDate.Text = order.OrderDeliveryDate.ToString();

        }
    }
}
