using LounaTravel.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LounaTravel.Service.CityService
{
    public class CityService
    {
        public IEnumerable<tbl_City> getOfficeByCityID(int ID)
        {
            using (var db = new LounaTravelDbContext())
            {
                return db.Database.SqlQuery<tbl_City>("sp_get_City_ByRegionID").ToList();
            }
        }
    }
}