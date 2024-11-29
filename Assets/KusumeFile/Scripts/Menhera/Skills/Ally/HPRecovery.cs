using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// �v���C���[�̗̑͂��񕜂�����X�L���N���X
    /// </summary>
    public class HPRecovery : MonoBehaviour, LucKee.ISkillObject
    {
        private PlayerController    player;

        [SerializeField]
        private int                 regain = 20;

        private void Awake()
        {
            player = FindObjectOfType<PlayerController>();
        }

        public void Execute()
        {
            player.HP.Regain(regain);
        }
    }

}
