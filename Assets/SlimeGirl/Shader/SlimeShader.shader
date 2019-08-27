Shader "Custom/SlimeShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_DisolveColor ("DisolveColor", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_DisolveTex ("DisolveTex (RGB)", 2D) = "white" {}
		_Alpha ("Alpha", Range(0,1.0)) = 1.0
		_DisAlpha ("DisAlpha", Range(0,1.0)) = 1.0
		_Concent("Concentration", Range(0,1))= 0.0
		_Rim("Rim",float) = 0.0
		_Amount("Amount", float)=1.0
	}
	SubShader {
		Tags { "RenderType"="Transparent" "Queue"="Transparent"}
        LOD 200

		Pass{
  		  ZWrite ON
  		  ColorMask 0
		}

		
        CGPROGRAM
        #pragma surface surf SimpleLight vertex:vert  alpha:fade
        #pragma target 3.0

		fixed4 _Color;
		fixed4 _DisolveColor;
        sampler2D _MainTex;
		sampler2D _DisolveTex;

		float _Alpha;
		float _DisAlpha;
		half _Concent;
		float _Rim;
		float _Amount;
		

        struct Input {
            float2 uv_MainTex;
			float2 uv_DisolveTex;
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
			float temp = sin(50 * (v.vertex.z + _Time));
			float temp2 = sin(50 * (v.vertex.x + _Time));
			float temp3 = sin(50 * (v.vertex.y + _Time));
			v.normal = normalize(float3(v.normal.x+temp*_Amount, v.normal.y+temp3*_Amount, v.normal.z+temp2*_Amount));
        }



        void surf (Input IN, inout SurfaceOutput o) {

		//color
		
			fixed2 uv = IN.uv_MainTex;
			fixed4 c = tex2D (_MainTex, uv);
            //o.Albedo = c.rgb + _Color.rgb;
			o.Albedo = _Color.rgb * c.rgb;
			o.Alpha = _Alpha;
			
		//distort
		
			uv = IN.uv_DisolveTex;
			uv.x += 0.5 * _Time;
			uv.y += 1.0 * _Time;
			fixed4 m = tex2D (_DisolveTex, uv);
			float g = m.r * 0.2 + m.g * 0.7 + m.b * 0.1;
			o.Albedo = o.Albedo + (m.a * (_DisolveColor - _Concent - 1)) * _DisAlpha;
			//o.Albedo = (g < _Concent) ? o.Albedo * (_Concent + m.rgb * _DisolveColor) : o.Albedo;
			
		//rim
		
			//fixed4 baseColor = fixed4(0.05, 0.1, 0, 1);
			fixed4 rimColor  = fixed4(0.5,0.7,0.5,1);

			//o.Albedo = baseColor;
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
