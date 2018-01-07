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
    /// Interaction logic for childNeedsWindow.xaml
    /// </summary>
    public partial class childNeedsWindow : Window
    {
        public string data;
        public bool yesNeeds = false;//is this a mistake??
        public childNeedsWindow()
        {
            InitializeComponent();
        }

        //private void button_Click(object sender, RoutedEventArgs e)//where dose this get returnd to??
        //{//this returns TextBlock instead of void changed back (i don't know what it means to return 
        //    //a textblock
        //   // return textBlockData;
        //}//i don't think this dose anything (anymore)

        private void button_ClickSave(object sender, RoutedEventArgs e)
        {
            data = textBlockData.Text;
            if(data != null)
            {
                yesNeeds = true;
                Close();//put here not below so not to close if pushed yes with nothing inside
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
