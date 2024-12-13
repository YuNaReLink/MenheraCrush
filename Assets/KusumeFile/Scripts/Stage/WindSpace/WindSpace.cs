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

        [SerializeField]
        private float angleRatio = 60.0f;

        [SerializeField]
        private float addAngle = 90.0f;

        private PlayerController playerController;
        public void SetPlayerController(PlayerController p) { playerController = p; }

        public void Activate()
        {
            if(playerController == null) { return; }
            if (!playerController.PieceContainer.NullPieceList()) { return; }
            if (!GameController.Instance.IsPlayable()) { return; }
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
                float angle = angleRatio * random;
                angle += addAngle;
                angle *= Mathf.Deg2Rad;
                v.x = Mathf.Cos(angle);
                v.y = Mathf.Sin(angle);
                Vector2 position = (Vector2)piece.transform.position + new Vector2(0.5f * random * piece.transform.localScale.x, 0);
                rb.AddForceAtPosition(v * power, position, ForceMode2D.Force);
            }
        }
    }
}
