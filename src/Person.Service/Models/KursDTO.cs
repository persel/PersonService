using System.Collections.Generic;
using System.Linq;
using Person.DomainModel;

namespace Person.Service.Models
{
    public class KursDTO
    {
        // Denna klass skulle också kunna implementeras som en "denormaliserad" icke hierarkisk struktur med 
        // kurs och tillfälle i samma klass om det vore mer lämpligt för konsumenten

        public int Id { get; set; }
        public string Kursnamn { get; set; }
        public int AntalDagar { get; set; }
        public List<KursTillfalleDTO> Tillfallen { get; set; }
        public string Kategori { get; set; }
        public KursDTO(Kurs kurs) // Här väljer vi att konstruera en DTO utifrån en domain model entity. Kan göras på andra sätt!
        {
            Id = kurs.Id;
            Kursnamn = kurs.Namn;
            AntalDagar = kurs.AntalDagar;
            Kategori = kurs.Kategori.ToString();
            Tillfallen = new List<KursTillfalleDTO>();
            
            kurs.Kurstillfalle.ToList().ForEach(tillfalle => Tillfallen.Add(new KursTillfalleDTO {Id = tillfalle.Id, Datum = tillfalle.StartDatum.ToShortDateString(), Ort = tillfalle.Ort}));
        }
    }
}
