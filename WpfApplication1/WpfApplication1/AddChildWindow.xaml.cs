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

namespace PL
{
    /// <summary>
    /// Interaction logic for AddChildWindow.xaml
    /// </summary>
    public partial class AddChildWindow : Window
    {
        
        IBL bl;
        Child child;
        
        public AddChildWindow()
        {
           InitializeComponent();
           child = new Child();
           this.DataContext = child;
           bl = BLFactory.getBL();
           motherIdComboBox.ItemsSource = bl.getListOfMothers();
        }
        public AddChildWindow(Child child)
        {
            InitializeComponent();
            this.DataContext = child;
            AddChildButton.Content = "update child";
            bl = BLFactory.getBL();
            motherIdComboBox.ItemsSource = bl.getListOfMothers();
        }


        private void AddChildButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(AddChildButton.Content.ToString() == "update child"))//lol make sure this is currect
            {
                try
                {
                    bl.addChild(child);
                    MessageBox.Show(child.firstName + " was successfully added\n" + bl.getListOfChildren(null).LastOrDefault().ToString());//what is this??
                    this.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
            else
            {
                try
                {
                    bl.updateChildDetalis(child);
                    MessageBox.Show(child.firstName + " was successfully updated \n" + bl.getListOfChildren(null).LastOrDefault().ToString());
                    this.Close();//wait is the abouve the curect thing to return
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }

        private void motherIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
