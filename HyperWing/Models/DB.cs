using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HyperWing.Models
{
    public class DB
    {
        public List<FlyReise> listAlleReiser()
        {
            var db = new FlyContext();
            List<Flyplasser> flyplasser = db.Flyplasser.ToList();
            List<FlyReise> alleReiser = new List<FlyReise>();

            foreach(var flyplass in flyplasser)
            {
                foreach(var reise in flyplass.Reiser)
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


            reiseListe.Add(reise1[0]);reiseListe.Add(reise2[0]);

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
    }
}