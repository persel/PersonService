using System;

namespace Person.DomainModel
{
    public class KursPeriod
    {
        private DateTime StartDatum { get; set; }
        private int AntalDagar { get; set; }

        private KursPeriod(){}

        public static KursPeriod FromValues(DateTime startDatum, int antalDagar)
        {
            return new KursPeriod {StartDatum = startDatum, AntalDagar = antalDagar};
        }

        public bool Overlappar(KursPeriod periodAttVerifiera)
        {
            var startDatumAttVerifiera = periodAttVerifiera.StartDatum;
            var slutDatumAttVerifiera = periodAttVerifiera.StartDatum.AddDays(periodAttVerifiera.AntalDagar);

            var slutDatum = StartDatum.AddDays(AntalDagar);

            return (StartDatum <= slutDatumAttVerifiera) && (slutDatum >= startDatumAttVerifiera);
        }
    }
}