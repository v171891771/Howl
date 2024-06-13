Shader "Hidden/Custom/EdgeDetection"
{
    Properties
    {
        _EdgeColor ("Edge Color", Color) = (0,0,0,1)
        _BackgroundColor ("Background Color", Color) = (1,1,1,1)
        _Threshold ("Threshold", Range(0.1, 1.0)) = 0.2
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float4 _EdgeColor;
            float4 _BackgroundColor;
            float _Threshold;

            fixed4 frag(v2f_img i) : SV_Target
            {
                float3 dx = float3(_MainTex_TexelSize.x, 0.0, 0.0);
                float3 dy = float3(0.0, _MainTex_TexelSize.y, 0.0);

                float3 c = tex2D(_MainTex, i.uv).rgb;
                float3 cx = tex2D(_MainTex, i.uv + dx).rgb;
                float3 cy = tex2D(_MainTex, i.uv + dy).rgb;

                float3 edge = step(_Threshold, abs(c - cx) + abs(c - cy));
                float edgeDetected = max(edge.r, max(edge.g, edge.b));

                return lerp(_BackgroundColor, _EdgeColor, edgeDetected);
            }
            ENDCG
        }
    }
}
