using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    //テスト用の適当なコンポーネント
    //動作担当
    public class Automatton : MonoBehaviour
    {
        //移動する円の半径
        [SerializeField]
        float radius = 1.0f;
        
        //現在の角度
        float radian = 0.0f;
        
        //秒間の角度の変化値
        [SerializeField]
        float radianSpeed = 1.0f;


        private void Update()
        {
            //角度の更新
            //ポーズのテストのため、Time.timeScaleの影響を受ける方で更新する。
            radian += radianSpeed * Time.deltaTime;

            //位置の計算
            Vector2 v = Vector2.one * radius;
            v.x *= Mathf.Cos(radian);
            v.y *= Mathf.Sin(radian);

            //位置の更新
            transform.position = v;
        }
    }
}

