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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        UsersTableAdapter Users = new UsersTableAdapter();
        public Page3()
        {
            InitializeComponent();
            UsersDataGrid.ItemsSource = Users.GetData();
            UsersDataGrid.DisplayMemberPath = "Users_name";
        }
        private void Page3Add_Click(object sender, RoutedEventArgs e)
        {
            int UserID = int.Parse(UserIDTextBox.Text);
            string UserName = UserNameTextBox.Text;
            string Email = EmailTextBox.Text;


            Users.InsertQuery(UserID, UserName, Email);
            UsersDataGrid.ItemsSource = Users.GetData();
        }
        private void Page3Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (UsersDataGrid.SelectedItem as DataRowView).Row[0];
            Users.DeleteQuery1(Convert.ToInt32(id));
            UsersDataGrid.ItemsSource = Users.GetData();
        }
        private void Page3Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (UsersDataGrid.SelectedItem as DataRowView).Row[0];
            Users.UpdateUserName(UserNameUpdateTextBox.Text, Convert.ToInt32(id));
            Users.UpdateEmail(EmailUpdateTextBox.Text, Convert.ToInt32(id));
            UsersDataGrid.ItemsSource = Users.GetData();
        }
    }
}