using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStudyBuddy.DataModels
{
    internal class Accessory : DatabaseManager
    {
        private int accessoryid { get; set; }
        private string petid { get; set; }
        private int userid { get; set; }
        public Accessory(int accessory, string p, int u)
        {
            this.accessoryid = accessory;
            this.petid = p;
            this.userid = u;
        }
    }

}
