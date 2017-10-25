using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperWing.DAL;
using HyperWing.Model;
using Model;

namespace HyperWing.BLL
{
    public class AdminBLL
    {
        DB db = new DB();

        public bool adminDB(Admin admin)
        {
            return db.adminDB(admin);
        }

        public List<String> hentAlleFraFlyplasser()
        {
            return db.hentAlleFraFlyplasser();
        }

        public List<String> hentTilFlyplasser(String ByFra)
        {
            return db.hentTilFlyplasser(ByFra);
        }

        public dynamic hentTilgjengeligRute(String ByFra, String ByTil)
        {
            return db.hentTilgjengeligRute(ByFra, ByTil);
        }

        public dynamic hentMellomlanding(String ByFra, String ByTil)
        {
            return db.hentMellomlanding(ByFra, ByTil);
        }

        public dynamic hentValgtReise(int id, int Id2)
        {
            return db.valgtReise(id, Id2);
        }

        public dynamic hentValgtReise(int id)
        {
            return db.valgtReise(id);
        }

        public Kunde leggTilKunde(Kunde kunde)
        {
            return db.leggTilKunde(kunde);
        }

        public Billett visBestilling(Kunde kunde, List<HyperWing.Model.Reiser> reiser)
        {
            return db.visBestilling(kunde, reiser);
        }

        public List<Kunde> hentKunder()
        {
            return db.hentKunder();
        }

        public bool endreKunde(int id, Kunde innKunde)
        {
            return db.endreKunde(id, innKunde);
        }

        public Kunde hentEnKunde(int id)
        {
            return db.hentEnKunde(id);
        }

        public bool settInnKunde(Kunde innKunde)
        {
            return db.settInnKunde(innKunde);
        }

        public bool slettKunde(int id)
        {
            return db.slettKunde(id);
        }

        public List<Flyplasser> hentFlyplasser()
        {
            var db = new DB();
            return db.hentFlyplasser();
        }

        public List<Billett> hentBilletter()
        {
            var db = new DB();
            return db.hentBilletter();
        }

        public List<Reiser> hentReiser()
        {
            var db = new DB();
            return db.hentReiser();
        }


    }

}

/*
 * 
 * namespace HyperWing.BLL
{
    public class AdminLogikk : BLL.IAdminLogikk
    {

        private IAdminRepository _repository;

        public AdminLogikk()
        {
            _repository = new AdminRepository();
        }

        public AdminLogikk(IAdminRepository stub)
        {
            _repository = stub;
        }

        /*
        public bool adminDB(Admin admin)
        {
            var db = new DB();
            return db.adminDB(admin);
        }
        

// Kunde
public bool endreKunde(int id, Kunde innKunde)
{
    return _repository.endreKunde(id, innKunde);
}

public List<Kunde> hentAlleKunder()
{
    List<Kunde> allePersoner = _repository.hentAlleKunder();
    return allePersoner;
}

public Kunde hentEnKunde(int id)
{
    return _repository.hentEnKunde(id);
}

public bool settInnKunde(Kunde innKunde)
{
    return _repository.settInnKunde(innKunde);
}

public bool slettKunde(int id)
{
    return _repository.slettKunde(id);
}

// Billett
public bool endreBillett(int id, Billett innBillett)
{
    return _repository.endreBillett(id, innBillett);
}

public List<Billett> hentAlleBilletter()
{
    List<Billett> alleBilletter = _repository.hentAlleBilletter();
    return alleBilletter;
}

public Billett hentEnBillett(int id)
{
    return _repository.hentEnBillett(id);
}

public bool settInnBillett(Billett innBillett)
{
    return _repository.settInnBillett(innBillett);
}

public bool slettBillett(int id)
{
    return _repository.slettBillett(id);
}

// Flyplass
public bool endreFlyplass(int id, Flyplasser innFlyplass)
{
    return _repository.endreFlyplass(id, innFlyplass);
}

public List<Flyplasser> hentAlleFlyplasser()
{
    List<Flyplasser> alleFlyplasser = _repository.hentAlleFlyplasser();
    return alleFlyplasser;
}

public Flyplasser hentEnFlyplass(int id)
{
    return _repository.hentEnFlyplass(id);
}

public bool settInnFlyplass(Flyplasser innFlyplass)
{
    return _repository.settInnFlyplass(innFlyplass);
}

public bool slettFlyplass(int id)
{
    return _repository.slettFlyplass(id);
}

// Reise
public bool endreReise(int id, Reiser innReise)
{
    return _repository.endreReise(id, innReise);
}

public List<Reiser> hentAlleReiser()
{
    List<Reiser> alleReiser = _repository.hentAlleReiser();
    return alleReiser;
}

public Reiser hentEnReise(int id)
{
    return _repository.hentEnReise(id);
}

public bool settInnReise(Reiser innReise)
{
    return _repository.settInnReise(innReise);
}

public bool slettReise(int id)
{
    return _repository.slettReise(id);
}

    }

}

 *
 * */
