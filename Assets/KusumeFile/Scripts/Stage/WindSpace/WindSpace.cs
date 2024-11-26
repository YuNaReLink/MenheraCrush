using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// ピースをまとめて動かす処理を行うクラス
    /// ワールド座標で上方向と
    /// ピースのローカル座標から右方向に動かす
    /// </summary>
    public class WindSpace : MonoBehaviour
    {

        [SerializeField]
        private float           power = 500.0f;

        public void Activate()
        {
            RunWind();
        }

        private void RunWind()
        {
            List<Piece> pieces = CreatePieceMachine.Instance.Pieces;
            foreach(Piece piece in pieces)
            {
                Rigidbody2D rb = piece.GetComponent<Rigidbody2D>();

                Vector2 v = Vector2.zero;
                float random = Random.Range(-1.0f, 1.0f);
                float angle = 60.0f * random;
                angle += 90.0f;
                angle *= Mathf.Deg2Rad;
                v.x = Mathf.Cos(angle);
                v.y = Mathf.Sin(angle);
                Vector2 position = (Vector2)piece.transform.position + new Vector2(0.5f * random * piece.transform.localScale.x, 0);
                rb.AddForceAtPosition(v * power, position, ForceMode2D.Force);
                Debug.Log(random);
            }
        }
    }
}
