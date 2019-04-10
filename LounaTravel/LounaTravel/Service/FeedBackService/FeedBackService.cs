using LounaTravel.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LounaTravel.Service.FeedBack
{
    public class FeedBackService : IFeedBackService
    {
        private LounaTravelDbContext db = new LounaTravelDbContext();
        public void addComment(tbl_FeedBack tbl_FeedBack)
        {
            try
            {
                tbl_FeedBack.isDelete = false;
                db.tbl_FeedBack.Add(tbl_FeedBack);
                db.SaveChanges();
            }
            catch (Exception ee)
            {

                throw ee;
            }

        }
    }
}