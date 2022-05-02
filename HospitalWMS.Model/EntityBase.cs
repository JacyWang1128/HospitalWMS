using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Model
{
    public class EntityBase
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long id { get; set; }
        public long createby { get; set; }
        public DateTime createtime { get; set; }
        public long updateby { get; set; }
        public DateTime updatetime { get; set; }
        public bool delFlag { get; set; }
        public EntityBase()
        {

        }
    }
}
