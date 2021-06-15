using NameSearch.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NameSearch.Api.PersonData
{
    public class SqlPersonData : IPersonData
    {
        private PersonContext _personContext;
        public SqlPersonData(PersonContext personContext)
        {
            _personContext = personContext;
        }
        public Person AddPerson(Person person)
        {
            person.Id = Guid.NewGuid();
            _personContext.People.Add(person);
            _personContext.SaveChanges();
            return person;
        }

        public void DeletePerson(Person person)
        {
            _personContext.People.Remove(person);
            _personContext.SaveChanges();

        }

        public Person EditPerson(Person person)
        {
            var curPerson = _personContext.People.Find(person.Id);
            if(curPerson != null)
            {
                curPerson.Name = person.Name;
                curPerson.Address = person.Address;
                curPerson.Age = person.Age;
                curPerson.Interests = person.Interests;
                _personContext.People.Update(curPerson);
                _personContext.SaveChanges();
            }
            return person;
        }

        public Person GetIDPerson(Guid id)
        {
            var person = _personContext.People.Find(id);
            return person;
        }

        public List<Person> GetPeople()
        {
            return _personContext.People.ToList();
        }

        //Returns a list of people or a person with the matching name
        public List<Person> SearchName(string name)
        {
            List<Person> peopleWithName = new List<Person>(); 
            foreach(Person p in _personContext.People)
            {
                if(p.Name.Contains(name))
                {
                    peopleWithName.Add(p);
                }
            }

            return peopleWithName;
        }
    }
}
