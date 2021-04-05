using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ImarcCodeExcercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> PersonList = new List<Person>(); 

            Console.WriteLine("Hello! Welcome to my solution to the coding challenge. Written on 4/5/2021.\n");
            Console.Write("Program Starting\n");
            

            // this loop allows you to continue adding persons to the list.
            bool createLoop = true;
            while (createLoop)
            {
                Console.WriteLine("Would you like to create a new Person? (y/n)");
                string newPersonPrompt = Console.ReadLine().ToLower();
                if (newPersonPrompt == "yes" || newPersonPrompt == "y")
                {
                    PersonList.Add(CreatePerson());
                }

                else if (newPersonPrompt == "no" || newPersonPrompt == "n")
                {
                    createLoop = false;
                }
                else 
                {
                    Console.WriteLine("You did not enter a vald option. Please try again. You may use y, n, yes, or no.");
                }
            }

            Console.WriteLine("Average age of all entered persons = " + AverageAge(PersonList) + "\n");
            foreach (Person person in PersonList)
            {
                Console.Write(person.FirstName + " " + person.LastName + " " + person.CurrentAge().ToString() + "\n");
            }

            Console.WriteLine("Now exporting input data to JSON file. File will be saved in the same directory as the application. \nWARNING! Previous file will be overwritten if this application is ran twice.");

            ExportData(PersonList);

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
            return;        
        }

        private static void ExportData(List<Person> personList)
        {
            string json = JsonSerializer.Serialize(personList);
            File.WriteAllText("ExportedData.json", json);

        }

        public static Person CreatePerson()
        {
            // first name string entry 
            Console.WriteLine("Please enter the persons first name.");
            string firstName = Console.ReadLine();

            // last name string entry 
            Console.WriteLine("Please enter the persons last name.");
            string lastName = Console.ReadLine();

            // converts string to DateTime
            Console.WriteLine("Please enter the persons date of birth.");
            DateTime dob = Convert.ToDateTime(Console.ReadLine());

            return new Person() 
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dob
            };
        }


        public static int AverageAge(List<Person> personList) 
        {
            int numPersons = personList.Count;
            int sumOfAges = 0;
            foreach (Person person in personList)
            {
                sumOfAges += person.CurrentAge();
            }
            return sumOfAges / numPersons;

        }
    }
}
