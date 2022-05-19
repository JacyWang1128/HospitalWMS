using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Model.Entities
{
    [SugarTable("plan")]
    public class Plan:Apply
    {
        [SugarColumn(IsIgnore =true)]
        public new List<PlanItem> items { get; set; }
    }
}
