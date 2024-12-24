using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    //疑似アニメーター
    //UnityのAnimatorを使う際の不具合に対し、そもそもAnimatorを使わないことで解決した。
    //とりあえずImageを要求する。
    [RequireComponent(typeof(Image))]
    public class PseudoAnimator : MonoBehaviour
    {
        /*Serialized*/

        //1枚あたりの秒数
        [SerializeField]
        private float secondPerOnce = 0.01f;

        //使用するスプライトの台帳
        //そのままの順番で切り替わる。
        [SerializeField]
        private SpriteLedger ledger = null;

        /*Member*/

        //カウントアップタイマー
        //周回の度に切られる。
        private float timer = 0.0f;

        //ループ1周の長さ
        //これが0以下の場合、初期化を行っていないものと判断する。
        private float length = 0.0f;

        /*Component*/

        private Image image = null;

        /*Event*/

        private void Awake()
        {
            image = GetComponent<Image>();
            if (ledger != null)
            {
                Initialize(ledger, true);
            }
        }

        private void Update()
        {
            //初期化前なので何もしない。
            if (length <= 0)
            {
                return;
            }

            //時間が止まっているなら処理が不要なので何もしない。
            float delta = Time.deltaTime;
            if (delta <= 0)
            {
                return;
            }

            //時間を進め、画像を更新する。
            AddTimer(delta);

        }

        /*Method*/

        //初期化
        //使用する画像の配列と共に、画像のサイズに合わせて拡縮するかのフラグを引数として受け取る。
        public void Initialize(SpriteLedger ledger, bool nativeSize = false)
        {
            //配列の設定
            this.ledger = ledger;

            //配列の長さから1周の長さを計算する。
            length = ledger.Count * secondPerOnce;

            //画像及びタイマーを初期化する。
            image.sprite = ledger[0];
            timer = 0;

            //フラグによってサイズを合わせる。
            if (nativeSize)
            {
                image.SetNativeSize();
            }
        }

        //時間を進める。
        public void AddTimer(float delta)
        {
            //時間を進める。
            timer += delta;

            //周回を検知して切り捨てる。
            int looped = (int)(timer / length);
            if (looped > 0)
            {
                timer -= length * looped;
            }

            //画像を更新する。
            UpdateSprite();
        }

        private void UpdateSprite()
        {
            //現在の画像番号を計算する。
            int index = (int)(timer / secondPerOnce);
            image.sprite = ledger[index];
        }

    }
}
