using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //instances
            User u = new User();
            Address a = new Address();

            //get data from console or form
            Country c = new Country();
            var allCountries = c.GetCountry();
            int countryId = allCountries[0].CountryId;
            //create address
            int addressID = a.SaveAddress("Zaplanjska 18", "Nis", 18100, countryId);

            var strees = a.FilterAddress("zapla");

            u.GetUser(1);


            int userID = u.SaveUser("Nemanja", "nem@info.com", 0 , addressID);

            if (userID == 0)
            {
                Console.WriteLine("User is not saved");
            }
            else
            {
                Console.WriteLine($"User with id: {userID} is saved.");
            }

            Console.ReadKey();
        }
    }
}
