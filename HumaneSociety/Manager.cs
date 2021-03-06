﻿using System;
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
        Employee employee;

        public Manager()
        {
            customer = new Customer();
            animal = new Animal();
            employee = new Employee();
        }

        public void EntryMenu()
        {
            Console.WriteLine("Are you an adopter or employee \n 1: Adopter \n 2:Employee");
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
            Console.WriteLine("Welcome, would you like to create an account with us,search for a pet or make a payment? \n 1: Create account \n 2: Search for pet \n 3: make payment");
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
                    Console.WriteLine("Wrong entry please try again");
                    break;
            }

        }
        public void checkType()
        {
            var type = from animal in humaneSociety.Animals
                       group animal by new { animal.Name, animal.Type_, animal.Size };
                       foreach (var animal in type)
            {
                Console.WriteLine(animal.Key + ":");
                
            }
            Console.WriteLine("press enter to go back to the main menu");
            Console.ReadLine();
            GetAdopter();
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
            Console.WriteLine("press enter to search for another specific trait");
            Console.ReadLine();
            CheckInventory();

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
            Console.WriteLine("press enter to search for another specific trait");
            Console.ReadLine();
            CheckInventory();
            

        }
        

    public void checkBreed()
        {
            var breed = from animal in humaneSociety.Animals
                        group animal by new { animal.Name, animal.Breed };
                        foreach(var animal in breed)
            {
                Console.WriteLine(animal.Key + ":");
            }
            Console.WriteLine("press enter to go back to the main menU");
            Console.ReadLine();
            GetAdopter();

        }
        public void checkPrice()
        {
            var size = from animal in humaneSociety.Animals
                       group animal by new { animal.Name, animal.Type_, animal.Price };
            foreach (var animal in size)
            {
                Console.WriteLine(animal.Key + ":");
            }
            Console.WriteLine("Press enter to go to the main menu");
            Console.ReadLine();
            CheckInventory();
            
        }
        public void GetEmployee()
        {
            Console.WriteLine("What would you like to do today? \n 1: Add animal \n 2: search animal location \n 3: keep track of animals food \n 4: change status of animal");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddAnimal();
                    break;

                case "2":
                    AnimalLocation();
                    break;

                case "3":
                    AnimalsFood();
                    break;

                case "4":
                    changeStatus();
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

            Console.WriteLine("Animal added to our inventory, Have a great day!");
            Console.ReadLine();
            
            Console.WriteLine("Press enter to go back to the main menu");
            Console.ReadLine();
            GetEmployee();

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
            Console.WriteLine("Press enter to go back to the main menu");
            Console.ReadLine();
            GetEmployee();
                      
                          
        }
        public void AnimalsFood()
        {
            Console.WriteLine("Choose a type of animal you would like to find out how much cups of food it eats in a week");
            string choice = Console.ReadLine();

            var results = from animal in humaneSociety.Animals
                          where animal.Type_ == choice || animal.Food_Amount == choice
                          select animal.Food_Amount;
                  
            foreach (var animalFoodAmount in results)             
            {
                Console.WriteLine(animalFoodAmount + "cups" );
            }
            Console.WriteLine("Press enter to go back to the main menu");
            Console.ReadLine();
            GetEmployee();


        }
        public void makePayment()
        {
            Console.WriteLine("Enter payment");
            employee.takePayment = Convert.ToInt32(Console.ReadLine());

            humaneSociety.Employees.InsertOnSubmit(employee);
            humaneSociety.SubmitChanges();

            Console.WriteLine("Payment recieved. press enter to go back to the menu");
            Console.ReadLine();
            GetAdopter();
        }

        public void changeStatus()
        {
            var status = from animal in humaneSociety.Animals
                         where animal.Status == null
                         select animal;
            foreach (var animal in status)
            {
                Console.WriteLine("{0} : {1} : {2}", animal.Type_, animal.Name, animal.Status);
            }
            Console.ReadLine();
        }
    }
        

        
    
}
