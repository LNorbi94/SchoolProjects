#include "MyApp.h"
#include "GLUtils.hpp"

#include <GL/GLU.h>
#include <math.h>

CMyApp::CMyApp(void)
{
	m_vaoID = 0;
	m_vboID = 0;
	m_programID = 0;
	m_waterTextureID = 0;

	m_meshFej = 0;
	m_meshLabak = 0;
}

glm::vec3 CMyApp::toDesc(float fi, float theta) {
	return glm::vec3(sin(fi)*cos(theta), cos(fi), -sin(fi)*sin(theta));
}

glm::vec3	CMyApp::GetUV(float u, float v)
{
	u *= 2 * 3.1415f;
	v *= 3.1415f;
	float cu = cosf(u), su = sinf(u), cv = cosf(v), sv = sinf(v);
	float r = 5;

	return glm::vec3(r*cu*sv, r*cv, r*su*sv);
}


CMyApp::~CMyApp(void)
{
}

GLuint CMyApp::GenTexture()
{
	unsigned char tex[512][512][3];

	for (int i = 0; i<512; ++i)
	{
		for (int j = 0; j<512; ++j)
		{
			tex[i][j][0] = 44;
			tex[i][j][1] = 44;
			tex[i][j][2] = 44;
		}
	}

	const int N = 5000;
	for (int i = 0; i < N; ++i)
	{
		glm::vec4 pont = glm::vec4(cos(1 / static_cast<float>(N) * i * 2 * M_PI) * 20 * 512 / 40.0
		, 0
		, -sin(1 / static_cast<float>(N) * i * 2 * M_PI) * 5 * 512 / 40.0
		, 1);
		pont = glm::translate<float>(256, 0, 256) * glm::rotate<float>(45, 0, 1, 0) * pont;
		tex[static_cast<int>(pont.x)][static_cast<int>(pont.z)][0] = 57;
		tex[static_cast<int>(pont.x)][static_cast<int>(pont.z)][1] = 195;
		tex[static_cast<int>(pont.x)][static_cast<int>(pont.z)][2] = 79;
	}

	GLuint tmpID;

	// generáljunk egy textúra erőforrás nevet
	glGenTextures(1, &tmpID);
	// aktiváljuk a most generált nevű textúrát
	glBindTexture(GL_TEXTURE_2D, tmpID);
	// töltsük fel adatokkal az...
	gluBuild2DMipmaps(GL_TEXTURE_2D,	// aktív 2D textúrát
		GL_RGB8,		// a vörös, zöld és kék csatornákat 8-8 biten tárolja a textúra
		512, 512,		// 256x256 méretű legyen
		GL_RGB,				// a textúra forrása RGB értékeket tárol, ilyen sorrendben
		GL_UNSIGNED_BYTE,	// egy-egy színkopmonenst egy unsigned byte-ról kell olvasni
		tex);				// és a textúra adatait a rendszermemória ezen szegletéből töltsük fel
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);	// bilineáris szűrés kicsinyítéskor
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);	// és nagyításkor is
	glBindTexture(GL_TEXTURE_2D, 0);

	return tmpID;
}

bool CMyApp::Init()
{
	// törlési szín legyen kékes
	glClearColor(0.125f, 0.25f, 0.5f, 1.0f);

	glEnable(GL_CULL_FACE); // kapcsoljuk be a hatrafele nezo lapok eldobasat
	glEnable(GL_DEPTH_TEST); // mélységi teszt bekapcsolása (takarás)
	glCullFace(GL_BACK); // GL_BACK: a kamerától "elfelé" néző lapok, GL_FRONT: a kamera felé néző lapok

						 //
						 // geometria letrehozasa
						 //

	Vertex vert[] =
	{
		//          x,  y, z               nx,ny,nz          s, t
		{ glm::vec3(-20, 0, -20), glm::vec3(0, 1, 0), glm::vec2(0, 0) },
		{ glm::vec3(-20, 0,  20), glm::vec3(0, 1, 0), glm::vec2(0, 1) },
		{ glm::vec3(20, 0, -20), glm::vec3(0, 1, 0), glm::vec2(1, 0) },
		{ glm::vec3(20, 0,  20), glm::vec3(0, 1, 0), glm::vec2(1, 1) },
	};

	// indexpuffer adatai
	GLushort indices[] =
	{
		// 1. háromszög
		0,1,2,
		// 2. háromszög
		2,1,3,
	};
	const int N = 10;
	const int M = 10;

	Vertex vertGomb[(N + 1)*(M + 1)];
	for (int i = 0; i <= N; ++i)
		for (int j = 0; j <= M; ++j)
		{
			float u = i / (float)N;
			float v = j / (float)M;

			vertGomb[i + j*(N + 1)].p = GetUV(u, v);
			vertGomb[i + j*(N + 1)].c = glm::normalize(vert[i + j*(N + 1)].p);
		}

	// indexpuffer adatai: NxM n�gysz�g = 2xNxM h�romsz�g = h�romsz�glista eset�n 3x2xNxM index
	GLushort indicesGomb[3 * 2 * (N)*(M)];
	for (int i = 0; i<N; ++i)
		for (int j = 0; j<M; ++j)
		{
			// minden n�gysz�gre csin�ljunk kett� h�romsz�get, amelyek a k�vetkez� 
			// (i,j) indexekn�l sz�letett (u_i, v_i) param�ter�rt�kekhez tartoz�
			// pontokat k�tik �ssze:
			//
			//		(i,j+1)
			//		  o-----o(i+1,j+1)
			//		  |\    |			a = p(u_i, v_i)
			//		  | \   |			b = p(u_{i+1}, v_i)
			//		  |  \  |			c = p(u_i, v_{i+1})
			//		  |   \ |			d = p(u_{i+1}, v_{i+1})
			//		  |	   \|
			//	(i,j) o-----o(i+1, j)
			//
			// - az (i,j)-hez tart�z� 1D-s index a VBO-ban: i+j*(N+1)
			// - az (i,j)-hez tart�z� 1D-s index az IB-ben: i*6+j*6*(N+1) 
			//		(mert minden n�gysz�gh�z 2db h�romsz�g = 6 index tartozik)
			//
			indicesGomb[6 * i + j * 3 * 2 * (N)+0] = (i)+(j)*	(N + 1);
			indicesGomb[6 * i + j * 3 * 2 * (N)+1] = (i + 1) + (j)*	(N + 1);
			indicesGomb[6 * i + j * 3 * 2 * (N)+2] = (i)+(j + 1)*(N + 1);
			indicesGomb[6 * i + j * 3 * 2 * (N)+3] = (i + 1) + (j)*	(N + 1);
			indicesGomb[6 * i + j * 3 * 2 * (N)+4] = (i + 1) + (j + 1)*(N + 1);
			indicesGomb[6 * i + j * 3 * 2 * (N)+5] = (i)+(j + 1)*(N + 1);
		}

	glGenVertexArrays(1, &m_vaoID);
	glBindVertexArray(m_vaoID);

	glGenBuffers(1, &m_vboID);
	glBindBuffer(GL_ARRAY_BUFFER, m_vboID); // tegyük "aktívvá" a létrehozott VBO-t
											// töltsük fel adatokkal az aktív VBO-t
	glBufferData(GL_ARRAY_BUFFER,  // az aktív VBO-ba töltsünk adatokat
		sizeof(vert),     // ennyi bájt nagyságban
		vert, // erről a rendszermemóriabeli címről olvasva
		GL_STATIC_DRAW);  // úgy, hogy a VBO-nkba nem tervezünk ezután írni és minden kirajzoláskor felhasnzáljuk a benne lévő adatokat


						  // VAO-ban jegyezzük fel, hogy a VBO-ban az első 3 float sizeof(Vertex)-enként lesz az első attribútum (pozíció)
	glEnableVertexAttribArray(0); // ez lesz majd a pozíció
	glVertexAttribPointer(
		0,              // a VB-ben található adatok közül a 0. "indexű" attribútumait állítjuk be
		3,              // komponens szam
		GL_FLOAT,       // adatok tipusa
		GL_FALSE,       // normalizalt legyen-e
		sizeof(Vertex), // stride (0=egymas utan)
		0               // a 0. indexű attribútum hol kezdődik a sizeof(Vertex)-nyi területen belül
		);

	// a második attribútumhoz pedig a VBO-ban sizeof(Vertex) ugrás után sizeof(glm::vec3)-nyit menve újabb 3 float adatot találunk (szín)
	glEnableVertexAttribArray(1); // ez lesz majd a szín
	glVertexAttribPointer(
		1,
		3,
		GL_FLOAT,
		GL_FALSE,
		sizeof(Vertex),
		(void*)(sizeof(glm::vec3)));

	// textúrakoordináták bekapcsolása a 2-es azonosítójú attribútom csatornán
	glEnableVertexAttribArray(2);
	glVertexAttribPointer(
		2,
		2,
		GL_FLOAT,
		GL_FALSE,
		sizeof(Vertex),
		(void*)(2 * sizeof(glm::vec3)));

	// index puffer létrehozása
	glGenBuffers(1, &m_ibID);
	// a VAO észreveszi, hogy bind-olunk egy index puffert és feljegyzi, hogy melyik volt ez!
	glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, m_ibID);
	glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(indices), indices, GL_STATIC_DRAW);

	glBindVertexArray(0); // feltöltüttük a VAO-t, kapcsoljuk le
	glBindBuffer(GL_ARRAY_BUFFER, 0); // feltöltöttük a VBO-t is, ezt is vegyük le
	glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, 0); // feltöltöttük a VBO-t is, ezt is vegyük le

	glGenVertexArrays(1, &g_vaoID);
	glBindVertexArray(g_vaoID);

	glGenBuffers(1, &g_vboID);
	glBindBuffer(GL_ARRAY_BUFFER, g_vboID); // tegyük "aktívvá" a létrehozott VBO-t
											// töltsük fel adatokkal az aktív VBO-t
	glBufferData(GL_ARRAY_BUFFER,  // az aktív VBO-ba töltsünk adatokat
		sizeof(vertGomb),     // ennyi bájt nagyságban
		vertGomb, // erről a rendszermemóriabeli címről olvasva
		GL_STATIC_DRAW);  // úgy, hogy a VBO-nkba nem tervezünk ezután írni és minden kirajzoláskor felhasnzáljuk a benne lévő adatokat


						  // VAO-ban jegyezzük fel, hogy a VBO-ban az első 3 float sizeof(Vertex)-enként lesz az első attribútum (pozíció)
	glEnableVertexAttribArray(0); // ez lesz majd a pozíció
	glVertexAttribPointer(
		0,              // a VB-ben található adatok közül a 0. "indexű" attribútumait állítjuk be
		3,              // komponens szam
		GL_FLOAT,       // adatok tipusa
		GL_FALSE,       // normalizalt legyen-e
		sizeof(Vertex), // stride (0=egymas utan)
		0               // a 0. indexű attribútum hol kezdődik a sizeof(Vertex)-nyi területen belül
		);

	// a második attribútumhoz pedig a VBO-ban sizeof(Vertex) ugrás után sizeof(glm::vec3)-nyit menve újabb 3 float adatot találunk (szín)
	glEnableVertexAttribArray(1); // ez lesz majd a szín
	glVertexAttribPointer(
		1,
		3,
		GL_FLOAT,
		GL_FALSE,
		sizeof(Vertex),
		(void*)(sizeof(glm::vec3)));

	// textúrakoordináták bekapcsolása a 2-es azonosítójú attribútom csatornán
	glEnableVertexAttribArray(2);
	glVertexAttribPointer(
		2,
		2,
		GL_FLOAT,
		GL_FALSE,
		sizeof(Vertex),
		(void*)(2 * sizeof(glm::vec3)));

	// index puffer létrehozása
	glGenBuffers(1, &g_ibID);
	// a VAO észreveszi, hogy bind-olunk egy index puffert és feljegyzi, hogy melyik volt ez!
	glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, g_ibID);
	glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(indicesGomb), indicesGomb, GL_STATIC_DRAW);

	glBindVertexArray(0); // feltöltüttük a VAO-t, kapcsoljuk le
	glBindBuffer(GL_ARRAY_BUFFER, 0); // feltöltöttük a VBO-t is, ezt is vegyük le
	glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, 0); // feltöltöttük a VBO-t is, ezt is vegyük le

											  //
											  // shaderek betöltése
											  //
	GLuint vs_ID = loadShader(GL_VERTEX_SHADER, "myVert.vert");
	GLuint fs_ID = loadShader(GL_FRAGMENT_SHADER, "myFrag.frag");

	// a shadereket tároló program létrehozása
	m_programID = glCreateProgram();

	// adjuk hozzá a programhoz a shadereket
	glAttachShader(m_programID, vs_ID);
	glAttachShader(m_programID, fs_ID);

	// VAO-beli attribútumok hozzárendelése a shader változókhoz
	// FONTOS: linkelés előtt kell ezt megtenni!
	glBindAttribLocation(m_programID,    // shader azonosítója, amiből egy változóhoz szeretnénk hozzárendelést csinálni
		0,              // a VAO-beli azonosító index
		"vs_in_pos");   // a shader-beli változónév
	glBindAttribLocation(m_programID, 1, "vs_in_col");
	glBindAttribLocation(m_programID, 2, "vs_in_tex0");

	// illesszük össze a shadereket (kimenő-bemenő változók összerendelése stb.)
	glLinkProgram(m_programID);

	// linkeles ellenorzese
	GLint infoLogLength = 0, result = 0;

	glGetProgramiv(m_programID, GL_LINK_STATUS, &result);
	glGetProgramiv(m_programID, GL_INFO_LOG_LENGTH, &infoLogLength);
	if (GL_FALSE == result)
	{
		std::vector<char> ProgramErrorMessage(infoLogLength);
		glGetProgramInfoLog(m_programID, infoLogLength, NULL, &ProgramErrorMessage[0]);
		fprintf(stdout, "%s\n", &ProgramErrorMessage[0]);

		char* aSzoveg = new char[ProgramErrorMessage.size()];
		memcpy(aSzoveg, &ProgramErrorMessage[0], ProgramErrorMessage.size());

		std::cout << "[app.Init()] Sáder Huba panasza: " << aSzoveg << std::endl;

		delete aSzoveg;
	}

	// mar nincs ezekre szukseg
	glDeleteShader(vs_ID);
	glDeleteShader(fs_ID);

	//
	// egyéb inicializálás
	//

	// vetítési mátrix létrehozása
	m_matProj = glm::perspective(45.0f, 640 / 480.0f, 1.0f, 1000.0f);

	// shader-beli transzformációs mátrixok címének lekérdezése
	m_loc_mvp = glGetUniformLocation(m_programID, "MVP");

	m_loc_texture = glGetUniformLocation(m_programID, "texture");

	//
	// egyéb erőforrások betöltése
	//

	// textúra betöltése
	m_waterTextureID = TextureFromFile("texture.bmp");
	talajTextureID = GenTexture();
	fejTextureID = TextureFromFile("fej.jpg");
	labakTextureID = TextureFromFile("labak.jpg");

	// mesh betoltese
	m_meshFej = ObjParser::parse("fej.obj");
	m_meshFej->initBuffers();

	m_meshLabak = ObjParser::parse("labak.obj");
	m_meshLabak->initBuffers();


	return true;
}

void CMyApp::Clean()
{
	delete m_meshFej;
	delete m_meshLabak;
	glDeleteTextures(1, &m_waterTextureID);

	glDeleteBuffers(1, &m_vboID);
	glDeleteVertexArrays(1, &m_vaoID);

	glDeleteProgram(m_programID);
}

void CMyApp::Update()
{
	m_matView = glm::lookAt(eye, at, glm::vec3(0, 1, 0));
}


void CMyApp::DrawGround()
{
	// a talaj kirajzolasahoz szukseges shader beallitasa
	glUseProgram(m_programID);

	// shader parameterek beállítása
	/*

	GLM transzformációs mátrixokra példák:
	glm::rotate<float>( szög, tengely_x, tengely_y, tengely_z) <- tengely_{xyz} körüli elforgatás
	glm::translate<float>( eltol_x, eltol_y, eltol_z) <- eltolás
	glm::scale<float>( s_x, s_y, s_z ) <- léptékezés

	*/
	m_matWorld = glm::mat4(1.0f);
	glm::mat4 mvp = m_matProj * m_matView * m_matWorld;
	// majd küldjük át a megfelelő mátrixokat!
	glUniformMatrix4fv(m_loc_mvp,// erre a helyre töltsünk át adatot
		1,          // egy darab mátrixot
		GL_FALSE,   // NEM transzponálva
		&(mvp[0][0])); // innen olvasva a 16 x sizeof(float)-nyi adatot

					   // aktiváljuk a 0-és textúra mintavételező egységet
	glActiveTexture(GL_TEXTURE0);
	// aktiváljuk a generált textúránkat
	glBindTexture(GL_TEXTURE_2D, talajTextureID);
	// textúra mintavételező és shader-beli sampler2D összerendelése
	glUniform1i(m_loc_texture,  // ezen azonosítójú sampler 2D
		0);             // olvassa az ezen indexű mintavételezőt

						// kapcsoljuk be a VAO-t (a VBO jön vele együtt)
	glBindVertexArray(m_vaoID);

	// kirajzolás
	glDrawElements(GL_TRIANGLES,       // primitív típus
		6,                  // hany csucspontot hasznalunk a kirajzolashoz
		GL_UNSIGNED_SHORT,  // indexek tipusa
		0);                 // indexek cime

							// VAO kikapcsolasa
	glBindVertexArray(0);

	// textúra kikapcsolása
	glBindTexture(GL_TEXTURE_2D, 0);

	glUseProgram(0);
}

void CMyApp::DrawMesh()
{
	// a mesh kirajzolasahoz hasznalt shader bekapcsolasa
	glUseProgram(m_programID);

	m_matWorld = glm::rotate<float>(45, 0, 1, 0) * glm::translate<float>(20 * cos(SDL_GetTicks() / 3000.0f * 2 * M_PI), 0, -5 * sin(SDL_GetTicks() / 3000.0f * 2 * M_PI));
	glm::mat4 mvp = m_matProj * m_matView * m_matWorld;
	// majd küldjük át a megfelelő mátrixokat!
	glUniformMatrix4fv(m_loc_mvp,// erre a helyre töltsünk át adatot
		1,          // egy darab mátrixot
		GL_FALSE,   // NEM transzponálva
		&(mvp[0][0])); // innen olvasva a 16 x sizeof(float)-nyi adatot

					   // aktiváljuk a 0-és textúra mintavételező egységet
	glActiveTexture(GL_TEXTURE0);
	// aktiváljuk a generált textúránkat
	glBindTexture(GL_TEXTURE_2D, fejTextureID);
	// textúra mintavételező és shader-beli sampler2D összerendelése
	glUniform1i(m_loc_texture,  // ezen azonosítójú sampler 2D
		0);             // olvassa az ezen indexű mintavételezőt


	m_meshFej->draw();
	m_matWorld *= glm::rotate<float>(SDL_GetTicks() / 500.0 * 360, 0, 1, 0);
	mvp = m_matProj * m_matView * m_matWorld;
	// majd küldjük át a megfelelő mátrixokat!
	glUniformMatrix4fv(m_loc_mvp,// erre a helyre töltsünk át adatot
		1,          // egy darab mátrixot
		GL_FALSE,   // NEM transzponálva
		&(mvp[0][0])); // innen olvasva a 16 x sizeof(float)-nyi adatot

					   // aktiváljuk a 0-és textúra mintavételező egységet
	glBindTexture(GL_TEXTURE_2D, labakTextureID);
	m_meshLabak->draw();

	/* gomb */
	m_matWorld = glm::translate<float>(0, 15, 0);
	mvp = m_matProj * m_matView * m_matWorld;
	// majd küldjük át a megfelelő mátrixokat!
	glUniformMatrix4fv(m_loc_mvp,// erre a helyre töltsünk át adatot
		1,          // egy darab mátrixot
		GL_FALSE,   // NEM transzponálva
		&(mvp[0][0])); // innen olvasva a 16 x sizeof(float)-nyi adatot
	glBindVertexArray(g_vaoID);
	glDrawElements(GL_TRIANGLES, 3 * 2 * 10 * 10, GL_UNSIGNED_SHORT, 0);

	glBindVertexArray(0);

	glUseProgram(0);
}

void CMyApp::Render()
{
	// töröljük a frampuffert (GL_COLOR_BUFFER_BIT) és a mélységi Z puffert (GL_DEPTH_BUFFER_BIT)
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	DrawGround();
	DrawMesh();
}

void CMyApp::KeyboardDown(SDL_KeyboardEvent& key)
{
	switch (key.keysym.sym) {
	case SDLK_w:
		eye += forward*glm::vec3(0.1);
		at = toDesc(fi, theta) + eye;
		break;
	case SDLK_s:
		eye -= forward*glm::vec3(0.1);
		at = toDesc(fi, theta) + eye;
		break;
	case SDLK_a:
		eye += glm::normalize(glm::cross(glm::vec3(0, 1, 0), forward))*glm::vec3(0.1);
		at = toDesc(fi, theta) + eye;
		break;
	case SDLK_d:
		eye -= glm::normalize(glm::cross(glm::vec3(0, 1, 0), forward))*glm::vec3(0.1);
		at = toDesc(fi, theta) + eye;
		break;
	}

}

void CMyApp::KeyboardUp(SDL_KeyboardEvent& key)
{
}

void CMyApp::MouseMove(SDL_MouseMotionEvent& mouse) {
	if (mouse.state & SDL_BUTTON_LMASK) {
		theta -= mouse.xrel*0.005;
		fi += mouse.yrel*0.005;
		fi = glm::clamp(fi, 0.001f, 3.13f);
		at = toDesc(fi, theta) + eye;
		forward = glm::normalize(at - eye);
	}
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
	glViewport(0, 0, _w, _h);

	m_matProj = glm::perspective(45.0f,       // 90 fokos nyilasszog
		_w / (float)_h,   // ablakmereteknek megfelelo nezeti arany
		0.01f,          // kozeli vagosik
		100.0f);        // tavoli vagosik
}