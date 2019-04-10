using LounaTravel.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LounaTravel.Service.OfficeService
{
    public interface IOfficeService
    {
        IEnumerable<tbl_Office> getOfficeByCityID(int ID);
        IEnumerable<tbl_Office> getAllOfficeInVietNam();
        IEnumerable<tbl_Office> getAllOfficeInNorthVietNam();
        IEnumerable<tbl_Office> getAllOfficeInCenterVietNam();
        IEnumerable<tbl_Office> getAllOfficeInSouthVietNam();
        IEnumerable<tbl_Office> getAllMainOfficeInVietNam();
    }
}
