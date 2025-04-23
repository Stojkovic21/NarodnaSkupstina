using NarodnaSkupstina.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarodnaSkupstina
{
    #region NarodniPoslanik
    public class NarodniPoslanikPregled
    {
        public long JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public long BrojTelefona { get; set; }
        public string IzbornaLista { get; set; }
        public NarodniPoslanikPregled() { }
        public NarodniPoslanikPregled(long JMBG, string ime, string prezime, long brojTelefona, string izbornaLista)
        {
            this.JMBG = JMBG;
            this.Ime = ime;
            this.Prezime = prezime;
            this.BrojTelefona = brojTelefona;
            this.IzbornaLista = izbornaLista;
        }
    }
    public class NarodniPoslanikWork
    {
        public int Id { get; set; }
        public long JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string ImeRoditelja { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string MestoRodjenja { get; set; }
        public string MestoStanovanja { get; set; }
        public string AdresaStanovanja { get; set; }
        public long BrojTelefona { get; set; }
        public long BrojTelefona2 { get; set; }
        public string IzbornaLista { get; set; }
        public int? IdOrganizacije { get; set; }
        public char StalniRadniOdnos { get; set; }
        public long? BrojRadneKnjizice { get; set; }
        public string? PrethodnoRadnoMesto { get; set; }
        public int? Godine { get; set; }
        public int? Meseci { get; set; }
        public int? Dani { get; set; }
        public NarodniPoslanikWork() { }
        public NarodniPoslanikWork(int id, long jMBG, string ime, string prezime, 
            string imeRoditelja, DateTime datumRodjenja, string mestoRodjenja, 
            string mestoStanovanja, string adresaStanovanja, long brojTelefona, 
            long brojTelefona2, string izbornaLista, 
            char stalniRadniOdnos, long? brojRadneKnjizice, string? prethodnoRadnoMesto, 
            int? godine, int? meseci, int? dani, int idOrganizacije=0)
        {
            this.Id = id;
            JMBG = jMBG;
            this.Ime = ime;
            this.Prezime = prezime;
            this.ImeRoditelja = imeRoditelja;
            this.DatumRodjenja = datumRodjenja;
            this.MestoRodjenja = mestoRodjenja;
            this.MestoStanovanja = mestoStanovanja;
            this.AdresaStanovanja = adresaStanovanja;
            this.BrojTelefona = brojTelefona;
            this.BrojTelefona2 = brojTelefona2;
            this.IzbornaLista = izbornaLista;
            this.StalniRadniOdnos = stalniRadniOdnos;
            this.BrojRadneKnjizice = brojRadneKnjizice;
            this.PrethodnoRadnoMesto = prethodnoRadnoMesto;
            this.Godine = godine;
            this.Meseci = meseci;
            this.Dani = dani;
            this.IdOrganizacije= idOrganizacije;
        }
    }
    #endregion
    #region Organizacije
    public class OrganizacijePregled
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string ImePredsednika { get; set; }
        public string PrezimePredsednika { get; set; }
        public string Tip { get; set; }
        public int BrojClanova { get; set; }

        public OrganizacijePregled() { }
        public OrganizacijePregled(int id, string ime, string imePredsednika, string prezimePredsednika, string tip, int brojClanova)
        {
            this.Id = id;
            this.Ime = ime;
            this.ImePredsednika = imePredsednika;
            this.PrezimePredsednika = prezimePredsednika;
            this.Tip = tip;
            this.BrojClanova = brojClanova;
        }
    }
    public class OrganizacijaWork
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public int PredsednikId { get; set; }
        public int ZamenikPredsednikaId { get; set; }
        public string Tip { get; set; }
        public List<NarodniPoslanik> Clanovi { get; set; }
        public OrganizacijaWork()
        {
            Clanovi = new List<NarodniPoslanik>();
        }

        public OrganizacijaWork(int id, string ime, int predsednik, int zamenikPredsednika, string tip, List<NarodniPoslanik> clanovi)
        {
            this.Id = id;
            this.Ime = ime;
            this.PredsednikId = predsednik;
            this.ZamenikPredsednikaId = zamenikPredsednika;
            this.Tip = tip;
            this.Clanovi = clanovi;
        }
    }

    #endregion
    #region Sednica
    public class SednicaWork
    {
        public int Id { get; set; }
        public DateTime? DatumPocetka { get; set; }
        public DateTime? DatumZavrsetka { get; set; }
        public int BrojSaziva { get; set; }
        public int BrojZasedanja { get; set; }
        public string Tip { get; set; }
        public string? KoSaziva { get; set; }
        public SednicaWork() { }
        public SednicaWork(int id, DateTime? datumPocetka, DateTime? datumZavrsetka, int brojSaziva, int brojZasedanja, string tip, string? saziva)
        {
            this.Id = id;
            this.DatumPocetka = datumPocetka;
            this.DatumZavrsetka = datumZavrsetka;
            this.BrojSaziva = brojSaziva;
            this.BrojZasedanja = brojZasedanja;
            this.Tip = tip;
            this.KoSaziva = saziva;
        }

        public SednicaWork(DateTime datumPocetka, DateTime datumZavrsetka, int brojSaziva, int brojZasedanja, string tip, string saziva)
        {
            this.DatumPocetka = datumPocetka;
            this.DatumZavrsetka = datumZavrsetka;
            this.BrojSaziva = brojSaziva;
            this.BrojZasedanja = brojZasedanja;
            this.Tip = tip;
            this.KoSaziva = saziva;
        }
    }
    #endregion
    #region Pravni akt
    public class PravniAktWork
    {
        public int Id { get; set; }
        public string Tema { get; set; }
        public string KoPredlaze { get; set; }
        public int BrojBiraca { get; set; }
        public PravniAktWork() { }
        public PravniAktWork(int id, string tema, string koPredlaze, int brojBiraca=0)
        {
            this.Id = id;
            this.Tema = tema;
            this.KoPredlaze = koPredlaze;
            this.BrojBiraca = brojBiraca;
        }
        public PravniAktWork(string tema, string koPredlaze, int brojBiraca)
        {
            this.Tema = tema;
            this.KoPredlaze = koPredlaze;
            this.BrojBiraca = brojBiraca;
        }
        public PravniAktWork(string tema, string koPredlaze)
        {
            this.Tema = tema;
            this.KoPredlaze = koPredlaze;
        }
    }
    public class PredlaganjeAktaWork
    {
        public int Id { get; set; }
        public NarodniPoslanik Poslanik { get; set; }
        public PravniAkt Akt { get; set; }

        public PredlaganjeAktaWork(NarodniPoslanik poslanik, PravniAkt akt)
        {
            Poslanik = poslanik;
            Akt = akt;
        }
    }
    #endregion
    #region Sluzbene prostorije
    public class SluzbeneProstorijeView
    {
        public int BrojProstorije { get; set; }
        public int Sprat { get; set; }
        public string ImeOrganizacije { get; set; }

        public SluzbeneProstorijeView(int brojProstorije, int sprat,string imeOrganizacije)
        {
            this.BrojProstorije = brojProstorije;
            this.Sprat = sprat;
            this.ImeOrganizacije=imeOrganizacije;
        }
    }
    #endregion
    #region Odrzavanje sednice
    public class OdrzavanjeSednicePregled
    {
        public DateTime Datum { get; set; }
        public int BrojPrisutnihPoslanika { get; set; }

        public OdrzavanjeSednicePregled(DateTime datum, int brojPrisutnihPoslanika)
        {
            this.Datum = datum;
            this.BrojPrisutnihPoslanika = brojPrisutnihPoslanika;
        }
    }
    #endregion
    #region Radni dan
    public class RadniDanWork
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public DateTime RadiOd { get; set; }
        public DateTime RadiDo { get; set; }

        public RadniDanWork(DateTime datum, DateTime radiOd, DateTime radiDod)
        {
            this.Datum = datum;
            this.RadiOd = radiOd;
            this.RadiDo = radiDod;
        }   
    }
    #endregion
}
