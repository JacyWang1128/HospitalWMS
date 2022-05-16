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
        public static User currentUser = null;
        public static readonly string connectString = Helpers.ConfigHelper.ReadAppSetting("ConnectString");
        public static long GetCurrentUserID()
        {
            if (currentUser == null)
                return 0;
            else
                return currentUser.id;
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
            currentUser = user;
            return true;
        }

        public static void Logout()
        {
            currentUser = null;
        }

    }
}
