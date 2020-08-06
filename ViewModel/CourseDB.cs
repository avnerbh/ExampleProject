using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CourseDB : BaseDB
    {
        private static CourseList list = null;

        protected override BaseEntity newEntity()
        {
            return new Course();
        }

        protected override BaseEntity FillEntity(BaseEntity entity)
        {
            base.FillEntity(entity); //ID
            Course course = entity as Course;
            course.Subject = reader["subject"].ToString();
            return course;
        }

        public CourseList SelectAll()
        {
            command.CommandText = "SELECT * FROM CourseTbl";
            list = new CourseList(Select());
            return list;
        }

        public static Course SelectByID(int CourseId)
        {
            if (list == null)
                new CourseDB().SelectAll();

            return list.Find(course => course.Id == CourseId);
        }
    }
}
