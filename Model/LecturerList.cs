using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LecturerList: List<Lecturer>
    {
        public LecturerList() { }

        public LecturerList(IEnumerable<Lecturer> enu) : base(enu) { }

        public LecturerList(IEnumerable<BaseEntity> enu) : base(enu.Cast<Lecturer>().ToList()) { } 
    }
}
