Shader "Custom/GaugeShader"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _Color1("Color1", Color) = (0, 1, 0, 1)
        _ColorBorder("Color Border", Range(0, 1)) = 0.8
        _Color2("Color2", Color) = (0, 0, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _Color1;
            float _ColorBorder;
            float4 _Color2;

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
                float4 mask = _Color1;
                if(i.uv.y > _ColorBorder) mask = _Color2;
                col.a *= mask.a;
                col.r *= mask.r;
                col.g *= mask.g;
                col.b *= mask.b;


                return col;
            }
            ENDCG
        }
    }
}