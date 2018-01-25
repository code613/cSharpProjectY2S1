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
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        IBL TheBL;
        Mother selectedMother;
        Nanny selectedNanny;
        Child selectedChild;
        Contract selectedContract;
        int flag;//globel to this scope (i hope)

        //property wraper
        public int MyProperty //CLR property
        {
            get { return (int)GetValue(BensDependincyProperty); }
            set { SetValue(BensDependincyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BensDependincyProperty =
            DependencyProperty.Register("MyProperty", typeof(int), typeof(UpdateWindow), new PropertyMetadata(0));



        public UpdateWindow(personsEnum.typeOfPerson thePerson)
        {
            InitializeComponent();
            TheBL = BLFactory.getBL();
            DELButton.Visibility = Visibility.Hidden;
            slowButton.Visibility = Visibility.Hidden;
            setPic(thePerson);
            // switch 

            switch (thePerson)
            {
                case personsEnum.typeOfPerson.nanny1:
                    IDComboBox.ItemsSource = TheBL.getListOfNannies();
                    slowButton.Content = "Update Nanny";
                    headerLabel.Content = "double click the Nanny's ID to update";
                    flag = 1;
                    break;
                case personsEnum.typeOfPerson.mother2:
                    IDComboBox.ItemsSource = TheBL.getListOfMothers();//for mother obvesly
                    slowButton.Content = "Update Mother";
                    headerLabel.Content = "double click the Mother's ID to update";
                    flag = 2;//need double click and switch
                    break;
                case personsEnum.typeOfPerson.child3:
                    IDComboBox.ItemsSource = TheBL.getListOfChildren();
                    slowButton.Content = "Update Child";
                    headerLabel.Content = "double click the Child's ID to update";
                    flag = 3;//need double click and switch
                    break;
                case personsEnum.typeOfPerson.contract4:
                    IDComboBox.ItemsSource = TheBL.getListOfContracts();
                    headerLabel.Content = "double click on the Contract ID to update";
                    flag = 4;//need double click and switch
                    break;
                case personsEnum.typeOfPerson.nannyDelete5:
                    IDComboBox.ItemsSource = TheBL.getListOfNannies();
                    DELButton.Visibility = Visibility.Visible;
                    flag = 5;
                    break;
                case personsEnum.typeOfPerson.motherDelete6:
                    IDComboBox.ItemsSource = TheBL.getListOfMothers();
                    DELButton.Visibility = Visibility.Visible;
                    flag = 6;
                    break;
                case personsEnum.typeOfPerson.childDelete7:
                    IDComboBox.ItemsSource = TheBL.getListOfChildren();
                    headerLabel.Content = "click Child to delete";
                    DELButton.Visibility = Visibility.Visible;
                    flag = 7;
                    break;
                case personsEnum.typeOfPerson.contractDelete8:
                    IDComboBox.ItemsSource = TheBL.getListOfContracts();
                    DELButton.Visibility = Visibility.Visible;
                    flag = 8;
                    break;
            }
        }

        private void setPic(personsEnum.typeOfPerson thePerson)
        {
            switch (thePerson)
            {
                case personsEnum.typeOfPerson.nannyDelete5:
                case personsEnum.typeOfPerson.nanny1:
                    updateWindowThemePicture.Source = new BitmapImage(new Uri("./ resources / badCaretakerIMG.jpg", UriKind.Relative));
                    break;
                case personsEnum.typeOfPerson.motherDelete6:
                case personsEnum.typeOfPerson.mother2:
                    break;
                case personsEnum.typeOfPerson.childDelete7:
                case personsEnum.typeOfPerson.child3:
                    break;
                case personsEnum.typeOfPerson.contractDelete8:
                case personsEnum.typeOfPerson.contract4:

                    break;
                default://for numbers 5-8
                    break;
            }
        }

        private void IDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (flag)
            {
                case 1:
                case 5:
                    //nanny
                    selectedNanny = IDComboBox.SelectedItem as Nanny;
                    break;
                case 2:
                case 6:
                    //mother
                    selectedMother = IDComboBox.SelectedItem as Mother;
                    break;
                case 3:
                case 7:
                    //child
                    selectedChild = IDComboBox.SelectedItem as Child;
                    break;
                case 4:
                case 8:
                    selectedContract = IDComboBox.SelectedItem as Contract;
                    break;
                default://for numbers 5-8
                    break;
            }
        }
        #region double click combobox both for update and delete
        int count;
        object _lastObject = null;
        DateTime _lastPressed = DateTime.MinValue;
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_lastObject == sender && DELButton.Visibility == Visibility.Hidden) { count++; }
            else { count = 0; }
            if (count > 4) { slowButton.Visibility = Visibility.Visible; }
            TimeSpan ts = new TimeSpan(1, 1, 1);
            if (_lastObject != null && _lastPressed != null)
            {
                ts = DateTime.Now - _lastPressed;
                if (ts.Milliseconds < 500 && sender.Equals(_lastObject))
                {
                    openwindowActionFunction();
                    //MessageBox.Show("Double clicked");
                }
            }
            _lastObject = sender;//sender is the object
            //make flag += sender and if 5 time then make the update button pop up
            _lastPressed = DateTime.Now;
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {//delete button
            try
            {
                switch (flag)
                {
                    // selectedMother;
                    // selectedNanny;
                    // selectedChild;
                    // selectedContract;
                    case 1:
                    case 5:
                        var result = MessageBox.Show(selectedNanny.ToString(), "Are you sure you want to remove this Nanny?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            TheBL.deleteNanny(selectedNanny.ToString());
                            Close();
                        }
                        //WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
                        //player.URL = @"track.mp3";
                        //player.controls.play();
                        break;
                    case 2:
                    case 6:
                        var result2 = MessageBox.Show(selectedMother.ToString(), "Are you sure you want to remove this Mother?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result2 == MessageBoxResult.Yes)
                        {
                            TheBL.deleteMother(selectedMother.ToString());
                            Close();
                        }
                        break;
                    case 3:
                    case 7:
                        var result3 = MessageBox.Show(selectedChild.ToString(), "Are you sure you want to remove this child?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result3 == MessageBoxResult.Yes)
                        {
                            TheBL.deleteChild(selectedChild.ToString());
                            Close();
                        }
                        break;
                    case 4:
                    case 8:
                        var result4 = MessageBox.Show(selectedContract.ToString(), "Are you sure you want to remove this contract?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result4 == MessageBoxResult.Yes)
                        {
                            TheBL.deleteChild(selectedContract.ToString());
                            Close();
                        }
                        break;
                    default://for numbers 5-8
                        break;
                }
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }
        }

        private void slowButton_Click(object sender, RoutedEventArgs e)
        {//update button
            openwindowActionFunction();
        }
        private void openwindowActionFunction()
        {
            switch (flag)
            {
                case 1:
                    //nanny
                    selectedNanny = IDComboBox.SelectedItem as Nanny;
                    Window addNannyWindow = new AddNannyWindow(selectedNanny);
                    addNannyWindow.Show();
                    this.Close();
                    break;
                case 2:
                    //mother
                    selectedMother = IDComboBox.SelectedItem as Mother;
                    Window addMotherWindow = new AddMotherWindow(selectedMother);//make cunstruter that gets parameter update
                    addMotherWindow.Show();
                    this.Close();
                    break;
                case 3:
                    //child
                    selectedChild = IDComboBox.SelectedItem as Child;
                    Window updateTC = new AddChildWindow(selectedChild);
                    updateTC.Show();//so will keep this window open that means
                    this.Close();
                    break;
                case 4:
                    selectedContract = IDComboBox.SelectedItem as Contract;
                    Window addContractWindow = new AddContractWindow(selectedContract);
                    addContractWindow.Show();
                    this.Close();
                    break;
                default://for numbers 5-8
                    break;
            }
        }
    }
}

//public enum Color { Red, Green, Blue }

//public class Example
//{
//    public static void Main()
//    {
//        Color c = (Color)(new Random()).Next(0, 3);
//        switch (c)
//        {
//            case Color.Red:
//                Console.WriteLine("The color is red");
//                break;
//            case Color.Green:
//                Console.WriteLine("The color is green");
//                break;
//            case Color.Blue:
//                Console.WriteLine("The color is blue");
//                break;
//            default:
//                Console.WriteLine("The color is unknown.");
//                break;
//        }
//    }
//}
 //switch (thePerson)
 //         {
 //             case personsEnum.typeOfPerson.nanny1:
 //                   IDComboBox.ItemsSource = TheBL.getListOfNannies();
 //                   upButton.Content = "Update Nanny";
 //                   headerLabel.Content = "double click the Nanny's ID to update";
 //                   flag = 1;//need double click and switch 
 //                   //need a thread?? like will this flag save .. it should

 //                   break;
 //             case personsEnum.typeOfPerson.mother2:
 //               IDComboBox.ItemsSource = TheBL.getListOfMothers();//for mother obvesly
 //               upButton.Content = "Update Mother";
 //               headerLabel.Content = "double click the Mother's ID to update";
 //               flag = 2;//need double click and switch

 //                 break;
 //             case personsEnum.typeOfPerson.child3:
 //               IDComboBox.ItemsSource = TheBL.getListOfChildren();
 //                  upButton.Content = "Update Child";
 //               headerLabel.Content = "double click the Child's ID to update";
 //               flag = 2;//need double click and switch

 //                   break;