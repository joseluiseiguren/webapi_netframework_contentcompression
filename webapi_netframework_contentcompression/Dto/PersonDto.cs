using System.Collections.Generic;
using webapiexample.Models;

namespace webapiexample.Dto
{
    public class PersonDto
    {
        public int Records { get; set; }

        public IEnumerable<Person> Persons { get; set; }
    }
}