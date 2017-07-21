#include "MyApp.h"
#include <math.h>
#include <iostream>

CMyApp::CMyApp(void)
{
	m_vaoID = 0;
	m_vboID = 0;
}


CMyApp::~CMyApp(void)
{
}

bool CMyApp::Init()
{
	// törlési szín legyen kékes
	glClearColor(0.125f, 0.25f, 0.5f, 1.0f);

	glEnable(GL_CULL_FACE); // kapcsoljuk be a hatrafele nezo lapok eldobasat
	// glEnable(GL_DEPTH_TEST); // mélységi teszt bekapcsolása (takarás)

	//
	// geometria letrehozasa
	//

	Vertex vert[62];

	drawRectangle(0, 0, 0.5, 0.5, vert, 0, glm::vec3(1, 0, 0));
	drawRectangle(-0.125, 0.5, 0.09, 0.5, vert, 6, glm::vec3(1, 1, 1));
	drawRectangle(0.125, 0.5, 0.09, 0.5, vert, 12, glm::vec3(1, 1, 1));

	drawCircle(0.125, 0.5, 0.04, vert, 18, glm::vec3(0, 0, 0));
	drawCircle(-0.125, 0.5, 0.04, vert, 40, glm::vec3(0, 0, 0));

	// 1 db VAO foglalasa
	glGenVertexArrays(1, &m_vaoID);
	// a frissen generált VAO beallitasa aktívnak
	glBindVertexArray(m_vaoID);
	
	// hozzunk létre egy új VBO erőforrás nevet
	glGenBuffers(1, &m_vboID); 
	glBindBuffer(GL_ARRAY_BUFFER, m_vboID); // tegyük "aktívvá" a létrehozott VBO-t
	// töltsük fel adatokkal az aktív VBO-t
	glBufferData( GL_ARRAY_BUFFER,	// az aktív VBO-ba töltsünk adatokat
				  sizeof(vert),		// ennyi bájt nagyságban
				  vert,	// erről a rendszermemóriabeli címről olvasva
				  GL_STATIC_DRAW);	// úgy, hogy a VBO-nkba nem tervezünk ezután írni és minden kirajzoláskor felhasnzáljuk a benne lévő adatokat
	

	// VAO-ban jegyezzük fel, hogy a VBO-ban az első 3 float sizeof(Vertex)-enként lesz az első attribútum (pozíció)
	glEnableVertexAttribArray(0); // ez lesz majd a pozíció
	glVertexAttribPointer(
		(GLuint)0,				// a VB-ben található adatok közül a 0. "indexű" attribútumait állítjuk be
		3,				// komponens szam
		GL_FLOAT,		// adatok tipusa
		GL_FALSE,		// normalizalt legyen-e
		sizeof(Vertex),	// stride (0=egymas utan)
		0				// a 0. indexű attribútum hol kezdődik a sizeof(Vertex)-nyi területen belül
	); 

	// a második attribútumhoz pedig a VBO-ban sizeof(Vertex) ugrás után sizeof(glm::vec3)-nyit menve újabb 3 float adatot találunk (szín)
	glEnableVertexAttribArray(3); // ez lesz majd a szín - de miért 3-as attribútum?
	glVertexAttribPointer(
		(GLuint)3,
		3, 
		GL_FLOAT,
		GL_FALSE,
		sizeof(Vertex),
		(void*)(sizeof(glm::vec3)) );

	glBindVertexArray(0); // feltöltüttük a VAO-t, kapcsoljuk le
	glBindBuffer(GL_ARRAY_BUFFER, 0); // feltöltöttük a VBO-t is, ezt is vegyük le

	return true;
}

void CMyApp::Clean()
{
	glDeleteBuffers(1, &m_vboID);
	glDeleteVertexArrays(1, &m_vaoID);
}

void CMyApp::Update()
{
}


void CMyApp::Render()
{
	// töröljük a frampuffert (GL_COLOR_BUFFER_BIT) és a mélységi Z puffert (GL_DEPTH_BUFFER_BIT)
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	// kapcsoljuk be a VAO-t (a VBO jön vele együtt)
	glBindVertexArray(m_vaoID);

	// kirajzolás
	glDrawArrays(GL_TRIANGLE_STRIP, 0, 6);
	glDrawArrays(GL_TRIANGLE_STRIP, 6, 6);
	glDrawArrays(GL_TRIANGLE_STRIP, 12, 6);

	glDrawArrays(GL_TRIANGLE_FAN, 18, 22);
	glDrawArrays(GL_TRIANGLE_FAN, 40, 22);

	// VAO kikapcsolasa
	glBindVertexArray(0);
}

void CMyApp::KeyboardDown(SDL_KeyboardEvent& key)
{
}

void CMyApp::KeyboardUp(SDL_KeyboardEvent& key)
{
}

void CMyApp::MouseMove(SDL_MouseMotionEvent& mouse)
{

}

void CMyApp::MouseDown(SDL_MouseButtonEvent& mouse)
{
}

void CMyApp::MouseUp(SDL_MouseButtonEvent& mouse)
{
}

void CMyApp::MouseWheel(SDL_MouseWheelEvent& wheel)
{
}

// a két paraméterbe az új ablakméret szélessége (_w) és magassága (_h) található
void CMyApp::Resize(int _w, int _h)
{
	glViewport(0, 0, _w, _h );
}

void CMyApp::drawRectangle(float x, float y, float w, float h, Vertex vec[], int start, const glm::vec3& colour)
{
	const glm::vec3 first = glm::vec3(x + w / 2.0, y - h / 2.0, 0);
	const glm::vec3 second = glm::vec3(x + w / 2.0, y + h / 2.0, 0);
	const glm::vec3 third = glm::vec3(x - w / 2.0, y + h / 2.0, 0);
	const glm::vec3 fourth = glm::vec3(x - w / 2.0, y - h / 2.0, 0);
	vec[start].p = first;
	vec[start + 1].p = second;
	vec[start + 2].p = third;
	vec[start + 3].p = first;
	vec[start + 4].p = fourth;
	vec[start + 5].p = third;
	for (int i = start; i < start + 6; ++i)
	{
		vec[i].c = colour;
	}
}

void CMyApp::drawCircle(float x, float y, float r, Vertex vec[], int start, const glm::vec3& colour)
{
	vec[start].p = glm::vec3(x, y, 0);

	for (int i = start; i < start + 21; ++i)
	{
		vec[i + 1].p = glm::vec3(cos(2 * M_PI / 20.0 * i) * r + x, sin(2 * M_PI / 20.0 * i) * r + y, 0);
	}
	for (int i = start; i < start + 22; ++i)
	{
		vec[i].c = colour;
	}
}