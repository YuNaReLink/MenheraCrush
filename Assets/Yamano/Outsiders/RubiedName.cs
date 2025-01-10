using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LucKee
{
    [RequireComponent(typeof(RectTransform))]
    public class RubiedName : MonoBehaviour
    {
        [SerializeField]
        private RubyableText family;
        [SerializeField]
        private RubyableText given;

        public void SetName(NamePlate plate)
        {
            family.SetText(plate.FamilyName, plate.FamilyRuby);
            given.SetText(plate.GivenName, plate.GivenRuby);
        }

    }
}
