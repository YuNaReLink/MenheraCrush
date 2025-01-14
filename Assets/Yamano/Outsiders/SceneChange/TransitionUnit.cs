using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    //遷移用の機能の親オブジェクト
    //手前側のキャンバスとして生成し、上から表示を行う。
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Mask))]
    [RequireComponent(typeof(Canvas))]
    public abstract class TransitionUnit : MonoBehaviour
    {
        //
        protected TransitionHole hole = null;

        protected virtual float StartSize => 0.0f;
        protected virtual float EndSize => 0.0f;


        private void Awake()
        {
            hole = GetComponentInChildren<TransitionHole>();
            hole.Initialize(StartSize, EndSize);
            hole.OnFinished += OnFinished;

            Canvas canvas = GetComponent<Canvas>();
            canvas.sortingOrder = 1;
        }
        private void OnDestroy()
        {
            hole.OnFinished -= OnFinished;
        }

        protected abstract void OnFinished();

        protected float CalcMaxSize()
        {
            CanvasScaler scaler = GetComponent<CanvasScaler>();
            Vector2 size = scaler.referenceResolution;

            return size.magnitude;
        }

    }
}