using System.Collections.Generic;
using SQLiteAndroid.Models;

namespace SQLiteAndroid
{
    public class ProfileService
    {
        private readonly SQLiteHelper<Profile> sqliteHelper;

        public ProfileService()
        {
            sqliteHelper = new SQLiteHelper<Profile>();
        }

        public void AddProfile(Profile model)
        {
            sqliteHelper.Save(model);
        }


        public void Delete(string userName)
        {
            sqliteHelper.Delete(t => t.UserName == userName);
        }
        public List<Profile> GetAll()
        {
            return sqliteHelper.GetAll();
        }
    }
}