using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NarodnaSkupstina.Entiteti;

namespace NarodnaSkupstina.Mapiranja
{
    public class SluzbeneProstorijeMapiranje : ClassMap<SluzbeneProstorije>
    {
        public SluzbeneProstorijeMapiranje()
        {
            Table("SLUZBENEPROSTORIJE");

            Id(x => x.BrojProstorije, "BROJ_PROSTORIJE").GeneratedBy.TriggerIdentity();

            Map(x => x.Sprat, "SPRAT");

            References(x => x.IdOrganizacije).Columns("IDORGANIZACIJE");
        }
    }
}
