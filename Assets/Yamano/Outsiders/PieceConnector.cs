using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LucKee
{
    //座標(主にピース)同士を繋ぐ線
    //横向きの画像を想定している。
    [RequireComponent(typeof(SpriteRenderer))]
    public class PieceConnector : MonoBehaviour
    {
        //線の始点
        [SerializeField]
        private Transform start;

        //線の終点
        [SerializeField]
        private Transform end;

        //始点と終点を設定し、位置を補正する。
        public void Initialize(Transform s, Transform e)
        {
            start = s;
            end = e;
            CorrectPosition();
        }

        //位置を計算し続ける。
        private void Update()
        {
            //流石に無いとは思うがエラー対策
            if (start == null || start.IsDestroyed())
            {
                Destroy(gameObject);
                return;
            }
            if (end == null || end.IsDestroyed())
            {
                Destroy(gameObject);
                return;
            }
            CorrectPosition();
        }

        //位置の補正
        private void CorrectPosition()
        {
            //差の取得
            Vector2 diff = start.position - end.position;

            //角度の計算
            float angle = Mathf.Atan2(diff.y, diff.x);
            angle *= Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = rotation;

            //位置の計算
            transform.position = (start.position + end.position) * 0.5f;

            //大きさの計算
            Vector3 scale = transform.localScale;
            scale.x = diff.magnitude;
            transform.localScale = scale;

        }
    }
}