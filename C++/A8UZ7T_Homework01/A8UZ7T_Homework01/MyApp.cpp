#include "MyApp.h"
#include "utils/GLUtils.hpp"

CMyApp::CMyApp(void) 
	: m_programID(0)
	, m_vaoID(0)
	, m_vboID(0)
	, rotate(false)
{ }


CMyApp::~CMyApp(void)
{ }

bool CMyApp::Init()
{
	glClearColor(0.125f, 0.25f, 0.5f, 1.0f);

	glEnable(GL_CULL_FACE);
	glEnable(GL_DEPTH_TEST);
	glCullFace(GL_BACK);

	Vertex vert[] =
	{
		// Felsõ oldallapok
		{ glm::vec3(1,	0, -1),	glm::vec3(0, 0, 1) },
		{ glm::vec3(-1,	0, -1),	glm::vec3(1, 0, 2) },
		{ glm::vec3(0,	1, 0),	glm::vec3(0, 2, 3) },

		{ glm::vec3(-1, 0, 1),	glm::vec3(3, 0, 1) },
		{ glm::vec3(1,	0, 1),	glm::vec3(1, 1, 2) },
		{ glm::vec3(0,	1, 0),	glm::vec3(0, 0, 3) },

		{ glm::vec3(1, 0, 1),		glm::vec3(0, 1, 3) },
		{ glm::vec3(1, 0, -1),	glm::vec3(1, 1, 2) },
		{ glm::vec3(0, 1, 0),		glm::vec3(0, 0, 1) },

		{ glm::vec3(-1, 0, -1),	glm::vec3(0, 1, 3) },
		{ glm::vec3(-1, 0, 1),	glm::vec3(0, 1, 2) },
		{ glm::vec3(0,	1, 0),	glm::vec3(0, 0, 1) },

		// Alsó oldallapok
		{ glm::vec3(1,	0, 1),	glm::vec3(1, 0, 0) },
		{ glm::vec3(-1, 0, 1),	glm::vec3(1, 1, 0) },
		{ glm::vec3(0, -1, 0),	glm::vec3(1, 0, 1) },

		{ glm::vec3(-1, 0, -1),	glm::vec3(1, 0, 1) },
		{ glm::vec3(1,	0, -1),	glm::vec3(1, 1, 0) },
		{ glm::vec3(0, -1, 0),	glm::vec3(1, 0, 1) },

		{ glm::vec3(1, 0,	 -1),	glm::vec3(1, 1, 0) },
		{ glm::vec3(1, 0,		1),	glm::vec3(1, 1, 0) },
		{ glm::vec3(0, -1,	0),	glm::vec3(1, 0, 1) },

		{ glm::vec3(-1, 0, 1),	glm::vec3(1, 1, 1) },
		{ glm::vec3(-1,	0, -1),	glm::vec3(1, 1, 0) },
		{ glm::vec3(0, -1, 0),	glm::vec3(1, 0, 1) }
	};

	glGenVertexArrays(1, &m_vaoID);
	glBindVertexArray(m_vaoID);

	glGenBuffers(1, &m_vboID);
	glBindBuffer(GL_ARRAY_BUFFER, m_vboID);
	glBufferData(GL_ARRAY_BUFFER, sizeof(vert), vert, GL_STATIC_DRAW);

	glEnableVertexAttribArray(0);
	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), nullptr);

	glEnableVertexAttribArray(1);
	glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), reinterpret_cast<void*>(sizeof(glm::vec3)));

	glBindVertexArray(0);
	glBindBuffer(GL_ARRAY_BUFFER, 0);

	GLuint vs_ID = loadShader(GL_VERTEX_SHADER, "Shaders/myVert.vert");
	GLuint fs_ID = loadShader(GL_FRAGMENT_SHADER, "Shaders/myFrag.frag");

	m_programID = glCreateProgram();

	glAttachShader(m_programID, vs_ID);
	glAttachShader(m_programID, fs_ID);


	glBindAttribLocation(m_programID, 0, "vs_in_pos");
	glBindAttribLocation(m_programID, 1, "vs_in_col");

	glLinkProgram(m_programID);

	GLint infoLogLength = 0, result = 0;

	glGetProgramiv(m_programID, GL_LINK_STATUS, &result);
	glGetProgramiv(m_programID, GL_INFO_LOG_LENGTH, &infoLogLength);
	if (GL_FALSE == result)
	{
		std::vector<char> ProgramErrorMessage(infoLogLength);
		glGetProgramInfoLog(m_programID, infoLogLength, nullptr, &ProgramErrorMessage[0]);
		std::cerr << "[app.Init()] Hiba tortent: " << &ProgramErrorMessage[0] << std::endl;
	}

	glDeleteShader(vs_ID);
	glDeleteShader(fs_ID);

	m_matProj = glm::perspective(45.0f, 640 / 480.0f, 1.0f, 1000.0f);

	m_loc_world = glGetUniformLocation(m_programID, "world");
	m_loc_view = glGetUniformLocation(m_programID, "view");
	m_loc_proj = glGetUniformLocation(m_programID, "proj");

	return true;
}

void CMyApp::Clean()
{
	glDeleteBuffers(1, &m_vboID);
	glDeleteVertexArrays(1, &m_vaoID);
	glDeleteProgram(m_programID);
}

void CMyApp::Update()
{
	m_matView = glm::lookAt(glm::vec3(5, 0, 17), glm::vec3(0, 0, 0), glm::vec3(0, 1, 0));
}


void CMyApp::Render()
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glUseProgram(m_programID);

	glUniformMatrix4fv(m_loc_world, 1, GL_FALSE, &(m_matWorld[0][0]));
	glUniformMatrix4fv(m_loc_view, 1, GL_FALSE, &(m_matView[0][0]));
	glUniformMatrix4fv(m_loc_proj, 1, GL_FALSE, &(m_matProj[0][0]));

	glBindVertexArray(m_vaoID);

	for (int i = 0; i < 5; ++i)
	{
		m_matWorld = glm::rotate<float>(SDL_GetTicks() / 11000.0f * 360, 10, 0, 1) * glm::rotate<float>(360 / 5.0f * i, 0, 0, 1) * glm::translate<float>(5, 0, 0);
		if (rotate)
			m_matWorld *= glm::rotate<float>(SDL_GetTicks() / 1000.0f * 360, 0, 1, 0);
		glUniformMatrix4fv(m_loc_world, 1, GL_FALSE, &(m_matWorld[0][0]));
		glDrawArrays(GL_TRIANGLES, 0, 24);
	}

	glBindVertexArray(0);
	glUseProgram(0);
}

void CMyApp::KeyboardDown(SDL_KeyboardEvent& key)
{
	if (key.keysym.sym == SDLK_SPACE)
		rotate = !rotate;
}

void CMyApp::KeyboardUp(SDL_KeyboardEvent& key)
{ }

void CMyApp::MouseMove(SDL_MouseMotionEvent& mouse)
{ }

void CMyApp::MouseDown(SDL_MouseButtonEvent& mouse)
{ }

void CMyApp::MouseUp(SDL_MouseButtonEvent& mouse)
{ }

void CMyApp::MouseWheel(SDL_MouseWheelEvent& wheel)
{ }

void CMyApp::Resize(int _w, int _h)
{
	glViewport(0, 0, _w, _h);
	m_matProj = glm::perspective(45.0f, _w / static_cast<float>(_h), 0.01f, 100.0f);
}