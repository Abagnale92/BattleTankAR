Shader "Custom/CoatShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Alpha ("Alpha", Range(0,1.0)) = 1.0
		_Rim("Rim",float) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Transparent" "Queue"="Transparent"}
        LOD 200
		Cull off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass{
  		  ZWrite ON
  		  ColorMask 0
		}

		
        CGPROGRAM
        #pragma surface surf SimpleLight vertex:vert  alpha:fade
        #pragma target 3.0

		fixed4 _Color;
        sampler2D _MainTex;

		float _Alpha;
		float _Rim;
		

        struct Input {
            float2 uv_MainTex;
			float3 viewDir;
        };

		////////////////////////
		/*float random (fixed2 p) 
        { 
            return frac(sin(dot(p, fixed2(12.9898,78.233))) * 43758.5453 * _Time);
        }

        float noise(fixed2 st)
        {
            fixed2 p = floor(st);
            return random(p);
        }*/
		/////////////////////////////

		
        void vert(inout appdata_full v, out Input o )
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);
        }
		



        void surf (Input IN, inout SurfaceOutput o) {

		//color
		
			fixed2 uv = IN.uv_MainTex;
			fixed4 c = tex2D (_MainTex, uv);
			o.Albedo = _Color.rgb * c.rgb;
			o.Alpha = _Alpha;
			
		//rim
		
			fixed4 rimColor  = fixed4(0.5,0.7,0.5,1);

			float rim = 1 - saturate(dot(IN.viewDir, o.Normal));
     		o.Emission = rimColor * pow(rim, 2.0 - _Rim);
			
        }

		half4 LightingSimpleLight(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
		{
			 half NdotL = max(0, dot (s.Normal, lightDir));
			 float3 R = normalize( - lightDir + 2.0 * s.Normal * NdotL );
			 float3 spec = pow(max(0, dot(R, viewDir)), 10.0);

			 half4 c;
			 c.rgb = s.Albedo * _LightColor0.rgb * NdotL + spec +  fixed4(0.1f, 0.1f, 0.1f, 1);
			 c.a = s.Alpha;
			 return c;
		}
		

        ENDCG
	}
	FallBack "Diffuse"
}
