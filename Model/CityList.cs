using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CityList : List<City>
    {
        public CityList() { }

        public CityList(IEnumerable<City> enu):base(enu) { }

        public CityList(IEnumerable<BaseEntity> enu) : base(enu.Cast<City>().ToList()) { } // Ronen: where using it?
    }
}
