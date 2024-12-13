using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LucKee
{
    //オブジェクトを揺らすためのコンポーネント
    [RequireComponent(typeof(RectTransform))]
    public class Shaker : MonoBehaviour
    {
        /*Serialized*/

        //揺れの開始同士の間隔
        [SerializeField]
        private float wait = 1.0f;

        //揺れの範囲
        //左右に揺れるため、Z回転は(-range)~(+range)までの範囲を取る。
        //度数法で設定する。
        [SerializeField]
        private float range = 30.0f;

        //揺れの所要時間
        //この時間が短いほど速く揺れる。
        [SerializeField]
        private float shakeTime = 0.3f;


        /*Member*/

        //タイマー用変数
        //ループで扱う。
        private Kusume.Timer waitTimer = new(0);

        //稼働状態のフラグ
        private bool state = false;

        /*Event*/

        private void Awake()
        {
            //ループ設定
            waitTimer.SetLoop(true);
        }

        private void Update()
        {
            //稼働状態で無ければ中断する。
            if (!state)
            {
                return;
            }

            //時間を進める。
            waitTimer.Update(Time.deltaTime);

            //揺らす処理は長くなるので分離している。
            UpdateShake(wait - waitTimer.Current);

        }

        /*Method*/

        //揺れの更新
        //経過時間を引数として受け取る。
        private void UpdateShake(float passed)
        {
            //揺れ終わった後は0度にする。
            if (passed > shakeTime)
            {
                SetAngle(0);
                return;
            }

            /*
             * 今回、揺れを3段階に分割している。
             * ・揺れ始め：0.0~0.25の間、0から始まって左に進む。
             * ・揺り戻し：0.25~0.75の間、左から右に進む。
             * ・揺れ終わり：0.75~1.0の間、右から0に進む。
             */

            //上記の3段階は4分の1の倍数で変化するので、事前に割っておく。
            float quarter = shakeTime * 0.25f;
            //角度(度数法)
            float angle = 0;

            //揺れ始めの場合
            if (passed < quarter)
            {
                //左に進む。
                angle = -range * passed / quarter;
            }
            else
            {
                //余分な計算を省くため、この時点で4分の1を引く。
                passed -= quarter;

                //揺り戻しの場合
                if (passed < quarter * 2)
                {
                    //左から始まって右に進む。
                    angle = range * (passed / quarter - 1);
                }
                //揺れ終わりの場合
                else
                {
                    //最後の4分の1のみが重要なので切り取る。
                    passed -= quarter * 2;

                    //右から0に戻る。
                    angle = range * (1 - passed / quarter);
                }
            }

            //角度を設定する。
            SetAngle(angle);
        }

        //角度の設定
        //勿論、度数法で受け取る。
        private void SetAngle(float angle)
        {
            Quaternion q = transform.rotation;

            //何故か弧度法で設定するので変換して代入する。
            q.z = angle * Mathf.Deg2Rad;

            transform.rotation = q;
        }

        //起動
        //終了するまで揺れ続ける。
        public void Activate()
        {
            //状態の変更
            state = true;

            //タイマーの初期化
            waitTimer.Start(wait);
        }

        //終了
        //これ自体にはオブジェクトの破棄は含まれない。
        public void Deactivate()
        {
            //状態の変更
            state = false;

            //角度の初期化
            SetAngle(0);
        }
    }
}
