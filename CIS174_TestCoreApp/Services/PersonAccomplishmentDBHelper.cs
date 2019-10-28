using CIS174_TestCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Services
{
    public class PersonAccomplishmentDBHelper
    {

        readonly AccomplishmentDbContext _context;

        public PersonAccomplishmentDBHelper(AccomplishmentDbContext context)
        {
            _context = context;
        }

        public Person CreatePerson(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();

            return person;
        }

        public void UpdatePerson(Person newPerson)
        {
            Person oldPerson = _context.Persons.Find(newPerson.PersonID);
            oldPerson.FirstName = newPerson.FirstName;
            oldPerson.LastName = newPerson.LastName;
            oldPerson.Birthdate = newPerson.Birthdate;
            oldPerson.City = newPerson.City;
            oldPerson.State = newPerson.State;
            oldPerson.Accomplishments = newPerson.Accomplishments;

            _context.SaveChanges();
        }

        public ISet<PersonAccomplishmentCommand> GetAllPersons()
        {
            return _context.Persons
                .Where(person => !person.IsDeleted)
                .Select(person => new PersonAccomplishmentCommand
                {
                    PersonID = person.PersonID,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Accomplishments = person.Accomplishments.ToList()
                }).ToHashSet();
        }

        public PersonAccomplishmentCommand GetPerson(int id)
        {
            return _context.Persons
                .Where(person => person.PersonID == id)
                .Select(person => new PersonAccomplishmentCommand
                {
                    PersonID = person.PersonID,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Birthdate = person.Birthdate,
                    City = person.City,
                    State = person.State,
                    Accomplishments = person.Accomplishments.ToList()
                }).SingleOrDefault();
        }

        public void DeletePerson(int id)
        {
            _context.Persons.Find(id).IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
