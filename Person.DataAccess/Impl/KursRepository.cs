using System.Collections.Generic;
using System.Linq;
using Person.DomainModel;

namespace Person.DataAccess.Impl
{
    public class KursRepository : IKursRepository
    {
        private PersonModel PersonModel { get; }
        private readonly Repository<Kurs, PersonModel> internalGenericRepository;

        public KursRepository(PersonModel personModel)
        {
            // Skapa DbContext genom dependency injection. Använd en DbContext per tjänsteanrop! Återanvänd i de olika Repositories. Se http://mehdi.me/ambient-dbcontext-in-ef6/
            PersonModel = personModel;
            internalGenericRepository = new Repository<Kurs, PersonModel>(PersonModel);
        }
        // Här kan man implementera mer specialiserade metoder för att hämta Anstalld, direkt genom context eller genom att använda den generiska Repository<T>

        public IEnumerable<Kurs> GetAll()
        {
            return internalGenericRepository.GetAll();
        }

        public Kurs GetById(int id)
        {
            return internalGenericRepository.GetById(id);
        }

        public IEnumerable<Kurs> GetByKategori(Kurskategori kategori)
        {
            return internalGenericRepository.Find(candidate => candidate.Kategori == kategori);
        }

        public Kurs GetByTillfalleId(int kurstillfalleId)
        {
            // Verifiera hur EF genererar SQL för denna query. Kanske kan den göras på bättre sätt. Eventuellt egen Repository för kurstillfällen?
            return internalGenericRepository.Find(candidate => candidate.Kurstillfalle.Any(tillfalle => tillfalle.Id == kurstillfalleId)).Single(); // OBS: Single, ej SingleOrDefault eftersom vi förväntar oss en träff!

        }
    }
}
