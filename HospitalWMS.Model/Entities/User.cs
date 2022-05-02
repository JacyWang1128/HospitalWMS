using HospitalWMS.Model.Enums;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Model.Entities
{
    [SugarTable("user")]
    public class User:EntityBase
    {
        public string username { get; set; }
        public string password { get; set; }
        public UserType role { get; set; }
        public long departmentid { get; set; }
        [SugarColumn(IsIgnore = true)]
        public Department department { get; set; }
        [SugarColumn(IsNullable = true)]
        public string worknum { get; set; }
        public string displayname { get; set; }
    }
}
