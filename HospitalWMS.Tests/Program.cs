using HospitalWMS.Model.Entities;
using HospitalWMS.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Service.Common.InitDatabase();
            Service.Common.InsertDefaultUser();
            Console.WriteLine($"登录系统：{(Service.Common.Login("admin", "123456") ? "成功" : "失败")}");
            Console.ReadKey();
        }
    }
}
