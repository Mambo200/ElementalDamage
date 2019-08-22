// Standard shader with triplanar mapping
// https://github.com/keijiro/StandardTriplanar

Shader "Standard Triplanar"
{
	Properties
	{

		_CircleSpeed("Speed of Circles", float) = 1
		_ColorOne("First Color", Vector) = (1,0,0)
		_ColorTwo("Second Color", Vector) = (0,0,0)
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }

		CGPROGRAM

		#pragma surface surf Standard vertex:vert fullforwardshadows addshadow

		#pragma shader_feature _NORMALMAP
		#pragma shader_feature _OCCLUSIONMAP

		#pragma target 3.0

		float _CircleSpeed;
	float4 _ColorOne;
	float4 _ColorTwo;

        struct Input
        {
            float3 localCoord;
            float3 localNormal;
        };

        void vert(inout appdata_full v, out Input data)
        {
            UNITY_INITIALIZE_OUTPUT(Input, data);
            data.localCoord = v.vertex.xyz;
            data.localNormal = v.normal.xyz;
        }

        void surf(Input IN, inout SurfaceOutputStandard o)
        {

			float time = _Time.x * _CircleSpeed;


			float x = (pow(IN.localCoord.x, 2));
			float z = (pow(IN.localCoord.z, 2));
			
			
			
			float red = sin(x + z + time);
			red = sign(red);

			float blue = 0;
			float green = 0;
			float alpha = 1;

			// Roter Kreis
			if (red == 1)
			{
				red = _ColorOne.r;
				blue = _ColorOne.b;
				green = _ColorOne.g;
			}
			
			// Weißer Kreis
			else
			{
				red = _ColorTwo.r;
				blue = _ColorTwo.b;
				green = _ColorTwo.g;
			}
			
			o.Albedo = float4(red, green, blue, 1);

        //    // Blending factor of triplanar mapping
        //    float3 bf = normalize(abs(IN.localNormal));
        //    bf /= dot(bf, (float3)1);

        //    // Triplanar mapping
        //    float2 tx = IN.localCoord.yz * _MapScale;
        //    float2 ty = IN.localCoord.zx * _MapScale;
        //    float2 tz = IN.localCoord.xy * _MapScale;

        //    // Base color
        //    half4 cx = tex2D(_MainTex, tx) * bf.x;
        //    half4 cy = tex2D(_MainTex, ty) * bf.y;
        //    half4 cz = tex2D(_MainTex, tz) * bf.z;
        //    half4 color = (cx + cy + cz) * _Color;
        //    o.Albedo = color.rgb;
        //    o.Alpha = color.a;

        //#ifdef _NORMALMAP
        //    // Normal map
        //    half4 nx = tex2D(_BumpMap, tx) * bf.x;
        //    half4 ny = tex2D(_BumpMap, ty) * bf.y;
        //    half4 nz = tex2D(_BumpMap, tz) * bf.z;
        //    o.Normal = UnpackScaleNormal(nx + ny + nz, _BumpScale);
        //#endif

        //#ifdef _OCCLUSIONMAP
        //    // Occlusion map
        //    half ox = tex2D(_OcclusionMap, tx).g * bf.x;
        //    half oy = tex2D(_OcclusionMap, ty).g * bf.y;
        //    half oz = tex2D(_OcclusionMap, tz).g * bf.z;
        //    o.Occlusion = lerp((half4)1, ox + oy + oz, _OcclusionStrength);
        //#endif

        //    // Misc parameters
        //    o.Metallic = _Metallic;
        //    o.Smoothness = _Glossiness;
        }
        ENDCG
    }
    FallBack "Diffuse"
    CustomEditor "StandardTriplanarInspector"
}
