using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Model.Entities
{
    [SugarTable("orderitem")]
    public class OrderItem:EntityBase
    {
        public long goodsid { get; set; }
        [SugarColumn(IsIgnore = true)]
        public Goods goods { get; set; }
        public int count { get; set; }
        public decimal price { get; set; }
        public long warehouseid { get; set; }
        [SugarColumn(IsIgnore = true)]
        public Warehouse warehouse { get; set; }
        public string orderid { get; set; }

        [SugarColumn(IsIgnore = true)]
        public Order order { get; set; }
        public int sort { get; set; }
    }
}
