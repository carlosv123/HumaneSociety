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
        Animal animal;

        public Manager()
        {
            customer = new Customer();
            animal = new Animal();
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
            Console.WriteLine("Welcome, would you like to create an account with us or would you just like too search for a pet? \n 1: Create account \n 2: Search for pet \n 3: make payment");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GetNewAdopter();
                    break;
                case "2":
                    CheckInventory();
                    break;
                case "3":
                    makePayment();
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
            if(customer.age < 18)
            {
                Console.WriteLine("Sorry, it seems like your under 18. Please comeback with a parent");
                Console.ReadLine();
                
            }
            
            Console.WriteLine("Please enter your phone number");
            customer.Phone_Number = Console.ReadLine();

            humaneSociety.Customers.InsertOnSubmit(customer);
            humaneSociety.SubmitChanges();

        }

        
        public void CheckInventory()
        {
            Console.WriteLine("search a specific trait \n 1:type \n 2:sex \n 3:breed \n 4:price");
            string trait = Console.ReadLine();

            switch (trait)
            {
                case "1":
                    checkType();
                    break;

                case "2":
                    checkSex();
                    break;

                case "3":
                    checkBreed();
                    break;

                case "4":
                    checkPrice();
                    break;

                default:
                    Console.ReadLine();
                    break;
            }

        }
        public void checkType()
        {
            var type = from animal in humaneSociety.Animals
                       group animal by new { animal.Name, animal.Type_ };
                       foreach (var animal in type)
            {
                Console.WriteLine(animal.Key + ":");
                
            }
            Console.WriteLine("press enter if you would like to search for another specific trait");
            Console.ReadLine();
            CheckInventory();
        }
        public void checkSex() 
        {
            Console.WriteLine("would you like to search for a female or male animal, \n 1: male \n 2: female");
            string sex = Console.ReadLine();

            switch (sex)
            {
                case "1":
                    maleAnimal();
                    break;

                case "2":
                    femaleAnimal();
                    break;

                default:
                    Console.ReadLine();
                    break;
           }      


        }
        public void maleAnimal()
        {
            var sex = from animal in humaneSociety.Animals
                      where animal.Sex.Contains("male")
                      select animal;
            foreach(var animal in sex)
            {
                Console.WriteLine("{0} : {1} : {2}", animal.Type_, animal.Name, animal.Sex);
            }
            Console.ReadLine();
        }
        public void femaleAnimal()
        {
            var sex = from animal in humaneSociety.Animals
                      where animal.Sex.Contains("female")
                     select animal;
            foreach(var animal in sex)
            {
                Console.WriteLine("{0} : {1} : {2}", animal.Type_, animal.Name, animal.Sex);
            }
            Console.ReadLine();
        }
        

    public void checkBreed()
        {
            var breed = from animal in humaneSociety.Animals
                        group animal by new { animal.Name, animal.Breed };
                        foreach(var animal in breed)
            {
                Console.WriteLine(animal.Key + ":");
            }
            Console.WriteLine("press enter if you would like to search for another specific trait");
            Console.ReadLine();
            CheckInventory();

        }
        public void checkPrice()
        {
            var size = from animal in humaneSociety.Animals
                       group animal by new { animal.Name, animal.Type_, animal.Price };
            foreach (var animal in size)
            {
                Console.WriteLine(animal.Key + ":");
            }
            Console.WriteLine("Press enter if you would like to search for anothe specific trait");
            Console.ReadLine();
            CheckInventory();
            
        }
        public void GetEmployee()
        {
            Console.WriteLine("welcome employee, what would you like to do today? \n 1: Add animal \n 2: collect money from adopter \n 3: search animal location \n 4: keep track of animals food \n 5: change status of animal");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddAnimal();
                    break;

                case "2":
                    //TakePayment();
                    break;

                case "3":
                    AnimalLocation();
                    break;

                case "4":
                    AnimalsFood();
                    break;

                case "5":
                    //ChangeStatus();
                    break;

                default:
                    Console.WriteLine("Wrong entry please try again");
                    break;        
            }
                               
        }
        public void AddAnimal()
        {
            Console.WriteLine("what's the name of the animal that you would like to add?");
            animal.Name = Console.ReadLine();

            Console.WriteLine("what type of animal is the animal you would like to add?");
            animal.Type_ = Console.ReadLine();

            Console.WriteLine("what type of breed is the animal?(no spaces)");
            animal.Breed = Console.ReadLine();

            Console.WriteLine("What room would you like to place the pet in?");
            animal.Room = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("how much many cups does the animal consume in a week?");
            animal.Food_Amount = Console.ReadLine();

            Console.WriteLine("set the price of the animal");
            animal.Price = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("what's the sex of the animal?");
            animal.Sex = Console.ReadLine();

            Console.WriteLine("Does the animal have its shots?");
            animal.Shots = Console.ReadLine();

            Console.WriteLine("what size is the animal?");
            animal.Size = Console.ReadLine();

            humaneSociety.Animals.InsertOnSubmit(animal);
            humaneSociety.SubmitChanges();

        }
        public void AnimalLocation()
        {
            var room = from animal in humaneSociety.Animals
                       group animal by new { animal.Type_, animal.Name, animal.Room };
            foreach(var animal in room) 
                {
                Console.WriteLine(animal.Key + ":");
                
                }
            Console.WriteLine("Press enter to go back to the Employee menu");
            Console.ReadLine();
            GetEmployee();
                      
                          
        }
        public void AnimalsFood()
        {
            Console.WriteLine("pick an animal you would like to find the food amount");
            string choice = Console.ReadLine();

            var results = from animal in humaneSociety.Animals
                          group animal by new { animal.Name, animal.Type_, animal.Food_Amount };

            foreach(var animalFoodAmount in results)             //FIX THIS
            {
                Console.WriteLine(animalFoodAmount.Key + ":");
               
                
            }
           
            
        }
        public void makePayment()
        {
            Console.WriteLine("Enter payment");
            customer.PayMent = Convert.ToInt32(Console.ReadLine());

            humaneSociety.Customers.InsertOnSubmit(customer);
            humaneSociety.SubmitChanges();

            Console.WriteLine("Payment recieved. press enter to go back to the menu");
            Console.ReadLine();
            GetAdopter();



        }
        // public void TakePayment()
        // {

        // }
    }
}
