using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LessonList : List<Lesson>
    {
        public LessonList() { }

        public LessonList(IEnumerable<Lesson> enu):base(enu) { }

        public LessonList(IEnumerable<BaseEntity> enu) : base(enu.Cast<Lesson>().ToList()) { } // Ronen: where using it?
    }
}
