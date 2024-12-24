using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Coffee.UIExtensions;

namespace LucKee
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Unmask))]
    public class TransitionHole : MonoBehaviour
    {
        [SerializeField]
        [Min(0.0f)]
        private float speed = 1000.0f;

        private float current = 0.0f;

        private float goal = 0.0f;

        public event Action OnFinished;

        private bool unscaled = true;

        private RectTransform r;
        private RectTransform rect
        {
            get
            {
                if (r == null)
                {
                    r = GetComponent<RectTransform>();
                }
                return r;
            }
        }

        private float Delta
        {
            get => unscaled ? Time.unscaledDeltaTime : Time.deltaTime;
        }

        private void Update()
        {
            if (current == goal)
            {
                return;
            }
            float delta = Delta;
            float move = speed * delta;
            if (Mathf.Abs(current - goal) <= move)
            {
                current = goal;
                rect.sizeDelta = current * Vector2.one;
                Finish();
                return;
            }
            if (current > goal)
            {
                move *= -1;
            }
            current += move;

            rect.sizeDelta = current * Vector2.one;
        }

        public void Initialize(float start, float end)
        {
            current = start;
            goal = end;
            rect.sizeDelta = current * Vector2.one;
        }

        private void Finish()
        {
            OnFinished.Invoke();
        }

        public void SetUnscaled(bool b) { unscaled = b; }
    }
}