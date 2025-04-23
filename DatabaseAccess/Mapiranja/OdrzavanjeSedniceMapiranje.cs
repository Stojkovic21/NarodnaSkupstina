using FluentNHibernate.Mapping;
using NarodnaSkupstina.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina.Mapiranja
{
    public class OdrzavanjeSedniceMapiranje:ClassMap<OdrzavanjeSednice>
    {
        public OdrzavanjeSedniceMapiranje()
        {
            Table("ODRZAVANJESEDNICE");

            Id(x => x.Id, "IDO").GeneratedBy.TriggerIdentity();
            Map(x => x.BrojPrisutnihPoslanika, "BROJ_PRISUTNIH_POSLANIKA");

            References(x => x.IdSednice).Column("IDSEDNICE").LazyLoad();
            References(x => x.IdDana).Column("IDDANA").LazyLoad();
        }
    }
}
