using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    //�Q�[�W�𖄂߂镔���̃R���|�[�l���g
    //Canvas�ォ�摜�ōs�����߁AImage��v�����Ă���B
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

        //�}�e���A���̐F�̋��E���̐ݒ�
        //0����1�̏����_���Őݒ肷��B
        public void SetGoalRatio(float ratio)
        {
            Material mat = image.material;
            mat.SetFloat("_ColorBorder", ratio);
        }

        //�Q�[�W�̖�����̐ݒ�
        //0����1�̏����_���Őݒ肷��B
        public void SetScoreRatio(float ratio)
        {
            image.fillAmount = ratio;
        }

    }
}