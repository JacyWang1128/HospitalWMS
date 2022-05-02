using HospitalWMS.Model.Entities;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalWMS.Runtime
{
    public static class Instance
    {
        public static User currentUser
        {
            get
            {
                return Service.Common.currentUser;
            }
        }

        public static void Restart()
        {
            Application.Restart();
        }
    }
}
