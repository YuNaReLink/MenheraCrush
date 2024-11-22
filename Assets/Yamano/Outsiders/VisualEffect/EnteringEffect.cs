using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LucKee
{
    //入場時の動きのためのコンポーネント
    //Canvas上で動かす想定のため、RectTransformを要求する。
    //入場終了後は仕事が無いため、このコンポーネントのみを破棄する。
    [RequireComponent(typeof(RectTransform))]
    public class EnteringEffect : MonoBehaviour
    {
        //初期地点の座標
        private Vector2 initialPosition;

        private RectTransform rect;

        private void Awake()
        {
            rect = GetComponent<RectTransform>();
            //初期地点を保持する。
            initialPosition = rect.position;
        }

        private void Update()
        {
            //初期地点にY座標の補正を加算した値を現在地とする。
            rect.position = initialPosition + EnteringLeader.OffsetY * Vector2.up;

            //値を計算する側が終了しているなら、自身も消える。
            if (EnteringLeader.Instance == null)
            {
                Destroy(this);
            }
        }
    }
}
