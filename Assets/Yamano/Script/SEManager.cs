using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //効果音を再生するためのコンポーネント
    //再生する効果音を予め台帳のScriptableObjectに登録しておく必要がある。
    //用途によって使い分けられるように非staticで作っている。
    public class SEManager : MonoBehaviour
    {

        /*Serialized*/

        //台帳
        [SerializeField]
        private AudioLedger ledger;

        /*Method*/

        //再生するためだけのオブジェクトを生成する。
        //番号指定なので間違いに注意。
        public void Play(int i)
        {
            //番号が範囲外なら無視する。
            if (i < 0 || i >= ledger.Count)
            {
                return;
            }

            //空のオブジェクトを生成する。
            GameObject o = new("SE Player");

            //コンポーネントを括り付ける。
            SEPlayer se = o.AddComponent<SEPlayer>();

            //鳴らす。
            se.Play(ledger[i]);
        }

    }
}

