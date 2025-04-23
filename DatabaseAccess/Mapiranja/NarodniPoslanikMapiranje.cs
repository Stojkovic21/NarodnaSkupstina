using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NarodnaSkupstina.Entiteti;

namespace NarodnaSkupstina.Mapiranja
{
    public class NarodniPoslanikMapiranje:ClassMap<NarodniPoslanik>
    {
        public NarodniPoslanikMapiranje()
        {
            Table("NARODNIPOSLANIK");

            Id(x => x.Id, "IDPOSLANIKA").GeneratedBy.TriggerIdentity();

            Map(x => x.JMBG, "JMBG");
            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "Prezime");
            Map(x => x.ImeRoditelja, "IME_RODITELJA");
            Map(x => x.MestoStanovanja, "MESTO_STANOVANJA");
            Map(x => x.AdresaStanovanja, "ADRESA_STANOVANJA");
            Map(x => x.BrojTelefona, "BROJ_TELEFONA");
            Map(x => x.BrojTelefona2, "BROJ_TELEFONA2");
            Map(x => x.IzbornaLista, "IZBORNA_LISTA");
            Map(x => x.DatumRodjenja, "DATUM_RODJENJA");
            Map(x => x.MestoRodjenja, "MESTO_RODJENJA");
            Map(x => x.StalniRadniOdnos, "STALNI_RADNI_ODNOS");
            Map(x => x.BrojRadneKnjizice, "BROJ_RADNE_KNJIZICE");
            Map(x => x.PrethodnoRadnoMesto, "PRETHODNO_RADNO_MESTO");
            Map(x => x.Godine, "GODINE");
            Map(x => x.Meseci, "MESECI");
            Map(x => x.Dani, "DANI");

            References(x => x.PripadaOrganizaciji).Column("IDORGANIZACIJE");
            HasMany(x => x.PredlozeniAktovi).KeyColumn("IDPOSLANIKA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.SazivaSednice).KeyColumn("IDPOSLANIKA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
