using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
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
using wpf4.GymDataSetTableAdapters;

namespace wpf4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class PageCustomer : Page
    {
        customerTableAdapter customer = new customerTableAdapter();
        public PageCustomer()
        {
            InitializeComponent();
            CustomerDataGrid.ItemsSource = customer.GetData();
            CustomerCbx.ItemsSource = customer.GetData();
            CustomerCbx.DisplayMemberPath = "firstname";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomerCbx.SelectedItem != null)
            {
                var firstname = (string)(CustomerCbx.SelectedItem as DataRowView).Row[1];
                CustomerDataGrid.ItemsSource = customer.FilterByFirstname(firstname);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomerDataGrid.ItemsSource = customer.SearchByName(SearchTxt.Text);
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CustomerDataGrid.ItemsSource = customer.GetData();
        }
    }
}

