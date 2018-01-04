using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;



namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string ID, first_name, last_name;
            DateTime birthday;
            MyBL bl=new MyBL();
            int choice;
            Console.WriteLine("enter 1 to add nanny");
            Console.WriteLine("enter 2 to update nanny");
            Console.WriteLine("enter 3 to remove nanny");
            Console.WriteLine("enter 4 to add child");
            Console.WriteLine("enter 5 to update child");
            Console.WriteLine("enter 6 to remove child");
            Console.WriteLine("enter 7 to add mother");
            Console.WriteLine("enter 8 to update mother");
            Console.WriteLine("enter 9 to remove mother");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("enter nanny details: id  first_name last_name and Birthday");
                    ID=Console.ReadLine();
                    first_name = Console.ReadLine();
                    last_name = Console.ReadLine();
                    birthday =DateTime.Parse( Console.ReadLine());
                    Nanny nan =new Nanny ();
                    bl.addNanny(nan);
                        break;
               /* case 2:
                    Console.WriteLine("enter nanny details: id  first_name last_name and Birthday");
                    ID = Console.ReadLine();
                    first_name = Console.ReadLine();
                    last_name = Console.ReadLine();
                    birthday = DateTime.Parse(Console.ReadLine());
                    Nanny nan = new Nanny(ID, first_name, last_name, birthday);
                    bl.addNanny(nan);
                    break;

                case 3:
                    Console.WriteLine("enter nanny details: id  first_name last_name and Birthday");
                    ID = Console.ReadLine();
                    first_name = Console.ReadLine();
                    last_name = Console.ReadLine();
                    birthday = DateTime.Parse(Console.ReadLine());
                    Nanny nan = new Nanny(ID, first_name, last_name, birthday);
                    bl.addNanny(nan);
                    break;

                case 4:
                    Console.WriteLine("enter nanny details: id  first_name last_name and Birthday");
                    ID = Console.ReadLine();
                    first_name = Console.ReadLine();
                    last_name = Console.ReadLine();
                    birthday = DateTime.Parse(Console.ReadLine());
                    Nanny nan = new Nanny(ID, first_name, last_name, birthday);
                    bl.addNanny(nan);
                    break;

                case 5:
                    Console.WriteLine("enter nanny details: id  first_name last_name and Birthday");
                    ID = Console.ReadLine();
                    first_name = Console.ReadLine();
                    last_name = Console.ReadLine();
                    birthday = DateTime.Parse(Console.ReadLine());
                    Nanny nan = new Nanny(ID, first_name, last_name, birthday);
                    bl.addNanny(nan);
                    break;

                case 6:
                    Console.WriteLine("enter nanny details: id  first_name last_name and Birthday");
                    ID = Console.ReadLine();
                    first_name = Console.ReadLine();
                    last_name = Console.ReadLine();
                    birthday = DateTime.Parse(Console.ReadLine());
                    Nanny nan = new Nanny(ID, first_name, last_name, birthday);
                    bl.addNanny(nan);
                    break;

                default:          
                    break;*/
            }
        }
    }
}
