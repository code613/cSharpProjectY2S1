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
    /// Interaction logic for AddContractWindow.xaml
    /// </summary>
    public partial class AddContractWindow : Window
    {
        IBL bl;
        Contract contract;
        public AddContractWindow()
        {
            InitializeComponent();
            contract = new Contract();
            this.DataContext = contract;
            bl = BLFactory.getBL();
            
        }

       

        private void AddContractButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addContract(contract);
                MessageBox.Show(bl.getListOfContracts(null).LastOrDefault().ToString());
                Close();
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
