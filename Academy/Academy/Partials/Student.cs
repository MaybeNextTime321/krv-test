using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
    public partial class Students
    {
        public String StudentText
        {
            get { return this.Name + "из" + this.Grade.Title; }
        }
    }
}
