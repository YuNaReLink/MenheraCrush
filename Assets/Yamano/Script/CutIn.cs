using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    //カットイン用のコンポーネント
    //画像を要求するのは勿論のこと、カットイン中はゲームの動きを止めるのでポーズも要求する。
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Pause))]
    public class CutIn : MonoBehaviour
    {
        //カットインの時間
        [SerializeField]
        float duration = 0.0f;

        //カットインが始まった時にゲームを一時停止する。
        void Start()
        {
            Pause pause = GetComponent<Pause>();
            pause.Enable();
        }


        void Update()
        {
            //Time.timeScaleの影響を受けない方で更新する。
            duration -= Time.unscaledDeltaTime;

            //カットインの終了時に破棄する。
            if (duration <= 0)
            {
                //ポーズは破棄時に無効化される。
                Destroy(gameObject);
            }
        }
    }
}

