Shader "Custom/Outline" {
    Properties {
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _Outline ("Outline Width", Range (0.0001, 0.01)) = 0.005
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
        fixed4 _OutlineColor;
        float _Outline;

        void surf (Input IN, inout SurfaceOutput o) {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;

            // Creates the outline by sampling the texture
            // at nearby pixels with a higher offset
            fixed4 outline = tex2D(_MainTex, IN.uv_MainTex + float2(_Outline, _Outline))
                            + tex2D(_MainTex, IN.uv_MainTex + float2(-_Outline, _Outline))
                            + tex2D(_MainTex, IN.uv_MainTex + float2(_Outline, -_Outline))
                            + tex2D(_MainTex, IN.uv_MainTex + float2(-_Outline, -_Outline));

            // If any of the nearby pixels are different from the center pixel
            // it means it's an outline
            if (outline.r != c.r || outline.g != c.g || outline.b != c.b) {
                o.Albedo = _OutlineColor.rgb;
                o.Alpha = _OutlineColor.a;
            }
        }
        ENDCG
    }
    FallBack "Diffuse"
}
