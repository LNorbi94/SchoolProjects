#include <SDL.h>
#include <iostream>

int main(int argc, char** args)
{
	if(SDL_Init(SDL_INIT_VIDEO) == -1)
	{
		std::cout << "[Starting SDL] Error during initialization: " << SDL_GetError() << std::endl;
		return 1;
	}

	SDL_Window* win = nullptr;
	win = SDL_CreateWindow("01. Practical", 100, 100, 1920, 1080, SDL_WINDOW_SHOWN | SDL_WINDOW_FULLSCREEN);
	if(!win)
	{
		std::cout << "[Creating Window] Error during initialization: " << SDL_GetError() << std::endl;
		return 1;
	}

	SDL_Renderer* ren = nullptr;
	ren = SDL_CreateRenderer(win, -1, SDL_RENDERER_ACCELERATED | SDL_RENDERER_PRESENTVSYNC);
	if(!ren)
	{
		std::cout << "[Creating Renderer] Error during initialization: " << SDL_GetError() << std::endl;
		return 1;
	}

	SDL_SetRenderDrawColor(ren, 0, 0, 0, 255);
	SDL_RenderClear(ren);

	// 1. feladat: Hello
	
	SDL_SetRenderDrawColor(ren, 0, 255, 0, 255);
    
    // H
    SDL_RenderDrawLine(ren, 10, 10, 10, 60);
    SDL_RenderDrawLine(ren, 30, 10, 30, 60);
    SDL_RenderDrawLine(ren, 10, 30, 30, 30);
    // E
    SDL_RenderDrawLine(ren, 50, 10, 50, 60);
    SDL_RenderDrawLine(ren, 50, 10, 80, 10);
    SDL_RenderDrawLine(ren, 50, 30, 80, 30);
    SDL_RenderDrawLine(ren, 50, 60, 80, 60);
    // L
    SDL_RenderDrawLine(ren, 90, 10, 90, 60);
    SDL_RenderDrawLine(ren, 90, 60, 120, 60);
    // L
    SDL_RenderDrawLine(ren, 130, 10, 130, 60);
    SDL_RenderDrawLine(ren, 130, 60, 160, 60);

	SDL_RenderPresent(ren);
	SDL_Delay(2000);

	SDL_DestroyRenderer(ren);
	SDL_DestroyWindow(win);
	SDL_Quit();

	return 0;
}