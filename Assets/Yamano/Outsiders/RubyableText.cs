using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    [RequireComponent(typeof(Text))]
    public class RubyableText : MonoBehaviour
    {
        [SerializeField]
        private float offsetY = 30.0f;

        [SerializeField]
        private Text rubyText = null;

        private Text mainText;
        private void Awake()
        {
            mainText = GetComponent<Text>();
        }

        public void SetText(String main, String ruby)
        {
            mainText.text = main;
            rubyText.text = ruby;

            Vector2 offset = offsetY * Vector2.up;
            rubyText.rectTransform.localPosition = GetCenter() + offset;


        }

        private Vector2 GetCenter()
        {
            Vector2 center = Vector2.zero;

            int anchor = (int)mainText.alignment;

            /*
             * -1:Left
             *  0:Center
             *  1:Right
             */
            int h = anchor % 3 - 1;

            if (h != 0)
            {
                if (h < 0)
                {
                    center.x = mainText.rectTransform.rect.xMin;
                }
                else
                {
                    center.x = mainText.rectTransform.rect.xMax;
                }
                float offset = mainText.text.Length * mainText.fontSize * 0.5f;
                center.x -= offset * h;
            }

            return center;
        }

    }
}
