// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,atwp:True,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:34221,y:33036,varname:node_1873,prsc:2|emission-1749-OUT,alpha-603-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:33186,y:32938,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:33447,y:33027,cmnt:RGB,varname:node_1086,prsc:2|A-4805-RGB,B-5983-RGB,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:33186,y:33124,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:33186,y:33288,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:33852,y:33285,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT,C-5133-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:33447,y:33201,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5983-A,C-5376-A;n:type:ShaderForge.SFN_Pi,id:6361,x:32287,y:33285,varname:node_6361,prsc:2;n:type:ShaderForge.SFN_Vector1,id:4241,x:32287,y:33391,varname:node_4241,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:8145,x:32499,y:33285,varname:node_8145,prsc:2|A-6361-OUT,B-4241-OUT;n:type:ShaderForge.SFN_Vector1,id:5144,x:32289,y:33462,varname:node_5144,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:222,x:32289,y:33558,varname:node_222,prsc:2,v1:0.333;n:type:ShaderForge.SFN_Vector1,id:5218,x:32289,y:33669,varname:node_5218,prsc:2,v1:0.666;n:type:ShaderForge.SFN_Time,id:2902,x:32116,y:33763,varname:node_2902,prsc:2;n:type:ShaderForge.SFN_Add,id:4401,x:32499,y:33462,varname:node_4401,prsc:2|A-5144-OUT,B-796-OUT;n:type:ShaderForge.SFN_Add,id:8110,x:32499,y:33619,varname:node_8110,prsc:2|A-222-OUT,B-796-OUT;n:type:ShaderForge.SFN_Add,id:3374,x:32499,y:33763,varname:node_3374,prsc:2|A-5218-OUT,B-796-OUT;n:type:ShaderForge.SFN_Sin,id:6479,x:32987,y:33439,varname:node_6479,prsc:2|IN-9901-OUT;n:type:ShaderForge.SFN_Sin,id:6778,x:32987,y:33596,varname:node_6778,prsc:2|IN-1402-OUT;n:type:ShaderForge.SFN_Sin,id:3773,x:32987,y:33741,varname:node_3773,prsc:2|IN-6624-OUT;n:type:ShaderForge.SFN_Append,id:9854,x:33408,y:33438,varname:node_9854,prsc:2|A-1356-OUT,B-2359-OUT,C-2820-OUT;n:type:ShaderForge.SFN_RemapRange,id:1356,x:33186,y:33438,varname:node_1356,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-6479-OUT;n:type:ShaderForge.SFN_RemapRange,id:2359,x:33186,y:33596,varname:node_2359,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-6778-OUT;n:type:ShaderForge.SFN_RemapRange,id:2820,x:33186,y:33741,varname:node_2820,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-3773-OUT;n:type:ShaderForge.SFN_Multiply,id:9901,x:32756,y:33439,varname:node_9901,prsc:2|A-8145-OUT,B-4401-OUT;n:type:ShaderForge.SFN_Multiply,id:1402,x:32756,y:33596,varname:node_1402,prsc:2|A-8145-OUT,B-8110-OUT;n:type:ShaderForge.SFN_Multiply,id:6624,x:32756,y:33741,varname:node_6624,prsc:2|A-8145-OUT,B-3374-OUT;n:type:ShaderForge.SFN_Slider,id:2770,x:31959,y:33669,ptovrint:False,ptlb:speed,ptin:_speed,varname:node_2770,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:3;n:type:ShaderForge.SFN_Multiply,id:796,x:32289,y:33763,varname:node_796,prsc:2|A-2902-T,B-2770-OUT;n:type:ShaderForge.SFN_RemapRange,id:5133,x:33607,y:33438,varname:node_5133,prsc:2,frmn:0,frmx:1,tomn:0.5,tomx:1|IN-9854-OUT;proporder:4805-5983-2770;pass:END;sub:END;*/

Shader "Shader Forge/bkColor" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _speed ("speed", Range(0, 3)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        _Stencil ("Stencil ID", Float) = 0
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilComp ("Stencil Comparison", Float) = 8
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilOpFail ("Stencil Fail Operation", Float) = 0
        _StencilOpZFail ("Stencil Z-Fail Operation", Float) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            Stencil {
                Ref [_Stencil]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilOp]
                Fail [_StencilOpFail]
                ZFail [_StencilOpZFail]
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Color;
            uniform float _speed;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_603 = (_MainTex_var.a*_Color.a*i.vertexColor.a); // A
                float node_8145 = (3.141592654*2.0);
                float4 node_2902 = _Time;
                float node_796 = (node_2902.g*_speed);
                float3 node_9854 = float3((sin((node_8145*(0.0+node_796)))*0.5+0.5),(sin((node_8145*(0.333+node_796)))*0.5+0.5),(sin((node_8145*(0.666+node_796)))*0.5+0.5));
                float3 emissive = ((_MainTex_var.rgb*_Color.rgb*i.vertexColor.rgb)*node_603*(node_9854*0.5+0.5));
                float3 finalColor = emissive;
                return fixed4(finalColor,node_603);
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
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
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
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
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
