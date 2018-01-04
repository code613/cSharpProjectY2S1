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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ChildDetailsWindow.xaml
    /// </summary>
    public partial class ChildDetailsWindow : Window
    {
        public string momID;
        private static string specailNeedsData;//is this ok as static??
        public bool childHasSpecailNeeds = false;
        public string finishSpecalData;
        public ChildDetailsWindow()
        {
            InitializeComponent();
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            childNeedsWindow need = new childNeedsWindow();
            need.Show();
            if (need.yesNeeds) {
                specailNeedsData = need.data;//inorder to accses data couldn't have been static
                childHasSpecailNeeds = true;//will this stay??
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void finishButton_Click(object sender, RoutedEventArgs e)
        {
            momID = textBox.Text;
            finishSpecalData = specailNeedsData;//wait so what happens if non? is it null?
        }
    }
}
