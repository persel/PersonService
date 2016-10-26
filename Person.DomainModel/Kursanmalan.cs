namespace Person.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Kursanmalan")]
    public partial class Kursanmalan
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Anstalld_FK { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Kurstillfalle_FK { get; set; }

        public DateTime SkapadDatum { get; set; }

        [Required]
        [StringLength(10)]
        public string SkapadAv { get; set; }

        public virtual Kurstillfalle Kurstillfalle { get; set; }

        public virtual Anstalld Anstalld { get; set; }
        public string KursNamn => Kurstillfalle.KursNamn;
        public DateTime StartDatum => Kurstillfalle.StartDatum;


        public bool TillfalletPagarUnder(KursPeriod period)
        {
            return Kurstillfalle.Overlappar(period);
        }
    }
}
