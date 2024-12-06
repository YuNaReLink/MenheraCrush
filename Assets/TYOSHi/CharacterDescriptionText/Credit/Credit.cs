using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credit : MonoBehaviour
{
    [SerializeField]
    private TextLedger credit;

    [SerializeField]
    private Text text;

    private void Awake()
    {
        text.text = credit.GetText(0);
    }
}
