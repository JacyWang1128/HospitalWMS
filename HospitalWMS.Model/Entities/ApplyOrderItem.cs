using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Model.Entities
{
    [SugarTable("applyorderitem")]
    public class ApplyOrderItem:ImWarehouseItem
    {
        [SugarColumn(IsIgnore = true)]
        public new ApplyOrder apply { get; set; }
    }
}
