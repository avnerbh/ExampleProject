using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //[DataContract]
    public class Student : Person , ICloneable
    {

        private int semester;
        //       private LessonList lessonList;

       //[DataMember]
        public int Semester { get => semester; set => semester = value; }

/*      public LessonList FinishedCourses
        {
            get
            {
                List<Lesson> lst = lessonList.FindAll(lesson => lesson.Grade > 55).ToList();
                return new LessonList(lst);
            }
        }
*/
        public object Clone() //shallow copy
        {
            return this.MemberwiseClone();
        }

    }
}
