using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [CollectionDataContract]
    public class StudentList : List<Student>
    {
        public StudentList() { }

        public StudentList(IEnumerable<Student> enu):base(enu) { }

        public StudentList(IEnumerable<BaseEntity> enu) : base(enu.Cast<Student>().ToList()) { } // Ronen: where using it?
    }
}
