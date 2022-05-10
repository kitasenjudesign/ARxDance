Shader "Unlit/DepthVisualizer"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        cull off

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

            v2f vert (appdata v)
            {
                v2f o;


                float2 uvv = v.uv;
                uvv.x = uvv.x*0.5+0.5;


                //half depth = SAMPLE_DEPTH_TEXTURE(_MainTex, uvv.xy);
                //depth = Linear01Depth(depth);


                float depth = tex2Dlod(_MainTex, float4(uvv.xy,0,0)).r;
                depth = 1 - depth;
                
                v.vertex.z += depth;


                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                //UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv*float2(0.5,1));

                

                // apply fog
                //UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
