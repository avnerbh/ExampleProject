using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LecturerDB : BaseDB
    {
        protected override BaseEntity newEntity()
        {
            return new Lecturer();
        }

        protected override BaseEntity FillEntity(BaseEntity entity)
        {
            base.FillEntity(entity);

            Lecturer l = entity as Lecturer;

            //l.degree = (string)reader["degree"];

            return l;
        }

        public LecturerList SelectAll()
        {
            command.CommandText = "SELECT *, PersonTbl.ID as ID, LecturerTbl.ID as dummy " +
                                  "FROM PersonTbl, LecturerTbl " +
                                  "WHERE PersonTbl.ID = LecturerTbl.ID";
            LecturerList LecturerList = new LecturerList(Select());
            return LecturerList;
        }

        public LecturerList SelectByName(string firstName, string lastName)
        {
            command.CommandText = "SELECT *, PersonTbl.ID as ID, LecturerTbl.ID as dummy  " +
                                  "FROM PersonTbl, LecturerTbl " +
                                  "WHERE PersonTbl.ID = LecturerTbl.ID " +
                                  $"AND FirstName='{firstName}' AND LastName='{lastName}'";
            LecturerList LecturerList = new LecturerList(Select());
            return LecturerList;
        }

        public Lecturer SelectByID(int id)
        {
            command.CommandText = "SELECT *, Person.ID as ID, LecturerTbl.ID as dummy  " +
                                  "FROM PersonTbl, LecturerTbl " +
                                  $"WHERE PersonTbl.ID={id}";
            List<BaseEntity> entities = Select();
            return entities.Count == 1 ? entities[0] as Lecturer : null;
        }

        public Lecturer SelectByEmailAndPassword(string eMail, string password)
        {
            return new Lecturer()
            { 
                FirstName = "dummy", 
                LastName = "lecturer", 
                City = new City
                {
                    Id = 3, 
                    Name = "Haifa"
                }, 
                Id = 66,
                Telephone = 7951423,
                TelephonePrefix = TelephonePrefix.of("050")
            };
        }
    }
}
