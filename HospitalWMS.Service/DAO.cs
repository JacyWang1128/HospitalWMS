using HospitalWMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Service
{
    public static class DAO
    {
        public static int Insert<T>(params T[] entities) where T :EntityBase, new()
        {
            foreach (var item in entities)
            {
                item.createby = Common.GetCurrentUserID();
                item.createtime = DateTime.Now;
            }
            return Common.db.Insertable<T>(entities).ExecuteCommand();
        }

        public static int Update<T>(params T[] entities) where T : EntityBase, new()
        {
            foreach (var item in entities)
            {
                item.updateby = Common.GetCurrentUserID();
                item.updatetime = DateTime.Now;
            }
            return Common.db.Updateable<T>(entities).ExecuteCommand();
        }

        public static int Delete<T>(T entity) where T : EntityBase, new()
        {
            return Common.db.Deleteable<T>().Where(entity).ExecuteCommand();
        }
    }
}
