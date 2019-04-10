using LounaTravel.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LounaTravel.Service.CityService
{
    interface ICityService
    {
        IEnumerable<tbl_City> getCityByRegionID(int ID);
    }
}
