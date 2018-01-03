using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;
namespace ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            MyBL TheBL;
            int userInput = 0;
            do
            {
                userInput = DisplayMenu();

                #region switch case
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Case 1. addNanny ");
                        Console.WriteLine("Case 1. addNanny ");

                        Nanny myNanny = new Nanny()
                        TheBL.addNanny;
                        break;
                    case 2:
                        Console.WriteLine("2. deleteNanny(Nanny nan)");
                        break;
                    case 3:
                        Console.WriteLine("3. updateNannyDetalis(Nanny nan)");
                        break;
                    case 4:
                        Console.WriteLine("4. addMother(Mother mom)");                 
                        break;
                    case 5:
                        Console.WriteLine("5. deleteMother(Mother mom)");
                        break;
                    case 6:
                        Console.WriteLine("6. updateMotherDetalis(Mother mom)");
                        break;
                    case 7:
                        Console.WriteLine("7. addChild(Child ch)");
                        break;
                    case 8:
                        Console.WriteLine("8. deleteChild(Child ch)");
                        break;
                    case 9:
                        Console.WriteLine("9. updateChildDetalis(Child ch)");
                        break;
                    case 10:
                        Console.WriteLine("10. addContract(Contract co)");
                        break;
                    case 11:
                        Console.WriteLine("11. deleteContract(Contract co)");
                        break;
                    case 12:
                        Console.WriteLine("12. updateContractDetalis(Contract co)");
                        break;
                    case 13:
                        Console.WriteLine("Case 13. Exit");
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                } 
                #endregion
            } while (userInput != 13);
        }
        static public int DisplayMenu()
        {
            Console.WriteLine("Nanny Manager");
            Console.WriteLine();
            Console.WriteLine("1. addNanny(Nanny nan)");
            Console.WriteLine("2. deleteNanny(Nanny nan)");
            Console.WriteLine("3. updateNannyDetalis(Nanny nan)");                   
            Console.WriteLine("4. addMother(Mother mom)");
            Console.WriteLine("5. deleteMother(Mother mom)");
            Console.WriteLine("6. updateMotherDetalis(Mother mom)");               
            Console.WriteLine("7. addChild(Child ch)");
            Console.WriteLine("8. deleteChild(Child ch)");
            Console.WriteLine("9. updateChildDetalis(Child ch)");               
            Console.WriteLine("10. addContract(Contract co)");
            Console.WriteLine("11. deleteContract(Contract co)");
            Console.WriteLine("12. updateContractDetalis(Contract co)");
            Console.WriteLine("13. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
        static public Person addPerson()
        {
            string inID, infirst_name, inlast_name; DateTime inBirthday;
            Console.WriteLine("please enter ID ");
            Console.ReadLine.inID();
            Console.WriteLine("please enter first_name ");
            Console.WriteLine("please enter last_name ");
            Console.WriteLine("please enter Birthday ");
            Person thisPerson = new Person(inID, infirst_name, inlast_name, inBirthday) { };
            //why do we need new? again? and what is the syintax?
             public Person(string inID, string infirst_name, string inlast_name, DateTime inBirthday)
        {
            ID = inID; firstName = infirst_name; lastName = inlast_name; Birthday = inBirthday;
        }
    }
    }
}