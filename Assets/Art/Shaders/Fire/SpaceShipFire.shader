// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "SpaceShipFire"
{
	Properties
	{
		_EdgeLength ( "Edge length", Range( 2, 50 ) ) = 15
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Geometry+0" }
		Cull Back
		CGINCLUDE
		#include "UnityShaderVariables.cginc"
		#include "Tessellation.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 4.6
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float _Cutoff = 0.5;
		uniform float _EdgeLength;


		float2 voronoihash5( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi5( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
		{
			float2 n = floor( v );
			float2 f = frac( v );
			float F1 = 8.0;
			float F2 = 8.0; float2 mg = 0;
			for ( int j = -1; j <= 1; j++ )
			{
				for ( int i = -1; i <= 1; i++ )
			 	{
			 		float2 g = float2( i, j );
			 		float2 o = voronoihash5( n + g );
					o = ( sin( time + o * 6.2831 ) * 0.5 + 0.5 ); float2 r = f - g - o;
					float d = 0.5 * dot( r, r );
			 		if( d<F1 ) {
			 			F2 = F1;
			 			F1 = d; mg = g; mr = r; id = o;
			 		} else if( d<F2 ) {
			 			F2 = d;
			 		}
			 	}
			}
			return F1;
		}


		float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }

		float snoise( float2 v )
		{
			const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
			float2 i = floor( v + dot( v, C.yy ) );
			float2 x0 = v - i + dot( i, C.xx );
			float2 i1;
			i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
			float4 x12 = x0.xyxy + C.xxzz;
			x12.xy -= i1;
			i = mod2D289( i );
			float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
			float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
			m = m * m;
			m = m * m;
			float3 x = 2.0 * frac( p * C.www ) - 1.0;
			float3 h = abs( x ) - 0.5;
			float3 ox = floor( x + 0.5 );
			float3 a0 = x - ox;
			m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
			float3 g;
			g.x = a0.x * x0.x + h.x * x0.y;
			g.yz = a0.yz * x12.xz + h.yz * x12.yw;
			return 130.0 * dot( m, g );
		}


		float2 voronoihash86( float2 p )
		{
			
			p = float2( dot( p, float2( 127.1, 311.7 ) ), dot( p, float2( 269.5, 183.3 ) ) );
			return frac( sin( p ) *43758.5453);
		}


		float voronoi86( float2 v, float time, inout float2 id, inout float2 mr, float smoothness )
		{
			float2 n = floor( v );
			float2 f = frac( v );
			float F1 = 8.0;
			float F2 = 8.0; float2 mg = 0;
			for ( int j = -1; j <= 1; j++ )
			{
				for ( int i = -1; i <= 1; i++ )
			 	{
			 		float2 g = float2( i, j );
			 		float2 o = voronoihash86( n + g );
					o = ( sin( time + o * 6.2831 ) * 0.5 + 0.5 ); float2 r = f - g - o;
					float d = 0.5 * dot( r, r );
			 		if( d<F1 ) {
			 			F2 = F1;
			 			F1 = d; mg = g; mr = r; id = o;
			 		} else if( d<F2 ) {
			 			F2 = d;
			 		}
			 	}
			}
			return F1;
		}


		float4 tessFunction( appdata_full v0, appdata_full v1, appdata_full v2 )
		{
			return UnityEdgeLengthBasedTess (v0.vertex, v1.vertex, v2.vertex, _EdgeLength);
		}

		void vertexDataFunc( inout appdata_full v )
		{
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 color20 = IsGammaSpace() ? float4(8,0,0,0) : float4(97.00587,0,0,0);
			float4 color21 = IsGammaSpace() ? float4(4,1.647059,0,0) : float4(21.11213,2.997506,0,0);
			float smoothstepResult14 = smoothstep( 0.0 , 1.0 , i.uv_texcoord.y);
			float time5 = 7.12;
			float2 coords5 = ( i.uv_texcoord + ( float2( 0,-1 ) * _Time.y ) ) * 6.75;
			float2 id5 = 0;
			float2 uv5 = 0;
			float voroi5 = voronoi5( coords5, time5, id5, uv5, 0 );
			float smoothstepResult16 = smoothstep( -0.1 , 0.52 , voroi5);
			float temp_output_15_0 = ( smoothstepResult14 * ( 1.0 - smoothstepResult16 ) );
			float4 lerpResult19 = lerp( color20 , color21 , temp_output_15_0);
			o.Albedo = lerpResult19.rgb;
			float2 uv_TexCoord25 = i.uv_texcoord * float2( 1,0.21 );
			float simplePerlin2D32 = snoise( ( i.uv_texcoord + ( float2( -1,0 ) * _Time.y ) )*2.92 );
			simplePerlin2D32 = simplePerlin2D32*0.5 + 0.5;
			float smoothstepResult28 = smoothstep( 0.2 , 1.43 , pow( ( 1.0 - distance( float3(0.52,0,0) , float3( ( uv_TexCoord25 + ( simplePerlin2D32 * 0.05 ) ) ,  0.0 ) ) ) , 1.0 ));
			float2 uv_TexCoord66 = i.uv_texcoord * float2( 1,0.62 );
			float time86 = 0.0;
			float2 coords86 = ( i.uv_texcoord + ( float2( 0,1 ) * _Time.y ) ) * 0.1;
			float2 id86 = 0;
			float2 uv86 = 0;
			float voroi86 = voronoi86( coords86, time86, id86, uv86, 0 );
			float smoothstepResult68 = smoothstep( -0.42 , 0.63 , distance( ( uv_TexCoord66 + ( uv86 * 1.0 ) ) , float2( 0.5,0.02 ) ));
			float temp_output_72_0 = ( 1.0 - step( ( ( smoothstepResult28 + temp_output_15_0 ) * ( 1.0 - smoothstepResult68 ) ) , 0.11 ) );
			o.Alpha = temp_output_72_0;
			clip( temp_output_72_0 - _Cutoff );
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Standard keepalpha fullforwardshadows vertex:vertexDataFunc tessellate:tessFunction 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 4.6
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			sampler3D _DitherMaskLOD;
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float3 worldPos : TEXCOORD2;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				vertexDataFunc( v );
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				o.worldPos = worldPos;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				return o;
			}
			half4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				float3 worldPos = IN.worldPos;
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				SurfaceOutputStandard o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandard, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				half alphaRef = tex3D( _DitherMaskLOD, float3( vpos.xy * 0.25, o.Alpha * 0.9375 ) ).a;
				clip( alphaRef - 0.01 );
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18301
604;515;611;484;1498.954;-1117.733;1;True;False
Node;AmplifyShaderEditor.SimpleTimeNode;40;-2700.508,1231.828;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;39;-2646.671,1078.436;Inherit;False;Constant;_Vector3;Vector 3;2;0;Create;True;0;0;False;0;False;-1,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;41;-2473.772,1052.836;Inherit;True;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;34;-2606.735,861.5104;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;38;-2251.399,857.8439;Inherit;True;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleTimeNode;81;-1920.735,1740.307;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;80;-1923.735,1472.307;Inherit;False;Constant;_Vector5;Vector 5;2;0;Create;True;0;0;False;0;False;0,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;10;-2386.778,363.4478;Inherit;False;Constant;_Vector0;Vector 0;2;0;Create;True;0;0;False;0;False;0,-1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;78;-1756.735,1486.307;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;42;-2244.426,661.2581;Inherit;False;Constant;_Vector2;Vector 2;2;0;Create;True;0;0;False;0;False;1,0.21;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;76;-1908.372,1244.986;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NoiseGeneratorNode;32;-2027.737,835.8116;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;2.92;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;37;-1961.546,1119.404;Inherit;False;Constant;_Float0;Float 0;2;0;Create;True;0;0;False;0;False;0.05;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;13;-2440.615,516.8402;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;77;-1501.171,1289.314;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;-2213.879,337.8478;Inherit;True;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;8;-2318.778,39.44778;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;25;-1998.477,658.4722;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;36;-1776.546,962.4036;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;83;-1271.342,1492.021;Inherit;False;Constant;_Float1;Float 1;2;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VoronoiNode;86;-1332.706,1245.937;Inherit;True;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;FLOAT;0.1;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleAddOpNode;9;-1981.778,157.4478;Inherit;True;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;35;-1648.546,767.4036;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector3Node;24;-1674.314,531.7239;Inherit;False;Constant;_Vector1;Vector 1;2;0;Create;True;0;0;False;0;False;0.52,0,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.TextureCoordinatesNode;66;-1340.431,1055.804;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,0.62;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;4;-2044.275,-171.7525;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DistanceOpNode;22;-1452.696,582.7516;Inherit;True;2;0;FLOAT3;-4.47,1,1;False;1;FLOAT2;1,1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;82;-1130.342,1240.021;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.VoronoiNode;5;-1698.582,65.11736;Inherit;True;0;0;1;0;1;False;1;False;False;4;0;FLOAT2;0,0;False;1;FLOAT;7.12;False;2;FLOAT;6.75;False;3;FLOAT;0;False;3;FLOAT;0;FLOAT2;1;FLOAT2;2
Node;AmplifyShaderEditor.SimpleAddOpNode;73;-997.6585,1046.992;Inherit;True;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;67;-955.8701,1289.452;Inherit;False;Constant;_Vector4;Vector 4;2;0;Create;True;0;0;False;0;False;0.5,0.02;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.BreakToComponentsNode;2;-1716.87,-179.7952;Inherit;True;FLOAT;1;0;FLOAT;0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.OneMinusNode;31;-1170.175,566.3887;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;16;-1503.917,68.13083;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;-0.1;False;2;FLOAT;0.52;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;14;-1477.465,-178.8889;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.DistanceOpNode;65;-681.735,1193.385;Inherit;True;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;17;-1263.917,71.13083;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;26;-899.0909,385.3771;Inherit;True;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;28;-636.0909,385.3771;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0.2;False;2;FLOAT;1.43;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;68;-392.1846,1188.741;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;-0.42;False;2;FLOAT;0.63;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;15;-1086.614,-3.499233;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;69;-114.7059,1187.617;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;45;-358.3942,275.1461;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;70;126.0927,445.7876;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;21;-1057.917,-272.8691;Inherit;False;Constant;_Color1;Color 1;2;1;[HDR];Create;True;0;0;False;0;False;4,1.647059,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;20;-1066.917,-455.8692;Inherit;False;Constant;_Color0;Color 0;2;1;[HDR];Create;True;0;0;False;0;False;8,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StepOpNode;71;329.6672,434.0618;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0.11;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;72;585.035,511.4672;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;19;-690.9165,-102.8692;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;787.2209,126.2265;Float;False;True;-1;6;ASEMaterialInspector;0;0;Standard;SpaceShipFire;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;False;Transparent;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;True;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;5;-1;-1;0;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;41;0;39;0
WireConnection;41;1;40;0
WireConnection;38;0;34;0
WireConnection;38;1;41;0
WireConnection;78;0;80;0
WireConnection;78;1;81;0
WireConnection;32;0;38;0
WireConnection;77;0;76;0
WireConnection;77;1;78;0
WireConnection;11;0;10;0
WireConnection;11;1;13;0
WireConnection;25;0;42;0
WireConnection;36;0;32;0
WireConnection;36;1;37;0
WireConnection;86;0;77;0
WireConnection;9;0;8;0
WireConnection;9;1;11;0
WireConnection;35;0;25;0
WireConnection;35;1;36;0
WireConnection;22;0;24;0
WireConnection;22;1;35;0
WireConnection;82;0;86;2
WireConnection;82;1;83;0
WireConnection;5;0;9;0
WireConnection;73;0;66;0
WireConnection;73;1;82;0
WireConnection;2;0;4;2
WireConnection;31;0;22;0
WireConnection;16;0;5;0
WireConnection;14;0;2;0
WireConnection;65;0;73;0
WireConnection;65;1;67;0
WireConnection;17;0;16;0
WireConnection;26;0;31;0
WireConnection;28;0;26;0
WireConnection;68;0;65;0
WireConnection;15;0;14;0
WireConnection;15;1;17;0
WireConnection;69;0;68;0
WireConnection;45;0;28;0
WireConnection;45;1;15;0
WireConnection;70;0;45;0
WireConnection;70;1;69;0
WireConnection;71;0;70;0
WireConnection;72;0;71;0
WireConnection;19;0;20;0
WireConnection;19;1;21;0
WireConnection;19;2;15;0
WireConnection;0;0;19;0
WireConnection;0;9;72;0
WireConnection;0;10;72;0
ASEEND*/
//CHKSM=3CD871E6A1DBF1E83233DD68275A61CB59E8681A