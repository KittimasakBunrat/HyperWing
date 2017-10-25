using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using HyperWing.Model;
using Model;

namespace HyperWing.DAL
{
    public class DB
    {
        public bool adminDB(Admin admin)
        {
            using (var db = new FlyContext())
            {
                dbAdmin funnetAdmin = db.Administratorer.FirstOrDefault(b => b.Navn == admin.Navn);
                if (funnetAdmin != null)
                {
                    byte[] testPass = lagHash(admin.Passord + funnetAdmin.Salt);
                    bool riktigBruker = funnetAdmin.Passord.SequenceEqual(testPass);
                    return riktigBruker;
                }
                else
                {
                    return false;
                }
            }
        }

        public byte[] lagHash(String hash)
        {
            byte[] innData, utData;
            var algoritme = SHA256.Create();
            innData = Encoding.UTF8.GetBytes(hash);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }

        public string lagSalt()
        {
            byte[] randomArray = new byte[10];
            string randomString;

            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomArray);
            randomString = Convert.ToBase64String(randomArray);
            return randomString;
        }

        public string HashStreng(String innStreng)
        {
            byte[] hash = lagHash(innStreng);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                stringBuilder.Append(hash[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }

        //Från gammal DB
        public List<FlyReise> listAlleReiser()
        {
            var db = new FlyContext();
            List<Flyplasser> flyplasser = db.Flyplasser.ToList();
            List<FlyReise> alleReiser = new List<FlyReise>();

            foreach (var flyplass in flyplasser)
            {
                foreach (var reise in flyplass.Reiser)
                {
                    var enReise = new FlyReise();
                    enReise.Id = reise.RId;
                    enReise.flyplass = flyplass.Navn;
                    enReise.byFra = reise.ByFra;
                    enReise.byTil = reise.ByTil;
                    enReise.avgangstid = reise.Avgangstid;
                    enReise.ankomstid = reise.Ankomstid;
                    enReise.pris = reise.Pris;
                    enReise.informasjon = reise.Informasjon;
                    enReise.reisetid = reise.Reisetid;
                    alleReiser.Add(enReise);
                }
            }

            return alleReiser;
        }

        public List<Reiser> valgtReise(int Id1, int Id2)
        {
            var db = new FlyContext();
            List<Reiser> reise1 = db.Reiser.Where(x => x.RId == Id1).ToList();
            List<Reiser> reise2 = db.Reiser.Where(x => x.RId == Id2).ToList();

            List<Reiser> reiseListe = new List<Reiser>();


            reiseListe.Add(reise1[0]); reiseListe.Add(reise2[0]);

            return reiseListe;
        }

        public List<Reiser> valgtReise(int Id1)
        {
            var db = new FlyContext();
            List<Reiser> reise1 = db.Reiser.Where(x => x.RId == Id1).ToList();

            return reise1;
        }

        public List<FlyReise> listAktuelleAvganger(String byFra, String byTil)
        {
            var db = new FlyContext();
            List<FlyReise> reiser = listAlleReiser().Where(x => x.byFra == byFra
            && x.byTil == byTil).ToList();

            return reiser;
        }

        public List<String> hentAlleFraFlyplasser()
        {
            using (var db = new FlyContext())
            {
                List<Reiser> alleFly = db.Reiser.ToList();
                var alleFraFly = new List<String>();

                foreach (Reiser f in alleFly)
                {
                    string funnetStrekning = alleFraFly.FirstOrDefault(fl => fl.Contains(f.ByFra));
                    if (funnetStrekning == null)
                    {
                        alleFraFly.Add(f.ByFra);
                    }
                }

                return alleFraFly;
            }
        }

        public List<String> hentTilFlyplasser(String ByFra)
        {
            using (var db = new FlyContext())
            {
                List<Reiser> alleFly = db.Reiser.ToList();

                var alleTilFly = new List<string>();

                foreach (Reiser f in alleFly)
                {
                    if (f.ByFra != ByFra)
                    {
                        string funnetStrekning = alleTilFly.FirstOrDefault(fl => fl.Contains(f.ByFra));
                        if (funnetStrekning == null)
                        {
                            alleTilFly.Add(f.ByFra);
                        }
                    }
                }

                return alleTilFly;
            }
        }

        public List<Reiser> hentTilgjengeligRute(String ByFra, String ByTil)
        {
            var db = new FlyContext();
            List<Reiser> tilgjengeligRute = db.Reiser.Where(f => f.ByTil == ByTil && f.ByFra == ByFra).ToList();

            return tilgjengeligRute;
        }

        public dynamic hentMellomlanding(String ByFra, String ByTil)
        {
            var db = new FlyContext();
            var mellomlandinger = (from ra in db.Reiser
                                   from rb in db.Reiser
                                   where ra.ByTil == rb.ByFra && ra.ByFra == ByFra && rb.ByTil == ByTil
                                   let pris = ra.Pris + rb.Pris

                                   select new
                                   {
                                       Ankomstid = rb.Ankomstid,
                                       Avgangstid = ra.Avgangstid,
                                       ByFra = ra.ByFra,
                                       Mellomlanding = rb.ByFra,
                                       ByTil = rb.ByTil,
                                       Flyplass = ra.Flyplass,
                                       Pris = pris,
                                       RId1 = ra.RId,
                                       RId2 = rb.RId,
                                       Reisetid = ra.Reisetid + rb.Reisetid
                                   }).ToList();

            return mellomlandinger;
        }

        public Kunde leggTilKunde(Kunde kunde)
        {

            Kunde nyKunde = kunde;

            using (var db = new FlyContext())
            {

                    db.Kunder.Add(nyKunde);
                    db.SaveChanges();
 
            }

            return nyKunde;
        }

        public void leggTil(List<HyperWing.Model.Reiser> reiser)
        {
            var db = new FlyContext();
            List<Reiser> reiseListe = db.Reiser.ToList();
        }

        public Billett visBestilling(Kunde kunde, List<HyperWing.Model.Reiser> reiser)
        {
            //den skal jo hente fra session?
            HyperWing.Model.Reiser reise1;
            HyperWing.Model.Reiser reise2;
        

            var billet = new Billett();

            if (reiser.Count == 1)
            {
                reise1 = reiser[0];

                billet = new Billett()
                {
                    PersonNr = kunde.personNr,
                    Navn = kunde.navn,
                    ByFra = reise1.ByFra,
                    ByTil = reise1.ByTil,
                    Epost = kunde.epost,
                    Telefon = kunde.telefon,
                    Avgang = reise1.Avgangstid,
                    Ankomst = reise1.Ankomstid,
                    Flyplass = reise1.Flyplass,
                    Pris = reise1.Pris,
                };
            }
            else
            {
                reise1 = reiser[0];
                reise2 = reiser[1];

                billet = new Billett()
                {
                    PersonNr = kunde.personNr,
                    Navn = kunde.navn,
                    ByFra = reise1.ByFra,
                    Mellomlanding = "Mellomlanding i: " + reise2.ByFra,
                    ByTil = reise2.ByTil,
                    Epost = kunde.epost,
                    Telefon = kunde.telefon,
                    Avgang = reise2.Avgangstid,
                    Ankomst = reise1.Ankomstid,
                    Flyplass = reise1.Flyplass,
                    Pris = reise1.Pris + reise2.Pris,
                };
            }
            using (var db = new FlyContext())
            {
                try
                {
                    db.Billetter.Add(billet);
                    db.SaveChanges();
                }
                catch
                {

                }
            }

            return billet;
        }

        /*
         * ----------------------------------------------------KUNDE
         */
        public List<Kunde> hentKunder()
        {
            var db = new FlyContext();
            List<Kunde> kundeListe = db.Kunder.ToList();
            return kundeListe;
        }
        public bool settInnKunde(Kunde innKunde)
        {
            var nyKunde = new Kunde()
            {
                navn = innKunde.navn,
                epost = innKunde.epost,
                telefon = innKunde.telefon,
                personNr = innKunde.personNr
            };

            var db = new FlyContext();
            try
            {
                db.Kunder.Add(nyKunde);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }

        }
        public bool endreKunde(int id, Kunde innKunde)
        {
            var db = new FlyContext();
            try
            {
                Kunde endreKunde = db.Kunder.FirstOrDefault(k => k.Id == id);
                endreKunde.navn = innKunde.navn;
                endreKunde.epost = innKunde.epost;
                endreKunde.personNr = innKunde.personNr;
                endreKunde.telefon = innKunde.telefon;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool slettKunde(int slettId)
        {
            var db = new FlyContext();
            try
            {
                Kunde slettKunde = db.Kunder.FirstOrDefault(k => k.Id == slettId);
                db.Kunder.Remove(slettKunde);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
        public Kunde hentEnKunde(int id)
        {
            var db = new FlyContext();

            var enDbKunde = db.Kunder.FirstOrDefault(k => k.Id == id);

            if (enDbKunde == null)
            {
                return null;
            }
            else
            {
                var utKunde = new Kunde()
                {
                    Id = enDbKunde.Id,
                    navn = enDbKunde.navn,
                    epost = enDbKunde.epost,
                    telefon = enDbKunde.telefon,
                    personNr = enDbKunde.personNr
                };
                return utKunde;
            }
        }
        /*
         * ----------------------------------------------------FLYPLASSER
         */
        public List<Flyplasser> hentFlyplasser()
        {
            var db = new FlyContext();
            List<Flyplasser> flyplassListe = db.Flyplasser.ToList();
            return flyplassListe;
        }
        public bool settInnFlyplass(Flyplasser innFlyplass)
        {
            var nyFlyplass = new Flyplasser()
            {
                Navn = innFlyplass.Navn
            };

            var db = new FlyContext();
            try
            {
                db.Flyplasser.Add(nyFlyplass);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }

        }
        public bool endreFlyplass(int id, Flyplasser innFlyplass)
        {
            var db = new FlyContext();
            try
            {
                Flyplasser endreFlyplass = db.Flyplasser.FirstOrDefault(k => k.FId == id);
                endreFlyplass.Navn = innFlyplass.Navn;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool slettFlyplass(int slettId)
        {
            var db = new FlyContext();
            try
            {
                Flyplasser slettFlyplass = db.Flyplasser.FirstOrDefault(k => k.FId == slettId);
                db.Flyplasser.Remove(slettFlyplass);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
        public Flyplasser hentEnFlyplass(int id)
        {
            var db = new FlyContext();

            var enDbFlyplass = db.Flyplasser.FirstOrDefault(k => k.FId == id);

            if (enDbFlyplass == null)
            {
                return null;
            }
            else
            {
                var utFlyplass = new Flyplasser()
                {
                    FId = enDbFlyplass.FId,
                    Navn = enDbFlyplass.Navn
                };
                return utFlyplass;
            }
        }
        /*
         * ----------------------------------------------------BILLETTER
         */
        public List<Billett> hentBilletter()
        {
            var db = new FlyContext();
            List<Billett> billettListe = db.Billetter.ToList();
            return billettListe;
        }
        public bool settInnBillett(Billett innBillett)
        {
            var nyBillett = new Billett()
            {
                PersonNr = innBillett.PersonNr,
                Navn = innBillett.Navn,
                ByFra = innBillett.ByFra,
                Mellomlanding = innBillett.Mellomlanding,
                ByTil = innBillett.ByTil,
                Epost = innBillett.Epost,
                Telefon = innBillett.Telefon,
                Avgang = innBillett.Avgang,
                Ankomst = innBillett.Ankomst,
                Flyplass = innBillett.Flyplass,
                Pris = innBillett.Pris
            };

            var db = new FlyContext();
            try
            {
                db.Billetter.Add(nyBillett);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
        public bool endreBillett(int id, Billett innBillett)
        {
            var db = new FlyContext();
            try
            {
                Billett endreBillett = db.Billetter.FirstOrDefault(k => k.Id == id);
                endreBillett.PersonNr = innBillett.PersonNr;
                endreBillett.Navn = innBillett.Navn;
                endreBillett.ByFra = innBillett.ByFra;
                endreBillett.Mellomlanding = innBillett.Mellomlanding;
                endreBillett.ByTil = innBillett.ByTil;
                endreBillett.Epost = innBillett.Epost;
                endreBillett.Telefon = innBillett.Telefon;
                endreBillett.Avgang = innBillett.Avgang;
                endreBillett.Ankomst = innBillett.Ankomst;
                endreBillett.Flyplass = innBillett.Flyplass;
                endreBillett.Pris = innBillett.Pris;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool slettBillett(int slettId)
        {
            var db = new FlyContext();
            try
            {
                Billett slettBillett = db.Billetter.FirstOrDefault(k => k.Id == slettId);
                db.Billetter.Remove(slettBillett);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
        public Billett hentEnBillett(int id)
        {
            var db = new FlyContext();

            var enDbBillett = db.Billetter.FirstOrDefault(k => k.Id == id);

            if (enDbBillett == null)
            {
                return null;
            }
            else
            {
                var utBillett = new Billett()
                {
                    Id = enDbBillett.Id,
                    PersonNr = enDbBillett.PersonNr,
                    Navn = enDbBillett.Navn,
                    ByFra = enDbBillett.ByFra,
                    Mellomlanding = enDbBillett.Mellomlanding,
                    ByTil = enDbBillett.ByTil,
                    Epost = enDbBillett.Epost,
                    Telefon = enDbBillett.Telefon,
                    Avgang = enDbBillett.Avgang,
                    Ankomst = enDbBillett.Ankomst,
                    Flyplass = enDbBillett.Flyplass,
                    Pris = enDbBillett.Pris
                };
                return utBillett;
            }
        }
        /*
         * ----------------------------------------------------REISER
         */
        public List<Reiser> hentReiser()
        {
            var db = new FlyContext();
            List<Reiser> reiserListe = db.Reiser.ToList();
            return reiserListe;
        }
        public bool settInnReise(Reiser innReise)
        {
            var nyReise = new Reiser()
            {
                RId = innReise.RId,
                ByFra = innReise.ByFra,
                ByTil = innReise.ByTil,
                Avgangstid = innReise.Avgangstid,
                Ankomstid = innReise.Ankomstid,
                Flyplass = innReise.Flyplass,
                Pris = innReise.Pris,
                Reisetid = innReise.Reisetid,
                FId = innReise.FId,
            };

            var db = new FlyContext();
            try
            {
                db.Reiser.Add(nyReise);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
        public bool endreReise(int id, Reiser innReise)
        {
            var db = new FlyContext();
            try
            {
                Reiser endreReise = db.Reiser.FirstOrDefault(k => k.RId == id);
                endreReise.ByFra = innReise.ByFra;
                endreReise.ByTil = innReise.ByTil;
                endreReise.Flyplass = innReise.Flyplass;
                endreReise.Avgangstid = innReise.Avgangstid;
                endreReise.Ankomstid = innReise.Ankomstid;
                endreReise.Reisetid = innReise.Reisetid;
                endreReise.Pris = innReise.Pris;
                endreReise.FId = innReise.FId;


                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool slettReise(int slettId)
        {
            var db = new FlyContext();
            try
            {
                Reiser slettReise = db.Reiser.FirstOrDefault(k => k.RId == slettId);
                db.Reiser.Remove(slettReise);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
        public Reiser hentEnReise(int id)
        {
            var db = new FlyContext();

            var enDbReise = db.Reiser.FirstOrDefault(k => k.RId == id);

            if (enDbReise == null)
            {
                return null;
            }
            else
            {
                var utReise = new Reiser()
                {
                    RId = enDbReise.RId,
                    ByFra = enDbReise.ByFra,
                    ByTil = enDbReise.ByTil,
                    Flyplass = enDbReise.Flyplass,
                    Avgangstid = enDbReise.Avgangstid,
                    Ankomstid = enDbReise.Ankomstid,
                    Reisetid = enDbReise.Reisetid,
                    Pris = enDbReise.Pris,
                    FId = enDbReise.FId,
                };
                return utReise;
            }
        }
    }
}

