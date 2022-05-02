using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Model.Entities
{
    [SugarTable("restitutionitem")]
    public class RestitutionItem:ApplyItem
    {
        [SugarColumn(IsIgnore = true)]
        public new Restitution apply { get; set; }
    }
}
