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
        Nanny updateNanny;
        Child selectedChild;
        int flag;//globel to this scope (i hope)


        public UpdateWindow(personsEnum.typeOfPerson thePerson)
        {
            InitializeComponent();
            TheBL = BLFactory.getBL();
           // switch 
                
          switch (thePerson)
          {
              case personsEnum.typeOfPerson.nanny1:
                    IDComboBox.ItemsSource = TheBL.getListOfNannies();
                 //   upButton.Content = "Update Nanny";
                    headerLabel.Content = "double click the Nanny's ID to update";
                    flag = 1;//need double click and switch 
                    //need a thread?? like will this flag save .. it should
                    break;
              case personsEnum.typeOfPerson.mother2:
                IDComboBox.ItemsSource = TheBL.getListOfMothers();//for mother obvesly
               // upButton.Content = "Update Mother";
                headerLabel.Content = "double click the Mother's ID to update";
                flag = 2;//need double click and switch
                  break;
              case personsEnum.typeOfPerson.child3:
                IDComboBox.ItemsSource = TheBL.getListOfChildren();
                //   upButton.Content = "Update Child";
                headerLabel.Content = "double click the Child's ID to update";
                flag = 2;//need double click and switch
                    break;
          }
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if(flag == 1)//oh but i was supposed to do double click
        //    selectedMother = IDComboBox.SelectedItem as Mother;
            
        //}

        private void IDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (flag == 3)
            {
                //selectedChild = IDComboBox.SelectedItem as Child;
            }
        }
        object _lastObject = null;
        DateTime _lastPressed = DateTime.MinValue;
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
          
            TimeSpan ts = new TimeSpan(1,1,1);
            if (_lastObject != null && _lastPressed != null)
            {
                ts = DateTime.Now - _lastPressed;
                if (ts.Milliseconds < 500  && sender.Equals(_lastObject))
                {
                    MessageBox.Show("Double clicked");
                    switch (flag)
                    {
                        case 1:
                            //nanny

                            break;
                        case 2:
                            //mother

                            break;
                        case 3:
                            //child
                            selectedChild = IDComboBox.SelectedItem as Child;
                            Window updateTC = new AddChildWindow(selectedChild);
                            break;
                    }
                }
            }
            _lastObject = sender;
            _lastPressed = DateTime.Now;
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