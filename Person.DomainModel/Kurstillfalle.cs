namespace Person.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Kurstillfalle")]
    public partial class Kurstillfalle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Kurs_FK { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDatum { get; set; }

        [Required]
        [StringLength(30)]
        public string Ort { get; set; }

        public virtual Kurs Kurs { get; set; }
        public KursPeriod KursPeriod => KursPeriod.FromValues(StartDatum, Kurs.AntalDagar);
        public string KursNamn => Kurs.Namn;

        public bool Overlappar(KursPeriod periodAttVerifiera)
        {
            return KursPeriod.Overlappar(periodAttVerifiera);
        }
    }
}
