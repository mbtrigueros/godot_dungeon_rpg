shader_type spatial;
uniform bool active = false;
render_mode unshaded, cull_disabled;
uniform vec4 flash_color: source_color = vec4(1.0, 1.0, 1.0, 1.0);
uniform sampler2D tex: source_color;

void fragment() {
	// Called for every pixel the material is visible on.
	vec4 color = texture(tex, UV);
	ALPHA = color.a;
	if(active == true) {
		color = flash_color;
	}
	ALBEDO = vec3(color.r, color.g, color.b);
}

//void light() {
	// Called for every pixel for every light affecting the material.
	// Uncomment to replace the default light processing function with this one.
//}
