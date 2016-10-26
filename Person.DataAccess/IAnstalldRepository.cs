using System.Collections.Generic;
using Person.DomainModel;

namespace Person.DataAccess
{
    // Repository-interfacen placeras ibland i DomainModel-projektet, med implementationen i DataAccess- eller Infrastructure-projektet.
    // Här väljer vi dock att förenkla och lägga både interface och implementationer i DataAccess-projektet.

    public interface IAnstalldRepository
    {
        IEnumerable<Anstalld> GetAll();
        IEnumerable<Anstalld> GetByEfternamn(string efternamn);
        Anstalld GetById(int id);
        void Update();
    }
}