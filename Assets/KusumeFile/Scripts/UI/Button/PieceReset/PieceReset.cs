using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PieceReset : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private WindSpace windSpace;

    private void Awake()
    {
        button = GetComponent<Button>();
        windSpace = FindObjectOfType<WindSpace>();
    }

    private void Start()
    {
        button.onClick.AddListener(StartPieceReset);
    }

    public void StartPieceReset()
    {
        if(windSpace.Duration > 0) { return; }
        windSpace.SetDuration(0.25f);
    }
}
