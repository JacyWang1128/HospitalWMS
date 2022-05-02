using HospitalWMS.Model.Enums;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Model.Entities
{
    [SugarTable("order")]
    public class Order:EntityBase
    {
        public string uuid { get; set; }
        public long applierid { get; set; }
        [SugarColumn(IsIgnore = true)]
        public User applier { get; set; }
        public DateTime applytime { get; set; }
        public OrderState state { get; set; }
        public ApplyResult result { get; set; }
        public long purchaserid { get; set; }
        [SugarColumn(IsIgnore =true)]
        public User perchaser { get; set; }

        [SugarColumn(IsIgnore = true)]
        public List<OrderItem> items { get; set; }
    }
}
