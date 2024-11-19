using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ClickEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem effect;

    [SerializeField]
    private Camera main;

    private Vector2 mousePos;

    private void Awake()
    {
        //以下キャンバスの設定
        //カメラのレンダーモードをスクリーンスペースカメラに変更
        //レンダーカメラにメインカメラをいれる
        //ソートレイヤーをUIに変更

        effect = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        main = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            //マウスの場所取得
            mousePos = Input.mousePosition;
            //エフェクトの位置設定
            effect.transform.position = main.ScreenToWorldPoint(mousePos);
            //プレイ
            effect.Play();
        }
    }
}
