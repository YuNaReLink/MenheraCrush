Shader "Custom/PrismGlowShader"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _GlowIntensity ("Glow Intensity", Range(0, 1)) = 0.8
        _PatternScale ("Pattern Scale", Range(0.1, 10.0)) = 5.0
        _Speed ("Animation Speed", Range(0.1, 5.0)) = 1.0
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
                float offset = sin(_Time.y * _Speed) * _PatternScale;

                // 輝きを適用 (白色の輝きが波の動きに従って変化する)
                float glow = smoothstep(0.2, 1.0, sin(i.uv.x * _PatternScale + offset) * 0.5 + 0.5) * _GlowIntensity;
                col.rgb = lerp(col.rgb, col.rgb + (prismColors * glow), _GlowIntensity); // 輝きを調整

                return col;
            }
            ENDCG
        }
    }
}
