using System.Linq;

namespace Person.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    // Denna entitet kan ses som "Aggregate Root" f�r Anstalld-aggregatet
    // Repositoryklassen returnerar och persisterar Anst�llda (instanser av denna klass)
    // Se t.ex. https://vaughnvernon.co/?p=879

    [Table("Anstalld")]
    public partial class Anstalld
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Anstalld()
        {
            Kursanmalan = new HashSet<Kursanmalan>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Fornamn { get; set; }

        [Required]
        [StringLength(30)]
        public string Efternamn { get; set; }

        [Required]
        [StringLength(12)]
        public string Personnummer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kursanmalan> Kursanmalan { get; set; }

        public void AnmalTillKurs(Kurstillfalle kurstillfalle)
        {
            var overlappandeKurser = Kursanmalan.Where(anmaldKurs => anmaldKurs.TillfalletPagarUnder(kurstillfalle.KursPeriod)).ToList();

            if(overlappandeKurser.Any())
            {
                var forstasomOverlappar = overlappandeKurser.First();
                throw new ApplicationException($"Kan ej anm�la till angiven kurs. Befintlig anm�lan �verlappar med tidsperioden f�r detta tillf�lle ('{forstasomOverlappar.KursNamn}' startar {forstasomOverlappar.StartDatum})");
            }
                
            // Utf�r ytterligare aff�rslogik, valideringar, s�tt andra v�rden, l�gg till/�ndra/ta bort relaterade egenskaper etc...

            var nyAnmalan = new Kursanmalan { Anstalld = this, Anstalld_FK = this.Id, Kurstillfalle_FK = kurstillfalle.Kurs.Id };

            Kursanmalan.Add(nyAnmalan);

        }
    }
}
