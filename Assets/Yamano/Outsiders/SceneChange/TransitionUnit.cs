using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Mask))]
    [RequireComponent(typeof(Canvas))]
    public abstract class TransitionUnit : MonoBehaviour
    {
        protected TransitionHole hole = null;

        protected virtual float StartSize => 0.0f;
        protected virtual float EndSize => 0.0f;


        private void Awake()
        {
            hole = GetComponentInChildren<TransitionHole>();
            hole.Initialize(StartSize, EndSize);
            hole.OnFinished += OnFinished;
        }
        private void OnDestroy()
        {
            hole.OnFinished -= OnFinished;
        }

        protected abstract void OnFinished();

        protected float CalcMaxSize()
        {
            RectTransform rect = GetComponent<RectTransform>();
            Vector2 size = rect.sizeDelta;

            return size.magnitude;
        }

    }
}