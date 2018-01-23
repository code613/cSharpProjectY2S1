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
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        IBL TheBL;
        Mother selectedMother;
        Nanny updateNanny;
        Child selectedChild;
        int flag;//globel to this scope (i hope)

        public UpdateWindow(personsEnum thePerson)
        {
            InitializeComponent();
            TheBL = BLFactory.getBL();
           // switch 
            IDComboBox.ItemsSource = TheBL.getListOfMothers();//for mother obvesly
            upButton.Content = "Update Mother";
            headerLabel.Content = "double click the Mother's ID to update";
            flag = 1;//need double click and switch

            IDComboBox.ItemsSource = TheBL.getListOfChildren();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(flag == 1)//oh but i was supposed to do double click
            selectedMother = IDComboBox.SelectedItem as Mother;
            
        }

        private void IDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (flag == 3)
            {
                //selectedChild = IDComboBox.SelectedItem as Child;
            }
        }
    }
}
