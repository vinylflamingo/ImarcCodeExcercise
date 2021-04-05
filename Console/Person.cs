using System;

namespace ImarcCodeExcercise
{
    class Person
    {
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public DateTime DateOfBirth {get; set;}

        public int CurrentAge()
        {
            DateTime currentDate = DateTime.Now;
            TimeSpan age = currentDate - DateOfBirth;
            return (int) age.TotalDays/365;
        }
    }

}
