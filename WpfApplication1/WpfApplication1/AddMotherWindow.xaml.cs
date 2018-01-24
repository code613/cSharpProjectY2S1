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

        public AddMotherWindow(Mother mother)
        {
            InitializeComponent();
            this.DataContext = mother;
            AddMotherButton.Content = "update mother";
            bl = BLFactory.getBL();
        }

        private void AddMotherButton_Click(object sender, RoutedEventArgs e)
        {
            if(!(AddMotherButton.Content.ToString() == "update mother"))
            try
            {
                mother = new Mother();
                SetTime(mother.serviseNeededTimeTable[0], startSundayTime, endSundayTime);
                SetTime(mother.serviseNeededTimeTable[1], startMondayTime, endMondayTime);
                SetTime(mother.serviseNeededTimeTable[2], startTuesdayTime, endTuesdayTime);
                SetTime(mother.serviseNeededTimeTable[3], startWednesdayTime, endWednesdayTime);
                SetTime(mother.serviseNeededTimeTable[4], startThursdayTime, endThursdayTime);
                SetTime(mother.serviseNeededTimeTable[5], startFridayTime, endFridayTime);
                bl.addMother(mother);
                System.Windows.MessageBox.Show("mother added succesfuly:", mother.ToString() );
                Close();
            }
            catch (Exception x)
            {
                System.Windows.MessageBox.Show(x.Message);
            }
            else
            {

                try
                {
                    SetTime(mother.serviseNeededTimeTable[0], startSundayTime, endSundayTime);
                    SetTime(mother.serviseNeededTimeTable[1], startMondayTime, endMondayTime);
                    SetTime(mother.serviseNeededTimeTable[2], startTuesdayTime, endTuesdayTime);
                    SetTime(mother.serviseNeededTimeTable[3], startWednesdayTime, endWednesdayTime);
                    SetTime(mother.serviseNeededTimeTable[4], startThursdayTime, endThursdayTime);
                    SetTime(mother.serviseNeededTimeTable[5], startFridayTime, endFridayTime);
                    bl.addMother(mother);
                    System.Windows.MessageBox.Show("mother added succesfuly:", mother.ToString());
                    Close();
                    bl.updateMotherDetalis(mother);
                    System.Windows.MessageBox.Show("mother succesfuly updated :", mother.ToString());
                    Close();
                }
                catch (Exception x)
                {
                    System.Windows.MessageBox.Show(x.Message);
                }
            }

        }
       
        
        private void SetTime( DayOfWork ts, TimePicker tp1, TimePicker tp2)
        {
            if (tp1.Value != null && tp2.Value != null)
            {
                ts.start = tp1.Value.Value.TimeOfDay;
                ts.end = tp2.Value.Value.TimeOfDay;
            }
        }
    }
}
