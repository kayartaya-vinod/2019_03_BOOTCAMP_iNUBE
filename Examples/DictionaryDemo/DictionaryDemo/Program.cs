using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> people = new Dictionary<string, string>();
            people.Add("Vinod", "Bangalore");
            people.Add("John", "Dallas");
            people.Add("Arun", "Washington");
            people.Add("Shyam", "Shimoga");
            // people.Add("Shyam", "Mumbai"); // will result in error
            people["Shyam"] = "Mumbai"; // will overwrite the previous entry for "Shyam"
            people["Murali"] = "Bangalore";

            String name = "Shyam";
            if (people.ContainsKey(name))
            {
                String city = people[name];
                Console.WriteLine("Key = {0} and Value = {1}", name, city);
            }
            else
            {
                Console.WriteLine("Invalid key {0}", name);
            }

            string place;

            people.TryGetValue("Arun", out place);
            if(place is null)
            {
                 place = "(we don't know)";
            }
            Console.WriteLine("Arun is from {0}", place);

        }
    }
}
