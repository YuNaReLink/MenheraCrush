Shader "Custom/PrismGlowShader"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _GlowIntensity ("Glow Intensity", Range(0, 1)) = 0.8
        _PatternScale ("Pattern Scale", Range(0.1, 10.0)) = 5.0
        _Speed ("Animation Speed", Range(0.1, 5.0)) = 1.0

        _LightOffset("LightOffset",float) = 0
        _SmoothstepTime("SmoothstepTime",float) = 0
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
            float _GlowIntensity;
            float _PatternScale;
            float _Speed;

            float _LightOffset;

            float _SmoothstepTime;

            float fractAlt(float x) 
            {

                return x - floor(x);
            }

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
                // メインテクスチャ
                fixed4 col = tex2D(_MainTex, i.uv);

                // プリズム効果を白一色に設定
                float3 prismColors = float3(1.0, 1.0, 1.0);

                // 時間による変化のためのオフセットを sin を使って波のように変化させる
                float offset = _LightOffset * _PatternScale;
                
                _SmoothstepTime = sin((i.uv.x + i.uv.y) * _PatternScale + offset) * 0.5 + 0.5;

                // 斜め方向に輝きを適用（UV座標のxとyを加算して斜め方向に）
                float glow = smoothstep(0.2, 1.0, _SmoothstepTime) * _GlowIntensity;
                col.rgb = lerp(col.rgb, col.rgb + (prismColors * glow), _GlowIntensity); // 輝きを調整

                return col;
            }
            ENDCG
        }
    }
}
