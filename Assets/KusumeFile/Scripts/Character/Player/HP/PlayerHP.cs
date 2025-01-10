using LucKee;
using UnityEngine;

namespace Kusume
{
    [System.Serializable]
    public class PlayerHP
    {
        [SerializeField]
        private float       maxHP = 200;
        [SerializeField]
        private float       currentHP = 0;

        public float        MaxHP => maxHP;

        public float        CurrentHP => currentHP;

        [SerializeField]
        private SEManager   seManager;

        public void Setup(PlayerController player)
        {
            currentHP = maxHP;
            seManager = player.gameObject.GetComponent<SEManager>();
        }


        public void Decrease(int damage)
        {
            currentHP -= damage;
            seManager.Play(1);
            if (currentHP <= 0)
            {
                currentHP = 0;
                GameController.Instance.EndGame();
            }
        }

        public void Regain(int addHP)
        {
            currentHP += addHP;
            seManager.Play();
            if (currentHP > maxHP)
            {
                currentHP = maxHP;
            }
        }

        public float GetRatio()
        {
            return currentHP / maxHP;
        }
    }
}
