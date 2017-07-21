#version 130

in vec3 vs_out_col;
in vec2 vs_out_tex0;
out vec4 fs_out_col;

uniform sampler2D texImage;
uniform sampler2D texImage2;

uniform float t;

void main()
{
	fs_out_col = mix(texture(texImage, vs_out_tex0.st), texture(texImage2, vs_out_tex0.st), t);
}