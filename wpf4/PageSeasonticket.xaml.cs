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
    public partial class PageSeasonticket : Page
    {
        seasonticketTableAdapter seasonticket = new seasonticketTableAdapter();
        public PageSeasonticket()
        {
            InitializeComponent();
            SeasonticketDataGrid.ItemsSource = seasonticket.GetData();
            SeasonticketCbx.ItemsSource = seasonticket.GetData();
            SeasonticketCbx.DisplayMemberPath = "term";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SeasonticketCbx.SelectedItem != null)
            {
                var term = (string)(SeasonticketCbx.SelectedItem as DataRowView).Row[1];
                SeasonticketDataGrid.ItemsSource = seasonticket.FilterByTerm(term);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SeasonticketDataGrid.ItemsSource = seasonticket.SearchBySeasonticket(SearchTxt.Text);
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SeasonticketDataGrid.ItemsSource = seasonticket.GetData();
        }
    }
}

