using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperWing.DAL;
using HyperWing.Model;

namespace HyperWing.BLL
{
    public class AdminLogikk
    {

        public static bool adminDB(Admin admin)
        {
            var db = new DB();
            return db.adminDB(admin);
        }
    }
}
