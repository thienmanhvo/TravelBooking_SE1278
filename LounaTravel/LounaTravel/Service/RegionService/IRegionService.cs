using LounaTravel.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LounaTravel.Service.Region
{
    public interface IRegionService
    {
        IEnumerable<tbl_Region> getRegionByCountryID(int ID);
        IEnumerable<tbl_Region> getRegionInVietNam();
    }
}
