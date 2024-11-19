using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //�l�̕ύX�ʒm���󂯎��C���^�[�t�F�[�X
    public interface IChangeWaiter
    {
        //�ύX���̃��\�b�h
        //�����Ƃ��āA�ύX�ɂ��O��̍��ƕύX��̒l��n���Ďg���B
        public void OnChanged(float moved, float current);
    }

    //�^�C�}�[�̏I���ʒm���󂯎��C���^�[�t�F�[�X
    public interface IFinishWaiter
    {
        //�I�����̃��\�b�h
        public void OnFinished();
    }

    //�l�����X�ɕύX���钊�ۃN���X
    //���x�ƏI�_�𒊏ۉ����Ă��邽�߁A�������K�v�ƂȂ�B
    public abstract class GradualValueHolder
    {
        //�ύX�ʒm���󂯎�郊�X�i�[�̃��X�g
        private List<IChangeWaiter> changed = new();

        //�I���ʒm���󂯎�郊�X�i�[�̃��X�g
        private List<IFinishWaiter> finished = new();

        //�ύX�ʒm�̃��X�i�[�̒ǉ�
        public void AddListener(IChangeWaiter c) { changed.Add(c); }

        //�I���ʒm�̃��X�i�[�̒ǉ�
        public void AddListener(IFinishWaiter f) { finished.Add(f); }

        //���݂̒l
        public float Current { get; protected set; }

        //�I�_�̒l
        public abstract float Goal { get; set; }

        //���x�̒l
        //���̒l��ݒ肷��ƕs����N���邽�߁A0�ȏ�̒l��ݒ肷�邱�ƁB
        public abstract float Speed { get; set; }

        //�I�_�ɒH�蒅���Ă��邩�ǂ����̔���
        public bool IsFinished() { return Current == Goal; }

        //�o�ߎ��Ԃ��󂯎���Ēl��i�߂�B
        public void Update(float delta)
        {
            //���ɏI����Ă���Ȃ牽�����Ȃ��B
            if (IsFinished())
            {
                return;
            }

            //�I�_�܂ł̍�
            float diff = Goal - Current;

            //����̏����œ�������ő�l
            float move = Speed * delta;
            
            //����ŒH�蒅����Ȃ�I��点��B
            if (Mathf.Abs(diff) <= move)
            {
                Current = Goal;
                InvokeChange(diff);
                InvokeFinish();
                return;
            }

            //�������Ȃ�ړ��ʂ����]����B
            if (diff < 0)
            {
                move *= -1;
            }

            //���݂̒l���X�V���A�ύX��ʒm����B
            Current += move;
            InvokeChange(diff);
        }

        //�ύX�̈ꊇ�ʒm
        private void InvokeChange(float moved)
        {
            foreach (IChangeWaiter c in changed)
            {
                c.OnChanged(moved, Current);
            }
        }

        //�I���̈ꊇ�ʒm
        private void InvokeFinish()
        {
            foreach (IFinishWaiter f in finished)
            {
                f.OnFinished();
            }
        }
    }
}