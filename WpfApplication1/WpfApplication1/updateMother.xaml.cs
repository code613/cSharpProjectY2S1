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
    /// Interaction logic for updateMother.xaml
    /// </summary>
    public partial class updateMother : Window
    {
        IBL TheBL;
        Mother selectedMother;

        public updateMother()
        {
            InitializeComponent();
            TheBL = BLFactory.getBL();
            idMotherComboBox.ItemsSource = TheBL.getListOfMothers();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //idMotherComboBox.IsEnabled = false;
            //firstUpdateButton.Visibility = Visibility.Hidden;
            //grid1.DataContext = selectedMother;
            //firstPicture.Visibility = Visibility.Hidden;
            //grid1.Visibility = Visibility.Visible;
            //SecondPicture.Visibility = Visibility.Visible;
            //thirdPicture.Visibility = Visibility.Visible;
            //UpdateMotherButton.Visibility = Visibility.Visible;
            //SetTime(selectedMother.Day_of_keep[0], startSundayTime, endSundayTime);
            //SetTime(selectedMother.Day_of_keep[1], startMondayTime, endMondayTime);
            //SetTime(selectedMother.Day_of_keep[2], startTuesdayTime, endTuesdayTime);
            //SetTime(selectedMother.Day_of_keep[3], startWednesdayTime, endWednesdayTime);
            //SetTime(selectedMother.Day_of_keep[4], startThursdayTime, endThursdayTime);
            //SetTime(selectedMother.Day_of_keep[5], startFridayTime, endFridayTime);
        }

        private void idMotherComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedMother = idMotherComboBox.SelectedItem as Mother;
        }

    }
}
