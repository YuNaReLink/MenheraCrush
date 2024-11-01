using LucKee;
using UnityEngine;

namespace Kusume
{
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
