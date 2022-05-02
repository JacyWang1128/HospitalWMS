using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Model.Entities
{
    [SugarTable("stock")]
    public class Stock : EntityBase
    {
        public long goodsid { get; set; }
        [SugarColumn(IsIgnore = true)]
        public Goods goods { get; set; }
        public int count { get; set; }
        public long warehouseid { get; set; }
        [SugarColumn(IsIgnore = true)]
        public Warehouse warehouse { get; set; }
    }
}
