
using NameSearch.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NameSearch.Api.PersonData
{
    public class MockPersonData : IPersonData
    {
        private List<Person> people = new List<Person>()
        {
            //random values and addresses https://www.randomlists.com/random-addresses
            new Person { Id = Guid.NewGuid(), Name = "John Smith", Age = 20, Address = "504 North Winchester Court Buffalo Grove, IL 60089", Interests = "Reading" },
            new Person { Id = Guid.NewGuid(), Name = "Bobby Pablo", Age = 40, Address = "56 Campfire CourtFarmington, MI 48331", Interests = "Writing"  },
            new Person { Id = Guid.NewGuid(), Name = "Garrett Lind", Age = 27, Address = "854 Wellington Dr. Asheboro, NC 27205", Interests = "Math"  },
            new Person { Id = Guid.NewGuid(), Name = "Garrett Thomas", Age = 23, Address = "564 Spruce Drive Powhatan, VA 23139", Interests = "Running"  },
            new Person { Id = Guid.NewGuid(), Name = "Paul John", Age = 34, Address = "9427 East Ohio Ave. Elmont, NY 11003", Interests = "Swimming"  }
        };
        public Person AddPerson(Person person)
        {
            person.Id = Guid.NewGuid();
            people.Add(person);
            return person;
        }

        public void DeletePerson(Person person)
        {
            people.Remove(person);
        }

        public Person EditPerson(Person person)
        {
            var cur_person = GetIDPerson(person.Id);
            cur_person.Name = person.Name;
            cur_person.Address = person.Address;
            cur_person.Age = person.Age;
            cur_person.Interests = person.Interests;
            return cur_person;
        }

        public List<Person> GetPeople()
        {
            return people;
        }

        public List<Person> SearchName(string name)
        {
            List<Person> peopleWithName = people.Where(person => person.Name.Contains(name)).ToList();

            return peopleWithName;

        }

        public Person GetIDPerson(Guid id)
        {
            return people.SingleOrDefault(person => person.Id == id);
        }
    }
}
