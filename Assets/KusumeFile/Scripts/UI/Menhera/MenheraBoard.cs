using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Animator))]
    public class MenheraBoard : MonoBehaviour
    {
        private Image image;

        private Animator animator;

        public void Init(AllyCharacterInfo characterInfo)
        {
            animator.runtimeAnimatorController = characterInfo.animator;

            image.sprite = characterInfo.sprite;
            image.color = Color.white;
            image.SetNativeSize();
        }

        private void Awake()
        {
            image = GetComponent<Image>();

            animator = GetComponent<Animator>();
        }
    }
}
