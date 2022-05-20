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
        public static object applylock = new object();
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
        public static bool CheckPlan(List<ApplyItem> applyItems)
        {
            bool ret = applyItems.Count != 0;
            if (Common.CurrentMonthPlan == null && Common.CurrentMonthPlan.items.Count < 1)
                return false;
            foreach (var item in applyItems)
            {
                var planitem = Common.CurrentMonthPlan.items.First(x => x.goodsid == item.goodsid);
                if (planitem.currentcount < item.count)
                {
                    ret = false;
                    break;
                }
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
                        ret = false;
                        break;
                    }
                    else
                    {
                        if (query.count < count)
                        {
                            ret = false;
                            break;
                        }
                        query.count -= count;
                        ret = 1 == db.Updateable(query).ExecuteCommand();
                    }
                }
                if (ret)
                    db.CommitTran();
                else
                    db.RollbackTran();
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
                t.GetType().GetProperty("purchaserid").SetValue(t, Common.CurrentUser.id);
                t.GetType().GetProperty("state").SetValue(t, OrderState.已收货);
            }
            else
                t.GetType().GetProperty("approverid").SetValue(t, Common.CurrentUser.id);
            //t.GetType().GetProperty("applytime").SetValue(t, DateTime.Now);
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
                t.GetType().GetProperty("purchaserid").SetValue(t, Common.CurrentUser.id);
            else
                t.GetType().GetProperty("approverid").SetValue(t, Common.CurrentUser.id);
            //t.GetType().GetProperty("applytime").SetValue(t, DateTime.Now);
            ret = 1 == DAO.Update(t);
            return ret;
        }

        public static bool Apply(Apply apply)
        {
            bool ret = apply != null;
            lock (applylock)
            {
                using (var db = Common.db)
                {
                    try
                    {

                        db.BeginTran();
                        //扣除当前申领计划currentcount
                        foreach (var item in apply.items)
                        {
                            var planitem = Common.CurrentMonthPlan.items.First(x => x.goodsid == item.goodsid);
                            planitem.currentcount -= item.count;
                            db.Updateable<PlanItem>(planitem).ExecuteCommand();
                        }
                        //插入Apply
                        db.Insertable<Apply>(apply).ExecuteCommand();
                        //插入ApplyItem
                        db.Insertable<ApplyItem>(apply.items).ExecuteCommand();
                        db.CommitTran();
                    }
                    catch (Exception)
                    {
                        db.RollbackTran();
                    }
                }
            }
            Common.SetMonthPlan();
            return ret;
        }

        public static bool RecallApply(long id)
        {
            var apply = Common.db.Queryable<Apply>().Mapper(x => x.applier, x => x.applierid).Where(x => x.id == id).First();
            if (apply == null)
                return false;
            var applyitems = Common.db.Queryable<ApplyItem>().Where(x => x.applyid == apply.uuid).ToList();
            apply.items = applyitems;
            var plan = Common.db.Queryable<Plan>().Mapper(x => x.applier, x => x.applierid).Where(x => x.applier.departmentid == apply.applier.departmentid && x.applytime.Year == apply.applytime.Year && x.applytime.Month == apply.applytime.Month).First();
            if (plan == null)
                return false;
            var planitems = Common.db.Queryable<PlanItem>().Where(x => x.applyid == plan.uuid).ToList();
            plan.items = planitems;
            bool ret = true;
            using(var db = Common.db)
            {
                try
                {
                    foreach (var item in applyitems)
                    {
                        var planitem = plan.items.First(x => x.goodsid == item.goodsid);
                        planitem.currentcount += item.count;
                        db.Updateable<PlanItem>(planitem).ExecuteCommand();
                    }
                    db.CommitTran();
                }
                catch (Exception)
                {
                    db.RollbackTran();
                    ret = false;
                }
            }
            if(ret)
               ret = RecallApply<Apply>(id);
            Common.SetMonthPlan();
            return ret;
        }

        public static bool ApproveRestitution(long id)
        {
            var apply = Common.db.Queryable<Restitution>().Mapper(x => x.applier, x => x.applierid).Where(x => x.id == id).First();
            if (apply == null)
                return false;
            var applyitems = Common.db.Queryable<RestitutionItem>().Where(x => x.applyid == apply.uuid).ToList();
            apply.items = applyitems;
            var plan = Common.db.Queryable<Plan>().Mapper(x => x.applier, x => x.applierid).Where(x => x.applier.departmentid == apply.applier.departmentid && x.applytime.Year == apply.applytime.Year && x.applytime.Month == apply.applytime.Month).First();
            if (plan == null)
                return false;
            var planitems = Common.db.Queryable<PlanItem>().Where(x => x.applyid == plan.uuid).ToList();
            plan.items = planitems;
            bool ret = true;
            using (var db = Common.db)
            {
                try
                {
                    foreach (var item in applyitems)
                    {
                        var planitem = plan.items.First(x => x.goodsid == item.goodsid);
                        planitem.currentcount += item.count;
                        db.Updateable<PlanItem>(planitem).ExecuteCommand();
                    }
                    db.CommitTran();
                }
                catch (Exception)
                {
                    db.RollbackTran();
                    ret = false;
                }
            }
            if (ret)
                ret = ApproveApply<Restitution>(id);
            Common.SetMonthPlan();
            return ret;
        }

        public static bool InsertGoods(Goods goods)
        {
            if (Common.db.Queryable<Goods>().Any(x => x.name == goods.name))
                throw new ApplicationException("商品名称重复！");
            return DAO.Insert(goods) == 1;
        }
        public static bool UpdateGoods(Goods goods)
        {
            if (Common.db.Queryable<Goods>().Any(x => x.name == goods.name))
                throw new ApplicationException("商品名称重复！");
            return DAO.Update(goods) == 1;
        }

        public static List<Apply> GetApplyList()
        {
            var query = Service.Common.db.Queryable<Model.Entities.Apply>()
                .Mapper(x => x.applier, x => x.applierid).Mapper(x => x.approver, x => x.approverid).ToList();
            return query;
        }
    }
}
