using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using HyperWing.Model;
using System.Threading.Tasks;

namespace HyperWing.DAL
{
    public class DB
    {
        public bool adminDB(Admin admin)
        {
            using (var db = new AdminContext())
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
    }
}
}
