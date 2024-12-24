using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    //カットインのマスク用のコンポーネント
    //高さ0(任意、RectTransform依存)から始まり、目標値まで一定速度で広げるように作っている。
    //マスク機能を使うため、MaskとImageを要求する。
    [RequireComponent(typeof(Mask))]
    [RequireComponent(typeof(Image))]
    public class CutInMask : MonoBehaviour
    {
        /*Serialized*/

        //最終的な高さ
        //Canvas上での値なので大きく見える。
        [SerializeField]
        private float goalHeight = 100.0f;

        //広がる速さ
        //秒速
        [SerializeField]
        private float widenSpeed = 200.0f;

        [SerializeField]
        private Image background = null;

        /*Component*/

        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void Update()
        {
            //現在の大きさを取得する。
            Vector2 size = image.rectTransform.sizeDelta;

            //カットイン中はTime.timeScaleを0にしているため、その影響を受けない方で処理を行う。
            float delta = Time.unscaledDeltaTime;

            //高さを伸ばす。
            size.y += widenSpeed * delta;

            //超えた分を切り捨てる。
            if (goalHeight < size.y)
            {
                size.y = goalHeight;
            }

            //大きさを入れ直す。
            image.rectTransform.sizeDelta = size;

            //目標値まで到達したならコンポーネントを破棄する。
            //上記の処理の関係で、この時点で目標値を超えることは無いため、同値演算子でも可。
            if (goalHeight <= size.y)
            {
                Destroy(this);
            }
        }
        public void SetBackSprite(Sprite sprite)
        {
            background.sprite = sprite;
            background.SetNativeSize();
            float ratio = image.rectTransform.rect.width / background.rectTransform.rect.width;
            background.rectTransform.localScale = ratio * Vector2.one;
        }
    }
}