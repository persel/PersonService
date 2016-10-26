using System.Collections.Generic;
using System.Linq;
using Person.DataAccess;
using Person.DataAccess.Impl;
using Person.DomainModel;

namespace Person.ApplicationServices
{
    public class PersonApplicationService : IPersonApplicationService
    {
        private readonly IAnstalldRepository anstalldRepository;
        private readonly IKursRepository kursRepository;

        public PersonApplicationService() //(IAnstalldRepository anstalldRepository, IKursRepository kursRepository)
        {
            // Repositories bör instantieras genom dependency injection istället! 

            var dbContext = new PersonModel();

            anstalldRepository = new AnstalldRepository(dbContext);
            kursRepository = new KursRepository(dbContext);
        }

        public IEnumerable<Anstalld> GetAllAnstallda()
        {
            var anstallda = anstalldRepository.GetAll();
            return anstallda;
        }

        public Anstalld GetAnstalldById(int id)
        {
            return anstalldRepository.GetById(id);
        }

        public IEnumerable<Kurs> GetAllKurs()
        {
            var kurser = kursRepository.GetAll();
            return kurser;
        }

        public void AnmalTillKurs(int anstalldId, int kurstillfalleId)
        {
            var anstalld = anstalldRepository.GetById(anstalldId);
            var kurs = kursRepository.GetByTillfalleId(kurstillfalleId);

            // Här väljer vi att låta vår ApplicationService hämta och "injecta" andra delar av modellen som Anstalld behöver för att kunna utföra affärslogik...
            // ...istället för att låta Anstalld hämta själv genom att hålla en referens till kursRepository. Följer bättre "Single responsibility principle". Se: http://gorodinski.com/blog/2012/04/14/services-in-domain-driven-design-ddd/

            var kurstillfalle = kurs.Kurstillfalle.Single(tillfalle => tillfalle.Id == kurstillfalleId);

            anstalld.AnmalTillKurs(kurstillfalle); // Här utförs affärslogik för just detta use case...

            anstalldRepository.Update(); // Borde göras centralt? (jfr. UnitOfWork)
        }
    }
}
