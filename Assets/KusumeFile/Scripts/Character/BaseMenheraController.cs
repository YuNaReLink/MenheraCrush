using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public abstract class BaseMenheraController : MonoBehaviour
    {
        [SerializeField]
        protected MenheraData menheraData;

        protected abstract MenheraBoard Board { get; }

        [SerializeField]
        protected int charaInt = 0;
        public int CharaInt => charaInt;
        public void SetCharaInt(int i) { charaInt = i; }

        public virtual void SetMenheraUI()
        {
            Board.Init(menheraData.Characters[charaInt]);
        }
    }
}
