using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Model.Entities
{
    [SugarTable("exwarehouseitem")]
    public class ExWarehouseItem:ImWarehouseItem
    {
        [SugarColumn(IsIgnore = true)]
        public new ExWarehouse apply { get; set; }
    }
}
