using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public abstract class BaseMenheraController : MonoBehaviour
    {
        [SerializeField]
        protected MenheraData menheraData;

        protected abstract MenheraBoard board { get; }

        [SerializeField]
        protected int charaInt = 0;
        public int CharaInt => charaInt;
        public void SetCharaInt(int i) { charaInt = i; }

        public virtual void SetMenheraUI()
        {
            board.Init(menheraData.Characters[charaInt]);
        }
    }
}
