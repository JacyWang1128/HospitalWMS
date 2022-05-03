using HospitalWMS.Model.Enums;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Model.Entities
{
    [SugarTable("imwarehouse")]
    public class ImWarehouse:EntityBase
    {
        public string uuid { get; set; }
        public long applierid { get; set; }
        [SugarColumn(IsIgnore = true)]
        public User applier { get; set; }
        public DateTime applytime { get; set; }
        public ApplyResult result { get; set; }
        public long approverid { get; set; }
        [SugarColumn(IsIgnore = true)]
        public User approver { get; set; }
        [SugarColumn(IsIgnore = true)]
        public List<ImWarehouseItem> items { get; set; }
        public long orderid { get; set; }
        [SugarColumn(IsIgnore = true)]
        public Order order { get; set; }
    }
}
