using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    /*旧式なので後々変更する予定*/

    //カットイン用のコンポーネント
    public class CutIn : MonoBehaviour
    {
        /*Serialized*/

        //カットインの制限時間
        //カウントアップ式なのでこの値は不動
        //この値の方が小さい場合、移動経路が持つ長さを優先する。
        [SerializeField]
        private float duration = 0.0f;

        //移動対象の画像
        [SerializeField]
        private Image image = null;

        //画像の移動経路
        [SerializeField]
        private RouteHolder route;

        /*Member*/

        //経過時間
        private float time = 0.0f;


        private MonoBehaviour after = null;

        private Skill skillObject;
        public void SetSkill(Skill skill) 
        {
            skillObject = skill; 
            skillObject.enabled = false;
        }

        /*Event*/

        void Start()
        {
            time = 0.0f;
            route.SetOffset(image.rectTransform.localPosition);
            image.rectTransform.localPosition = route.GetPosition(0.0f);
        }

        void Update()
        {
            //Time.timeScaleの影響を受けない方で更新する。
            time += Time.unscaledDeltaTime;

            //カットインの終了時に破棄する。
            if (time >= duration && time >= route.GetDuration())
            {
                Finish();
                return;
            }

            if (image == null)
            {
                return;
            }
            image.rectTransform.localPosition = route.GetPosition(time);
        }

        /*Method*/

        //カットイン中に動く画像の変更
        public void SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
        }

        //カットイン終了後に生成したいものを設定する。
        public void SetAfter(MonoBehaviour mono)
        {
            after = mono;
        }

        //カットインの終了
        //終了後の生成やオブジェクトの破棄を行う。
        //ポーズは破棄時に無効化される。
        private void Finish()
        {
            if (after != null)
            {
                Instantiate(after);
            }
            if(skillObject != null)
            {
                skillObject.enabled = true;
            }
            Destroy(gameObject);
        }
    }
}

