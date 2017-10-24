using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using HyperWing.Model;

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

        public List<Kunde> hentKunder()
        {
            var db = new FlyContext();
            List<Kunde> kundeListe = db.Kunder.ToList();
            return kundeListe;
        }
    }
}

