using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    [RequireComponent(typeof(Mask))]
    [RequireComponent(typeof(Image))]
    public class CutInMask : MonoBehaviour
    {
        [SerializeField]
        private float goalHeight = 100.0f;

        [SerializeField]
        private float widenSpeed = 200.0f;

        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void Update()
        {
            Vector2 size = image.rectTransform.sizeDelta;
            if (goalHeight <= size.y)
            {
                return;
            }
            float delta = Time.unscaledDeltaTime;
            size.y += widenSpeed * delta;
            if (goalHeight < size.y)
            {
                size.y = goalHeight;
            }
            image.rectTransform.sizeDelta = size;

        }

    }

}