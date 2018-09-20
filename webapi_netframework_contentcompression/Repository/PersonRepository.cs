using System;
using System.Collections.Generic;
using webapiexample.Interfaces;
using webapiexample.Models;

namespace webapiexample.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private static readonly IList<Person> _lstPersons = new List<Person>();

        public PersonRepository()
        {
            if (_lstPersons.Count <= 0)
            {
                _lstPersons.Add(new Person()
                {
                    Birthdate = new DateTime(1980, 5, 13),
                    Id = 1,
                    Name = "Pedro"
                });

                _lstPersons.Add(new Person()
                {
                    Birthdate = new DateTime(1984, 10, 2),
                    Id = 2,
                    Name = "Martin"
                });

                _lstPersons.Add(new Person()
                {
                    Birthdate = new DateTime(2001, 1, 30),
                    Id = 3,
                    Name = "Juan"
                });
            }
        }

        public IEnumerable<Person> GetByFilter(string name = null, DateTime? birthDate = null)
        {
            return _lstPersons;
        }
    }
}