using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// プレイヤーの体力を回復させるスキルクラス
    /// </summary>
    public class HPRecovery : MonoBehaviour
    {
        private PlayerController    player;

        [SerializeField]
        private int                 regain = 20;

        private void Awake()
        {
            player = FindObjectOfType<PlayerController>();
        }

        private void Start()
        {
            Execute();
        }


        private void Execute()
        {
            player.HP.Regain(regain);
        }
    }

}
