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
using BE;
using BL;
using Xceed.Wpf.Toolkit;


namespace PL
{
    /// <summary>
    /// Interaction logic for AddMotherWindow.xaml
    /// </summary>
    /// 


    public partial class AddMotherWindow : Window
    {
        IBL bl;
        Mother mother;
        public AddMotherWindow()
        {
            InitializeComponent();
            mother = new Mother();
            this.DataContext = mother;
            bl = BLFactory.getBL();

        }

        private void AddMotherButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTime(mother.daysNeedNanny[0], startSundayTime, endSundayTime);
                SetTime(mother.daysNeedNanny[1], startMondayTime, endMondayTime);
                SetTime(mother.daysNeedNanny[2], startTuesdayTime, endTuesdayTime);
                SetTime(mother.daysNeedNanny[3], startWednesdayTime, endWednesdayTime);
                SetTime(mother.daysNeedNanny[4], startThursdayTime, endThursdayTime);
                SetTime(mother.daysNeedNanny[5], startFridayTime, endFridayTime);
                bl.addMother(mother);
                System.Windows.MessageBox.Show(mother.ToString(), "This mother has been added:");
                Close();
            }
            catch (Exception)
            {

                throw;
            }

        }
        Mother m;
        
        private void SetTime(m. DayOfWork ts, TimePicker tp1, TimePicker tp2)
        {
            if (tp1.Value != null && tp2.Value != null)
            {
                ts.start = tp1.Value.Value.TimeOfDay;
                ts.end = tp2.Value.Value.TimeOfDay;
            }
        }

    }
}
