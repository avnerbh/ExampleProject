using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //[DataContract]
    public abstract class Person : BaseEntity
    {
        private string firstName;
        private string lastName;
        private City city;
        private int telephone;
        private TelephonePrefix telephonePrefix;

        //[DataMember]
        public string FirstName { get => firstName; set => firstName = value; }

        //[DataMember]
        public string LastName { get => lastName; set => lastName = value; }

        //[DataMember]
        public City City { get => city; set => city = value; }

        //[DataMember]
        public int Telephone { get => telephone; set => telephone = value; }

        //[DataMember]
        public TelephonePrefix TelephonePrefix { get => telephonePrefix; set => telephonePrefix = value; }
    }
}
