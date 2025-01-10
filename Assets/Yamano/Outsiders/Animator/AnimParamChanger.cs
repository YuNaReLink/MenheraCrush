using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LucKee
{
    [RequireComponent(typeof(Animator))]
    public class AnimParamChanger : MonoBehaviour
    {
        [SerializeField]
        CharacterNameList character;

        private void Awake()
        {
            Animator animator = GetComponent<Animator>();
            animator.SetInteger("Number", (int)character);
            Destroy(this);
        }
    }
}
