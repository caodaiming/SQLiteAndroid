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


        public void Delete(int id)
        {
            sqliteHelper.Delete(id);
        }
        public List<Profile> GetAll()
        {
            return sqliteHelper.GetAll();
        }
    }
}