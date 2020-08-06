using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LessonDB : BaseDB
    {
        protected override BaseEntity newEntity()
        {
            return new Lesson();
        }

        protected override BaseEntity FillEntity(BaseEntity entity)
        {
            base.FillEntity(entity); //Id

            int studentId  =  Int32.Parse(reader["Student"].ToString());
            int lecturerId =  Int32.Parse(reader["Lecturer"].ToString());
            int courseId = Int32.Parse(reader["Course"].ToString());

            Lesson lesson = entity as Lesson;

            lesson.Student = new StudentDB().SelectByID(studentId);
            lesson.Lecturer = new LecturerDB().SelectByID(lecturerId);
            lesson.Course = CourseDB.SelectByID(courseId);

            lesson.Grade = Int32.Parse(reader["Grade"].ToString());

            return entity;
        }



        public Lesson SelectByID(int id)
        {
            command.CommandText = $"SELECT * FROM LessonTbl WHERE id={id}";
                                  
            List<BaseEntity> entities = Select();
            return entities.Count == 1 ? entities[0] as Lesson : null;
        }

        public LessonList SelectByStudentID(int id)
        {
            command.CommandText = $"SELECT * FROM LessonTbl WHERE student={id}";
            return new LessonList(Select());
        }
        
        public LessonList SelectByLecturerID(int id)
        {
            command.CommandText = $"SELECT * FROM LessonTbl WHERE lecturer={id}";
            return new LessonList(Select());
        }


    }
}
