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

                // プリズム効果を模倣するための色分解
                float3 prismColors = float3(0, 0, 0);
                float offset = _Time.y * _Speed;

                // 色を生成
                prismColors.r = sin(i.uv.x * _PatternScale + offset) * 0.5 + 0.5; // 赤
                prismColors.g = sin(i.uv.x * _PatternScale + offset + 1.0) * 0.5 + 0.5; // 緑
                prismColors.b = sin(i.uv.x * _PatternScale + offset + 2.0) * 0.5 + 0.5; // 青

                // 輝きを適用
                float glow = smoothstep(0.2, 1.0, prismColors.r + prismColors.g + prismColors.b) * _GlowIntensity;
                col.rgb += (prismColors * glow);

                return col;
            }
            ENDCG
        }
    }
}