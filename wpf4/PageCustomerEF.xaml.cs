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

namespace wpf4
{
    /// <summary>
    /// Логика взаимодействия для PageCustomerEF.xaml
    /// </summary>
    public partial class PageCustomerEF : Page
    {
        private GymEntities customer = new GymEntities();
        public PageCustomerEF()
        {
            InitializeComponent();
            CustomerEFDataGrid.ItemsSource = customer.customer.ToList();
            CustomerEFCbx.ItemsSource = customer.trainer.ToList();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CustomerEFCbx.SelectedItem != null) 
            {
                var selected = CustomerEFCbx.SelectedItem as trainer;
                int selectedtrainerId = selected.ID_trainer;
                CustomerEFDataGrid.ItemsSource = customer.customer.Where(customer => customer.ID_trainer == selectedtrainerId).ToList();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            CustomerEFDataGrid.ItemsSource = customer.customer.ToList().Where(customer => customer.firstname.Contains(SearchTxt.Text));
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CustomerEFDataGrid.ItemsSource=customer.customer.ToList();
        }
    }
}
