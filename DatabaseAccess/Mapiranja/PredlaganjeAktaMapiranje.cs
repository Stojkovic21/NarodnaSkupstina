using FluentNHibernate.Mapping;
using NarodnaSkupstina.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina.Mapiranja
{
    public class PredlaganjeAktaMapiranje:ClassMap<PredlaganjeAkta>
    {
        public PredlaganjeAktaMapiranje()
        {
            Table("PREDLAGANJEAKTA");

            Id(x => x.Id, "IDP").GeneratedBy.TriggerIdentity();

            References(x => x.IdPoslanika).Column("IDPOSLANIKA").LazyLoad();
            References(x => x.IdAkta).Column("IDAKTA").LazyLoad();
        }
    }
}
