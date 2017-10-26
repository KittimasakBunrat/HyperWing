using HyperWing.Model;
using System;
using System.Collections.Generic;

namespace HyperWing.BLL
{
    public interface IAdminLogikk
    {
        bool adminDB(Admin admin);

        bool endreKunde(int id, Kunde innKunde);
        List<Kunde> hentAlleKunder();
        Kunde hentEnKunde(int id);
        bool settInnKunde(Kunde innKunde);
        bool slettKunde(int id);

        bool endreBillett(int id, Billett innBillett);
        List<Billett> hentAlleBilletter();
        Billett hentEnBillett(int id);
        bool settInnBillett(Billett innBillett);
        bool slettBillett(int id);

        bool endreFlyplass(int id, Flyplasser innFlyplass);
        List<Flyplasser> hentAlleFlyplasser();
        Flyplasser hentEnFlyplass(int id);
        bool settInnFlyplass(Flyplasser innFlyplass);
        bool slettFlyplass(int id);


        bool endreReise(int id, Reiser innReise);
        List<Reiser> hentAlleReiser();
        Reiser hentEnReise(int id);
        bool settInnReise(Reiser innReise);
        bool slettReise(int id);
    }
}
