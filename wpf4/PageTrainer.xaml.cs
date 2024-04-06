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
    public partial class PageTrainer : Page
    {
        trainerTableAdapter trainer = new trainerTableAdapter();
        public PageTrainer()
        {
            InitializeComponent();
            TrainerDataGrid.ItemsSource = trainer.GetData();
            TrainerCbx.ItemsSource = trainer.GetData();
            TrainerCbx.DisplayMemberPath = "firstname";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TrainerCbx.SelectedItem != null)
            {
                var firstname = (string)(TrainerCbx.SelectedItem as DataRowView).Row[1];
                TrainerDataGrid.ItemsSource = trainer.FilterByTrainerFirstname(firstname);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TrainerDataGrid.ItemsSource = trainer.SearchByTrainer(SearchTxt.Text);
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TrainerDataGrid.ItemsSource = trainer.GetData();
        }
    }
}

