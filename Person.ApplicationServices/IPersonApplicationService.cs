using System.Collections.Generic;
using Person.DomainModel;

namespace Person.ApplicationServices
{
    public interface IPersonApplicationService
    {
        IEnumerable<Anstalld> GetAllAnstallda();
        Anstalld GetAnstalldById(int id);
        IEnumerable<Kurs> GetAllKurs();
        void AnmalTillKurs(int anstalldId, int kurstillfalleId);
    }
}