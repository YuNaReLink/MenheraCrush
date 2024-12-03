using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public enum ButtonColor
    {
        Normal,
        Highlighted,
        Pressed,
        Selected,
        Disabled
    }
    [Serializable]
    public struct ButtonColors
    {
        public List<Color> colors;
    }

    [CreateAssetMenu(fileName = "SkillButtonColorData", menuName = "ScriptableObjects/SkillButtonColorData", order = 1)]
    public class SkillButtonColorDataList : ScriptableObject
    {
        [SerializeField]
        private List<ButtonColors> buttonColors;
        public List<ButtonColors> ButtonColors => buttonColors;
    }
}
