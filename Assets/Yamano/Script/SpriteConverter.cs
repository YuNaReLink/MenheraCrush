using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace LucKee
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class SpriteConverter : MonoBehaviour
    {
        private TextMeshProUGUI mesh;

        [SerializeField]
        private String format = "<sprite index={0}>";


        private void Awake()
        {
            mesh = GetComponent<TextMeshProUGUI>();
        }

        public void SetText(String text)
        {
            for (int i = 0; i < 10; i++)
            {
                text = text.Replace(i.ToString(), String.Format(format, i));
            }
            mesh.text = text;
        }

    }
}