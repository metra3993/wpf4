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
    public partial class PageSeasonticketEF : Page
    {
        private GymEntities seasonticket = new GymEntities();
        public PageSeasonticketEF()
        {
            InitializeComponent();
            SeasonticketEFDataGrid.ItemsSource = seasonticket.seasonticket.ToList();
            SeasonticketEFCbx.ItemsSource = seasonticket.seasonticket.ToList();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SeasonticketEFCbx.SelectedItem != null)
            {
                var selected = SeasonticketEFCbx.SelectedItem as seasonticket;
                SeasonticketEFDataGrid.ItemsSource = seasonticket.seasonticket.ToList().Where(seasonticket => seasonticket.term == selected.term);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SeasonticketEFDataGrid.ItemsSource = seasonticket.seasonticket.ToList().Where(seasonticket => seasonticket.term.Contains(SearchTxt.Text));
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SeasonticketEFDataGrid.ItemsSource = seasonticket.seasonticket.ToList();
        }
    }
}
