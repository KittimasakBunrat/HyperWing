using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace HyperWing.DAL
{
    public class SeedValues
    {
        public List<Reiser> osloReise()
        {

            List<Reiser> reiser = new List<Reiser>();
            StringBuilder stringBuilder = new StringBuilder();
            TimeSpan timeSpan = new TimeSpan();

            var osloReise1 = new Reiser()
            {
                ByFra = "Oslo",
                ByTil = "Stockholm",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)659.99,
                

            };
            osloReise1.Ankomstid = osloReise1.Avgangstid.AddMinutes(55);

            var osloReise2 = new Reiser()
            {
                ByFra = "Oslo",
                ByTil = "Stockholm",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)789.99,
                
            };
            osloReise2.Ankomstid = osloReise2.Avgangstid.AddHours(1);

            var osloReise3 = new Reiser()
            {
                ByFra = "Oslo",
                ByTil = "Stockholm",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)489.99,
                
            };
            osloReise3.Ankomstid = osloReise3.Avgangstid.AddMinutes(50);

            var osloReise4 = new Reiser()
            {
                ByFra = "Oslo",
                ByTil = "Amsterdam",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)394.99,
                

            };
            osloReise4.Ankomstid = osloReise4.Avgangstid.AddHours(2).AddMinutes(50);

            var osloReise5 = new Reiser()
            {
                ByFra = "Oslo",
                ByTil = "Amsterdam",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)1106.99,
                
            };
            osloReise5.Ankomstid = osloReise5.Avgangstid.AddHours(2);

            var osloReise6 = new Reiser()
            {
                ByFra = "Oslo",
                ByTil = "Amsterdam",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)1650.99,
                
            };
            osloReise6.Ankomstid = osloReise6.Avgangstid.AddHours(1).AddMinutes(20);

            var osloReise7 = new Reiser()
            {
                ByFra = "Oslo",
                ByTil = "London",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)1086.99,
                

            };
            osloReise7.Ankomstid = osloReise7.Avgangstid.AddHours(3).AddMinutes(10);

            var osloReise8 = new Reiser()
            {
                ByFra = "Oslo",
                ByTil = "London",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)1297.99,
                
            };
            osloReise8.Ankomstid = osloReise8.Avgangstid.AddHours(2).AddMinutes(20);

            var osloReise9 = new Reiser()
            {
                ByFra = "Oslo",
                ByTil = "London",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)1575.99,
                
            };
            osloReise9.Ankomstid = osloReise9.Avgangstid.AddHours(2);

            reiser.Add(osloReise1);
            reiser.Add(osloReise2);
            reiser.Add(osloReise3);
            reiser.Add(osloReise4);
            reiser.Add(osloReise5);
            reiser.Add(osloReise6);
            reiser.Add(osloReise7);
            reiser.Add(osloReise8);
            reiser.Add(osloReise9);


            foreach (var r in reiser)
            {

                timeSpan = (r.Ankomstid - r.Avgangstid);
                stringBuilder = new StringBuilder().Append
                    (String.Format("{0}t {1}m", timeSpan.Hours, timeSpan.Minutes));
                 r.Reisetid = stringBuilder.ToString();


            }

            return reiser;
        }

        public List<Reiser> stockholmReise()
        {

            List<Reiser> reiser = new List<Reiser>();
            StringBuilder stringBuilder = new StringBuilder();
            TimeSpan timeSpan = new TimeSpan();

            var stockholmReise1 = new Reiser()
            {
                ByFra = "Stockholm",
                ByTil = "Oslo",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)299.99,
                

            };
            stockholmReise1.Ankomstid = stockholmReise1.Avgangstid.AddHours(1).AddMinutes(10);

            var stockholmReise2 = new Reiser()
            {
                ByFra = "Stockholm",
                ByTil = "Oslo",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)406.99,
                
            };
            stockholmReise2.Ankomstid = stockholmReise2.Avgangstid.AddHours(1).AddMinutes(20);

            var stockholmReise3 = new Reiser()
            {
                ByFra = "Stockholm",
                ByTil = "Oslo",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)607.99,
                
            };
            stockholmReise3.Ankomstid = stockholmReise3.Avgangstid.AddHours(1);


            var stockholmReise4 = new Reiser()
            {
                ByFra = "Stockholm",
                ByTil = "Helsinki",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)613.99,
                

            };
            stockholmReise4.Ankomstid = stockholmReise4.Avgangstid.AddHours(1).AddMinutes(30);

            var stockholmReise5 = new Reiser()
            {
                ByFra = "Stockholm",
                ByTil = "Helsinki",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)802.99,
                
            };
            stockholmReise5.Ankomstid = stockholmReise5.Avgangstid.AddHours(1).AddMinutes(5);

            var stockholmReise6 = new Reiser()
            {
                ByFra = "Stockholm",
                ByTil = "Helsinki",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)1487.99,
                
            };
            stockholmReise6.Ankomstid = stockholmReise6.Avgangstid.AddMinutes(50);

            var stockholmReise7 = new Reiser()
            {
                ByFra = "Stockholm",
                ByTil = "New York",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)2777.99,
                

            };
            stockholmReise7.Ankomstid = stockholmReise7.Avgangstid.AddHours(17).AddMinutes(30);

            var stockholmReise8 = new Reiser()
            {
                ByFra = "Stockholm",
                ByTil = "New York",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)5020.99,
                
            };
            stockholmReise8.Ankomstid = stockholmReise8.Avgangstid.AddHours(14).AddMinutes(20);

            var stockholmReise9 = new Reiser()
            {
                ByFra = "Stockholm",
                ByTil = "New York",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)7820.99,
                
            };
            stockholmReise9.Ankomstid = stockholmReise9.Avgangstid.AddHours(10).AddMinutes(30);


            reiser.Add(stockholmReise1);
            reiser.Add(stockholmReise2);
            reiser.Add(stockholmReise3);
            reiser.Add(stockholmReise4);
            reiser.Add(stockholmReise5);
            reiser.Add(stockholmReise6);
            reiser.Add(stockholmReise7);
            reiser.Add(stockholmReise8);
            reiser.Add(stockholmReise9);

            foreach (var r in reiser)
            {

                timeSpan = (r.Ankomstid - r.Avgangstid);
                stringBuilder = new StringBuilder().Append
                    (String.Format("{0}t {1}m", timeSpan.Hours, timeSpan.Minutes));
                r.Reisetid = stringBuilder.ToString();

            }

            return reiser;
        }

        public List<Reiser> helsinkiReise()
        {

            List<Reiser> reiser = new List<Reiser>();
            StringBuilder stringBuilder = new StringBuilder();
            TimeSpan timeSpan = new TimeSpan();

            var helsinkiReise1 = new Reiser()
            {
                ByFra = "Helsinki",
                ByTil = "Stockholm",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)705.99,
                

            };
            helsinkiReise1.Ankomstid = helsinkiReise1.Avgangstid.AddHours(1).AddMinutes(55);

            var helsinkiReise2 = new Reiser()
            {
                ByFra = "Helsinki",
                ByTil = "Stockholm",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)810.99,
                
            };
            helsinkiReise2.Ankomstid = helsinkiReise2.Avgangstid.AddHours(1).AddMinutes(20);

            var helsinkiReise3 = new Reiser()
            {
                ByFra = "Helsinki",
                ByTil = "Stockholm",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)1448.99,
                
            };
            helsinkiReise3.Ankomstid = helsinkiReise3.Avgangstid.AddHours(1);

            var helsinkiReise4 = new Reiser()
            {
                ByFra = "Helsinki",
                ByTil = "London",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)999.99,
                

            };
            helsinkiReise4.Ankomstid = helsinkiReise4.Avgangstid.AddHours(7);

            var helsinkiReise5 = new Reiser()
            {
                ByFra = "Helsinki",
                ByTil = "London",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)2551.99,
                
            };
            helsinkiReise5.Ankomstid = helsinkiReise5.Avgangstid.AddHours(6).AddMinutes(10);

            var helsinkiReise6 = new Reiser()
            {
                ByFra = "Helsinki",
                ByTil = "London",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)4123.99,
                
            };
            helsinkiReise6.Ankomstid = helsinkiReise6.Avgangstid.AddHours(5);

            var helsinkiReise7 = new Reiser()
            {
                ByFra = "Helsinki",
                ByTil = "Hong Kong",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)2521.99,
                

            };
            helsinkiReise7.Ankomstid = helsinkiReise7.Avgangstid.AddHours(20).AddMinutes(30);

            var helsinkiReise8 = new Reiser()
            {
                ByFra = "Helsinki",
                ByTil = "Hong Kong",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)4200.99,
                
            };
            helsinkiReise8.Ankomstid = helsinkiReise8.Avgangstid.AddHours(17).AddMinutes(20);

            var helsinkiReise9 = new Reiser()
            {
                ByFra = "Helsinki",
                ByTil = "Hong Kong",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)9320.99,
                
            };
            helsinkiReise9.Ankomstid = helsinkiReise9.Avgangstid.AddHours(15);

            reiser.Add(helsinkiReise1);
            reiser.Add(helsinkiReise2);
            reiser.Add(helsinkiReise3);
            reiser.Add(helsinkiReise4);
            reiser.Add(helsinkiReise5);
            reiser.Add(helsinkiReise6);
            reiser.Add(helsinkiReise7);
            reiser.Add(helsinkiReise8);
            reiser.Add(helsinkiReise9);

            foreach (var r in reiser)
            {

                timeSpan = (r.Ankomstid - r.Avgangstid);
                stringBuilder = new StringBuilder().Append
                    (String.Format("{0}t {1}m", timeSpan.Hours, timeSpan.Minutes));
                r.Reisetid = stringBuilder.ToString();

            }

            return reiser;
        }

        public List<Reiser> amsterdamReise()
        {

            List<Reiser> reiser = new List<Reiser>();
            StringBuilder stringBuilder = new StringBuilder();
            TimeSpan timeSpan = new TimeSpan();

            var amsterdamReise1 = new Reiser()
            {
                ByFra = "Amsterdam",
                ByTil = "Oslo",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)411.99,
                

            };
            amsterdamReise1.Ankomstid = amsterdamReise1.Avgangstid.AddHours(1).AddMinutes(55);

            var amsterdamReise2 = new Reiser()
            {
                ByFra = "Amsterdam",
                ByTil = "Oslo",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)1224.99,
                
            };
            amsterdamReise2.Ankomstid = amsterdamReise2.Avgangstid.AddHours(2).AddMinutes(20);

            var amsterdamReise3 = new Reiser()
            {
                ByFra = "Amsterdam",
                ByTil = "Oslo",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)3092.99,
                
            };
            amsterdamReise3.Ankomstid = amsterdamReise3.Avgangstid.AddHours(1).AddMinutes(30);

            var amsterdamReise4 = new Reiser()
            {
                ByFra = "Amsterdam",
                ByTil = "Hong Kong",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)4664.99,
                

            };
            amsterdamReise4.Ankomstid = amsterdamReise4.Avgangstid.AddHours(19);

            var amsterdamReise5 = new Reiser()
            {
                ByFra = "Amsterdam",
                ByTil = "Hong Kong",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)6289.99,
                
            };
            amsterdamReise5.Ankomstid = amsterdamReise5.Avgangstid.AddHours(17).AddMinutes(30);

            var amsterdamReise6 = new Reiser()
            {
                ByFra = "Amsterdam",
                ByTil = "Hong Kong",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)12032.99,
                
            };
            amsterdamReise6.Ankomstid = amsterdamReise6.Avgangstid.AddHours(15);

            var amsterdamReise7 = new Reiser()
            {
                ByFra = "Amsterdam",
                ByTil = "Bangkok",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)3542.99,
                

            };
            amsterdamReise7.Ankomstid = amsterdamReise7.Avgangstid.AddHours(15).AddMinutes(30);

            var amsterdamReise8 = new Reiser()
            {
                ByFra = "Amsterdam",
                ByTil = "Bangkok",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)4540.99,
                
            };
            amsterdamReise8.Ankomstid = amsterdamReise8.Avgangstid.AddHours(16).AddMinutes(20);

            var amsterdamReise9 = new Reiser()
            {
                ByFra = "Amsterdam",
                ByTil = "Bangkok",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)7320.99,
                
            };
            amsterdamReise9.Ankomstid = amsterdamReise9.Avgangstid.AddHours(9);

            reiser.Add(amsterdamReise1);
            reiser.Add(amsterdamReise2);
            reiser.Add(amsterdamReise3);
            reiser.Add(amsterdamReise4);
            reiser.Add(amsterdamReise5);
            reiser.Add(amsterdamReise6);
            reiser.Add(amsterdamReise7);
            reiser.Add(amsterdamReise8);
            reiser.Add(amsterdamReise9);

            foreach (var r in reiser)
            {

                timeSpan = (r.Ankomstid - r.Avgangstid);
                stringBuilder = new StringBuilder().Append
                    (String.Format("{0}t {1}m", timeSpan.Hours, timeSpan.Minutes));
                r.Reisetid = stringBuilder.ToString();

            }

            return reiser;
        }

        public List<Reiser> londonReise()
        {

            List<Reiser> reiser = new List<Reiser>();
            StringBuilder stringBuilder = new StringBuilder();
            TimeSpan timeSpan = new TimeSpan();

            var londonReise1 = new Reiser()
            {
                ByFra = "London",
                ByTil = "Oslo",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)1094.99,
                

            };
            londonReise1.Ankomstid = londonReise1.Avgangstid.AddHours(3).AddMinutes(55);

            var londonReise2 = new Reiser()
            {
                ByFra = "London",
                ByTil = "Oslo",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)1242.99,
                
            };
            londonReise2.Ankomstid = londonReise2.Avgangstid.AddHours(2).AddMinutes(30);

            var londonReise3 = new Reiser()
            {
                ByFra = "London",
                ByTil = "Oslo",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)2092.99,
                
            };
            londonReise3.Ankomstid = londonReise3.Avgangstid.AddHours(2);

            var londonReise4 = new Reiser()
            {
                ByFra = "London",
                ByTil = "Helsinki",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)1198.99,
                

            };
            londonReise4.Ankomstid = londonReise4.Avgangstid.AddHours(4).AddMinutes(20);

            var londonReise5 = new Reiser()
            {
                ByFra = "London",
                ByTil = "Helsinki",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)2485.99,
                
            };
            londonReise5.Ankomstid = londonReise5.Avgangstid.AddHours(3).AddMinutes(30);

            var londonReise6 = new Reiser()
            {
                ByFra = "London",
                ByTil = "Helsinki",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)3023.99,
                
            };
            londonReise6.Ankomstid = londonReise6.Avgangstid.AddHours(3);

            var londonReise7 = new Reiser()
            {
                ByFra = "London",
                ByTil = "New York",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)4342.99,
                

            };
            londonReise7.Ankomstid = londonReise7.Avgangstid.AddHours(13);

            var londonReise8 = new Reiser()
            {
                ByFra = "London",
                ByTil = "New York",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)5440.99,
                
            };
            londonReise8.Ankomstid = londonReise8.Avgangstid.AddHours(12).AddMinutes(25);

            var londonReise9 = new Reiser()
            {
                ByFra = "London",
                ByTil = "New York",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)8420.99,
                
            };
            londonReise9.Ankomstid = londonReise9.Avgangstid.AddHours(10);

            reiser.Add(londonReise1);
            reiser.Add(londonReise2);
            reiser.Add(londonReise3);
            reiser.Add(londonReise4);
            reiser.Add(londonReise5);
            reiser.Add(londonReise6);
            reiser.Add(londonReise7);
            reiser.Add(londonReise8);
            reiser.Add(londonReise9);

            foreach (var r in reiser)
            {

                timeSpan = (r.Ankomstid - r.Avgangstid);
                stringBuilder = new StringBuilder().Append
                    (String.Format("{0}t {1}m", timeSpan.Hours, timeSpan.Minutes));
                r.Reisetid = stringBuilder.ToString();

            }

            return reiser;
        }

        public List<Reiser> hongKongReise()
        {

            List<Reiser> reiser = new List<Reiser>();
            StringBuilder stringBuilder = new StringBuilder();
            TimeSpan timeSpan = new TimeSpan();

            var hongKongReise1 = new Reiser()
            {
                ByFra = "Hong Kong",
                ByTil = "Amsterdam",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)3004.99,
                

            };
            hongKongReise1.Ankomstid = hongKongReise1.Avgangstid.AddHours(17).AddMinutes(55);

            var hongKongReise2 = new Reiser()
            {
                ByFra = "Hong Kong",
                ByTil = "Amsterdam",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)4982.99,
                
            };
            hongKongReise2.Ankomstid = hongKongReise2.Avgangstid.AddHours(15).AddMinutes(30);

            var hongKongReise3 = new Reiser()
            {
                ByFra = "Hong Kong",
                ByTil = "Amsterdam",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)9219.99,
                
            };
            hongKongReise3.Ankomstid = hongKongReise3.Avgangstid.AddHours(12);

            var hongKongReise4 = new Reiser()
            {
                ByFra = "Hong Kong",
                ByTil = "Helsinki",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)2798.99,
                

            };
            hongKongReise4.Ankomstid = hongKongReise4.Avgangstid.AddHours(15).AddMinutes(30);

            var hongKongReise5 = new Reiser()
            {
                ByFra = "Hong Kong",
                ByTil = "Helsinki",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)6902.99,
                
            };
            hongKongReise5.Ankomstid = hongKongReise5.Avgangstid.AddHours(17).AddMinutes(25);

            var hongKongReise6 = new Reiser()
            {
                ByFra = "Hong Kong",
                ByTil = "Helsinki",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)11999.99,
                
            };
            hongKongReise6.Ankomstid = hongKongReise6.Avgangstid.AddHours(10).AddMinutes(20);

            var hongKongReise7 = new Reiser()
            {
                ByFra = "Hong Kong",
                ByTil = "Bangkok",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)1350.99,
                

            };
            hongKongReise7.Ankomstid = hongKongReise7.Avgangstid.AddHours(6).AddMinutes(35);

            var hongKongReise8 = new Reiser()
            {
                ByFra = "Hong Kong",
                ByTil = "Bangkok",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)1887.99,
                
            };
            hongKongReise8.Ankomstid = hongKongReise8.Avgangstid.AddHours(4).AddMinutes(25);

            var hongKongReise9 = new Reiser()
            {
                ByFra = "Hong Kong",
                ByTil = "Bangkok",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)1995.99,
                
            };
            hongKongReise9.Ankomstid = hongKongReise9.Avgangstid.AddHours(3);

            reiser.Add(hongKongReise1);
            reiser.Add(hongKongReise2);
            reiser.Add(hongKongReise3);
            reiser.Add(hongKongReise4);
            reiser.Add(hongKongReise5);
            reiser.Add(hongKongReise6);
            reiser.Add(hongKongReise7);
            reiser.Add(hongKongReise8);
            reiser.Add(hongKongReise9);

            foreach (var r in reiser)
            {

                timeSpan = (r.Ankomstid - r.Avgangstid);
                stringBuilder = new StringBuilder().Append
                    (String.Format("{0}t {1}m", timeSpan.Hours, timeSpan.Minutes));
                r.Reisetid = stringBuilder.ToString();

            }

            return reiser;
        }

        public List<Reiser> newYorkReise()
        {

            List<Reiser> reiser = new List<Reiser>();
            StringBuilder stringBuilder = new StringBuilder();
            TimeSpan timeSpan = new TimeSpan();

            var newYorkReise1 = new Reiser()
            {
                ByFra = "New York",
                ByTil = "London",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)2656.99,
                

            };
            newYorkReise1.Ankomstid = newYorkReise1.Avgangstid.AddHours(13).AddMinutes(35);

            var newYorkReise2 = new Reiser()
            {
                ByFra = "New York",
                ByTil = "London",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)5132.99,
                
            };
            newYorkReise2.Ankomstid = newYorkReise2.Avgangstid.AddHours(10).AddMinutes(30);

            var newYorkReise3 = new Reiser()
            {
                ByFra = "New York",
                ByTil = "London",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)9542.99,
                
            };
            newYorkReise3.Ankomstid = newYorkReise3.Avgangstid.AddHours(7);

            var newYorkReise4 = new Reiser()
            {
                ByFra = "New York",
                ByTil = "Stockholm",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)3172.99,
                

            };
            newYorkReise4.Ankomstid = newYorkReise4.Avgangstid.AddHours(14).AddMinutes(30);

            var newYorkReise5 = new Reiser()
            {
                ByFra = "New York",
                ByTil = "Stockholm",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)5435.99,
                
            };
            newYorkReise5.Ankomstid = newYorkReise5.Avgangstid.AddHours(13).AddMinutes(55);

            var newYorkReise6 = new Reiser()
            {
                ByFra = "New York",
                ByTil = "Stockholm",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)8020.99,
                
            };
            newYorkReise6.Ankomstid = newYorkReise6.Avgangstid.AddHours(8).AddMinutes(10);

            var newYorkReise7 = new Reiser()
            {
                ByFra = "New York",
                ByTil = "Bangkok",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)2938.99,
                

            };
            newYorkReise7.Ankomstid = newYorkReise7.Avgangstid.AddHours(22).AddMinutes(25);

            var newYorkReise8 = new Reiser()
            {
                ByFra = "New York",
                ByTil = "Bangkok",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)4209.99,
                
            };
            newYorkReise8.Ankomstid = newYorkReise8.Avgangstid.AddHours(21).AddMinutes(15);

            var newYorkReise9 = new Reiser()
            {
                ByFra = "New York",
                ByTil = "Bangkok",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)48920.99,
                
            };
            newYorkReise9.Ankomstid = newYorkReise9.Avgangstid.AddHours(19);

            reiser.Add(newYorkReise1);
            reiser.Add(newYorkReise2);
            reiser.Add(newYorkReise3);
            reiser.Add(newYorkReise4);
            reiser.Add(newYorkReise5);
            reiser.Add(newYorkReise6);
            reiser.Add(newYorkReise7);
            reiser.Add(newYorkReise8);
            reiser.Add(newYorkReise9);

            foreach (var r in reiser)
            {

                timeSpan = (r.Ankomstid - r.Avgangstid);
                stringBuilder = new StringBuilder().Append
                    (String.Format("{0}t {1}m", timeSpan.Hours, timeSpan.Minutes));
                r.Reisetid = stringBuilder.ToString();

            }

            return reiser;

        }

        public List<Reiser> bangkokkReise()
        {

            List<Reiser> reiser = new List<Reiser>();
            StringBuilder stringBuilder = new StringBuilder();
            TimeSpan timeSpan = new TimeSpan();

            var bangkokReise1 = new Reiser()
            {

                ByFra = "Bangkok",
                ByTil = "Hong Kong",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)1207.99,
                

            };
            bangkokReise1.Ankomstid = bangkokReise1.Avgangstid.AddHours(6).AddMinutes(35);

            var bangkokReise2 = new Reiser()
            {
                ByFra = "Bangkok",
                ByTil = "Hong Kong",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)2194.99,
                
            };
            bangkokReise2.Ankomstid = bangkokReise2.Avgangstid.AddHours(3).AddMinutes(30);

            var bangkokReise3 = new Reiser()
            {
                ByFra = "Bangkok",
                ByTil = "Hong Kong",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)2492.99,
                
            };
            bangkokReise3.Ankomstid = bangkokReise3.Avgangstid.AddHours(2).AddMinutes(15);

            var bangkokReise4 = new Reiser()
            {
                ByFra = "Bangkok",
                ByTil = "Amsterdam",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)4372.99,
                

            };
            bangkokReise4.Ankomstid = bangkokReise4.Avgangstid.AddHours(17).AddMinutes(30);

            var bangkokReise5 = new Reiser()
            {
                ByFra = "Bangkok",
                ByTil = "Amsterdam",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)6535.99,
                
            };
            bangkokReise5.Ankomstid = bangkokReise5.Avgangstid.AddHours(13).AddMinutes(55);

            var bangkokReise6 = new Reiser()
            {
                ByFra = "Bangkok",
                ByTil = "Amsterdam",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)9123.99,
                
            };
            bangkokReise6.Ankomstid = bangkokReise6.Avgangstid.AddHours(11).AddMinutes(40);

            var bangkokReise7 = new Reiser()
            {
                ByFra = "Bangkok",
                ByTil = "New York",
                Avgangstid = new DateTime(2017, 10, 20, 3, 43, 54),
                Pris = (int)5012.99,
                

            };
            bangkokReise7.Ankomstid = bangkokReise7.Avgangstid.AddHours(30).AddMinutes(15);

            var bangkokReise8 = new Reiser()
            {
                ByFra = "Bangkok",
                ByTil = "New York",
                Avgangstid = new DateTime(2017, 10, 20, 9, 43, 54),
                Pris = (int)(int)6494.99,
                
            };
            bangkokReise8.Ankomstid = bangkokReise8.Avgangstid.AddHours(24).AddMinutes(15);

            var bangkokReise9 = new Reiser()
            {
                ByFra = "Bangkok",
                ByTil = "New York",
                Avgangstid = new DateTime(2017, 10, 24, 8, 12, 12, 3),
                Pris = (int)20242.99,
                
            };
            bangkokReise9.Ankomstid = bangkokReise9.Avgangstid.AddHours(19).AddMinutes(45);

            reiser.Add(bangkokReise1);
            reiser.Add(bangkokReise2);
            reiser.Add(bangkokReise3);
            reiser.Add(bangkokReise4);
            reiser.Add(bangkokReise5);
            reiser.Add(bangkokReise6);
            reiser.Add(bangkokReise7);
            reiser.Add(bangkokReise8);
            reiser.Add(bangkokReise9);

            foreach (var r in reiser)
            {

                timeSpan = (r.Ankomstid - r.Avgangstid);
                stringBuilder = new StringBuilder().Append
                    (String.Format("{0}t {1}m", timeSpan.Hours, timeSpan.Minutes));
                r.Reisetid = stringBuilder.ToString();

            }

            return reiser;

        }
    }
}