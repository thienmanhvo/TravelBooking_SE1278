using LounaTravel.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LounaTravel.Service.TourService
{
    public interface ITourService
    {
        //get tour by ID
        tbl_Tour getTourByID(string ID);

        IEnumerable<tbl_Tour> getTourByPrice(double Price); //Get all Tour By Price

        IEnumerable<tbl_Tour> getNTourByPrice(double Price, string ID, int N); //Get first N tour by price but not tour have ID order by TimeBegin

        IEnumerable<tbl_Tour> getTourByDateBegin(DateTime timeBegin); //get All tour by Date

        IEnumerable<tbl_Tour> getNTourByDateBegin(DateTime timeBegin, string ID, int N);     //Get first N tour by Date but not tour have ID order by TimeBegin

        IEnumerable<tbl_Tour> getTourByDuration(TimeSpan duration); //Get all Tour By Price

        IEnumerable<tbl_Tour> getNTourByDuration(int duration, string ID, int N);//Get first N tour by price but not tour have ID order by TimeBegin

        IEnumerable<tbl_City> listComboBoxToPlace();

        IEnumerable<tbl_City> listComboBoxFromPlace();

        bool updateSeat(string tourID, int seat);
    }
}
