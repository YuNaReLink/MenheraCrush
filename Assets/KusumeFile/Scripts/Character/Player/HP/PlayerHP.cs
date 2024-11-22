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

        public void Setup()
        {
            currentHP = maxHP;
        }


        public void Decrease(int damage)
        {
            currentHP -= damage;
            if (currentHP < 0)
            {
                currentHP = 0;
                GameController.Instance.EndGame();
            }
        }

        public void Regain(int addHP)
        {
            currentHP += addHP;
            if (currentHP > maxHP)
            {
                currentHP = maxHP;
            }
        }
    }
}
