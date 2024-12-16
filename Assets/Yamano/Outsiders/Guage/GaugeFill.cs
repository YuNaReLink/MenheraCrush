using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    //ゲージを埋める部分のコンポーネント
    //Canvas上かつ画像で行うため、Imageを要求している。
    [RequireComponent(typeof(Image))]
    public class GaugeFill : MonoBehaviour
    {
        /*Component*/

        Image image = null;

        /*Event*/

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        /*Method*/

        //マテリアルの色の境界線の設定
        //0から1の小数点数で設定する。
        public void SetGoalRatio(float ratio)
        {
            Material mat = image.material;
            mat.SetFloat("_ColorBorder", ratio);
        }

        //ゲージの満ち具合の設定
        //0から1の小数点数で設定する。
        public void SetScoreRatio(float ratio)
        {
            image.fillAmount = ratio;
        }

    }
}