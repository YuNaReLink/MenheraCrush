using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ClickEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem effectPrefab;

    [SerializeField]
    private Camera main;


    private void Awake()
    {
        //以下キャンバスの設定
        //カメラのレンダーモードをスクリーンスペースカメラに変更
        //レンダーカメラにメインカメラをいれる
        //ソートレイヤーをUIに変更

        main = GameObject.Find("Main Camera").GetComponent<Camera>();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            //マウスの場所取得
            Vector2 mousePos = Input.mousePosition;
            Vector2 pos = main.ScreenToWorldPoint(mousePos);
            ParticleSystem effect = Instantiate(effectPrefab, transform);
            effect.transform.position = pos;
            effect.Play();
        }
    }
}
