using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    /* The most important project type in c# is: 1. Class Library 2. API 
     * Database calls shouldn't happen in the API or any user interface
     * They Should happen in the class library
     */

    /// <summary>
    /// This is where i give you all information about my peeps
    /// </summary>
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();

        public PeopleController()
        {
            people.Add(new Person { FirstName = "Tim", LastName = "Corey", Id = 1});
            people.Add(new Person { FirstName = "Adarsh", LastName = "Menon", Id = 2 });
            people.Add(new Person { FirstName = "Gargi", LastName = "Unni", Id = 3 });
        }

        /// <summary>
        ///  Gets a list of first name of all users
        /// </summary>
        /// <param name="userId">The unique identifier for this person</param>
        /// <param name="age">We want to know how old they are</param>
        /// <returns>List of first names</returns>
        // We can modify how this call is made to accept variables.
        [Route("api/People/GetFirstNames/{userId:int}/{age:int}")]
        //[Route("api/People/GetFirstNames")]
        [HttpGet]
        public List<string> GetFirstNames(int userId, int age)
        {
            List<string> output = new List<string>();

            foreach( var p in people)
            {
                output.Add(p.FirstName);
            }

            return output;
        }

        // GET: api/People
        public List<Person> Get()
        {
            return people;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return people.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/People
        public void Post(Person val)
        {
            people.Add(val);
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}
