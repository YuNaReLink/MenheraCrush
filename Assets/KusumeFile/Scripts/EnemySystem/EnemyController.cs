using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private PlayerController player;

        [SerializeField]
        private Image thisImage;

        private Timer attackTimer;

        private void Awake()
        {
            player = FindObjectOfType<PlayerController>();
            attackTimer = new Timer();
        }

        // Start is called before the first frame update
        private void Start()
        {
            attackTimer.SetLoop(true);
            attackTimer.Start(2.0f);
            attackTimer.OnEnd += DecreaseHP;
        }

        
        private void Update()
        {
            attackTimer.Update();
        }
        private void DecreaseHP()
        {
            player.HP.Decrease(10);
        }
    }
}
