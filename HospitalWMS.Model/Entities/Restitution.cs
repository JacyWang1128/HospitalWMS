using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Model.Entities
{
    [SugarTable("restitution")]
    public class Restitution:Apply
    {
        [SugarColumn(IsIgnore = true)]
        public new List<RestitutionItem> items { get; set; }
    }
}
