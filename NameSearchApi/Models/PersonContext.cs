/*
 * Charles Walker
 * PersonContext.cs
 * This file is not used, but would be used by "SqlPersonData.cs" as the DbContext
 */
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NameSearch.Api.Models
{
    public class PersonContext: DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options): base(options)
        {

        }
        public DbSet<Person> People { get; set; }

    }
}
