using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //値の変更通知を受け取るインターフェース
    public interface IChangeWaiter
    {
        //変更時のメソッド
        //引数として、変更による前後の差と変更後の値を渡して使う。
        public void OnChanged(float moved, float current);
    }

    //タイマーの終了通知を受け取るインターフェース
    public interface IFinishWaiter
    {
        //終了時のメソッド
        public void OnFinished();
    }

    //値を徐々に変更する抽象クラス
    //速度と終点を抽象化しているため、実装が必要となる。
    public abstract class GradualValueHolder
    {
        //変更通知を受け取るリスナーのリスト
        private List<IChangeWaiter> changed = new();

        //終了通知を受け取るリスナーのリスト
        private List<IFinishWaiter> finished = new();

        //変更通知のリスナーの追加
        public void AddListener(IChangeWaiter c) { changed.Add(c); }

        //終了通知のリスナーの追加
        public void AddListener(IFinishWaiter f) { finished.Add(f); }

        //現在の値
        public float Current { get; protected set; }

        //終点の値
        public abstract float Goal { get; set; }

        //速度の値
        //負の値を設定すると不具合が起こるため、0以上の値を設定すること。
        public abstract float Speed { get; set; }

        //終点に辿り着いているかどうかの判定
        public bool IsFinished() { return Current == Goal; }

        //経過時間を受け取って値を進める。
        public void Update(float delta)
        {
            //既に終わっているなら何もしない。
            if (IsFinished())
            {
                return;
            }

            //終点までの差
            float diff = Goal - Current;

            //今回の処理で動かせる最大値
            float move = Speed * delta;
            
            //今回で辿り着けるなら終わらせる。
            if (Mathf.Abs(diff) <= move)
            {
                Current = Goal;
                InvokeChange(diff);
                InvokeFinish();
                return;
            }

            //差が負なら移動量も反転する。
            if (diff < 0)
            {
                move *= -1;
            }

            //現在の値を更新し、変更を通知する。
            Current += move;
            InvokeChange(diff);
        }

        //変更の一括通知
        private void InvokeChange(float moved)
        {
            foreach (IChangeWaiter c in changed)
            {
                c.OnChanged(moved, Current);
            }
        }

        //終了の一括通知
        private void InvokeFinish()
        {
            foreach (IFinishWaiter f in finished)
            {
                f.OnFinished();
            }
        }
    }
}