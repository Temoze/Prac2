using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using Prac1.SampleDatabaseDataSetTableAdapters;

namespace Prac1
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        OrderDetailsTableAdapter OrderDetails = new OrderDetailsTableAdapter();

        public Page1()
        {
            InitializeComponent();
            OrderDetailsDataGrid.ItemsSource = OrderDetails.GetData();
            OrderDetailsDataGrid.DisplayMemberPath = "OrderDetails_name";
        }

        private void Page1Add_Click(object sender, RoutedEventArgs e)
        {
            int orderDetailsID = int.Parse(OrderDetailsIDTextBox.Text);
            int orderID = int.Parse(OrderIDTextBox.Text);
            string productName = ProductNameTextBox.Text;
            int quantity = int.Parse(QuantityTextBox.Text);
            decimal price = decimal.Parse(PriceTextBox.Text);

            OrderDetails.InsertQuery(orderDetailsID, orderID, productName, quantity, price);
            OrderDetailsDataGrid.ItemsSource = OrderDetails.GetData();
        }

        private void Page1Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (OrderDetailsDataGrid.SelectedItem as DataRowView).Row[0];
            OrderDetails.DeleteQuery(Convert.ToInt32(id));
            OrderDetailsDataGrid.ItemsSource = OrderDetails.GetData();
        }

        private void Page1Update_Click(object sender, RoutedEventArgs e)
        {
            
            
            object id = (OrderDetailsDataGrid.SelectedItem as DataRowView).Row[0];
            OrderDetails.UpdateOrderID(Convert.ToInt32(OrderIDUpdateTextBox.Text), Convert.ToInt32(id));
            OrderDetails.UpdateProduct(ProductNameUpdateTextBox.Text, Convert.ToInt32(id));
            OrderDetails.UpdateQuantity(Convert.ToInt32(QuantityUpdateTextBox.Text), Convert.ToInt32(id));
            OrderDetails.UpdatePrice(Convert.ToInt32(PriceUpdateTextBox.Text), Convert.ToInt32(id));
            OrderDetailsDataGrid.ItemsSource = OrderDetails.GetData();
        }
    }
}