float rotationAngle;
// TODO: add effect parameters here.
sampler mapSampler  : register(s2);

struct VS_INPUT
{
	float4 pos		: POSITION0;
	float2 Uv		: TEXCOORD0;
};

struct PS_INPUT
{
	float4 pos		: POSITION0;
	float2 Uv		: TEXCOORD;
};

PS_INPUT VS_MAIN(VS_INPUT input)
{
	PS_INPUT output = (PS_INPUT)0;
	output.Uv = input.Uv;

	return output;
}
float4 PS_MAIN(PS_INPUT input) : COLOR
{
	float4 normalMap = tex2D(mapSampler, input.Uv);

	float3x3 rotationMatrix = { cos(rotationAngle), -sin(rotationAngle), 0,
								sin(rotationAngle), cos(rotationAngle), 0,
								0,					 0,					 1
							  };

    return float4(1, 0, 0, 1);
}

technique Technique1
{
    pass Pass1
    {
        
        VertexShader = compile vs_2_0 VS_MAIN();
        PixelShader = compile ps_2_0 PS_MAIN();
    }
}
