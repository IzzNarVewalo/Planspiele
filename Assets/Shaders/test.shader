Shader "Custom/test"
{
	Properties
	{
		_MainTex("Texture", 2D) = "bump" {}
		//_MyColor("Color", Color) = (0.7, 0.3, 0, 1)
		//_MyFloat("Bound", Float) = 0.3


	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
		Tags{ "LightMode" = "ForwardBase" }
		LOD 200

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog

			#pragma multi_compile_fwdbase

			#include "UnityCG.cginc"
			#include "AutoLight.cginc"
		


			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float3 uv : TEXCOORD0;
			};

			struct v2f
			{
				float3 uv : TEXCOORD0;
				float3 uv2 : TEXCOORD1;
				UNITY_FOG_COORDS(1)
				float4 pos : SV_POSITION;
				LIGHTING_COORDS(2, 3)
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed4 _MyColor;
			uniform float _MyFloat;


			v2f vert(appdata v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				//o.vertex = v.vertex;
				o.uv = v.uv;
				o.uv2 = v.vertex;
				TRANSFER_VERTEX_TO_FRAGMENT(o);

				UNITY_TRANSFER_FOG(o, o.vertex);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				if (i.uv2.y + 0.4999999 < _MyFloat)
					col = _MyColor;
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				float attenuation = LIGHT_ATTENUATION(i);
				col *= attenuation;
				return col;
		}
		ENDCG
	}
	}
		Fallback "VertexLit"
}

