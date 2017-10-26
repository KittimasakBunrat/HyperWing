using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperWing.DAL;
using HyperWing.Model;

namespace HyperWing.BLL
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

        public bool adminDB(Admin admin)
        {
            return _repository.adminDB(admin);
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
