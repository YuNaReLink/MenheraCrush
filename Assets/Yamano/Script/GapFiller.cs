using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    [RequireComponent(typeof(Image))]
    public class GapFiller : MonoBehaviour
    {
        public void Fill(Rect rect)
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.position = rect.center;
            rectTransform.sizeDelta = rect.size;
        }
    }
}
