using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //[DataContract]
    public class City : BaseEntity
    {
        private string name;

        //[DataMember]
        public string Name { get => name; set => name = value; }
    }
}
