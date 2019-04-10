using LounaTravel.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LounaTravel.Service.UserService
{
    public interface IUserService
    {
        
        tbl_User getUser(string userName, string password);
        tbl_User checkLogin(string userName, string password);
        void CreateUser(tbl_User user);
        bool isExistedUser(string username);
        int updateUser(string username,string firstName,string lastName,string email,string phoneNumber);

    }
}
