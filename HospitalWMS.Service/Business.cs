using HospitalWMS.Model;
using HospitalWMS.Model.Entities;
using HospitalWMS.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Service
{
    public static class Business
    {
        public static bool ImWarehouse(long warehouseid, long goodsid, int count)
        {
            bool ret = true;
            var query = Common.db.Queryable<Stock>().First(x => x.warehouseid == warehouseid && x.goodsid == goodsid);
            if (query == null)
            {
                var entity = new Stock() { goodsid = goodsid, warehouseid = warehouseid, count = count };
                ret = (1 == DAO.Insert(entity));
            }
            else
            {
                query.count += count;
                ret = 1 == DAO.Update(query);
            }
            return ret;
        }
        public static bool CheckStock(List<Tuple<long, long, int>> items)
        {
            bool ret = items.Count == 0;
            using (var db = Common.db)
            {
                db.BeginTran();
                foreach (var item in items)
                {
                    long warehouseid = item.Item1;
                    long goodsid = item.Item2;
                    int count = item.Item3;
                    var query = db.Queryable<Stock>().First(x => x.warehouseid == warehouseid && x.goodsid == goodsid);
                    if (query == null)
                    {
                        db.RollbackTran();
                        ret = false;
                        break;
                    }
                    else
                    {
                        if (query.count < count)
                        {
                            db.RollbackTran();
                            ret = false;
                            break;
                        }
                        query.count -= count;
                        ret = 1 == db.Updateable(query).ExecuteCommand();
                    }
                }
                db.RollbackTran();
            }
            return ret;
        }
        public static bool ExWarehouse(List<Tuple<long, long, int>> items)
        {
            bool ret = true;
            using (var db = Common.db)
            {
                db.BeginTran();
                foreach (var item in items)
                {
                    long warehouseid = item.Item1;
                    long goodsid = item.Item2;
                    int count = item.Item3;
                    var query = db.Queryable<Stock>().First(x => x.warehouseid == warehouseid && x.goodsid == goodsid);
                    if (query == null)
                    {
                        db.RollbackTran();
                        ret = false;
                        break;
                    }
                    else
                    {
                        if (query.count < count)
                        {
                            db.RollbackTran();
                            ret = false;
                            break;
                        }
                        query.count -= count;
                        ret = 1 == db.Updateable(query).ExecuteCommand();
                    }
                }
                if (ret)
                    db.CommitTran();
            }
            return ret;
        }
        public static bool ApproveApply<T>(long id) where T : EntityBase, new()
        {
            bool ret = true;
            T t = Common.db.Queryable<T>().First(x => x.id == id);
            if (t == null)
                return false;
            t.GetType().GetProperty("result").SetValue(t, ApplyResult.审核通过);
            if (t.GetType() == typeof(Order))
            {
                t.GetType().GetProperty("purchaserid").SetValue(t, Common.currentUser.id);
                t.GetType().GetProperty("state").SetValue(t, OrderState.已收货);
            }
            else
                t.GetType().GetProperty("approverid").SetValue(t, Common.currentUser.id);
           // t.GetType().GetProperty("applytime").SetValue(t, DateTime.Now);
            ret = 1 == DAO.Update(t);
            return ret;
        }
        public static bool RecallApply<T>(long id) where T : EntityBase, new()
        {
            bool ret = true;
            T t = Common.db.Queryable<T>().First(x => x.id == id);
            if (t == null)
                return false;
            t.GetType().GetProperty("result").SetValue(t, ApplyResult.审核不通过);
            if (t.GetType() == typeof(Order))
                t.GetType().GetProperty("purchaserid").SetValue(t, Common.currentUser.id);
            else
                t.GetType().GetProperty("approverid").SetValue(t, Common.currentUser.id);
            //t.GetType().GetProperty("applytime").SetValue(t, DateTime.Now);
            ret = 1 == DAO.Update(t);
            return ret;
        }
        public static List<Apply> GetApplyList()
        {
            var query = Service.Common.db.Queryable<Model.Entities.Apply>()
                .Mapper(x => x.applier, x => x.applierid).Mapper(x => x.approver, x => x.approverid).ToList();
            return query;
        }
    }
}
