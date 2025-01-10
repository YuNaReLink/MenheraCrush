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
        private String familyName;
        private String givenName;
        private String familyRuby;
        private String givenRuby;

        public String FamilyName => familyName;
        public String GivenName => givenName;
        public String FamilyRuby => familyRuby;
        public String GivenRuby => givenRuby;

        public String FullName => familyName + givenName;
    }
}
