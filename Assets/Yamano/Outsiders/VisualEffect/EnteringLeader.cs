using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //入場時の動きを先導するオブジェクト
    //空のオブジェクトに括り付けて使う。
    //重力を扱うため、Rigidbody2Dを要求する。
    //終了時に消えるため、他のコンポーネントを付けてはいけない。
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnteringLeader : MonoBehaviour
    {
        //唯一のインスタンス
        public static EnteringLeader Instance { get; private set; }

        //y座標の補正
        //実際にはオブジェクトのy座標を代入する。
        //取得の簡易化及びインスタンスの削除後であっても不具合を起こさないようにstaticに保持している。
        public static float OffsetY { get; private set; }

        //上方向への力
        //生成後に自身を上に打ち上げる。
        [SerializeField]
        private float power = 1.0f;
        [SerializeField]
        private bool jumpOnStart = false;

        private Rigidbody2D rigid = null;

        private void Awake()
        {
            Instance = this;
            rigid = GetComponent<Rigidbody2D>();
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        private void Start()
        {
            if (jumpOnStart)
            {
                Jump();
            }
        }
        private void Update()
        {
            //y座標のみを取得する。
            float y = transform.position.y;

            //0を下回った時には終了する。
            if (y < 0)
            {
                y = 0;
                Destroy(gameObject);
            }

            //static側に代入する。
            //仮に破棄後であったとしても、ローカル変数とstatic変数なので問題なく代入できる。
            OffsetY = y;
        }


        private void OnDestroy()
        {
            Instance = null;
        }


        public void Jump()
        {
            if (rigid.constraints == RigidbodyConstraints2D.None)
            {
                return;
            }
            rigid.constraints = RigidbodyConstraints2D.None;
            //上に打ち上げる。
            rigid.AddForce(power * Vector2.up, ForceMode2D.Impulse);
        }
    }
}