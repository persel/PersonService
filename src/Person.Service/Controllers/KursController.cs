using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Person.ApplicationServices;
using Person.Service.Models;
using System.Linq;

namespace Person.Service.Controllers
{
    [Route("api/[controller]")]
    public class KursController : Controller
    {
        private IPersonApplicationService personService;

        public KursController()
        {
            // Services bör instantieras genom dependency injection istället! 
            personService = new PersonApplicationService();
        }

        // GET api/kurs
        public IEnumerable<KursDTO> Get()
        {
            var kurser = personService.GetAllKurs();
            return kurser.Select(kurs => new KursDTO(kurs));
        }


        // Metoderna nedan exponeras bara om det är relevant!


        // GET api/kurs/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
