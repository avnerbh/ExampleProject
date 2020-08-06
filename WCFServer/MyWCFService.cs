using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ViewModel;

namespace WCFServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MyWCFService : IMyWCFService
    {

        public Student StudentSelectByID(int id)
        {
            StudentDB sDB = new StudentDB();
            Student s = sDB.SelectByID(id);

            return s;
        }


        public StudentList StudentSelectAll()
        {
            StudentDB sDB = new StudentDB();
            StudentList students = sDB.SelectAll();

            return students;
        }


        public Lecturer LecturerLogin(string eMail, string password)
        {
            return new LecturerDB().SelectByEmailAndPassword(eMail, password);
        }






        /*****************************************************************************
         * 
         *       not used
         * 
         ****************************************************************************/
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
