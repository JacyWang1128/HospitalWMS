using HospitalWMS.Model.Enums;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Model.Entities
{
    [SugarTable("goods")]
    public class Goods:EntityBase
    {
        public string name { get; set; }
        public string specification { get; set; }
        //[SugarColumn(IsIgnore = true)]
        //public Specification specification { get; set; }
        public GoodsType goodstype { get; set; }
        public decimal price { get; set; }
        public string unit { get; set; }
        public long supplierid { get; set; }
        [SugarColumn(IsIgnore = true)]
        public Supplier supplier { get; set; }
    }
}
