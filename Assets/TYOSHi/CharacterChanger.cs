using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour
{
    [SerializeField] private CharacterSwitching charaSwitch;
    [SerializeField] private CharacterNameList chara;
    public void Change()
    {
        //ƒLƒƒƒ‰•ÏXŒÄ‚Ño‚µ
        charaSwitch.Select(chara);
    }
}
