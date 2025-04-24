using NarodnaSkupstina.Entiteti;
using NHibernate;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NarodnaSkupstina
{
    public class DTOManager
    {
        #region Narodni poslanici
        public static List<NarodniPoslanikPregled> SviPoslanici()
        {
            List<NarodniPoslanikPregled> Poslanici = new List<NarodniPoslanikPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<NarodniPoslanik> sviNarodniPoslanici = from o in s.Query<NarodniPoslanik>()
                                                                   select o;

                foreach (NarodniPoslanik p in sviNarodniPoslanici)
                {
                    Poslanici.Add(new NarodniPoslanikPregled(p.JMBG, p.Ime, p.Prezime, p.BrojTelefona, p.IzbornaLista));
                }
                s.Close();
            }
            catch (Exception ec)
            {
            }

            return Poslanici;
        }
        public static NarodniPoslanikWork JedanPoslanik(long jmbg)
        {
            NarodniPoslanikWork Poslanici = new NarodniPoslanikWork();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<NarodniPoslanik> sviNarodniPoslanici = from o in s.Query<NarodniPoslanik>()
                                                                   where o.JMBG == jmbg
                                                                   select o;

                foreach (NarodniPoslanik p in sviNarodniPoslanici)
                {
                    if (p.PripadaOrganizaciji == null)
                    {
                        Poslanici = new NarodniPoslanikWork(p.Id, p.JMBG, p.Ime, p.Prezime, p.ImeRoditelja, p.DatumRodjenja, p.MestoRodjenja, p.MestoStanovanja, p.AdresaStanovanja,
                        p.BrojTelefona, p.BrojTelefona2, p.IzbornaLista, p.StalniRadniOdnos, p.BrojRadneKnjizice, p.PrethodnoRadnoMesto, p.Godine, p.Meseci, p.Dani);
                    }
                    else
                    {
                        Poslanici = new NarodniPoslanikWork(p.Id, p.JMBG, p.Ime, p.Prezime, p.ImeRoditelja, p.DatumRodjenja, p.MestoRodjenja, p.MestoStanovanja, p.AdresaStanovanja,
                            p.BrojTelefona, p.BrojTelefona2, p.IzbornaLista, p.StalniRadniOdnos, p.BrojRadneKnjizice, p.PrethodnoRadnoMesto, p.Godine, p.Meseci, p.Dani, p.PripadaOrganizaciji.Id);
                    }
                }

                s.Close();
            }
            catch (Exception ec)
            {
            }

            return Poslanici;
        }
        public static NarodniPoslanik JedanPoslanik(int id)
        {
            NarodniPoslanik Poslanici = new NarodniPoslanik();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<NarodniPoslanik> sviNarodniPoslanici = from o in s.Query<NarodniPoslanik>()
                                                                   where o.Id == id
                                                                   select o;

                foreach (NarodniPoslanik p in sviNarodniPoslanici)
                {
                    Poslanici = p;
                }

                s.Close();
            }
            catch (Exception ec)
            {
            }

            return Poslanici;
        }
        public static void DodajPoslanika(NarodniPoslanikWork np)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                NarodniPoslanik poslanik = new NarodniPoslanik();
                poslanik.JMBG = np.JMBG;
                poslanik.Ime = np.Ime;
                poslanik.Prezime = np.Prezime;
                poslanik.ImeRoditelja = np.ImeRoditelja;
                poslanik.DatumRodjenja = np.DatumRodjenja;
                poslanik.MestoRodjenja = np.MestoRodjenja;
                poslanik.MestoStanovanja = np.MestoStanovanja;
                poslanik.AdresaStanovanja = np.AdresaStanovanja;
                poslanik.BrojTelefona = np.BrojTelefona;
                poslanik.BrojTelefona2 = np.BrojTelefona2;
                poslanik.IzbornaLista = np.IzbornaLista;
                poslanik.StalniRadniOdnos = np.StalniRadniOdnos;
                poslanik.BrojRadneKnjizice = np.BrojRadneKnjizice;
                poslanik.PrethodnoRadnoMesto = np.PrethodnoRadnoMesto;
                poslanik.Godine = np.Godine;
                poslanik.Meseci = np.Meseci;
                poslanik.Dani = np.Dani;

                s.SaveOrUpdate(poslanik);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void IzmeniPoslanika(NarodniPoslanikWork np)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                NarodniPoslanik poslanik = s.Load<NarodniPoslanik>(JedanPoslanik(np.JMBG).Id);
                poslanik.JMBG = np.JMBG;
                poslanik.Ime = np.Ime;
                poslanik.Prezime = np.Prezime;
                poslanik.ImeRoditelja = np.ImeRoditelja;
                poslanik.DatumRodjenja = np.DatumRodjenja;
                poslanik.MestoRodjenja = np.MestoRodjenja;
                poslanik.MestoStanovanja = np.MestoStanovanja;
                poslanik.AdresaStanovanja = np.AdresaStanovanja;
                poslanik.BrojTelefona = np.BrojTelefona;
                poslanik.BrojTelefona2 = np.BrojTelefona2;
                poslanik.IzbornaLista = np.IzbornaLista;
                poslanik.StalniRadniOdnos = np.StalniRadniOdnos;
                poslanik.BrojRadneKnjizice = np.BrojRadneKnjizice;
                poslanik.PrethodnoRadnoMesto = np.PrethodnoRadnoMesto;
                poslanik.Godine = np.Godine;
                poslanik.Meseci = np.Meseci;
                poslanik.Dani = np.Dani;

                s.Update(poslanik);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static List<long> PosaljiJMBG()
        {
            List<long> jmbgs = new List<long>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<NarodniPoslanik> sviNarodniPoslanici = from o in s.Query<NarodniPoslanik>()
                                                                   select o;

                foreach (var item in sviNarodniPoslanici)
                {
                    jmbgs.Add(item.JMBG);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return jmbgs;
        }
        public static List<long> PoslaniciBezOrganizacije()
        {
            List<long> jmbgs = new List<long>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<NarodniPoslanik> sviNarodniPoslanici = from o in s.Query<NarodniPoslanik>()
                                                                   where o.PripadaOrganizaciji == null
                                                                   select o;

                foreach (var item in sviNarodniPoslanici)
                {
                    jmbgs.Add(item.JMBG);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return jmbgs;
        }
        public static List<NarodniPoslanik> PoslaniciUOrganizaciji(int idOrganizacije)
        {
            List<NarodniPoslanik> poslanici = new List<NarodniPoslanik>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<NarodniPoslanik> sviNarodniPoslanici = from o in s.Query<NarodniPoslanik>()
                                                                   where o.PripadaOrganizaciji.Id == idOrganizacije
                                                                   select o;

                foreach (var item in sviNarodniPoslanici)
                {
                    poslanici.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return poslanici;
        }
        public static void ObrisiPoslanika(long jmbg)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                NarodniPoslanik narodniPoslanik = session.Load<NarodniPoslanik>(JedanPoslanik(jmbg).Id);
                Organizacija organizacija = session.Load<Organizacija>(JedanPoslanik(jmbg).IdOrganizacije);
                if (organizacija.Id != 0)
                {
                    if ((narodniPoslanik != narodniPoslanik.PripadaOrganizaciji.IdPredsednika) && (narodniPoslanik != narodniPoslanik.PripadaOrganizaciji.IdZamenikaPredsednika))
                    {
                        foreach (var item in narodniPoslanik.PredlozeniAktovi)
                        {
                            PredlaganjeAkta akta = session.Load<PredlaganjeAkta>(item.Id);
                            akta.IdPoslanika = null;
                            session.Update(item);
                        }
                        foreach (var item in narodniPoslanik.SazivaSednice)
                        {
                            SazivanjeSednice sazivanjeSednice = session.Load<SazivanjeSednice>(item.Id);
                            sazivanjeSednice.IdPoslanika = null;
                            session.Update(item);
                        }
                        organizacija.BrojClanova--;
                        session.Delete(narodniPoslanik);
                    }
                    else
                    {
                        //MessageBox.Show("Poslanik koga zelite da obrisete je predsednik ili " +
                        //"zamenik predsednika neke organizacije. Mora ga prvo skinuti sa te pozicije" +
                        //"pa tek onda obrisati");
                    }
                }
                else
                {
                    session.Delete(narodniPoslanik);
                }
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion
        #region Organizacije
        public static List<OrganizacijePregled> VratiSveOrganizacije()
        {
            List<OrganizacijePregled> Organizacije = new List<OrganizacijePregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Organizacija> sveOrganicacije = from o in s.Query<Organizacija>()
                                                            select o;

                foreach (Organizacija p in sveOrganicacije)
                {
                    Organizacije.Add(new OrganizacijePregled(p.Id, p.Ime, p.IdPredsednika.Ime, p.IdPredsednika.Prezime, p.Tip, p.BrojClanova));
                }

                s.Close();
            }
            catch (Exception ec)
            {
            }

            return Organizacije;
        }
        public static List<string> SvaImenaOrganizacija()
        {
            List<string> Organizacije = new List<string>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<string> sveOrganicacije = from o in s.Query<Organizacija>()
                                                      select o.Ime;

                foreach (var p in sveOrganicacije)
                {
                    Organizacije.Add(p);
                }

                s.Close();
            }
            catch (Exception ec)
            {
            }

            return Organizacije;
        }
        public static Organizacija JednaOrganizacija(string ime)
        {
            Organizacija Organizacije = new Organizacija();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Organizacija> sveOrganizacije = from o in s.Query<Organizacija>()
                                                            where o.Ime == ime
                                                            select o;

                foreach (Organizacija p in sveOrganizacije)
                {
                    Organizacije = p;
                }

                s.Close();
            }
            catch (Exception ec)
            {
                throw ec;
            }

            return Organizacije;
        }
        public static int IdOrganizacije(string ime)
        {
            int id = 0;
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<int> sveOrganizacije = from o in s.Query<Organizacija>()
                                                   where o.Ime == ime
                                                   select o.Id;

                foreach (var p in sveOrganizacije)
                {
                    id = p;
                }

                s.Close();
            }
            catch (Exception ec)
            {
                throw ec;
            }

            return id;
        }
        public static void KreirajOrganizaciju(OrganizacijaWork orga)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Organizacija o = new Organizacija();
                o.Ime = orga.Ime;
                o.Tip = orga.Tip;
                o.IdPredsednika = JedanPoslanik(orga.PredsednikId);
                o.IdZamenikaPredsednika = JedanPoslanik(orga.ZamenikPredsednikaId);

                s.Save(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void IzmeniOrganizaciju(int id, OrganizacijaWork orga)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Organizacija o = session.Load<Organizacija>(id);
                o.Ime = orga.Ime;
                o.Tip = orga.Tip;

                session.Save(o);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void DodajClanaOrganizacije(string ime, long jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                NarodniPoslanik poslanik = s.Load<NarodniPoslanik>(JedanPoslanik(jmbg).Id);
                Organizacija organizacija = s.Load<Organizacija>(JednaOrganizacija(ime).Id);
                organizacija.NarodniPoslanici.Add(poslanik);
                poslanik.PripadaOrganizaciji = organizacija;
                organizacija.BrojClanova++;

                s.Save(organizacija);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void IzbaciClanaIzOrganizacije(string ime, long jmbg)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                NarodniPoslanik poslanik = s.Load<NarodniPoslanik>(JedanPoslanik(jmbg).Id);
                Organizacija organizacija = s.Load<Organizacija>(JednaOrganizacija(ime).Id);
                organizacija.NarodniPoslanici.Remove(poslanik);
                poslanik.PripadaOrganizaciji = null;
                organizacija.BrojClanova--;

                s.Save(organizacija);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void ObrisiOrganizaciju(int id)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Organizacija organizacija = session.Load<Organizacija>(id);
                foreach (var item in organizacija.NarodniPoslanici)
                {
                    NarodniPoslanik poslanik = session.Load<NarodniPoslanik>(item.Id);
                    poslanik.PripadaOrganizaciji = null;
                    session.Update(poslanik);
                }
                foreach (var item in organizacija.SluzbeneProstorije)
                {
                    SluzbeneProstorije prostorije = session.Load<SluzbeneProstorije>(item.BrojProstorije);
                    prostorije.IdOrganizacije = null;
                    session.Update(prostorije);
                }
                session.Delete(organizacija);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void PromeniPredsednika(string imeOrganizacije, long jmbgPredsednika = 0, long jmbgZamenikaPredsednika = 0)
        {
            try
            {
                int id = JednaOrganizacija(imeOrganizacije).Id;
                ISession session = DataLayer.GetSession();
                Organizacija organizacija = session.Load<Organizacija>(id);
                if (jmbgPredsednika > 0)
                {
                    NarodniPoslanik predsednik = session.Load<NarodniPoslanik>(JedanPoslanik(jmbgPredsednika).Id);
                    organizacija.IdPredsednika = predsednik;
                }
                if (jmbgZamenikaPredsednika > 0)
                {
                    NarodniPoslanik zamenikPredsednik = session.Load<NarodniPoslanik>(JedanPoslanik(jmbgZamenikaPredsednika).Id);
                    organizacija.IdZamenikaPredsednika = zamenikPredsednik;
                }

                session.Update(organizacija);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
        #region Sednice
        public static List<SednicaWork> VratiSveSednice()
        {
            List<SednicaWork> Sednice = new List<SednicaWork>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Sednica> sveSednice = from o in s.Query<Sednica>()
                                                  select o;

                foreach (Sednica p in sveSednice)
                {
                    Sednice.Add(new SednicaWork(p.Id, p.DatumPocetka, p.DatumZavrsetka, p.BrojSaziva, p.BrojZasedanja, p.Tip, p.KoSaziva));
                }

                s.Close();
            }
            catch (Exception ec)
            {
            }

            return Sednice;
        }
        public static void SazoviSednicu(SednicaWork sednica)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Sednica novaSednica = new Sednica();

                novaSednica.DatumPocetka = sednica.DatumPocetka;
                novaSednica.DatumZavrsetka = sednica.DatumZavrsetka;
                novaSednica.BrojSaziva = sednica.BrojSaziva;
                novaSednica.BrojZasedanja = sednica.BrojZasedanja;
                novaSednica.Tip = sednica.Tip;
                novaSednica.KoSaziva = sednica.KoSaziva;

                session.Save(novaSednica);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void IzmeniSednicu(SednicaWork sednica)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Sednica izmenjenaSednica = session.Load<Sednica>(sednica.Id);

                izmenjenaSednica.DatumPocetka = sednica.DatumPocetka;
                izmenjenaSednica.DatumZavrsetka = sednica.DatumZavrsetka;
                izmenjenaSednica.BrojSaziva = sednica.BrojSaziva;
                izmenjenaSednica.BrojZasedanja = sednica.BrojZasedanja;
                izmenjenaSednica.Tip = sednica.Tip;
                izmenjenaSednica.KoSaziva = sednica.KoSaziva;
                session.Save(izmenjenaSednica);

                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void KojiPoslaniciSazivajuSednicu(long poslanici)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Sednica novaSednica = session.Load<Sednica>(PoslednjaSazvanaSednica());
                SazivanjeSednice sazivaSeSednica = new SazivanjeSednice();
                NarodniPoslanik predlozio = session.Load<NarodniPoslanik>(JedanPoslanik(poslanici).Id);
                sazivaSeSednica.IdPoslanika = predlozio;
                sazivaSeSednica.IdSednice = novaSednica;
                predlozio.SazivaSednice.Add(sazivaSeSednica);
                novaSednica.SazivaSednice.Add(sazivaSeSednica);
                session.Save(predlozio);

                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static int PoslednjaSazvanaSednica()
        {
            int id;
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("select max(o.Id) from Sednica o");
                id = q.UniqueResult<int>();
            }
            catch (Exception ex)
            {
                throw;
            }
            return id;
        }
        public static List<NarodniPoslanikPregled> PoslaniciKojiSazivajuSednicu(int idSednice)
        {
            List<NarodniPoslanikPregled> Poslanici = new List<NarodniPoslanikPregled>();
            Sednica sednica = new Sednica();
            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<Sednica> s = from o in session.Query<Sednica>()
                                         where o.Id == idSednice
                                         select o;

                foreach (var item in s)
                {
                    sednica = item;
                }
                foreach (var item in sednica.SazivaSednice)
                {
                    Poslanici.Add(new NarodniPoslanikPregled(item.IdPoslanika.JMBG, item.IdPoslanika.Ime, item.IdPoslanika.Prezime, item.IdPoslanika.BrojTelefona, item.IdPoslanika.IzbornaLista));
                }

                session.Close();
            }
            catch (Exception ec)
            {
            }

            return Poslanici;
        }
        public static void ObrisiSednicu(int idSednice)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                Sednica sednica = session.Load<Sednica>(idSednice);
                foreach (var item in sednica.OdrzavanjeSednice)
                {
                    OdrzavanjeSednice odrzavanjeSednice = session.Load<OdrzavanjeSednice>(item.Id);
                    odrzavanjeSednice.IdSednice = null;
                    session.Update(odrzavanjeSednice);
                }
                foreach (var item in sednica.SazivaSednice)
                {
                    SazivanjeSednice sazivanjeSednice = session.Load<SazivanjeSednice>(item.Id);
                    sazivanjeSednice.IdSednice = null;
                    session.Update(sazivanjeSednice);
                }
                session.Delete(sednica);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Pravni akt
        public static List<PravniAktWork> VratiSvePravneAkte()
        {
            List<PravniAktWork> PravniAkti = new List<PravniAktWork>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<PravniAkt> sveSednice = from o in s.Query<PravniAkt>()
                                                    select o;

                foreach (var p in sveSednice)
                {
                    PravniAkti.Add(new PravniAktWork(p.Id, p.Tema, p.KoPredlaze));
                }

                s.Close();
            }
            catch (Exception ec)
            {
            }

            return PravniAkti;
        }
        public static void PredloziAkt(PravniAktWork akt)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                PravniAkt novAkt = new PravniAkt();

                novAkt.Tema = akt.Tema;
                novAkt.KoPredlaze = akt.KoPredlaze;
                novAkt.BrojBiraca = akt.BrojBiraca;

                session.Save(novAkt);
                session.Flush();

                session.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void IzmeniAkt(int idAkta, PravniAktWork akt)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                PravniAkt novAkt = session.Load<PravniAkt>(idAkta);

                novAkt.Tema = akt.Tema;
                novAkt.KoPredlaze = akt.KoPredlaze;
                novAkt.BrojBiraca = akt.BrojBiraca;

                session.Save(novAkt);
                session.Flush();

                session.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void ObrisiAkt(int idAkta)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                PravniAkt obrisiAkt = session.Load<PravniAkt>(idAkta);

                foreach (var item in obrisiAkt.PredlazuAkt)
                {
                    PredlaganjeAkta predlaze = session.Load<PredlaganjeAkta>(item);
                    predlaze.IdAkta = null;
                    session.Update(predlaze);
                }

                session.Delete(obrisiAkt);
                session.Flush();

                session.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void KojiPoslaniciPredlazuAkt(List<long> poslanici)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                PravniAkt noviAkt = session.Load<PravniAkt>(PoslednjiDodatAkt());
                foreach (var item in poslanici)
                {
                    PredlaganjeAkta predlazeSeAkt = new PredlaganjeAkta();
                    NarodniPoslanik predlozio = session.Load<NarodniPoslanik>(JedanPoslanik(item).Id);
                    predlazeSeAkt.IdPoslanika = predlozio;
                    predlazeSeAkt.IdAkta = noviAkt;
                    predlozio.PredlozeniAktovi.Add(predlazeSeAkt);
                    noviAkt.PredlazuAkt.Add(predlazeSeAkt);
                    session.Save(predlozio);
                }
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static int PoslednjiDodatAkt()
        {
            int id;
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("select max(o.Id) from PravniAkt o");
                id = q.UniqueResult<int>();
            }
            catch (Exception ex)
            {
                throw;
            }
            return id;
        }
        public static List<NarodniPoslanikPregled> PoslaniciKojiPredlazuAkt(int idAkta)
        {
            List<NarodniPoslanikPregled> Poslanici = new List<NarodniPoslanikPregled>();
            PravniAkt pravniAkt = new PravniAkt();
            try
            {
                ISession session = DataLayer.GetSession();

                IEnumerable<PravniAkt> s = from o in session.Query<PravniAkt>()
                                           where o.Id == idAkta
                                           select o;

                foreach (var item in s)
                {
                    pravniAkt = item;
                }
                foreach (var item in pravniAkt.PredlazuAkt)
                {
                    Poslanici.Add(new NarodniPoslanikPregled(item.IdPoslanika.JMBG, item.IdPoslanika.Ime, item.IdPoslanika.Prezime, item.IdPoslanika.BrojTelefona, item.IdPoslanika.IzbornaLista));
                }

                session.Close();
            }
            catch (Exception ec)
            {
            }

            return Poslanici;
        }
        #endregion
        #region Sluzbene prostorije
        public static List<SluzbeneProstorijeView> SveSluzbeneProstorije()
        {
            List<SluzbeneProstorijeView> sluzbeneProstorije = new List<SluzbeneProstorijeView>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<SluzbeneProstorije> sveOrganicacije = from o in s.Query<SluzbeneProstorije>()
                                                                  select o;

                foreach (var item in sveOrganicacije)
                {
                    if (item.IdOrganizacije != null)
                        sluzbeneProstorije.Add(new SluzbeneProstorijeView(item.BrojProstorije, item.Sprat, item.IdOrganizacije.Ime));
                    else sluzbeneProstorije.Add(new SluzbeneProstorijeView(item.BrojProstorije, item.Sprat, string.Empty));
                }

                s.Close();
            }
            catch (Exception ec)
            {
            }

            return sluzbeneProstorije;
        }
        public static List<int> SlobodneSluzbeneProstorije()
        {
            List<int> Organizacije = new List<int>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<int> sveOrganicacije = from o in s.Query<SluzbeneProstorije>()
                                                   where o.IdOrganizacije == null
                                                   select o.BrojProstorije;

                foreach (var item in sveOrganicacije)
                {
                    Organizacije.Add(item);
                }
                s.Close();
            }
            catch (Exception ec)
            {
            }

            return Organizacije;
        }
        public static void DodeliProstoriju(int brojProstorije, string imeOrganizacije)
        {
            try
            {
                ISession sessions = DataLayer.GetSession();
                SluzbeneProstorije prostorija = sessions.Load<SluzbeneProstorije>(brojProstorije);
                Organizacija orga = sessions.Load<Organizacija>(IdOrganizacije(imeOrganizacije));
                orga.SluzbeneProstorije.Add(prostorija);
                prostorija.IdOrganizacije = orga;
                sessions.Save(orga);
                sessions.Flush();
                sessions.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void OslobodiProstoriju(int id)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                SluzbeneProstorije sluzbeneProstorije = session.Load<SluzbeneProstorije>(id);
                sluzbeneProstorije.IdOrganizacije.SluzbeneProstorije.Remove(sluzbeneProstorije);
                sluzbeneProstorije.IdOrganizacije = null;

                session.Update(sluzbeneProstorije);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void NovaSluzbenaProstorija(int brojProstorije, int sprat)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                SluzbeneProstorije sluzbeneProstorije = new SluzbeneProstorije();
                sluzbeneProstorije.Sprat = sprat;
                sluzbeneProstorije.BrojProstorije = brojProstorije;

                session.Save(sluzbeneProstorije);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void IzmeniSluzbenuProstoriji(int idSluzbeneProstorijeint, int brojProstorije, int sprat)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                SluzbeneProstorije sluzbeneProstorije = session.Load<SluzbeneProstorije>(idSluzbeneProstorijeint);
                sluzbeneProstorije.Sprat = sprat;
                sluzbeneProstorije.BrojProstorije = brojProstorije;

                session.Save(sluzbeneProstorije);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void ObrisiSluzbenuProstoriji(int idSluzbeneProstorijeint)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                SluzbeneProstorije sluzbeneProstorije = session.Load<SluzbeneProstorije>(idSluzbeneProstorijeint);
                Organizacija organizacija = session.Load<Organizacija>(sluzbeneProstorije.IdOrganizacije.Id);
                organizacija.SluzbeneProstorije = null;

                session.Delete(sluzbeneProstorije);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
        #region Odrzavanje sednice
        public static List<OdrzavanjeSednicePregled> sviDaniKadaJeOdrzanaSednica(int id)
        {
            List<OdrzavanjeSednicePregled> odrzaneSednice = new List<OdrzavanjeSednicePregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<OdrzavanjeSednice> sveOdrzaneSednice = from o in s.Query<OdrzavanjeSednice>()
                                                                   where o.IdSednice.Id == id
                                                                   select o;

                foreach (var p in sveOdrzaneSednice)
                {
                    odrzaneSednice.Add(new OdrzavanjeSednicePregled(p.IdDana.Datum, p.BrojPrisutnihPoslanika));
                }

                s.Close();
            }
            catch (Exception ec)
            {
            }
            return odrzaneSednice;
        }

        public static void SazoviSednicu(DateTime datum, int idSednice, int brp)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                OdrzavanjeSednice odrz = new OdrzavanjeSednice();
                RadniDan radniDan = session.Load<RadniDan>(VratiRadniDanId(datum));
                Sednica sednica = session.Load<Sednica>(idSednice);
                if (radniDan.Id == 0)
                {
                    UnesiRadniDan(datum);
                    radniDan = session.Load<RadniDan>(VratiRadniDanId(datum));
                }
                odrz.IdSednice = sednica;
                odrz.IdDana = radniDan;
                odrz.BrojPrisutnihPoslanika = brp;
                sednica.OdrzavanjeSednice.Add(odrz);
                radniDan.OdrzavanjeSednice.Add(odrz);

                session.Save(sednica);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void IzmeniOdrzavanjeSednice(DateTime datum, int idSednice, int brp, int id)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                OdrzavanjeSednice odrz = session.Load<OdrzavanjeSednice>(id);
                RadniDan radniDan = session.Load<RadniDan>(VratiRadniDanId(datum));
                Sednica sednica = session.Load<Sednica>(idSednice);
                if (radniDan.Id == 0)
                {
                    UnesiRadniDan(datum);
                    radniDan = session.Load<RadniDan>(VratiRadniDanId(datum));
                }
                odrz.IdSednice = sednica;
                odrz.IdDana = radniDan;
                odrz.BrojPrisutnihPoslanika = brp;
                sednica.OdrzavanjeSednice.Add(odrz);
                radniDan.OdrzavanjeSednice.Add(odrz);

                session.Save(sednica);
                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void ObrisiOdrzavanjeSednice(int id)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                OdrzavanjeSednice odrzanaSednica = session.Load<OdrzavanjeSednice>(id);
                Sednica sednica = session.Load<Sednica>(odrzanaSednica.IdSednice.Id);
                sednica.OdrzavanjeSednice.Remove(odrzanaSednica);
                RadniDan radniDan = session.Load<RadniDan>(odrzanaSednica.IdDana.Id);
                radniDan.OdrzavanjeSednice.Remove(odrzanaSednica);

                session.Delete(odrzanaSednica);

                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
        #region Radni dan
        public static List<RadniDan> SviRadniDani()
        {
            List<RadniDan> RadniDani = new List<RadniDan>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<RadniDan> sviNarodniPoslanici = from o in s.Query<RadniDan>()
                                                            select o;

                foreach (var p in sviNarodniPoslanici)
                {
                    RadniDani.Add(new RadniDan(p.Id, p.Datum, p.RadiDo, p.RadiDo));
                }
                s.Close();
            }
            catch (Exception ec)
            {
            }

            return RadniDani;
        }
        public static void UnesiRadniDan(DateTime datum)
        {
            TimeSpan pocinje = new TimeSpan(9, 00, 0);
            TimeSpan zavrsavaSe = new TimeSpan(17, 00, 0);
            try
            {
                ISession session = DataLayer.GetSession();
                RadniDan novRadniDan = new RadniDan();
                novRadniDan.Datum = datum;
                novRadniDan.RadiOd = datum.Date + pocinje;
                novRadniDan.RadiDo = datum.Date + zavrsavaSe;

                session.Save(novRadniDan);
                session.Flush();

                session.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static int VratiRadniDanId(DateTime datum)
        {
            int idDana = 0;
            try
            {
                ISession session = DataLayer.GetSession();
                IEnumerable<int> dani = from o in session.Query<RadniDan>()
                                        where o.Datum == datum
                                        select o.Id;
                foreach (var item in dani)
                {
                    idDana = item;
                }

            }
            catch (Exception)
            {

                throw;
            }

            return idDana;
        }
        public static void ObrisiRadniDan(DateTime Datum)
        {
            try
            {
                ISession session = DataLayer.GetSession();
                RadniDan radniDan = session.Load<RadniDan>(VratiRadniDanId(Datum));

                foreach (var item in radniDan.OdrzavanjeSednice)
                {
                    OdrzavanjeSednice sednica = session.Load<OdrzavanjeSednice>(item.Id);
                    sednica.IdDana = null;
                }

                session.Delete(radniDan);

                session.Flush();
                session.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
