using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CityDB : BaseDB
    {
        private static CityList list = null;


        private CityDB()
        {
            command.CommandText = "SELECT * FROM CityTbl";
            list = new CityList(Select());
        }


        public static CityList SelectAll()
        {
            if (list == null)
            {
                new CityDB();
            }
    
            return list;
        }

        public static City SelectByID(int id)
        {
            if(list==null)
            {
                new CityDB();
            }

            City city = list.Find(aCity => aCity.Id == id);
            return city;
        }

        protected override BaseEntity newEntity()
        {
            return new City();
        }

        protected override BaseEntity FillEntity(BaseEntity entity)
        {
            base.FillEntity(entity);

            City city = entity as City;

            city.Name = (string)reader["cityName"];

            return entity;
        }
    }
}
