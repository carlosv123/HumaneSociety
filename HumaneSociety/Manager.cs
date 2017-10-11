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
            Console.WriteLine("Welcome, would you like to create an account with us or would you just like too search for a pet?");
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
                    MakePayment();
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
                    checkSex();
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
        public void checkType()
        {
            Console.WriteLine("what type of animal are you looking for?");
            string animalType = Console.ReadLine();

            var results = (from Animal in humaneSociety.Animals
                           where Animal.Type_ == animalType
                           select Animal).ToList();
            foreach (var type in results)
            {
                Console.WriteLine("These are the types of animals we currently have" + type.Type_);
                Console.ReadLine();
            }


        }
        public void checkSex() { }
        //{
        //    Console.WriteLine("male or female\n 1: male \n 2: female");
        //    string animalSex = Console.ReadLine();

        //    switch(animalSex)
        //    {
        //        case "1":
        //            break;

        //        case "2":
        //            break;
        //    }

        //}
        public void checkBreed()
        {
            Console.WriteLine("what type of breed are you looking for?");
            String animalBreed = Console.ReadLine();

            var results = (from Animal in humaneSociety.Animals
                           where Animal.Breed == animalBreed
                           select Animal).ToList();
            foreach (var type in results)
            {
                Console.WriteLine(type.Name);
                Console.WriteLine("These are the type of breeds we currently have" + type.Breed);
                Console.ReadLine();
            }


        }
        public void checkSize()
        {
            Console.WriteLine("what type of size are you looking for?");
            string animalSize = Console.ReadLine();

            var results = (from Animal in humaneSociety.Animals
                           where Animal.Size == animalSize
                           select Animal).ToList();
            foreach (var type in results)
            {
                Console.WriteLine("These are the type of size of animals we currently have");
                Console.ReadLine();
            }
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
                    TakePayment();
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

            Console.WriteLine("what type of breed is the animal?");
            animal.Breed = Console.ReadLine();

            Console.WriteLine("What room would you like to place the pet in?");
            animal.Room = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("how much food does the animal consume in a week?");
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
            Console.WriteLine("Enter the room number that you like to search for");
            int RoomNumber = Convert.ToInt32(Console.ReadLine());

            var results = (from animal in humaneSociety.Animals
                          where animal.Room == RoomNumber
                          select animal).ToList();
            foreach (var room in results)
            {
                Console.WriteLine("A {0) is placed in this {1}",room.Type_, room.Room);
                Console.ReadLine();
            }
                          
        }
        public void AnimalsFood()
        {
            var results = from animal in humaneSociety.Animals
                          where animal.Food_Amount == animal.Food_Amount
                          select animal;

            foreach(var food in results)
            {
                Console.WriteLine("all the animals food amount", food.Food_Amount);

            }
            Console.ReadLine();
        }
       public void MakePayment()
        {
            Console.WriteLine("Enter payment");
            customer.PayMent = Convert.ToInt32(Console.ReadLine());

            

        }
        public void TakePayment()
        {
           
        }
    }
}
