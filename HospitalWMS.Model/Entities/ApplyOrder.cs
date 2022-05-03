using HospitalWMS.Model.Enums;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Model.Entities
{
    [SugarTable("applyorder")]
    public class ApplyOrder: EntityBase
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
        public List<ApplyOrderItem> items { get; set; }
    }
}
