Shader "Custom/LucKeeShader"
{
    Properties
    {
        //値を変更する時は、Materialの変数に対してSetFloatなどを用いて設定する。
        //引数では変数名(String)と設定したい値を渡す。
        //この場合の変数名は頭にアンダースコアを付けている部分を指す。
        //Material型変数materialに対して回転の補正を0にする処理を行う場合、下記のようになる。
        //material.SetFloat("_Rotation", 0.0f);

        //加算するための画像
        //全体的に同じ色を加算するので白無地の画像を設定する。
        _MainTex ("Main Texture", 2D) = "white" {}

        //光の区画
        //光の正方形の単体の、全体を1とした時の大きさを設定する。
        //0にするとUnityがクラッシュするので制限している。
        _ShineDivision("Shine Division", Range(0.01, 1)) = 0.1

        //回転の加算値
        //この値をラジアン角として加算し、光の強さを計算する。
        _Rotation("Rotation(Radian)", float) = 0

        //光の始点の色
        //角度が進むにつれて弱くなっていく。
        _StartColor ("Start Color", Color) = (1, 0, 0, 1)

        //光の終点の色
        //角度が進むにつれて強くなっていく。
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
                //多用するので書きやすいように変数化
                float halfPi = 1.57;
                float2 uv = i.uv;

                // メインテクスチャ
                fixed4 col = tex2D(_MainTex, uv);
                //区画内での位置の計算
                while(uv.x > _ShineDivision) uv.x -= _ShineDivision;
                while(uv.y > _ShineDivision) uv.y -= _ShineDivision;


                //区画内での角度の計算
                float angle = atan2(uv.y - _ShineDivision * 0.5, uv.x - _ShineDivision * 0.5);

                //角度の補正
                angle += _Rotation;

                //角度のループの計算
                while(angle > halfPi * 2) angle -= halfPi * 4;
                while(angle < -halfPi * 2) angle += halfPi * 4;

                //光の有無の判定
                //この計算を終えた後、angleには光の始点からの角度が入っている。
                if(angle < 0) angle += halfPi * 2;
                angle -= halfPi;
                //この時点でマイナスになった場合は何もしない。
                if(angle < 0) return col;

                //光の始点から終点までの中で自身がどれほど始点に近いかの割合
                float ratio = angle / halfPi;
                //始点から近いほど始点の色に近づける。
                col += _StartColor * ratio;
                //終点から近いほど終点の色に近づける。
                col += _EndColor * (1.0 - ratio);

                //計算結果を返す。
                return col;
            }
            ENDCG
        }
    }
}