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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyBL TheBL;
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "premeir nanny Hiring enterprise";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }


        private void ButtonToAddChild_Click(object sender, RoutedEventArgs e)
        {
            Child theChild;
            Person tempPer ;
            //MessageBox.Show("please fill in the child's details");
          //  this.Close();//i don't understand .. where are we commanding it to butten. close.??
            personDeitailsWindow per = new personDeitailsWindow();
            per.ShowDialog();//i think i need this to open up the window after it was created above
            tempPer = per.temp;//how dose this work ?? with a copyconstructer??
            #region threeMonthSaga commented out
            //bool Month3flag;
            //do
            //{
            //    Month3flag = false;
            //    personDeitailsWindow per = new personDeitailsWindow();
            //    per.Show();//i think i need this to open up the window after it was created above
            //    if (TheBL.is3Month(per.temp))
            //    {
            //        Month3flag = true;
            //        MessageBoxResult result = MessageBox.Show("please relize that the child is under 3 months and therfor won't be able to be inside a contract/n do you wish to cuntinue?"
            //            , "Are You Shore?", MessageBoxButton.YesNo);
            //        switch (result)
            //        {
            //            case MessageBoxResult.Yes:
            //                Month3flag = false;
            //                tempPer = per.temp;
            //                break;
            //            case MessageBoxResult.No:
            //                MessageBox.Show("please refill in the child's details");
            //                break;
            //        }
            //    }
            //    else
            //        tempPer = per.temp;//how dose this work ?? with a copyconstructer??
            //} while (Month3flag); 
            #endregion
            ChildDetailsWindow childDet = new ChildDetailsWindow();
            childDet.Show();//open's the other window(?!?)
            theChild = new Child(tempPer.ID, tempPer.firstName, tempPer.Birthday, TheBL.findMother(childDet.momID),
                childDet.childHasSpecailNeeds, childDet.finishSpecalData);//humm wounder if can do some defoult here?
            MessageBox.Show("CONGRADUALTINS!! welcome {0} to nanny care center ", tempPer.firstName);
            this.Close();
            TheBL.addChild(theChild);
        }

        private void ButtonToAddContract_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonToAddNanny_Click(object sender, RoutedEventArgs e)
        {
            Nanny theNanny;
            Person tempPer;
            MessageBox.Show("please fill in the Nanny's details");
            this.Close();//i don't understand ..A there is a default butten to close a MessageBox??
            personDeitailsWindow per = new personDeitailsWindow();
            per.Show();//i think i need this to open up the window after it was created above
            tempPer = per.temp;//how dose this work ?? with a copyconstructer??

        }

        /* example of meesige box this example will help for initilzing a value of id 
private void validateUserEntry()
{

// Checks the value of the text.

if (serverName.Text.Length == 0)
{

// Initializes the variables to pass to the MessageBox.Show method.

string message = "You did not enter a server name. Cancel this operation?";
string caption = "Error Detected in Input";
MessageBoxButtons buttons = MessageBoxButtons.YesNo;
DialogResult result;

// Displays the MessageBox.

result = MessageBox.Show(message, caption, buttons);

if (result == System.Windows.Forms.DialogResult.Yes)
{

  // Closes the parent form.

  this.Close();

}

}

}*/
    }
}
