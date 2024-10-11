using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //ピースの識別タグ
    //仮名なので後々変わる。
    enum PieceTag
    {
        Null,
        Piece0,
        Piece1,
        Piece2,
        Piece3,
        Count
    }


    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    //ピース用コンポーネント(試作)
    //破棄するも良し、参考にするも良し。
    public class Piece : MonoBehaviour
    {
        //ピースのサイズ一覧
        private static float[] Size = { 1.0f, 2.0f };

        //ピースの爆発力一覧
        private static float[] Power = { 0.0f, 1.0f };

        //ピースの爆発範囲一覧
        private static float[] Radius = { 0.0f, 1.0f };

        //ピースの識別タグ
        [SerializeField]
        private new PieceTag tag = PieceTag.Null;

        //ピースのサイズ番号
        [SerializeField]
        int sizeIndex = 0;

        //ピースの破壊までの待機時間
        float wait = 0;
        
        //生成後の処理
        //タグやサイズの不正を検知した場合は即座に破壊する。
        private void Start()
        {
            //タグ検査
            if (tag == PieceTag.Null)
            {
                Destroy(gameObject);
                return;
            }
            
            //サイズ検査
            if (sizeIndex < 0 || sizeIndex >= Size.Length)
            {
                Destroy(gameObject);
                return;
            }

            //サイズ番号を基にピースのサイズを変更する
            transform.localScale = Vector3.one * Size[sizeIndex];
            
            //ピースの種類によって画像か色を変更するのでとりあえず取得
            //SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        }

        //更新処理
        //待機時間が終了したら破壊する。
        private void Update()
        {
            //待機中ではないので中断
            if (wait <= 0)
            {
                return;
            }

            //ポーズ中はカウントを進めないよう、Time.timeScaleの影響を受ける方を使う。
            wait -= Time.deltaTime;

            //待機時間が終了したら破壊する。
            if (wait <= 0)
            {
                Crush();
            }
        }

        //破壊処理
        //即座に破壊する。
        public void Crush()
        {
            Impact();
            Destroy(gameObject);
        }

        //破壊処理
        //待機時間(秒)を指定して破壊する。
        public void Crush(float w)
        {
            //0以下の場合は待機せずに破壊する。
            if (w <= 0)
            {
                Crush();
                return;
            }

            //待機時間を設定し、残りはUpdateに任せる。
            wait = w;
        }

        //破壊時に起こる衝撃の処理
        private void Impact()
        {
            //サイズ番号を基に爆発力を取得する。
            float power = Power[sizeIndex];

            //0以下なら発生させない。
            if (power <= 0)
            {
                return;
            }

            //サイズ番号を基に爆発の半径を取得する。
            float radius = Radius[sizeIndex];

            //・自身を中心に
            //・上記の半径内の
            //
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, new Vector2());

            foreach (RaycastHit2D hit in hits)
            {
                Vector2 diff = hit.point - (Vector2)transform.position;
                Rigidbody2D rigid = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                if (rigid == null)
                {
                    continue;
                }
                Vector2 force = diff.normalized;
                force *= power;
                rigid.AddForce(force);
            }
        }
    }
}
