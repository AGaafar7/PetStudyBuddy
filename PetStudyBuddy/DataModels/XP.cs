using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStudyBuddy.DataModels
{
    internal class XP : DatabaseManager
    {
        private int xp { get; set; }
        private int userid { get; set; }

        public XP(int xp, int userid) {
           this.xp = xp;
            this.userid = userid;

        }
    }
}
