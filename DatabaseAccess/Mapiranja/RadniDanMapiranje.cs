using FluentNHibernate.Mapping;
using NarodnaSkupstina.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina.Mapiranja
{
    public class RadniDanMapiranje: ClassMap<RadniDan>
    {
        public RadniDanMapiranje()
        {
            Table("RADNIDAN");

            Id(x => x.Id, "IDDANA").GeneratedBy.TriggerIdentity();
            Map(x => x.Datum, "DATUM");
            Map(x => x.RadiOd, "RADI_OD").CustomType("timestamp") ;
            Map(x => x.RadiDo, "RADI_DO").CustomType("timestamp");
            HasMany(x => x.OdrzavanjeSednice).KeyColumn("IDDANA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
