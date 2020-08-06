using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    
    public class StudentDB : PersonDB
    {
        protected override BaseEntity newEntity()
        {
            return new Student();
        }

        protected override BaseEntity FillEntity(BaseEntity entity)
        {
            base.FillEntity(entity);

            Student s = entity as Student;

            s.Semester = Int32.Parse(reader["Semester"].ToString());

            return s;
        }

        public StudentList SelectAll()
        {
            command.CommandText = "SELECT *, PersonTbl.ID as ID , StudentTbl.ID as dummy " +
                                  "FROM PersonTbl, StudentTbl " +
                                  "WHERE PersonTbl.ID = StudentTbl.ID";
            StudentList studentList = new StudentList(Select());
            return studentList;
        }

        public StudentList SelectByName(string firstName, string lastName)
        {
            command.CommandText = "SELECT *, PersonTbl.ID as ID " +
                                  "FROM PersonTbl, StudentTbl " +
                                  "WHERE PersonTbl.ID = StudentTbl.ID " +
                                  $"AND FirstName='{firstName}' AND LastName='{lastName}'";
            StudentList studentList = new StudentList(Select());
            return studentList;
        }

        public Student SelectByID(int id)
        {
            command.CommandText = "SELECT *, PersonTbl.ID as ID , StudentTbl.ID AS dummy " +
                                  "FROM PersonTbl, StudentTbl " +
                                  $"WHERE PersonTbl.ID=StudentTbl.ID AND PersonTbl.ID={id}";


            List<BaseEntity> entities = Select();

            Student s = entities.Count == 1 ? entities[0] as Student : null;
            System.Diagnostics.Debug.WriteLine("Ronen is here");
            return s;
        }



        protected override int doInsert(BaseEntity entity)
        {
            System.Diagnostics.Debug.WriteLine("StudentDB doInsert");

            int count = base.doInsert(entity); //insert to Person table first (also generates person's id)

            Student s = entity as Student;
            
            command.CommandText =
                $"INSERT INTO StudentTbl VALUES({s.Id},{s.Semester})";

            count += command.ExecuteNonQuery();

            return count;
        }
    }
}
