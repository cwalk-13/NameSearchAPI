﻿/*
 * Charles Walker
 * PersonController.cs
 * This is the controller where the API calls are defined
 */
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NameSearch.Api.Models;
using NameSearch.Api.PersonData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace NameSearch.Api.Controllers
{
    
    [ApiController]

    public class PersonController : ControllerBase
    {
        private IPersonData _personData; //Dependency injection ensures that a new instance of the interface is not created, and that all API calls will operate with the same data
        public PersonController(IPersonData personData)
        {
            this._personData = personData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetPeople() // Returns all "Person" objects in the database
        {
            return Ok(_personData.GetPeople());
        }

        [HttpGet]
        [Route("api/[controller]/name/{name}")]
        public IActionResult SearchName(string name) // Returns a list of all people with the name argument
        {
            List<Person> person = null;

            var delay = Task.Delay(2000).ContinueWith(_ => //this simulates latency in the API call
            {
                person = _personData.SearchName(name);
                return person;
            });

            if (delay.Result == null)
            {
                return NotFound();
            }
            return Ok(delay.Result);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetIDPerson(Guid id) // Returns a person given an Id
        {
            var person = _personData.GetIDPerson(id);

            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddPerson(Person person) //Returns the newly created person
        {
            //_personData.AddPerson(person);
            var delay = Task.Delay(2000).ContinueWith(_ => //this simulates latency in the API call
            {
                _personData.AddPerson(person);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + person.Id, person);
            });

            if (delay.Result.Value == null)
            {
                return NotFound();
            }
            return Ok(delay.Result.Value);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeletePerson(Guid id) //Deletes a person given an Id
        {
            var person = _personData.GetIDPerson(id);

            if(person == null)
            {
                return NotFound();
            }

            _personData.DeletePerson(person);
            return Ok();
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditPerson(Guid id, Person person) //Updates a person's attributes
        {
            var cur_person = _personData.GetIDPerson(id);

            if (cur_person != null)
            {
                person.Id = cur_person.Id;
                _personData.EditPerson(person);
            }
            return Ok();
        }
    }
}
