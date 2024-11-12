using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class BaseMenheraController : MonoBehaviour
    {
        [SerializeField]
        protected MenheraData menheraData;

        [SerializeField]
        protected Image thisImage;

        [SerializeField]
        protected Animator animator;

        [SerializeField]
        protected int charaInt = 0;

        public void SetCharaInt(int i) { charaInt = i; }

        public virtual void SetMenheraUI()
        {
            if(animator != null)
            {
                animator.runtimeAnimatorController = menheraData.Characters[charaInt].animator;
            }
            thisImage.sprite = menheraData.Characters[charaInt].sprite;
            thisImage.color = Color.white;
            thisImage.SetNativeSize();
        }
    }
}
