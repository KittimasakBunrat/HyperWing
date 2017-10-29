using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HyperWing.Model;
using Model;

namespace HyperWing.DAL
{
    public class DbInit : CreateDatabaseIfNotExists<FlyContext>
    {
        protected override void Seed(FlyContext context)
        {

            var OSL = new Flyplasser() { Navn = "OSL - Oslo Lufthavn" };
            var BKK = new Flyplasser() { Navn = "BKK - Suvarnabhumi Airport" };
            var ARN = new Flyplasser() { Navn = "ARN - Stockholm Arlanda Airport" };
            var HEL = new Flyplasser() { Navn = "HEL - Vantaa Helsinki Airport" };
            var AMS = new Flyplasser() { Navn = "AMS - Schiphol Airport" };
            var LHR = new Flyplasser() { Navn = "LHR - Heathrow Airport" };
            var HKG = new Flyplasser() { Navn = "HKG - Hong Kong Airport" };
            var JFK = new Flyplasser() { Navn = "JFK - John F Kennedy Airport" };

            var db = new AdminRepository();
            String passord = "root";
            String salt = db.lagSalt();
            var passordOgSalt = passord + salt;
            byte[] passordDB = db.lagHash(passordOgSalt);
            var admin = new dbAdmin()
            {
                Navn = "root",
                Salt = salt,
                Passord = passordDB
            };


            SeedValues values = new SeedValues();

            OSL.Reiser = values.osloReise();
            BKK.Reiser = values.bangkokkReise();
            ARN.Reiser = values.stockholmReise();
            HEL.Reiser = values.helsinkiReise();
            AMS.Reiser = values.amsterdamReise();
            LHR.Reiser = values.londonReise();
            HKG.Reiser = values.hongKongReise();
            JFK.Reiser = values.newYorkReise();

            foreach (var r in OSL.Reiser) { r.Flyplass = OSL.Navn; }
            foreach (var r in BKK.Reiser) { r.Flyplass = BKK.Navn; }
            foreach (var r in ARN.Reiser) { r.Flyplass = ARN.Navn; }
            foreach (var r in HEL.Reiser) { r.Flyplass = HEL.Navn; }
            foreach (var r in AMS.Reiser) { r.Flyplass = AMS.Navn; }
            foreach (var r in LHR.Reiser) { r.Flyplass = LHR.Navn; }
            foreach (var r in HKG.Reiser) { r.Flyplass = HKG.Navn; }
            foreach (var r in JFK.Reiser) { r.Flyplass = JFK.Navn; }

            context.Flyplasser.Add(OSL);
            context.Flyplasser.Add(BKK);
            context.Flyplasser.Add(ARN);
            context.Flyplasser.Add(HEL);
            context.Flyplasser.Add(AMS);
            context.Flyplasser.Add(LHR);
            context.Flyplasser.Add(HKG);
            context.Flyplasser.Add(JFK);
            context.Administratorer.Add(admin);

            base.Seed(context);
        }
    }
}