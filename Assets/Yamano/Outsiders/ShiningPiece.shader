Shader "Custom/ShiningPieceShader"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}

        _ShineDivision ("Shine Division", Range(0.01, 1)) = 0.1

        _Rotation("Rotation(Radian)", float) = 0

        _StartColor ("Start Color", Color) = (1, 0, 0, 0)

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
                float halfPi = 1.57;
                float2 uv = i.uv;

                fixed4 col = tex2D(_MainTex, uv);

                while(uv.x > _ShineDivision) uv.x -= _ShineDivision;
                while(uv.y > _ShineDivision) uv.y -= _ShineDivision;


                float angle = atan2(uv.y - _ShineDivision * 0.5, uv.x - _ShineDivision * 0.5);

                angle += _Rotation;

                while(angle > halfPi * 2) angle -= halfPi * 4;
                while(angle < -halfPi * 2) angle += halfPi * 4;

                if(angle < 0) angle += halfPi * 2;
                angle -= halfPi;

                if(angle < 0) return col;

                float ratio = angle / halfPi;

                col += _StartColor * ratio;

                col += _EndColor * (1.0 - ratio);

                return col;
            }
            ENDCG
        }
    }
}
