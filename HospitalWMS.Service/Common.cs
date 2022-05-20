using HospitalWMS.Model.Entities;
using HospitalWMS.Model.Enums;
using HospitalWMS.Service.Helpers;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Service
{
    public static class Common
    {
        public static readonly string connectString = Helpers.ConfigHelper.ReadAppSetting("ConnectString");

        private static User currentUser = null;

        private static Plan currentMonthPlan = null;

        public static long GetCurrentUserID()
        {
            if (CurrentUser == null)
                return 0;
            else
                return CurrentUser.id;
        }
        public static SqlSugarClient db
        {
            get
            {
                return new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = connectString,
                    DbType = DbType.MySql,
                    IsAutoCloseConnection = true
                });
            }
        }

        public static User CurrentUser
        {
            get => currentUser; 
            set
            {
                currentUser = value;
                SetMonthPlan(CurrentUser.departmentid);
            }
        }

        public static Plan CurrentMonthPlan { get => currentMonthPlan; set => currentMonthPlan = value; }

        internal static void SetMonthPlan()
        {
            SetMonthPlan(CurrentUser.departmentid);
        }

        public static void SetMonthPlan(long deptid)
        {
            var query = db.Queryable<Plan>()
                .Mapper(x => x.applier, x => x.applierid)
                .Where(x => x.applytime.Month == DateTime.Now.Month && x.applytime.Year == DateTime.Now.Year && x.applier.departmentid == deptid && x.result == ApplyResult.审核通过)
                .First();
            if (query == null)
                return;
            query.items = db.Queryable<PlanItem>().Mapper(x => x.goods, x => x.goodsid).Mapper(x => x.warehouse, x => x.warehouseid).Where(x => x.applyid == query.uuid).ToList();
            CurrentMonthPlan = query;
        }

        public static bool InitDatabase()
        {
            try
            {
                var ret = db.DbMaintenance.CreateDatabase();
                Type[] types = Assembly
                                .LoadFrom("HospitalWMS.Model.dll")//如果 .dll报错，可以换成 xxx.exe 有些生成的是exe 
                                .GetTypes().Where(it => it.FullName.Contains("Entities.")).//命名空间过滤，当然你也可以写其他条件过滤
                                ToArray();//断点调试一下是不是需要的Type，不是需要的在进行过滤
                // 也可以这么用 var types= typeof(任意实体类中的类).Assembly.GetTypes();
                db.CodeFirst.SetStringDefaultLength(200).InitTables(types);
                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static void InsertDefaultUser()
        {
            if(!db.Queryable<User>().Any(x=>x.username == "admin"))
            DAO.Insert(new User() { displayname = "系统管理员", username = "admin", password = "123456".ToSHA(), role = UserType.系统管理员 });
        }

        public static bool Login(string username,string pwd)
        {
            var user = db.Queryable<User>().First(x => x.username == username && x.password == pwd.ToSHA());
            if (user == null)
                return false;
            CurrentUser = user;
            return true;
        }

        public static void Logout()
        {
            currentUser = null;
        }

    }
}
