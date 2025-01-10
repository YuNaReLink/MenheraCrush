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
        [SerializeField]
        private String familyName;
        [SerializeField]
        private String givenName;
        [SerializeField]
        private String familyRuby;
        [SerializeField]
        private String givenRuby;

        public String FamilyName => familyName;
        public String GivenName => givenName;
        public String FamilyRuby => familyRuby;
        public String GivenRuby => givenRuby;

        public String FullName => familyName + givenName;
    }
}
