using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucKee
{
    [Serializable]
    public struct NamePlate
    {
        private static readonly String Format = "<r={0}>{1}</r> <r={2}>{3}</r>";

        private String familyName;
        private String givenName;
        private String familyRuby;
        private String givenRuby;
        public String FullName => familyName + givenName;
        public String RubiedFullName => String.Format(Format, familyRuby, familyName, givenRuby, givenName);
    }
}
