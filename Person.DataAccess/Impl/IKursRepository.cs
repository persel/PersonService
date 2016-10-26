using System.Collections.Generic;
using Person.DomainModel;

namespace Person.DataAccess.Impl
{
    public interface IKursRepository
    {
        IEnumerable<Kurs> GetAll();
        Kurs GetById(int id);
        IEnumerable<Kurs> GetByKategori(Kurskategori kategori);
        Kurs GetByTillfalleId(int kurstillFalleId);
    }
}