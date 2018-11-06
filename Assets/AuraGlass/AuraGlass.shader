// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Aura Glass" {

	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_SColor ("Secondary Color", Color) = (1,0,0,1)
		_Rim ("Rim", Float) = 1.0
		_Thr ("Threshold", Range(0.0, 1.0)) = 0.3
	}

	SubShader {
		Tags { "Queue" = "Transparent" }
		
		Pass {
			ZWrite Off 
			Blend SrcAlpha OneMinusSrcAlpha 
			Cull Back
			CGPROGRAM

			#pragma vertex vert 
			#pragma fragment frag
			#include "UnityCG.cginc" 

			uniform float4 _Color;
			uniform float _Rim;
			uniform float4 _SColor;
			uniform float _Thr;

			struct vertexInput{
				float4 vertex : POSITION;
				float3 normal: NORMAL;
			};

			struct vertexOutput{
				float4 pos : SV_POSITION;
				float3 normal : TEXCOORD0;
				float3 viewDir: TEXCOORD1;
			};

			vertexOutput vert(vertexInput input){ 
				vertexOutput output;
				output.pos = UnityObjectToClipPos(input.vertex);
				output.normal = normalize(mul(float4(input.normal,0.0), unity_WorldToObject).xyz);
				output.viewDir = normalize(_WorldSpaceCameraPos - mul(unity_ObjectToWorld, input.vertex).xyz);

				return output;
			}

			float4 frag(vertexOutput input) : COLOR { 

				float3 viewDir = normalize(input.viewDir);
				float3 norm = normalize(input.normal);
				float newOpacity = min(1.0, _Color.a / abs((pow(dot(viewDir, norm), _Rim)) - (0.3 - _Color.a )));
				if (newOpacity > _Thr){ 
					float3 variationColor = _Color.xyz + newOpacity * _SColor.xyz;
					return float4(variationColor, newOpacity);

				}else{ 
					float3 variationColor = _Color.xyz;
					return float4(variationColor, newOpacity);
				}
			}
						
			ENDCG
		}
		
		Pass {
			ZWrite Off 
			Blend SrcAlpha OneMinusSrcAlpha
			Cull Front
			CGPROGRAM

			#pragma vertex vert 
			#pragma fragment frag
			#include "UnityCG.cginc" 

			uniform float4 _Color;
			uniform float _Rim;
			uniform float4 _SColor;
			uniform float _Thr;

			struct vertexInput{
				float4 vertex : POSITION;
				float3 normal: NORMAL;
			};

			struct vertexOutput{
				float4 pos : SV_POSITION;
				float3 normal : TEXCOORD0;
				float3 viewDir: TEXCOORD1;
			};

			vertexOutput vert(vertexInput input){ 
				vertexOutput output;
				output.pos = UnityObjectToClipPos(input.vertex);
				output.normal = normalize(mul(float4(input.normal,0.0), unity_WorldToObject).xyz);
				output.viewDir = normalize(_WorldSpaceCameraPos - mul(unity_ObjectToWorld, input.vertex).xyz);

				return output;
			}

			float4 frag(vertexOutput input) : COLOR{

				float3 viewDir = normalize(input.viewDir);
				float3 norm = normalize(input.normal);
				return float4(_SColor.rgb, _SColor.a - abs(dot(viewDir, norm)));
			}
	
			ENDCG
		}
	}
}