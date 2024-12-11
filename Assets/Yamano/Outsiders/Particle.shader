Shader "LucKee/Particle"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _SubTex ("Sub Texture", 2D) = "white" {}
        _DivideV("Vertical Division", int) = 1
    }
    SubShader
    {
    Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" "PreviewType"="Plane" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            sampler2D _SubTex;
            int _DivideV;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

                v2f j = i;
                j.uv.y /= _DivideV;

                if(col.a > 0) col.rgb = tex2D(_SubTex, j.uv).rgb;

                return col;
            }
            ENDCG
        }
    }
}
