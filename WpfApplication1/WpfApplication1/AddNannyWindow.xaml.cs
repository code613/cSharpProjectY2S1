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
    /// Interaction logic for AddNannyWindow.xaml
    /// </summary>
    public partial class AddNannyWindow : Window
    {
        private Nanny selectedNanny;
        IBL bl;

        public AddNannyWindow()
        {
            InitializeComponent();
            this.DataContext = selectedNanny;
            AddNannyButton.Content = "update mother";
            bl = BLFactory.getBL();
        }

        public AddNannyWindow(Nanny selectedNanny)
        {
            this.selectedNanny = selectedNanny;
        }

        
        private void SetTime(DayOfWork ts, TimePicker tp1, TimePicker tp2)
        {
            if (tp1.Value != null && tp2.Value != null)
            {
                ts.start = tp1.Value.Value.TimeOfDay;
                ts.end = tp2.Value.Value.TimeOfDay;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                SetTime(selectedNanny.WorkWeek[0], startSundayTime, endSundayTime);
                SetTime(selectedNanny.WorkWeek[1], startMondayTime, endMondayTime);
                SetTime(selectedNanny.WorkWeek[2], startTuesdayTime, endTuesdayTime);
                SetTime(selectedNanny.WorkWeek[3], startWednesdayTime, endWednesdayTime);
                SetTime(selectedNanny.WorkWeek[4], startThursdayTime, endThursdayTime);
                SetTime(selectedNanny.WorkWeek[5], startFridayTime, endFridayTime);
                iDTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                bl.addNanny(selectedNanny);
                System.Windows.MessageBox.Show("mother added succesfuly:", selectedNanny.ToString());// bl.getListOfNannies.LastOrDefault().ToString());
                Close();
            }
            catch (Exception x)
            {
                System.Windows.MessageBox.Show(x.Message);
            }
        }

        private void SetTime(object p, TimePicker startSundayTime, TimePicker endSundayTime)
        {
            throw new NotImplementedException();
        }
    }
}
