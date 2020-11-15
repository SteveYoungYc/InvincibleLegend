Shader "Tatakai/MuzzleFlash_orig" {
Properties {
	_flameValue ("Flame Scale", Float) = 6.0
	_Color ("Main Color", Color) = (1, 1, 1, 1)
	_MainTex ("Particle Texture", 2D) = "black" {}
}
SubShader {
	Tags { "Queue"="Transparent+11" "IgnoreProjector"="True"}
	//Cull Back
	Lighting Off
	//ZWrite Off
	//Ztest Off
	Fog { Mode Off }
	Blend One One
	//Blend SrcAlpha One
	Cull Back
	ZWrite On

	
	CGPROGRAM
	#pragma surface surf MuzzleFlash noambient alpha vertex:vert

	
      half4 LightingMuzzleFlash (SurfaceOutput s, half3 lightDir, half atten) {
          half NdotL = dot (s.Normal, lightDir);
          half diff = NdotL * 0.5 + 0.5;
          half4 c;
          c.rgb = s.Albedo * _LightColor0.rgb * 20.0;//* diff;// * atten * 2);
          c.rgb = s.Albedo * _LightColor0.r;//* diff;// * atten * 2);
          c.a = s.Alpha;
          
          	
          return c;
      }
      
      
	sampler2D _MainTex;
	fixed4 _Color;
	fixed _flameValue;
		
	struct Input {
		float2 uv_MainTex;
		float4 vertexColor;
	};
		
	void vert (inout appdata_full v, out Input o) {
		o.uv_MainTex = v.texcoord;
		o.vertexColor.rgb = v.color.rgb;
		o.vertexColor.a = v.color.a;
		v.normal = normalize (v.vertex);
		v.tangent = float4 (0, 0, 0, 0);
	}
		
	void surf (Input IN, inout SurfaceOutput o) {
		float4 tex = tex2D (_MainTex, IN.uv_MainTex);
		half3 useColor = IN.vertexColor.rgb;
		//if (useColor.r <= 0.5) useColor.r = 0.5;
		//if (useColor.g <= 0.5) useColor.g = 0.5;
		//if (useColor.b <= 0.5) useColor.b = 0.5;
		
		o.Albedo = tex.rgb * _Color.rgb * useColor;//(IN.vertexColor.rgb);
		o.Alpha = tex.a * _Color.a * (IN.vertexColor.a);// * (1.0 - _LightColor0.r);
		o.Emission = _Color.rgb*_flameValue;
		
	}

	ENDCG 
	
} 	


}
