Shader "Custom/LucKeeShader"
{
    Properties
    {
        //�l��ύX���鎞�́AMaterial�̕ϐ��ɑ΂���SetFloat�Ȃǂ�p���Đݒ肷��B
        //�����ł͕ϐ���(String)�Ɛݒ肵�����l��n���B
        //���̏ꍇ�̕ϐ����͓��ɃA���_�[�X�R�A��t���Ă��镔�����w���B
        //Material�^�ϐ�material�ɑ΂��ĉ�]�̕␳��0�ɂ��鏈�����s���ꍇ�A���L�̂悤�ɂȂ�B
        //material.SetFloat("_Rotation", 0.0f);

        //���Z���邽�߂̉摜
        //�S�̓I�ɓ����F�����Z����̂Ŕ����n�̉摜��ݒ肷��B
        _MainTex ("Main Texture", 2D) = "white" {}

        //���̋��
        //���̐����`�̒P�̂́A�S�̂�1�Ƃ������̑傫����ݒ肷��B
        //0�ɂ����Unity���N���b�V������̂Ő������Ă���B
        _ShineDivision("Shine Division", Range(0.01, 1)) = 0.1

        //��]�̉��Z�l
        //���̒l�����W�A���p�Ƃ��ĉ��Z���A���̋������v�Z����B
        _Rotation("Rotation(Radian)", float) = 0

        //���̎n�_�̐F
        //�p�x���i�ނɂ�Ďキ�Ȃ��Ă����B
        _StartColor ("Start Color", Color) = (1, 0, 0, 1)

        //���̏I�_�̐F
        //�p�x���i�ނɂ�ċ����Ȃ��Ă����B
        _EndColor ("End Color", Color) = (0, 0, 0, 0)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float _ShineDivision;

            float _Rotation;
            float4 _StartColor;
            float4 _EndColor;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //���p����̂ŏ����₷���悤�ɕϐ���
                float halfPi = 1.57;
                float2 uv = i.uv;

                // ���C���e�N�X�`��
                fixed4 col = tex2D(_MainTex, uv);
                //�����ł̈ʒu�̌v�Z
                while(uv.x > _ShineDivision) uv.x -= _ShineDivision;
                while(uv.y > _ShineDivision) uv.y -= _ShineDivision;


                //�����ł̊p�x�̌v�Z
                float angle = atan2(uv.y - _ShineDivision * 0.5, uv.x - _ShineDivision * 0.5);

                //�p�x�̕␳
                angle += _Rotation;

                //�p�x�̃��[�v�̌v�Z
                while(angle > halfPi * 2) angle -= halfPi * 4;
                while(angle < -halfPi * 2) angle += halfPi * 4;

                //���̗L���̔���
                //���̌v�Z���I������Aangle�ɂ͌��̎n�_����̊p�x�������Ă���B
                if(angle < 0) angle += halfPi * 2;
                angle -= halfPi;
                //���̎��_�Ń}�C�i�X�ɂȂ����ꍇ�͉������Ȃ��B
                if(angle < 0) return col;

                //���̎n�_����I�_�܂ł̒��Ŏ��g���ǂ�قǎn�_�ɋ߂����̊���
                float ratio = angle / halfPi;
                //�n�_����߂��قǎn�_�̐F�ɋ߂Â���B
                col += _StartColor * ratio;
                //�I�_����߂��قǏI�_�̐F�ɋ߂Â���B
                col += _EndColor * (1.0 - ratio);

                //�v�Z���ʂ�Ԃ��B
                return col;
            }
            ENDCG
        }
    }
}