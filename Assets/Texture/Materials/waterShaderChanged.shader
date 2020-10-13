// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Water Wave" {
	Properties {
		_Color ("Main Color", Color) = (0, 0.15, 0.115, 1)
		_SkyColor ("Sky Color", Color) = (0, 0.15, 0.115, 1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_WaveMap ("Wave Map", 2D) = "bump" {}
		_WaveEdge("Wave Edge",2D)="black"{}
		_Cubemap ("Environment Cubemap", Cube) = "_Skybox" {}
		_WaveXSpeed ("Wave Horizontal Speed", Range(-0.1, 0.1)) = 0.01
		_WaveYSpeed ("Wave Vertical Speed", Range(-0.1, 0.1)) = 0.01
		_Distortion ("Distortion", Range(0, 100)) = 10

		//_EdgeWidth("Edge Width",Range(0,1) ) = 0.1
		_FoamWidth("Foam Width",Range(0,1) ) = 0.1

		_fresnelWidth("Fresnel Width",Range(0,1))=1
	}
	SubShader {
		// We must be transparent, so other objects are drawn before this one.
		Tags { "Queue"="Transparent" "RenderType"="Transparent" }
		
		// This pass grabs the screen behind the object into a texture.
		// We can access the result in the next pass as _RefractionTex
		GrabPass { "_RefractionTex" }
		
		Pass {
			Tags { "LightMode"="ForwardBase" }
			
			CGPROGRAM
			
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			
			#pragma multi_compile_fwdbase
			
			#pragma vertex vert
			#pragma fragment frag
			
			fixed4 _Color;
			fixed4 _SkyColor;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _WaveMap;
			float4 _WaveMap_ST;
			samplerCUBE _Cubemap;
			fixed _WaveXSpeed;
			fixed _WaveYSpeed;
			float _Distortion;	
			sampler2D _RefractionTex;
			float4 _RefractionTex_TexelSize;
			
			sampler2D _WaveEdge;
			float4 _WaveEdge_ST;

			fixed _fresnelWidth;
			//fixed _EdgeWidth;
			fixed _FoamWidth;

			uniform sampler2D_float _CameraDepthTexture;


			struct a2v {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT; 
				float4 texcoord : TEXCOORD0;
			};
			
			struct v2f {
				float4 pos : SV_POSITION;
				float4 scrPos : TEXCOORD0;
				float4 uv : TEXCOORD1;
				float4 TtoW0 : TEXCOORD2;  
				float4 TtoW1 : TEXCOORD3;  
				float4 TtoW2 : TEXCOORD4;
				
				float3 normal:NORMAL;
				float4 screenuv:TEXCOORD5;//
                float depth:TEXCOORD6;
				
			};

			fixed3 getSkyColor(fixed3 co)
			{
			
			return co;
			}
			fixed3 getSeaColor(fixed3 skyCo)
			{
			
			return skyCo;
			}

			v2f vert(a2v v) {
				v2f o;

				COMPUTE_EYEDEPTH(o.depth);////

				o.pos = UnityObjectToClipPos(v.vertex);
				
				o.scrPos = ComputeGrabScreenPos(o.pos);
				
				o.uv.xy = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.uv.zw = TRANSFORM_TEX(v.texcoord, _WaveMap);
				
				float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;  
				fixed3 worldNormal = UnityObjectToWorldNormal(v.normal);  
				fixed3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);  
				fixed3 worldBinormal = cross(worldNormal, worldTangent) * v.tangent.w; 
				
				o.TtoW0 = float4(worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x);  
				o.TtoW1 = float4(worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y);  
				o.TtoW2 = float4(worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z);  
			
				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target {
				
				float ScreenZ = LinearEyeDepth( SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.scrPos))  );
                float diff=saturate(abs(i.depth-ScreenZ)*0.25);
				float foamWidth= clamp(1-(abs(i.depth-ScreenZ)*0.5),0,1);
				//fixed d = clamp(1.0 - (abs(i.depth - ScreenZ)*0.5),0,1);

				float3 worldPos = float3(i.TtoW0.w, i.TtoW1.w, i.TtoW2.w);
				fixed3 viewDir = normalize(UnityWorldSpaceViewDir(worldPos));
				float2 speed = _Time.y * float2(_WaveXSpeed, _WaveYSpeed);
				//float3 normal = float3(i.TtoW0.z,i.TtoW1.z,i.TtoW2.z);
				// Get the normal in tangent space
				fixed3 bump1 = UnpackNormal(tex2D(_WaveMap, i.uv.zw + speed)).rgb;
				fixed3 bump2 = UnpackNormal(tex2D(_WaveMap, i.uv.zw - speed)).rgb;
				fixed3 bump = normalize(bump1 + bump2);
				
				fixed mask = dot(i.normal,float3(0,-1,0))+0.5;
				// mask = mask>0.2?0:1;


				// Compute the offset in tangent space
				float2 offset = bump.xy * _Distortion * _RefractionTex_TexelSize.xy;
				i.scrPos.xy = offset * i.scrPos.z + i.scrPos.xy;
				fixed3 refrCol = tex2D( _RefractionTex, i.scrPos.xy/i.scrPos.w).rgb;
				
				// Convert the normal to world space
				bump = normalize(half3(dot(i.TtoW0.xyz, bump), dot(i.TtoW1.xyz, bump), dot(i.TtoW2.xyz, bump)));
				
			
				//fixed3 finalColor = reflCol * fresnel + refrCol * (1 - fresnel);
				float3 color_ = lerp(
					getSeaColor(_Color),
			        getSkyColor(_SkyColor),
			    	diff
					);

	
			fixed s=1;
				fixed4 texColor = tex2D(_MainTex, i.uv.xy + speed); 

				texColor=saturate(smoothstep(_FoamWidth,1,texColor));

				fixed3 reflDir = reflect(-viewDir, bump);
				fixed3 reflCol = texCUBE(_Cubemap, reflDir).rgb * color_.rgb+ texColor.rgb ;
				
				//fixed4 edgeCol = mask>0?lerp(_EdgeWidth, _Color, diff):_Color;

				//float3 finalColor=saturate(float3(diff,diff,diff));
				
				fixed2 waveUV =i.uv.xy/_WaveEdge_ST.xy ;
          
                fixed4 waveCol = tex2D(_WaveEdge,waveUV+float2(0.5+sin(_Time.x), foamWidth*0.5-_Time.x*s )).r;
                       waveCol *= tex2D(_WaveEdge,waveUV +float2(0.5-sin(_Time.x), foamWidth*0.5-_Time.x*s )).r;

                      waveCol *=foamWidth*0.8;

				fixed fresnel = pow(1 - saturate(dot(viewDir, bump)),(_fresnelWidth*10))+saturate(pow(texColor,2));
				fresnel*=diff;
				float3 diffuse=diff*_Color+refrCol*(1-diff);
				fixed3 finalColor=(reflCol)*fresnel+diffuse*(1-fresnel)+waveCol*(diff+0.5);

				//finalColor=float3(foamWidth,foamWidth,foamWidth);

				return fixed4(finalColor, 1);
			//return waveCol;
			}
			
			ENDCG
		}
	}
	// Do not cast shadow
	FallBack Off
}