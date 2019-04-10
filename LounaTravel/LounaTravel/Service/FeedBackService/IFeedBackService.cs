using LounaTravel.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LounaTravel.Service.FeedBack
{
    public interface IFeedBackService
    {
        void addComment(tbl_FeedBack tbl_FeedBack);
    }
}
