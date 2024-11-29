using LucKee;
using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// スコア倍率のスキルクラス
    /// </summary>
    [RequireComponent(typeof(Skill))]
    public class BonusScoreTime : MonoBehaviour,LucKee.ISkillObject
    {
        private Skill skill;

        private void Start()
        {
            GameScore.SetBonus(true);
        }

        public void Execute()
        {
            GameScore.SetBonus(false);
        }
    }

}
