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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for NannyDetailsWindow.xaml
    /// </summary>
    public partial class NannyDetailsWindow : Window
    {
        public string Windowphone;
        public string WindowAddress;
        public bool Windowelevator;
        public int Windowfloor;
        public int Windowexperience;
        public int Windowmax_kids;
        public int WindowMinAge;
        public int WindowMaxAge;
        public bool WindowisPerHour;
        public float WindowHourSalary;
        public float WindowMonthSalary;
        public bool[] WindowWorkWeek = new bool[7];
        public DateTime[][] WindowTimeTable = new DateTime[2][];
        public bool WindowGovVacation;
        public string WindowReferences;

        public NannyDetailsWindow()
        {
            InitializeComponent();
        }

        private void finishButton_Click(object sender, RoutedEventArgs e)
        {
            //adding changes??

        }
        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            text1.Text = "The CheckBox is checked.";
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
            text1.Text = "The CheckBox is unchecked.";
        }

        private void HandleThirdState(object sender, RoutedEventArgs e)
        {
            text1.Text = "The CheckBox is in the indeterminate state.";
        }

        private void HourRateHandleCheck(object sender, RoutedEventArgs e)
        {

        }
    }
}
