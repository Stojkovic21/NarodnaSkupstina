using FluentNHibernate.Mapping;
using NarodnaSkupstina.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina.Mapiranja
{
    public class SazivanjeSedniceMapiranje:ClassMap<SazivanjeSednice>
    {
        public SazivanjeSedniceMapiranje()
        {
            Table("SAZIVANJESEDNICE");

            Id(x => x.Id, "IDS").GeneratedBy.TriggerIdentity();

            References(x => x.IdPoslanika).Column("IDPOSLANIKA").LazyLoad();
            References(x => x.IdSednice).Column("IDSEDNICE").LazyLoad();
        }
    }
}
