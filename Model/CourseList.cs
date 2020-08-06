using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CourseList: List<Course>
    {
        public CourseList() { }

        public CourseList(IEnumerable<Course> enu) : base(enu) { }

        public CourseList(IEnumerable<BaseEntity> enu) : base(enu.Cast<Course>().ToList()) { } // Ronen: where using it?
    }
}
