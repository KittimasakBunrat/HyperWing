using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperWing.DAL;
using HyperWing.Model;

namespace HyperWing.BLL
{
    public class AdminBLL
    {
        public bool adminDB(Admin admin)
        {
            var db = new DB();
            return db.adminDB(admin);
        }

        public List<String> hentAlleFraFlyplasser()
        {
            var db = new DB();
            return db.hentAlleFraFlyplasser();
        }

        public List<String> hentTilFlyplasser(String ByFra)
        {
            var db = new DB();
            return db.hentTilFlyplasser(ByFra);
        }

        public dynamic hentTilgjengeligRute(String ByFra, String ByTil)
        {
            var db = new DB();
            return db.hentTilgjengeligRute(ByFra, ByTil);
        }

        public dynamic hentMellomlanding(String ByFra, String ByTil)
        {
            var db = new DB();
            return db.hentMellomlanding(ByFra, ByTil);
        }

        public dynamic hentValgtReise(int id, int Id2)
        {
            var db = new DB();
            return db.valgtReise(id, Id2);
        }

        public dynamic hentValgtReise(int id)
        {
            var db = new DB();
            return db.valgtReise(id);
        }

        public Kunde leggTilKunde(Kunde kunde)
        {
            var db = new DB();
            return db.leggTilKunde(kunde);
        }

        public Billett visBestilling(Kunde kunde, List<HyperWing.Model.Reiser> reiser)
        {
            var db = new DB();
            return db.visBestilling(kunde, reiser);
        }

        public List<Kunde> hentKunder()
        {
            var db = new DB();
            return db.hentKunder();
        }


    }

}
