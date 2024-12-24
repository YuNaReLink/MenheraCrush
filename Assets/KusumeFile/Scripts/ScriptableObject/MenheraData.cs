using System;
using UnityEngine;

namespace Kusume
{
    [Serializable]
    public struct CharacterInfo
    {
        public CharacterNameList tag;
        public string name;
        public LucKee.Skill skill;
        public int skillGauge; 
        public int characterNumber;
        public Sprite sprite;
        public Sprite faceSprite;
        public Sprite backSprite;
        public Sprite backSprite2;
        public Vector2 ImageOffset;
        public Color imageColor;
        public float ImageScale;
    }

    [CreateAssetMenu(fileName = "Menhera", menuName = "ScriptableObjects/Menhera", order = 1)]
    public class MenheraData : ScriptableObject
    {
        [SerializeField]
        private CharacterInfo[] characters;
        public CharacterInfo[] Characters => characters;

    }
}

