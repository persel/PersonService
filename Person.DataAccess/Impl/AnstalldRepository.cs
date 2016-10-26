using System.Collections.Generic;
using Person.DataAccess.Impl;
using Person.DomainModel;

namespace Person.DataAccess
{
    // Ett repository skapas per "Aggregat" (struktur av entiteter i Domainmodel) , t.ex. Anstalld, Organisation etc. 
    // Entity Framework används i detta lager för att hämta och returnera aggregaten baserat på olika kriterier, samt persistera nya och ändrade aggregat.
    // Repositories kan implementeras med bara generiska metoder, eller mer specialiserade metoder.
    // Man kan också välja att exponera eller inte DbSet/DbContext, IQueryable, eller bara exponera ett Api som använder domänmodellen.
    //
    // Se t.ex. http://codebetter.com/gregyoung/2009/01/16/ddd-the-generic-repository/
    // Samt: http://www.ben-morris.com/why-the-generic-repository-is-just-a-lazy-anti-pattern/
    public class AnstalldRepository : IAnstalldRepository
    {
        private PersonModel PersonModel { get; }
        private readonly Repository<Anstalld, PersonModel> internalGenericRepository;

        public AnstalldRepository(PersonModel personModel)
        {
            // Skapa DbContext genom dependency injection. Använd en DbContext per tjänsteanrop! Återanvänd i de olika Repositories. Se http://mehdi.me/ambient-dbcontext-in-ef6/

            PersonModel = personModel;
            internalGenericRepository = new Repository<Anstalld, PersonModel>(PersonModel);
        }
        
        // Här kan man implementera mer specialiserade metoder för att hämta Anstalld, direkt genom context eller genom att använda den generiska Repository<T>
        
        public IEnumerable<Anstalld> GetAll()
        {
            return internalGenericRepository.GetAll();
        }

        public Anstalld GetById(int id)
        {
            return internalGenericRepository.GetById(id);
        }

        public IEnumerable<Anstalld> GetByEfternamn(string efternamn)
        {
            return internalGenericRepository.Find(candidate => candidate.Efternamn == efternamn);
        }

        public void Update()
        {
            internalGenericRepository.Update(); // alt. personModel.SaveChanges();
        }
    }
}
