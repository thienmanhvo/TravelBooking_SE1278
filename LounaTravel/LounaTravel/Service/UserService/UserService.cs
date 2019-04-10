using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LounaTravel.EntityFramework;

namespace LounaTravel.Service.UserService
{
    public class UserService : IUserService
    {
        private LounaTravelDbContext db = new LounaTravelDbContext();

        public bool isExistedUser(string username)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (db.tbl_User.FirstOrDefault(a => a.Username.Equals(username)) != null)
            {
                return true;
            }
            else { return false; }
            
        }

        public tbl_User checkLogin(string userName, string password)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.tbl_User.Where(a => a.Username.Equals(userName) && a.Password.Equals(password) && a.isDelete == false).FirstOrDefault();
        }


        public void CreateUser(tbl_User tbl_User)
        {
            try
            {
                tbl_User.isDelete = false;
                db.tbl_User.Add(tbl_User);
                db.SaveChanges();
            }
            catch (Exception ee)
            {

                throw ee;
            }
                
        }

        public tbl_User getUser(string userName, string password)
        { 
            return db.tbl_User.Where(a => a.Username.Equals(userName) && a.Password.Equals(password) && a.isDelete == false).FirstOrDefault();
        }

        public int updateUser(string username, string firstName, string lastName, string email, string phoneNumber)
        {
            int result = db.Database.ExecuteSqlCommand("db_Update_User @p0,@p1,@p2,@p3,@p4", username, firstName, lastName, email, phoneNumber);
            return result;
        }
    }
}