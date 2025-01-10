using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LucKee
{
    [Serializable]
    public struct NamePlate
    {
        private static readonly String Format = "<r={0}>{1}</r> <r={2}>{3}</r>";
        [SerializeField]
        private String familyName;
        [SerializeField]
        private String givenName;
        [SerializeField]
        private String familyRuby;
        [SerializeField]
        private String givenRuby;
        public String FullName => familyName + givenName;
        public String RubiedFullName => String.Format(Format, familyRuby, familyName, givenRuby, givenName);
    }
}
