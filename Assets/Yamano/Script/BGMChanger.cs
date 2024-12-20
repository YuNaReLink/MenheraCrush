using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LucKee
{
    public class BGMChanger : MonoBehaviour
    {
        [SerializeField]
        private AudioClip clip = null;

        private void Start()
        {
            BGMManager.Play(clip);
        }
    }
}
