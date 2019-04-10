using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LounaTravel.EntityFramework;

namespace LounaTravel.Service.Region
{
    public class RegionService : IRegionService
    {
        private LounaTravelDbContext db = new LounaTravelDbContext();
        public IEnumerable<tbl_Region>  getRegionByCountryID(int ID)
        {
            return db.tbl_Region.Where(a => a.isDelete == false && a.CountryID.Equals(ID)).ToList<tbl_Region>();
        }

        public IEnumerable<tbl_Region> getRegionInVietNam()
        {
            return db.tbl_Region.Where(a => a.isDelete == false && a.CountryID.Equals("VNM")).ToList<tbl_Region>();
        }
    }
}