using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HyperWing.Model;

namespace HyperWing.DAL
{
    public class AdminRepositoryStub : DAL.IAdminRepository
    {

        public List<Kunde> hentAlleKunder()
        {
            var kundeListe = new List<Kunde>();
            var kunde = new Kunde()
            {
                Id = 1,
                navn = "Shohaib Bunrat",
                epost = "knoll@tott.com",
                telefon = 12345678,
                personNr = "987654321",

            };
            kundeListe.Add(kunde);
            kundeListe.Add(kunde);
            kundeListe.Add(kunde);
            return kundeListe;
        }
        public bool settInnKunde(Kunde innKunde)
        {
            if (innKunde.navn == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool endreKunde(int id, Kunde innKunde)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool slettKunde(int slettId)
        {
            if (slettId == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Kunde hentEnKunde(int id)
        {
            if (id == 0)
            {
                var kunde = new Kunde();
                kunde.Id = 0;
                return kunde;
            }
            else
            {
                var kunde = new Kunde()
                {
                    Id = 1,
                    navn = "Shohaib Bunrat",
                    epost = "knoll@tott.com",
                    telefon = 12345678,
                    personNr = "987654321"
                };
                return kunde;
            }
        }

        public List<Billett> hentAlleBilletter()
        {
            var billettListe = new List<Billett>();
            var billett = new Billett()
            {
                Id = 1,
                PersonNr = "987654321",
                Navn = "Shohaib Bunrat",
                ByFra = "Oslo",
                Mellomlanding = "Amsterdam",
                ByTil = "Hong Kong",
                Epost = "knoll@tott.com",
                Telefon = 12345678,
                Avgang = new DateTime(2017, 10, 20, 3, 43, 54),
                Ankomst = new DateTime(2017, 10, 20, 9, 43, 54),
                Flyplass = "OSL - Oslo Lufthavn",
                Pris = (int)789.99,

            };
            billettListe.Add(billett);
            billettListe.Add(billett);
            billettListe.Add(billett);
            return billettListe;
        }
        public bool settInnBillett(Billett innBillett)
        {
            if (innBillett.ByFra == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool endreBillett(int id, Billett innBillett)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool slettBillett(int slettId)
        {
            if (slettId == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Billett hentEnBillett(int id)
        {
            if (id == 0)
            {
                var billett = new Billett();
                billett.Id = 0;
                return billett;
            }
            else
            {
                var billett = new Billett()
                {
                    Id = 1,
                    PersonNr = "987654321",
                    Navn = "Shohaib Bunrat",
                    ByFra = "Oslo",
                    Mellomlanding = "Amsterdam",
                    ByTil = "Hong Kong",
                    Epost = "knoll@tott.com",
                    Telefon = 12345678,
                    Avgang = new DateTime(2017, 10, 20, 3, 43, 54),
                    Ankomst = new DateTime(2017, 10, 20, 9, 43, 54),
                    Flyplass = "OSL - Oslo Lufthavn",
                    Pris = (int)789.99
                };
                return billett;
            }
        }

        public List<Reiser> hentAlleReiser()
        {
            var reiseListe = new List<Reiser>();
            var reise = new Reiser()
            {
                RId = 1,
                ByFra = "Oslo",
                ByTil = "Stockholm",
                Flyplass = "OSL - Oslo Lufthavn",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Ankomstid = new DateTime(2017, 10, 20, 4, 43, 54),
                Reisetid = "0t 55m",
                Pris = (int)659.99,
                Informasjon = null,
                FId = 1,

            };
            reiseListe.Add(reise);
            reiseListe.Add(reise);
            reiseListe.Add(reise);
            return reiseListe;
        }
        public bool settInnReise(Reiser innReise)
        {
            if (innReise.ByFra == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool endreReise(int id, Reiser innReise)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool slettReise(int slettId)
        {
            if (slettId == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Reiser hentEnReise(int id)
        {
            if (id == 0)
            {
                var reise = new Reiser();
                reise.RId = 0;
                return reise;
            }
            else
            {
                var reise = new Reiser()
                {
                    RId = 1,
                    ByFra = "Oslo",
                    ByTil = "Stockholm",
                    Flyplass = "OSL - Oslo Lufthavn",
                    Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                    Ankomstid = new DateTime(2017, 10, 20, 4, 43, 54),
                    Reisetid = "0t 55m",
                    Pris = (int)659.99,
                    Informasjon = null,
                    FId = 1
                };
                return reise;
            }
        }

        public List<Flyplasser> hentAlleFlyplasser()
        {
            var flyplassListe = new List<Flyplasser>();
            var flyplass = new Flyplasser()
            {
                FId = 1,
                Navn = "OSL - Oslo Lufthavn",

            };
            flyplassListe.Add(flyplass);
            flyplassListe.Add(flyplass);
            flyplassListe.Add(flyplass);
            return flyplassListe;
        }
        public bool settInnFlyplass(Flyplasser innFlyplass)
        {
            if (innFlyplass.Navn == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool endreFlyplass(int id, Flyplasser innFlyplass)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool slettFlyplass(int slettId)
        {
            if (slettId == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Flyplasser hentEnFlyplass(int id)
        {
            if (id == 0)
            {
                var flyplass = new Flyplasser();
                flyplass.FId = 0;
                return flyplass;
            }
            else
            {
                var flyplass = new Flyplasser()
                {
                    FId = 1,
                    Navn = "OSL - Oslo Lufthavn"
                };
                return flyplass;
            }
        }

        public bool adminDB(Admin admin)
        {
            if (admin.Navn == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
