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
using System.Windows.Shapes;
using BL;
using BE;

namespace PL
{
    /// <summary>
    /// Interaction logic for updateContract.xaml
    /// </summary>
    public partial class updateContract : Window
    {
        IBL TheBL;
        public Contract selectedContract;

        public updateContract()
        {
            InitializeComponent();
            TheBL = BLFactory.getBL();
            contractNumberComboBox.ItemsSource = TheBL.getListOfContracts();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //update.DataContext = selectedContract;
            //update.Visibility = Visibility.Visible;
            //contractNumberComboBox.IsEnabled = false;
        }

        private void contractNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedContract = contractNumberComboBox.SelectedItem as Contract;
        }
    }
}
