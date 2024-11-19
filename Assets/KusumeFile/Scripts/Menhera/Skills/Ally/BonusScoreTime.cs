using LucKee;
using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// �X�R�A�{���̃X�L���N���X
    /// </summary>
    [RequireComponent(typeof(Skill))]
    public class BonusScoreTime : MonoBehaviour
    {
        private Skill skill;

        private void Start()
        {
            GameScore.SetBonus(true);
        }

        private void OnDestroy()
        {
            GameScore.SetBonus(false);
        }
    }

}
