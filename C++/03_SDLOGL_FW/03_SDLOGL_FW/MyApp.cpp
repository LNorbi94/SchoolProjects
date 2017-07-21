#include "MyApp.h"
#include <math.h>

CMyApp::CMyApp(void)
{
}


CMyApp::~CMyApp(void)
{
}

bool CMyApp::Init()
{
	up = false;
	r = 0.125f;
	g = 0.25f;
	b = 0.5f;

	// törlési szín legyen kékes
	glClearColor(r, g, b, 1.0f);

	// kapcsoljuk be a hatrafele nezo lapok eldobasat
	glEnable(GL_CULL_FACE);
	glEnable(GL_DEPTH_TEST);

	return true;
}

void CMyApp::Clean()
{
}

void CMyApp::Update()
{
	if (up)
	{
		Uint32 tr = (SDL_GetTicks() - bgAnimStart) / 2000.0 * newR + (1 - (SDL_GetTicks() - bgAnimStart / 2000.0)) * r;
		Uint32 tb = (SDL_GetTicks() - bgAnimStart) / 2000.0 * newG + (1 - (SDL_GetTicks() - bgAnimStart / 2000.0)) * g;
		Uint32 tg = (SDL_GetTicks() - bgAnimStart) / 2000.0 * newB + (1 - (SDL_GetTicks() - bgAnimStart / 2000.0)) * b;
		glClearColor(tr, tg, tb, 1.0f);
		if (SDL_GetTicks() - bgAnimStart >= 2000)
		{
			up = !up;
			r = newR;
			g = newG;
			b = newB;
		}
	}
	else
	{
		glClearColor(r, g, b, 1.0f);
	}
}


void CMyApp::Render()
{
	// töröljük a frampuffert (GL_COLOR_BUFFER_BIT) és a mélységi Z puffert (GL_DEPTH_BUFFER_BIT)
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
}

void CMyApp::KeyboardDown(SDL_KeyboardEvent& key)
{
	if(!up)
	{
		if (key.keysym.sym == SDLK_a)
		{
			newR = 1.0;
			newG = 0.0;
			newB = 0.0;
		}
		else if (key.keysym.sym == SDLK_s)
		{
			newR = 0.0;
			newG = 1.0;
			newB = 0.0;
		}
		else if (key.keysym.sym == SDLK_d)
		{
			newR = 0.0;
			newG = 0.0;
			newB = 1.0;
		}
		bgAnimStart = SDL_GetTicks();
		up = !up;
	}
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