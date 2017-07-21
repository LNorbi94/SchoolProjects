#include <SDL.h>
#include <iostream>

void exitProgram()
{
	std::cout << "Kilépéshez nyomj meg egy billentyűt..." << std::endl;
	std::cin.get();
}

int main(int argc, char* args[])
{
	const int upperLimit = 100;
	const int lowerLimit = 10;
	const int scale = 2;
	const int numOfCircles = 5;

	atexit(exitProgram);

	if (SDL_Init(SDL_INIT_VIDEO) == -1)
	{
		std::cout << "[SDL indítása] Hiba az SDL inicializálása közben: " << SDL_GetError() << std::endl;
		return 1;
	}

	SDL_Window *win = nullptr;
	win = SDL_CreateWindow("Nagyon kis beadandó. [01]", 100, 100, 800, 600, SDL_WINDOW_SHOWN);

	if (!win)
	{
		std::cout << "[Ablak létrehozása] Hiba az SDL inicializálása közben: " << SDL_GetError() << std::endl;
		return 1;
	}

	SDL_Renderer *ren = nullptr;
	ren = SDL_CreateRenderer(win, -1, SDL_RENDERER_ACCELERATED | SDL_RENDERER_PRESENTVSYNC);

	if (!ren)
	{
		std::cout << "[Renderer létrehozása] Hiba az SDL inicializálása közben: " << SDL_GetError() << std::endl;
		return 1;
	}

	bool quit = false;
	int r = lowerLimit;

	SDL_Event ev;
	Sint32 mouseX = 0, mouseY = 0;

	while (!quit)
	{
		while (SDL_PollEvent(&ev))
		{
			switch (ev.type)
			{
				case SDL_QUIT:
					quit = true;
					break;
				case SDL_KEYDOWN:
					if (ev.key.keysym.sym == SDLK_ESCAPE)
					{
						quit = true;
					}
					else if (ev.key.keysym.sym == SDLK_UP)
					{
						if (r <= upperLimit)
							r += scale;
					}
					else if (ev.key.keysym.sym == SDLK_DOWN)
					{
						if (r >= lowerLimit)
							r -= scale;
					}
					break;
				case SDL_MOUSEMOTION:
					mouseX = ev.motion.x;
					mouseY = ev.motion.y;
					break;
				case SDL_MOUSEBUTTONUP:
					break;
			}
		}
		SDL_SetRenderDrawColor(ren, 255, 255, 255, 255);
		SDL_RenderClear(ren);

		SDL_SetRenderDrawColor(ren, 255, 0, 0, 255);
		
		int insR = static_cast<int>((sin(SDL_GetTicks() / 1000.0 / 1.0 * 2 * M_PI) * 0.5 + 0.5) * (r + 20) + 10);
		float rotate = SDL_GetTicks() / 1000 * M_PI * 2.0;

		for (int j = 0; j < numOfCircles; ++j)
		{
			for (int i = 0; i < 103; ++i)
			{
				SDL_RenderDrawLine( ren,
					insR * cos(2 * M_PI / 103.0 * i) + mouseX + 50 * cos(2 * M_PI / numOfCircles * 1.0 * j - rotate),
					insR * sin(2 * M_PI / 103.0 * i) + mouseY + 50 * sin(2 * M_PI / numOfCircles * 1.0 * j - rotate),
					insR * cos(2 * M_PI / 103.0 * (i + 1)) + mouseX + 50 * cos(2 * M_PI / numOfCircles * 1.0 * j - rotate),
					insR * sin(2 * M_PI / 103.0 * (i + 1)) + mouseY + 50 * sin(2 * M_PI / numOfCircles * 1.0 * j - rotate)
				);
			}
		}

		SDL_RenderPresent(ren);
	}

	SDL_DestroyRenderer(ren);
	SDL_DestroyWindow(win);

	SDL_Quit();

	return 0;
}
