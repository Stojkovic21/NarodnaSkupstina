using FluentNHibernate.Mapping;
using NarodnaSkupstina.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina.Mapiranja
{
    public class SednicaMapiranje:ClassMap<Sednica>
    {
        public SednicaMapiranje()
        {
            Table("SEDNICA");

            Id(x => x.Id, "IDSEDNICE").GeneratedBy.TriggerIdentity();
            Map(x => x.DatumPocetka, "DATUM_POCETKA");
            Map(x => x.DatumZavrsetka, "DATUM_ZAVRSETKA");
            Map(x => x.BrojZasedanja, "BROJ_ZASEDANJA");
            Map(x => x.BrojSaziva, "BROJ_SAZIVA");
            Map(x => x.Tip, "TIP");
            Map(x => x.KoSaziva, "SAZIVA");

            HasMany(x => x.OdrzavanjeSednice).KeyColumn("IDSEDNICE").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.SazivaSednice).KeyColumn("IDSEDNICE").LazyLoad().Cascade.All().Inverse();
        }
    }
}
