using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //[DataContract]
    public class Lesson : BaseEntity
    {
        private Student student;
        private Lecturer lecturer;
        private Course course;
        private int grade;

        // in the SQL table, we have the Student *ID*, Lecturer *ID* and Course *ID* 
       
        //DataMember]
        public Student Student { get => student; set => student = value; }

        //[DataMember]
        public Lecturer Lecturer { get => lecturer; set => lecturer = value; }

        //[DataMember]
        public Course Course { get => course; set => course = value; }

        //[DataMember]
        public int Grade { get => grade; set => grade = value; }
    }
}
