using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    /*旧式なので後々変更する予定*/

    //カットイン用のコンポーネント
    //カットイン中はゲームの動きを止めるのでポーズを要求する。
    [RequireComponent(typeof(Pause))]
    public class CutIn : MonoBehaviour
    {
        /*Serialized*/

        //カットインの制限時間
        //カウントアップ式なのでこの値は不動
        [SerializeField]
        private float duration = 0.0f;

        [SerializeField]
        private Image image = null;

        [SerializeField]
        private RouteHolder route;

        /*Member*/

        //経過時間
        private float time = 0.0f;

        /*Event*/

        void Start()
        {
            //カットインが始まった時にゲームを一時停止する。
            Pause pause = GetComponent<Pause>();
            pause.Enable();

            time = 0.0f;
            image.rectTransform.localPosition = route.GetPosition(0.0f);
        }

        void Update()
        {
            //Time.timeScaleの影響を受けない方で更新する。
            time += Time.unscaledDeltaTime;

            //カットインの終了時に破棄する。
            if (time >= duration)
            {
                //ポーズは破棄時に無効化される。
                Destroy(gameObject);
                return;
            }

            if (image == null)
            {
                return;
            }
            image.rectTransform.localPosition = route.GetPosition(time);
        }
    }
}

