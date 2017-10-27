using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using HyperWing.Model;
using System.IO;

namespace HyperWing.DAL
{
    public class AdminRepository : DAL.IAdminRepository
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

      /*  public bool adminDB(Admin admin)
        {
            var db = new DB();
            return db.adminDB(admin);
        }*/

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


        public List<Kunde> hentAlleKunder()
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
                db.Database.Log = (s) => { db.LoggEndringer(s); };
                db.Kunder.Add(nyKunde);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                db.LoggFeilmeldinger(feil.ToString());
                return false;
            }

        }
        public bool endreKunde(int id, Kunde innKunde)
        {
            var db = new FlyContext();
            try
            {
                db.Database.Log = (s) => { db.LoggEndringer(s); };
                Kunde endreKunde = db.Kunder.FirstOrDefault(k => k.Id == id);
                endreKunde.epost = innKunde.epost;
                endreKunde.navn = innKunde.navn;
                endreKunde.personNr = innKunde.personNr;
                endreKunde.telefon = innKunde.telefon;
             
                db.SaveChanges();
                return true;
            }
            catch(Exception feil)
            {
                db.LoggFeilmeldinger(feil.ToString());
                return false;
            }
        }
        public bool slettKunde(int slettId)
        {
            var db = new FlyContext();
            try
            {
                db.Database.Log = (s) => { db.LoggEndringer(s); };
                Kunde slettKunde = db.Kunder.FirstOrDefault(k => k.Id == slettId);
                db.Kunder.Remove(slettKunde);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                db.LoggFeilmeldinger(feil.ToString());
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

        public List<Billett> hentAlleBilletter()
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
                db.Database.Log = (s) => { db.LoggEndringer(s); };
                db.Billetter.Add(nyBillett);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                db.LoggFeilmeldinger(feil.ToString());
                return false;
            }
        }
        public bool endreBillett(int id, Billett innBillett)
        {
            var db = new FlyContext();
            try
            {
                db.Database.Log = (s) => { db.LoggEndringer(s); };
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
            catch (Exception feil)
            {
                db.LoggFeilmeldinger(feil.ToString());
                return false;
            }
        }
        public bool slettBillett(int slettId)
        {
            var db = new FlyContext();
            try
            {
                db.Database.Log = (s) => { db.LoggEndringer(s); };
                Billett slettBillett = db.Billetter.FirstOrDefault(k => k.Id == slettId);
                db.Billetter.Remove(slettBillett);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                db.LoggFeilmeldinger(feil.ToString());
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

        public List<Reiser> hentAlleReiser()
        {
            var db = new FlyContext();
            List<Reiser> reiseListe = db.Reiser.ToList();
            return reiseListe;
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
                db.Database.Log = (s) => { db.LoggEndringer(s); };
                db.Reiser.Add(nyReise);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                db.LoggFeilmeldinger(feil.ToString());
                return false;
            }
        }
        public bool endreReise(int id, Reiser innReise)
        {
            var db = new FlyContext();
            try
            {
                db.Database.Log = (s) => { db.LoggEndringer(s); };
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
            catch(Exception feil)
            {
                db.LoggFeilmeldinger(feil.ToString());
                return false;
            }
        }
        public bool slettReise(int slettId)
        {
            var db = new FlyContext();
            try
            {
                db.Database.Log = (s) => { db.LoggEndringer(s); };
                Reiser slettReise = db.Reiser.FirstOrDefault(k => k.RId == slettId);
                db.Reiser.Remove(slettReise);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                db.LoggFeilmeldinger(feil.ToString());
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

        public List<Flyplasser> hentAlleFlyplasser()
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
                db.Database.Log = (s) => { db.LoggEndringer(s); };
                db.Flyplasser.Add(nyFlyplass);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                db.LoggFeilmeldinger(feil.ToString());
                return false;
            }

        }
        public bool endreFlyplass(int id, Flyplasser innFlyplass)
        {
            var db = new FlyContext();
            try
            {
                db.Database.Log = (s) => { db.LoggEndringer(s); };
                Flyplasser endreFlyplass = db.Flyplasser.FirstOrDefault(k => k.FId == id);
                endreFlyplass.Navn = innFlyplass.Navn;

                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                db.LoggFeilmeldinger(feil.ToString());
                return false;
            }
        }
        public bool slettFlyplass(int slettId)
        {
            var db = new FlyContext();
            try
            {
                db.Database.Log = (s) => { db.LoggEndringer(s); };
                Flyplasser slettFlyplass = db.Flyplasser.FirstOrDefault(k => k.FId == slettId);
                db.Flyplasser.Remove(slettFlyplass);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                db.LoggFeilmeldinger(feil.ToString());
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
    }
}
        

