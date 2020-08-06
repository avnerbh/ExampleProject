using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{


    /* Ronen: it is intendent that MessageBox.Show((TelephonePrefix.of("052") == TelephonePrefix.of("052")).ToString()); will show True
     */
    //[DataContract]
    public class TelephonePrefix
    {
        private string prefix;

        private TelephonePrefix() { }

        private static List<TelephonePrefix> prefixes;

        //[DataMember]
        public string Prefix { get => prefix; set => prefix = value; }

        static TelephonePrefix()
        {
            initPrefixes();
        }

        private static void initPrefixes()
        {
            string[] values = { "02", "03", "04", "08", "09", "050", "052", "054" };

            prefixes = new List<TelephonePrefix>();

            foreach (string prefix in values)
            {
                TelephonePrefix temp = new TelephonePrefix();
                temp.prefix = prefix;
                prefixes.Add(temp);
            }
        }

        public static TelephonePrefix of(string prefix)
        {
            if (prefixes == null)
                initPrefixes();

            return prefixes.Find(p => p.prefix.Equals(prefix));
        }

        public static TelephonePrefixList GetAllPrefixes()
        {
            return new TelephonePrefixList(prefixes);
        }

        public override string ToString()
        {
            return prefix;
        }
    }

    public class TelephonePrefixList : List<TelephonePrefix> //can also apply singleton pattern on this class
    {
        public TelephonePrefixList(List<TelephonePrefix> lst) : base(lst) { }
    }
}
