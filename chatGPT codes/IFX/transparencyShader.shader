Shader "Custom/Transparent" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _MaxDistance ("Max Distance", Float) = 10
    }

    SubShader {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        struct Input {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;
        fixed4 _Color;
        float _MaxDistance;

        void surf (Input IN, inout SurfaceOutput o) {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a * (1 - saturate(length(IN.worldPos - cameraPos) / _MaxDistance));
        }
        ENDCG
    }
    FallBack "Diffuse"
}
