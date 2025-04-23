using FluentNHibernate.Mapping;
using NarodnaSkupstina.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina.Mapiranja
{
    public class PravniAktMapiranje:ClassMap<PravniAkt>
    {
        public PravniAktMapiranje() 
        {
            Table("PRAVNIAKT");

            Id(x => x.Id, "idAkta").GeneratedBy.TriggerIdentity();

            Map(x => x.Tema, "TEMA");
            Map(x => x.KoPredlaze, "KO_PREDLAZE");
            Map(x => x.BrojBiraca, "BROJ_BIRACA");
            HasMany(x => x.PredlazuAkt).KeyColumn("IDAKTA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
