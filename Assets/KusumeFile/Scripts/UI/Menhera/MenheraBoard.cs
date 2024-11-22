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

        private bool entry = false;

        public void Init(CharacterInfo characterInfo)
        {
            animator.runtimeAnimatorController = characterInfo.animator;

            image.sprite = characterInfo.sprite;
            image.color = Color.white;
            image.SetNativeSize();
            image.enabled = true;
        }

        private void Awake()
        {
            image = GetComponent<Image>();

            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            image.enabled = false;
        }

        private void Update()
        {
            
        }

        private void EntryUpdate()
        {
            if (!entry) { return; }

        }
    }
}
