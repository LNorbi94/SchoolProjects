#pragma once

// GLEW
#include <GL/glew.h>

// SDL
#include <SDL.h>
#include <SDL_opengl.h>

// GLM
#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtx/transform2.hpp>

// mesh
#include "ObjParser_OGL3.h"

class CMyApp
{
public:
	CMyApp(void);
	~CMyApp(void);

	bool Init();
	void Clean();

	void Update();
	void Render();

	void KeyboardDown(SDL_KeyboardEvent&);
	void KeyboardUp(SDL_KeyboardEvent&);
	void MouseMove(SDL_MouseMotionEvent&);
	void MouseDown(SDL_MouseButtonEvent&);
	void MouseUp(SDL_MouseButtonEvent&);
	void MouseWheel(SDL_MouseWheelEvent&);
	void Resize(int, int);
protected:
	// belsõ eljárások
	void DrawGround();
	void DrawMesh();
	glm::vec3 toDesc(float fi, float theta);
	glm::vec3 GetUV(float, float);
	GLuint GenTexture();

	// shaderekhez szükséges változók
	GLuint m_programID; // shaderek programja

	GLuint talajTextureID;
	GLuint fejTextureID;
	GLuint labakTextureID;

	float fi = M_PI / 2.0;
	float theta = M_PI / 2.0;

	glm::vec3 eye = glm::vec3(10, 10, 10);
	glm::vec3 at = toDesc(fi, theta) + eye;
	glm::vec3 forward = glm::vec3(at - eye);

	// transzformációs mátrixok
	glm::mat4 m_matWorld;
	glm::mat4 m_matView;
	glm::mat4 m_matProj;

	// mátrixok helye a shaderekben
	GLuint  m_loc_mvp;
	GLuint  m_loc_texture;

	// OpenGL-es dolgok
	GLuint m_vaoID; // vertex array object erõforrás azonosító
	GLuint m_vboID; // vertex buffer object erõforrás azonosító
	GLuint m_ibID;  // index buffer object erõforrás azonosító
	GLuint g_vaoID; // vertex array object erõforrás azonosító
	GLuint g_vboID; // vertex buffer object erõforrás azonosító
	GLuint g_ibID;  // index buffer object erõforrás azonosító
	GLuint m_waterTextureID; // fájlból betöltött textúra azonosítója

	struct Vertex
	{
		glm::vec3 p; // pozíció
		glm::vec3 c; // szín
		glm::vec2 t; // textúra koordináták
	};

	// mesh adatok
	Mesh *m_meshFej;
	Mesh *m_meshLabak;
};