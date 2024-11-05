Shader "Custom/SpriteGlow"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _EmissionColor ("Emission Color", Color) = (0,0,0,0) // �����F
    }

    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        Lighting Off
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _Color;
            float4 _EmissionColor;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // �e�N�X�`���J���[��Color����Z
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;
                
                // �����F��ǉ��i�����F�̃A���t�@�����x�Ƃ��Ďg�p�j
                col.rgb += _EmissionColor.rgb * _EmissionColor.a;
                
                return col;
            }
            ENDCG
        }
    }
}
