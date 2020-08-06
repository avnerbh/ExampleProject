using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //[DataContract]
    public class Course : BaseEntity
    {
        private string subject;

        //[DataMember]
        public string Subject { get => subject; set => subject = value; }
    }
}
