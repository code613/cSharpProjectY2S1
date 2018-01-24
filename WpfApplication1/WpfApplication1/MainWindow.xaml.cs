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

namespace PL
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL TheBL ;
        string  theTitle = "premeir Nanny Hiring enterprise";//how to make const?
        public MainWindow()
        {
            InitializeComponent();
            this.Title = theTitle;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TheBL = BLFactory.getBL();
        }


        private void SetVisibilty()
        {
            AddMother.Visibility = Visibility.Hidden;
            DeleteMother.Visibility = Visibility.Hidden;
            UpdateMother.Visibility = Visibility.Hidden;
            AddNanny.Visibility = Visibility.Hidden;
            DeleteNanny.Visibility = Visibility.Hidden;
            UpdateNanny.Visibility = Visibility.Hidden;
            AddChild.Visibility = Visibility.Hidden;
            DeleteChild.Visibility = Visibility.Hidden;
            UpdateChild.Visibility = Visibility.Hidden;
            AddContract.Visibility = Visibility.Hidden;
            DeleteContract.Visibility = Visibility.Hidden;
            UpdateContract.Visibility = Visibility.Hidden;
            MotherList.Visibility = Visibility.Hidden;
            NannyList.Visibility = Visibility.Hidden;
            ChildrenList.Visibility = Visibility.Hidden;

        }

        private void Mother_Click(object sender, RoutedEventArgs e)
        {
            SetVisibilty();
            AddMother.Visibility = Visibility.Visible;
            DeleteMother.Visibility = Visibility.Visible;
            UpdateMother.Visibility = Visibility.Visible; 
        }

        private void Nanny_Click(object sender, RoutedEventArgs e)
        {
            SetVisibilty();
            AddNanny.Visibility = Visibility.Visible;
            DeleteNanny.Visibility = Visibility.Visible;
            UpdateNanny.Visibility = Visibility.Visible;
        }

        private void Child_Click(object sender, RoutedEventArgs e)
        {
            SetVisibilty();
            AddChild.Visibility = Visibility.Visible;
            DeleteChild.Visibility = Visibility.Visible;
            UpdateChild.Visibility = Visibility.Visible;
        }

        private void Contract_Click(object sender, RoutedEventArgs e)
        {
            SetVisibilty();
            AddContract.Visibility = Visibility.Visible;
            DeleteContract.Visibility = Visibility.Visible;
            UpdateContract.Visibility = Visibility.Visible;
        }

        private void Data_Base_Click(object sender, RoutedEventArgs e)
        {
            SetVisibilty();
            MotherList.Visibility = Visibility.Visible;
            NannyList.Visibility = Visibility.Visible;
            ChildrenList.Visibility = Visibility.Visible;
        }

        #region child Button
        private void addChild_Click(object sender, RoutedEventArgs e)
        {
            Window addChildWindow = new AddChildWindow();
            addChildWindow.Show();
        }
        private void UpdateChild_Click(object sender, RoutedEventArgs e)
        {
            Window updateChildw = new UpdateWindow(personsEnum.typeOfPerson.child3);
            //Window updateChildw = new updateChild();
            updateChildw.Show();
        }
        private void DeleteChild_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        #region mother Button
        private void addMother_Click(object sender, RoutedEventArgs e)
        {
            Window addMotherWindow = new AddMotherWindow();//make cunstruter that gets parameter update
            addMotherWindow.Show();
        }
        private void UpdateMother_Click(object sender, RoutedEventArgs e)
        {
            Window updateTheMother = new UpdateWindow(personsEnum.typeOfPerson.mother2);
           // Window updateTheMother = new updateMother();
            updateTheMother.Show();
        }
        private void DeleteMother_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        #region Nanny Button
        private void addNanny_Click(object sender, RoutedEventArgs e)
        {
            Window addNannyWindow = new AddNannyWindow();
            addNannyWindow.Show();
        }
        private void UpdateNanny_Click(object sender, RoutedEventArgs e)
        {
            Window updateTheNanny = new UpdateWindow(personsEnum.typeOfPerson.nanny1);
            //Window updateTheNanny = new UpdateNanny();
            updateTheNanny.Show();
        }
        private void DeleteNanny_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        #region Contract Button
        private void addContract_Click(object sender, RoutedEventArgs e)
        {
            Window addContractWindow = new AddContractWindow();
            addContractWindow.Show();
        }
        private void UpdateContract_Click(object sender, RoutedEventArgs e)
        {
            Window updateTheContract = new UpdateWindow(personsEnum.typeOfPerson.contract4);
            updateTheContract.Show();
        }
        private void DeleteContract_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        #region Data Base Button
        private void MotherList_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ChildrenList_Click(object sender, RoutedEventArgs e)
        {

        }
        private void NannyList_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion


        /* example of meesige box this example will help for initilzing a value of id 
private void validateUserEntry()
{
    //    private void AddChild_Click(object sender, RoutedEventArgs e)
    //    {
    //        Child theChild;
    //        Person tempPer  = personWindow();//get person window
    //        if (tempPer == null) { return; }//if exit of window then returns as detils not filled in
    //        theChild = theChildWindow(tempPer);//get child window (w/o mistakes)
    //        if (theChild == null) { return; }
    //        MessageBox.Show("CONGRADUALATIONS!! welcome {0} to {1} ", tempPer.firstName);//, theTitle);
    //        TheBL.addChild(theChild);
    //    }

    //    private Child theChildWindow(Person tempPer)
    //    {
    //bool flag = false;
    //do
    //{
    //     try
    //     {
    //        ChildDetailsWindow childDet = new ChildDetailsWindow();
    //        childDet.ShowDialog();//open's the other window(?!?)//becouse of Dialog()??
    //        Mother mom = TheBL.findMother(childDet.momID);
    //       if (mom != null)
    //       {
    //            Child theChild = new Child(tempPer.ID, tempPer.firstName, tempPer.Birthday, TheBL.findMother(childDet.momID),
    //                childDet.childHasSpecailNeeds, childDet.finishSpecalData);//humm wounder if can do some defoult here?
    //            return theChild;
    //       }
    //        else
    //        {
    //                  throw new Exception ("Error mother ID is not found (or not typed in properly)");
    //        }
    //            }
    //            catch (Exception err)
    //            {
    //             MessageBox.Show(err.Message);//need yes and no if no the return else flag = true 
    //                return null;
    //            }  
    //        } while (flag);
    //    }
    //    private Person personWindow()
    //    {
    //        personDeitailsWindow per = new personDeitailsWindow();
    //        per.ShowDialog();//i think i need this to open up the window after it was created above
    //        return per.temp;//how dose this work ?? with a copyconstructer??
    //    }

    //    private void ButtonToAddContract_Click(object sender, RoutedEventArgs e)
    //    {

    //    }

        //private void ButtonToAddNanny_Click(object sender, RoutedEventArgs e)
        //{
        //    Nanny theNanny;
        //    Person tempPer = personWindow();
        //    if (tempPer == null) { return; }

        //}
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Mother theMother;
        //    Person tempPer = personWindow();
        //    if (tempPer == null) { return; }
        //}

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
