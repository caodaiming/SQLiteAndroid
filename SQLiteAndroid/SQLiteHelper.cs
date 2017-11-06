using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.Linq.Expressions;
using System;

namespace SQLiteAndroid
{
    public class SQLiteHelper<T> where T : new()
    {
        private string DbName = "SqliteDBTest";   

        private string DbPath;

        private string GetDbPath()
        {
            var folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(folder, DbName);
        }

        public SQLiteHelper()
        {
            DbPath = GetDbPath();
            using (var db = new SQLiteConnection(DbPath))
            {
                db.CreateTable<T>();
            }
        }


        public void Save(T t)
        {
            using (var db = new SQLiteConnection(DbPath))
            {
                db.Insert(t);
            }
        }

        public List<T> GetAll()
        {
            using (var db = new SQLiteConnection(DbPath))
            {
                var table = db.Table<T>();

                return table.ToList();
            }
        }

        public void Delete(int id)
        {
            using (var db = new SQLiteConnection(DbPath))
            {
                db.Delete(id);
            }
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            using (var db = new SQLiteConnection(DbPath))
            {
                var t = db.Find<T>(predicate);
                db.Delete(t);
            }
        }

        public void DeleteAll()
        {
            using (var db = new SQLiteConnection(DbPath))
            {
                db.DeleteAll<T>();
            }
        }
    }
}