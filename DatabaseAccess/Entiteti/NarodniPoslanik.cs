using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina.Entiteti
{
    public class NarodniPoslanik
    {
        public virtual int Id { get; protected set; }
        public virtual long JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string ImeRoditelja { get; set; }
        public virtual string MestoStanovanja { get; set; }
        public virtual string AdresaStanovanja { get; set; }
        public virtual long BrojTelefona { get; set; }
        public virtual long BrojTelefona2 { get; set; }
        public virtual string IzbornaLista { get; set; }
        public virtual string MestoRodjenja { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual char StalniRadniOdnos { get; set; }
        public virtual long? BrojRadneKnjizice { get; set; }
        public virtual string? PrethodnoRadnoMesto { get; set; }
        public virtual int? Godine { get; set; }
        public virtual int? Meseci { get; set; }
        public virtual int? Dani { get; set; }
        public virtual Organizacija PripadaOrganizaciji { get; set; }
        public virtual IList<PredlaganjeAkta>PredlozeniAktovi { get; set; }
        public virtual IList<SazivanjeSednice> SazivaSednice { get; set; }
        public NarodniPoslanik() 
        {
            PredlozeniAktovi=new List<PredlaganjeAkta>();
            SazivaSednice=new List<SazivanjeSednice>();
        }
    }
}
