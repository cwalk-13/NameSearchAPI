/*
 * Charles Walker
 * IPersonData.cs
 * This interface allows for Dependency injection
 */
using NameSearch.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NameSearch.Api.PersonData
{
    public interface IPersonData
    {
        List<Person> GetPeople();
        List<Person> SearchName(string name);
        Person GetIDPerson(Guid id);
        Person AddPerson(Person person);
        void DeletePerson(Person person);
        Person EditPerson(Person person);
    }
}
