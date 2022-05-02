using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Model.Entities
{
    [SugarTable("supplier")]
    public class Supplier:EntityBase
    {
        public string name { get; set; }
        public DateTime expire { get; set; }
        /// <summary>
        /// 仓库id，0为所有仓库，否则用,分隔
        /// </summary>
        public string warehouseids { get; set; }
        public bool isabandon { get; set; }
    }
}
