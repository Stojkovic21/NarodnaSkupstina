using FluentNHibernate.Mapping;
using NarodnaSkupstina.Entiteti;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina.Mapiranja
{
    public class OrganizacijaMapiranje : ClassMap<Organizacija>
    {
        public OrganizacijaMapiranje()
        {
            Table("ORGANIZACIJE");

            Id(x => x.Id, "IDORGANIZACIJE").GeneratedBy.TriggerIdentity();

            Map(x => x.BrojClanova, "BROJ_CLANOVA");
            Map(x => x.Tip, "TIP");
            Map(x => x.Ime, "IME");

            //References(x => x.IdPredsednika).Column("IDPOSLANIKA").LazyLoad();
            //References(x => x.IdZamenikaPredsednika).Column("IDPOSLANIKA").LazyLoad();
            HasMany(x => x.NarodniPoslanici).KeyColumn("IDORGANIZACIJE").LazyLoad().Inverse();
            HasMany(x=> x.SluzbeneProstorije).KeyColumn("IDORGANIZACIJE").LazyLoad().Inverse();
            References(x => x.IdPredsednika).Columns("IDPREDSEDNIKA");
            References(x => x.IdZamenikaPredsednika).Columns("IDZAMENIKA_PREDSEDNIKA");
        }
    }
}