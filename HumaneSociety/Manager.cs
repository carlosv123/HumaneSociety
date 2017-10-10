using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
     public class Manager
    {
        HumaneSocietyDataContext humaneSociety = new HumaneSocietyDataContext();
        Customer customer;

        public Manager()
        {
            customer = new Customer();
        }

        public void EntryMenu()
        {
            Console.WriteLine("Are you an adopter or employee \n 1: adopter \n 2:Employee");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    GetAdopter();
                    break;
                case "2":
                    GetEmployee();
                    break;
            }
        }
        public void GetAdopter()
        {
            Console.WriteLine("Welcome, would you like to create an account with us or would you just like search for a pet?");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GetNewAdopter();
                    break;
                case "2":
                    CheckInventory();
                    break;

                default:
                    Console.WriteLine("Sorry wrong entry, please try again.");
                        break;
              
            }
        }
       
        public void GetNewAdopter()
        {
            Console.WriteLine("Please enter you first name");
            customer.First_Name = Console.ReadLine();

            Console.WriteLine("Plese Enter your last name");
            customer.Last_Name = Console.ReadLine();

            Console.WriteLine("Plese enter your age");
            customer.age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter your phone number");
            customer.Phone_Number = Console.ReadLine();

        }
        public void GetEmployee()
        {
            Console.WriteLine();

        }
        public void CheckInventory()
        {
            Console.WriteLine("would you like to search for an specific trait? \n 1:type \n 2:sex \n 3:breed \n 4:size");
            string trait = Console.ReadLine();

            switch (trait)
            {
                case "1":
                    checkType();
                    break;

                case "2":
                    checkedSex();
                    break;

                case "3":
                    checkBreed();
                    break;

                case "4":
                    checkSize();
                    break;

                default:
                    Console.ReadLine();
                    break;
            }

        }
        
      



    }
}
