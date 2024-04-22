using Prac1.SampleDatabaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Prac1
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        OrdersTableAdapter Orders = new OrdersTableAdapter();
        public Page2()
        {
            InitializeComponent();
            OrdersDataGrid.ItemsSource = Orders.GetData();
            OrdersDataGrid.DisplayMemberPath = "Orders_name";
        }
        private void Page2Add_Click(object sender, RoutedEventArgs e)
        {
            int OrderID = int.Parse(OrderIDTextBox.Text);
            int UsersID = int.Parse(UsersIDTextBox.Text);
            string OrderDate = OrderDateTextBox.Text;
            int TotalAmount = int.Parse(TotalAmountTextBox.Text);


            Orders.InsertQuery(OrderID, UsersID, OrderDate, TotalAmount);
            OrdersDataGrid.ItemsSource = Orders.GetData();
        }
        private void Page2Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (OrdersDataGrid.SelectedItem as DataRowView).Row[0];
            Orders.DeleteQuery(Convert.ToInt32(id));
            OrdersDataGrid.ItemsSource = Orders.GetData();
        }
        private void Page2Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (OrdersDataGrid.SelectedItem as DataRowView).Row[0];
            Orders.UpdateUserID(Convert.ToInt32(UsersIDUpdateTextBox.Text), Convert.ToInt32(id));
            Orders.UpdateOrderDate(OrderDateUpdateTextBox.Text, Convert.ToInt32(id));
            Orders.UpdateTotalAmount(Convert.ToInt32(TotalAmountUpdateTextBox.Text), Convert.ToInt32(id));
            OrdersDataGrid.ItemsSource = Orders.GetData();
        }
    }
}
