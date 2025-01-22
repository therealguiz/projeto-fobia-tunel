Shader "Custom/UnlitTransparent"
{
    Properties
    {
        _Color ("Color", Color) = (0, 0, 0, 0) // Cor padr�o: preto e totalmente transparente
        _MainTex ("Texture", 2D) = "white" {} // Textura opcional
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha // Habilita transpar�ncia
            ZWrite Off // N�o escreve na profundidade para evitar ocultar objetos
            Cull Off // Permite que o Quad seja visto de ambos os lados

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _Color;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;
                return col;
            }
            ENDCG
        }
    }
}
