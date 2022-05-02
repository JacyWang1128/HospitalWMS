using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Model.Entities
{
    [SugarTable("exwarehouse")]
    public class ExWarehouse:ImWarehouse
    {
        [SugarColumn(IsIgnore = true)]
        public new List<ExWarehouseItem> items { get; set; }
    }
}
