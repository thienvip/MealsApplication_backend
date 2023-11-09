using src.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Core
{
    public partial class UserCampus
    {
        public int UserId { get; set; }
        public string Campuscode { get; set; }

        public virtual Campus Campus { get; set; }
        public virtual User User { get; set; }
    }
}
