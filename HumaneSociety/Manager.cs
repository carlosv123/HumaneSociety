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

        public Manager()
        {

        }

        public void EntryMenu()
        {
            Console.WriteLine("Are you an adopter or employee> \n 1: adopter \n 2:Employee");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    ChechAdopter();
                    break;
                case "2":
                    CheckEmployee();
                    break;
            }
        }

    }
}
