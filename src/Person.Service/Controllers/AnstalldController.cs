using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Person.ApplicationServices;
using Person.Service.Models;

namespace Person.Service.Controllers
{
    
    [Route("api/[controller]")]
    public class AnstalldController : Controller
    {
        private IPersonApplicationService personService;

        public AnstalldController()
        {
            // Services bör instantieras genom dependency injection istället! 
            personService = new PersonApplicationService();  
        }

        // GET api/anstalld
        [HttpGet]
        public IEnumerable<AnstalldSearchResultDTO> Get()
        {
            var anstallda = personService.GetAllAnstallda();
            return anstallda.Select(model => new AnstalldSearchResultDTO {Id = model.Id, Namn = model.Fornamn + " " + model.Efternamn});
        }

        
        // GET api/anstalld/5
        [HttpGet]
        public AnstalldDTO Get(int id)
        {
            var anstalld = personService.GetAnstalldById(id);
            return new AnstalldDTO { Id = anstalld.Id, Fornamn = anstalld.Fornamn, Efternamn = anstalld.Efternamn, Personnummer = anstalld.Personnummer};
        }


        // Routa denna mot t.ex. GET api/anstalld/anmaltillkurs?anstalldId=?&kurstillfalleId=?
        public void AnmalTillKurs(int anstalldId, int kurstillfalleId)
        {
            personService.AnmalTillKurs(anstalldId, kurstillfalleId);
        }


        // Metoderna nedan exponeras bara om det är relevant!

        // POST api/anstalld
        [HttpPost]
        public void Post([FromBody]AnstalldDTO anstalld)
        {
        }

        // PUT api/anstalld/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]AnstalldDTO anstalld)
        {
        }

        // DELETE api/anstalld/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
