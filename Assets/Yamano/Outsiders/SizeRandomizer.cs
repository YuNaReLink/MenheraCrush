using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    public struct SizeInfo
    {
        public float size;
        public bool large;
    }
    //[CreateAssetMenu(fileName = "SizeRandomizer", menuName = "ScriptableObjects/Randomizer/Size", order = 1)]
    public class SizeRandomizer : RandomizerBase<SizeInfo>
    {
    }

}
