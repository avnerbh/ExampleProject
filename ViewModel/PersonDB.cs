using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public abstract class PersonDB : BaseDB
    {
        protected override BaseEntity FillEntity(BaseEntity entity)
        {

            base.FillEntity(entity); // fill ID

            Person p = entity as Person;

            p.FirstName = (string)reader["FirstName"];
            p.LastName = (string)reader["LastName"];
            p.Telephone = Int32.Parse(reader["Telephone"].ToString());
            p.TelephonePrefix = TelephonePrefix.of((string)reader["TelephonePrefix"]); //singleton

            p.City = CityDB.SelectByID(Int32.Parse(reader["city"].ToString()));
            return p;
        }

        protected override int doInsert(BaseEntity entity)
        {
            System.Diagnostics.Debug.WriteLine("PersonDB doInsert");
            Person p = entity as Person;
            command.CommandText = 
                $"INSERT INTO PersonTbl(FirstName, LastName, City, TelephonePrefix, Telephone) VALUES('{p.FirstName}','{p.LastName}',{p.City.Id},'{p.TelephonePrefix.ToString()}',{p.Telephone})";

            int count = command.ExecuteNonQuery();

            //update entity's id
            command.CommandText = "SELECT @@Identity";
            entity.Id = (int)command.ExecuteScalar();

            return count;
        }
    }
}
