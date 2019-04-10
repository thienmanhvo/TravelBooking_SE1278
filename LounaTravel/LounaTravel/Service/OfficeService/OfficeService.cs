using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LounaTravel.EntityFramework;

namespace LounaTravel.Service.OfficeService
{
    public class OfficeService : IOfficeService
    {
        LounaTravelDbContext db = new LounaTravelDbContext();

        public IEnumerable<tbl_Office> getAllMainOfficeInVietNam()
        {
             return db.Database.SqlQuery<tbl_Office>("spGet_All_Main_Office_In_VietNam").ToList();
        }

        public IEnumerable<tbl_Office> getAllOfficeInCenterVietNam()
        {
           
             return db.Database.SqlQuery<tbl_Office>("spGet_All_Main_Office_In_Center_VietNam").ToList();
        }

        public IEnumerable<tbl_Office> getAllOfficeInNorthVietNam()
        {
            return db.Database.SqlQuery<tbl_Office>("spGet_All_Main_Office_In_North_VietNam").ToList();
        }

        public IEnumerable<tbl_Office> getAllOfficeInSouthVietNam()
        {
            return db.Database.SqlQuery<tbl_Office>("[spGet_All_Main_Office_In_South_VietNam]").ToList();
        }

        public IEnumerable<tbl_Office> getAllOfficeInVietNam()
        {
            return db.Database.SqlQuery<tbl_Office>("spGet_All_Office_In_VietNam").ToList();
        }

        public IEnumerable<tbl_Office> getOfficeByCityID(int ID)
        {
            
               return db.Database.SqlQuery<tbl_Office>("sp_get_Office_ByCityID @p0",ID).ToList();
            
        }
    }
}