Shader "Unlit/Infinite-plane-gradient"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_ColorCenter("Center Color", color) = (1,1,1,1)
		_ColorFar("Far Color", color) = (1,1,1,1)
		_DistMax("Distance fin gradient", int) = 10
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 100

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "unitycg.cginc"

				struct appdata
				{
					float4 vertex : position;
					float2 uv : texcoord0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 vertex : SV_POSITION;
					float4 pos : POSITION1;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;
				float4 _ColorCenter;
				float4 _ColorFar;
				int _DistMax;

				v2f vert(appdata v)
				{
					v2f o;
					o.pos = v.vertex;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					float dist = distance(i.pos, float3(0,0,0));
					if (dist > _DistMax || dist < 0) {
						dist = 1;
					}
					else {
						dist = dist / _DistMax;
					}

					//fixed4 col = tex2D(_MainTex, i.uv);
					//col = col * (_ColorCenter + _ColorFar * (dist / _DistMax));
					fixed4 col = ( _ColorCenter * (1-dist) + dist * lerp( _ColorFar, tex2D(_MainTex, i.uv), 0.7 ) );

					return col;
				}
				ENDCG
			}
		}
}
