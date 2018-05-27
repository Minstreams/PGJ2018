// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33928,y:32924,varname:node_9361,prsc:2|custl-6090-OUT;n:type:ShaderForge.SFN_Tex2d,id:427,x:33091,y:33362,ptovrint:False,ptlb:Tex0,ptin:_Tex0,varname:node_427,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:14ee94473049b5f4081b10f1bd67be00,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6971,x:32561,y:33099,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_6971,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a17b55346d7f9c849aaa9f4ec70195ab,ntxv:0,isnm:False;n:type:ShaderForge.SFN_SceneColor,id:4819,x:32582,y:32918,varname:node_4819,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4551,x:33091,y:33014,varname:node_4551,prsc:2|A-4819-RGB,B-6971-RGB;n:type:ShaderForge.SFN_Add,id:6090,x:33710,y:33171,varname:node_6090,prsc:2|A-1089-OUT,B-4551-OUT,C-7032-OUT;n:type:ShaderForge.SFN_Tex2d,id:6942,x:32561,y:33304,ptovrint:False,ptlb:Apple,ptin:_Apple,varname:node_6942,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1e96e9a2d830a7140bbdbd154fc0343d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:8694,x:32287,y:33453,ptovrint:False,ptlb:Strength,ptin:_Strength,varname:node_8694,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Multiply,id:7032,x:33091,y:33171,varname:node_7032,prsc:2|A-6942-RGB,B-2053-OUT;n:type:ShaderForge.SFN_Time,id:959,x:32260,y:33684,varname:node_959,prsc:2;n:type:ShaderForge.SFN_Sin,id:1330,x:32659,y:33700,varname:node_1330,prsc:2|IN-2030-OUT;n:type:ShaderForge.SFN_Slider,id:1414,x:32220,y:33568,ptovrint:False,ptlb:BlingTime,ptin:_BlingTime,varname:node_1414,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Multiply,id:2030,x:32483,y:33673,varname:node_2030,prsc:2|A-959-T,B-1414-OUT;n:type:ShaderForge.SFN_Slider,id:1890,x:32212,y:33840,ptovrint:False,ptlb:AppleRange,ptin:_AppleRange,varname:node_1890,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:0.6461473,max:1;n:type:ShaderForge.SFN_Multiply,id:2332,x:32680,y:33525,varname:node_2332,prsc:2|A-8694-OUT,B-1890-OUT,C-1330-OUT;n:type:ShaderForge.SFN_Add,id:2053,x:32852,y:33387,varname:node_2053,prsc:2|A-8694-OUT,B-2332-OUT;n:type:ShaderForge.SFN_Slider,id:5519,x:32581,y:33901,ptovrint:False,ptlb:bkRange,ptin:_bkRange,varname:node_5519,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_RemapRange,id:6247,x:32870,y:33707,varname:node_6247,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-1330-OUT;n:type:ShaderForge.SFN_Multiply,id:7281,x:33051,y:33746,varname:node_7281,prsc:2|A-6247-OUT,B-5519-OUT;n:type:ShaderForge.SFN_Vector1,id:6068,x:33051,y:33627,varname:node_6068,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:5442,x:33231,y:33695,varname:node_5442,prsc:2|A-6068-OUT,B-7281-OUT;n:type:ShaderForge.SFN_Multiply,id:1089,x:33479,y:33171,varname:node_1089,prsc:2|A-427-RGB,B-5442-OUT;proporder:427-6971-6942-8694-1890-1414-5519;pass:END;sub:END;*/

Shader "Shader Forge/全景" {
    Properties {
        _Tex0 ("Tex0", 2D) = "white" {}
        _Mask ("Mask", 2D) = "white" {}
        _Apple ("Apple", 2D) = "white" {}
        _Strength ("Strength", Range(0, 5)) = 0
        _AppleRange ("AppleRange", Range(0.1, 1)) = 0.6461473
        _BlingTime ("BlingTime", Range(0, 5)) = 1
        _bkRange ("bkRange", Range(0, 1)) = 0
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
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform sampler2D _Tex0; uniform float4 _Tex0_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform sampler2D _Apple; uniform float4 _Apple_ST;
            uniform float _Strength;
            uniform float _BlingTime;
            uniform float _AppleRange;
            uniform float _bkRange;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 projPos : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
                float4 _Tex0_var = tex2D(_Tex0,TRANSFORM_TEX(i.uv0, _Tex0));
                float4 node_959 = _Time;
                float node_1330 = sin((node_959.g*_BlingTime));
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float4 _Apple_var = tex2D(_Apple,TRANSFORM_TEX(i.uv0, _Apple));
                float3 finalColor = ((_Tex0_var.rgb*(1.0+((node_1330*0.5+0.5)*_bkRange)))+(sceneColor.rgb*_Mask_var.rgb)+(_Apple_var.rgb*(_Strength+(_Strength*_AppleRange*node_1330))));
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
