// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33087,y:32621,varname:node_4795,prsc:2|normal-7426-OUT,alpha-1549-OUT,refract-3943-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:31501,y:33314,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:31501,y:33472,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:832,x:31012,y:32414,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_832,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4266-UVOUT;n:type:ShaderForge.SFN_Rotator,id:4266,x:30817,y:32414,varname:node_4266,prsc:2|UVIN-2964-UVOUT,SPD-2815-OUT;n:type:ShaderForge.SFN_TexCoord,id:2964,x:30502,y:32371,varname:node_2964,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:6689,x:30817,y:32647,ptovrint:False,ptlb:Normal Intensity,ptin:_NormalIntensity,varname:node_6689,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5817057,max:2;n:type:ShaderForge.SFN_Vector3,id:7167,x:31012,y:32245,varname:node_7167,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Lerp,id:4478,x:31293,y:32409,varname:node_4478,prsc:2|A-7167-OUT,B-832-RGB,T-6689-OUT;n:type:ShaderForge.SFN_ComponentMask,id:648,x:31243,y:32567,varname:node_648,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-832-RGB;n:type:ShaderForge.SFN_Multiply,id:1612,x:31491,y:32642,varname:node_1612,prsc:2|A-648-OUT,B-5359-OUT;n:type:ShaderForge.SFN_Slider,id:4748,x:30839,y:32900,ptovrint:False,ptlb:Distorsion,ptin:_Distorsion,varname:node_4748,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Tex2d,id:7929,x:31138,y:32991,ptovrint:False,ptlb:AlphaMask,ptin:_AlphaMask,varname:node_7929,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:5487,x:31456,y:33097,varname:node_5487,prsc:2|A-7929-R,B-6738-OUT;n:type:ShaderForge.SFN_Vector1,id:6738,x:31138,y:33204,varname:node_6738,prsc:2,v1:0;n:type:ShaderForge.SFN_ComponentMask,id:4172,x:31456,y:32900,varname:node_4172,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-7929-R;n:type:ShaderForge.SFN_Multiply,id:8109,x:31761,y:33414,varname:node_8109,prsc:2|A-2053-A,B-797-A;n:type:ShaderForge.SFN_Multiply,id:432,x:31729,y:32815,varname:node_432,prsc:2|A-1612-OUT,B-4172-OUT;n:type:ShaderForge.SFN_Multiply,id:5877,x:31976,y:33112,varname:node_5877,prsc:2|A-432-OUT,B-8109-OUT;n:type:ShaderForge.SFN_Multiply,id:5359,x:31210,y:32719,varname:node_5359,prsc:2|A-6689-OUT,B-4748-OUT;n:type:ShaderForge.SFN_Set,id:6105,x:31640,y:33144,varname:Op,prsc:2|IN-5487-OUT;n:type:ShaderForge.SFN_Set,id:3469,x:32151,y:33173,varname:Ref,prsc:2|IN-5877-OUT;n:type:ShaderForge.SFN_Set,id:1628,x:31470,y:32445,varname:Norm,prsc:2|IN-4478-OUT;n:type:ShaderForge.SFN_Get,id:7426,x:32708,y:32699,varname:node_7426,prsc:2|IN-1628-OUT;n:type:ShaderForge.SFN_Get,id:1549,x:32695,y:32862,varname:node_1549,prsc:2|IN-6105-OUT;n:type:ShaderForge.SFN_Get,id:3943,x:32695,y:32919,varname:node_3943,prsc:2|IN-3469-OUT;n:type:ShaderForge.SFN_Vector1,id:2815,x:30626,y:32504,varname:node_2815,prsc:2,v1:0;proporder:797-832-7929-4748-6689;pass:END;sub:END;*/

Shader "Wao3DStudio/FX/Distortion" {
    Properties {
        _TintColor ("Color", Color) = (1,1,1,1)
        _Normal ("Normal", 2D) = "white" {}
        _AlphaMask ("AlphaMask", 2D) = "white" {}
        _Distorsion ("Distorsion", Range(0, 1)) = 0.5
        _NormalIntensity ("Normal Intensity", Range(0, 2)) = 0.5817057
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform float4 _TintColor;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _NormalIntensity;
            uniform float _Distorsion;
            uniform sampler2D _AlphaMask; uniform float4 _AlphaMask_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float3 tangentDir : TEXCOORD2;
                float3 bitangentDir : TEXCOORD3;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD4;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float4 node_4942 = _Time;
                float node_4266_ang = node_4942.g;
                float node_4266_spd = 0.0;
                float node_4266_cos = cos(node_4266_spd*node_4266_ang);
                float node_4266_sin = sin(node_4266_spd*node_4266_ang);
                float2 node_4266_piv = float2(0.5,0.5);
                float2 node_4266 = (mul(i.uv0-node_4266_piv,float2x2( node_4266_cos, -node_4266_sin, node_4266_sin, node_4266_cos))+node_4266_piv);
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(node_4266, _Normal));
                float3 Norm = lerp(float3(0,0,1),_Normal_var.rgb,_NormalIntensity);
                float3 normalLocal = Norm;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _AlphaMask_var = tex2D(_AlphaMask,TRANSFORM_TEX(i.uv0, _AlphaMask));
                float2 Ref = (((_Normal_var.rgb.rg*(_NormalIntensity*_Distorsion))*_AlphaMask_var.r.r)*(i.vertexColor.a*_TintColor.a));
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + Ref;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
                float3 finalColor = 0;
                float Op = (_AlphaMask_var.r*0.0);
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,Op),1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
