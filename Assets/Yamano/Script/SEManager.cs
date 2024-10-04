using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    public class SEManager : MonoBehaviour
    {
        static SEManager instance = null;
        static SEManager Instance { get => instance; }

        [SerializeField]
        private SELedger ledger;


        private void Awake()
        {
            instance = this;
        }

        public void Play(int i)
        {
            if (i < 0 || i >= ledger.Count)
            {
                return;
            }
            GameObject o = Instantiate(new GameObject());
            SEPlayer se = o.AddComponent<SEPlayer>();
            se.Play(ledger[i]);
        }

    }
}

