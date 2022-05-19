using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Model.Entities
{
    [SugarTable("planitem")]
    public class PlanItem:ApplyItem
    {
        [SugarColumn(IsIgnore = true)]
        public new Plan apply { get; set; }
        public int currentcount { get; set; }
    }
}
