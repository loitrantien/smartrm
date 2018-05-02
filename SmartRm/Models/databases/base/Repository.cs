using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SmartRm.Models.databases;
using SmartRm.Models.databases.entity;

namespace SmartRm.Models.databases
{
    public class Repository : IRepository
    {
        private static IRepository INSTANCE;

        protected QLNHDBContext db { get; set; }
       
        public static IRepository getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new Repository();
            return INSTANCE;
        }

        private Repository()
        {
            db = new QLNHDBContext();
        }

        public List<T> GetAll<T>() where T : class
        {
            return db.Set<T>().ToList();
        }

        public int Update<T>(T item) where T : class
        {
            db.Set<T>().Attach(item);
            db.Entry(item).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public int Delete<T>(T item) where T : class
        {
            db.Set<T>().Remove(item);
            return db.SaveChanges();
        }

        public int Create<T>(T item) where T : class
        {
            db.Set<T>().Add(item);
            return db.SaveChanges();
        }

        public List<T> query<T>(string query) where T : class
        {
            throw new NotImplementedException();
        }

        public Dictionary<Guid, string> Delete<T>(Guid[] lstid) where T:class
        {
            Dictionary<Guid, string> result = new Dictionary<Guid, string>();
            foreach (var item in lstid)
            {
                try
                {
                    T t = db.Set<T>().Find(item);
                    db.Set<T>().Remove(t);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    result.Add(item, ex.Message);
                }
            }

            return result;
        }
    }
}
