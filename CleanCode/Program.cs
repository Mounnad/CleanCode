using CleanCode;
using CleanCode.Entities;
using CleanCode.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            using (EnumsDbContext context = new EnumsDbContext())
            {
                foreach(var user in context.Users.ToList())
                {
                    persons.Add(MappingUserToPerson(user));
                }
            }

            //Show Table of Users
            
            foreach ( var person in persons)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(string.Format("User {0} Information :", person.Id));
                Console.WriteLine("Name : " + person.Name);
                Console.WriteLine("Role : " + person.Role);
                Console.WriteLine("-------------------------------------------------");
            }
            Console.ReadKey();
        }

        static Person MappingUserToPerson(User user)
        {
            Person person = new Person();
            person.Id = user.Id;
            person.Name = user.Name;
            person.Role = user.UserRole.Name;
            return person;
        }
    }

    class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
    }
}
