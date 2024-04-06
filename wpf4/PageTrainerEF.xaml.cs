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
    public partial class PageTrainerEF : Page
    {
        private GymEntities trainer = new GymEntities();
        public PageTrainerEF()
        {
            InitializeComponent();
            TrainerEFDataGrid.ItemsSource = trainer.trainer.ToList();
            TrainerEFCbx.ItemsSource = trainer.trainer.ToList();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TrainerEFCbx.SelectedItem != null)
            {
                var selected = TrainerEFCbx.SelectedItem as trainer;
                int selectedtrainerId = selected.ID_trainer;
                TrainerEFDataGrid.ItemsSource = trainer.trainer.Where(trainer => trainer.ID_trainer == selectedtrainerId).ToList();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            TrainerEFDataGrid.ItemsSource = trainer.trainer.ToList().Where(trainer => trainer.firstname.Contains(SearchTxt.Text));
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TrainerEFDataGrid.ItemsSource = trainer.trainer.ToList();
        }
    }
}
