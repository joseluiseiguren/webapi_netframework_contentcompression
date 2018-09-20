using System.Web.Http;
using webapiexample.Filters;
using webapiexample.Repository;

namespace webapiexample.Controllers
{
    [RoutePrefix("api/persons")]
    public class PersonsController : ApiController
    {
        [Route]
        //[CustomCompression]
        public IHttpActionResult Get()
        {
            var personRepository = new PersonRepository();

            var persons = personRepository.GetByFilter();

            return this.Ok(persons);
        }
    }
}
