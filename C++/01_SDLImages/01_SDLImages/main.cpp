#include <SDL.h>
#include <SDL_image.h>
#include <iostream>

void exitProgram()
{
	std::cout << "Kil�p�shez nyomj meg egy billenty�t..." << std::endl;
	std::cin.get();
}

int main( int argc, char* args[] )
{
	// �ll�tsuk be, hogy kil�p�s el�tt h�vja meg a rendszer az exitProgram() f�ggv�nyt - K�rd�s: mi lenne en�lk�l?
	atexit( exitProgram );

	//
	// 1. l�p�s: inicializ�ljuk az SDL-t
	//

	// a grafikus alrendszert kapcsoljuk csak be, ha gond van, akkor jelezz�k �s l�pj�n ki
	if ( SDL_Init( SDL_INIT_VIDEO ) == -1 )
	{
		// irjuk ki a hibat es terminaljon a program
		std::cout << "[SDL ind�t�sa]Hiba az SDL inicializ�l�sa k�zben: " << SDL_GetError() << std::endl;
		return 1;
	}
			
	//
	// 2. l�p�s: hozzuk l�tre az ablakot, amire rajzolni fogunk
	//

	SDL_Window *win = 0;
    win = SDL_CreateWindow( "Hello SDL!",				// az ablak fejl�ce
							100,						// az ablak bal-fels� sark�nak kezdeti X koordin�t�ja
							100,						// az ablak bal-fels� sark�nak kezdeti Y koordin�t�ja
							640,						// ablak sz�less�ge
							480,						// �s magass�ga
							SDL_WINDOW_SHOWN);			// megjelen�t�si tulajdons�gok

	// ha nem siker�lt l�trehozni az ablakot, akkor �rjuk ki a hib�t, amit kaptunk �s l�pj�nk ki
    if (win == 0)
	{
		std::cout << "[Ablak l�trehoz�sa]Hiba az SDL inicializ�l�sa k�zben: " << SDL_GetError() << std::endl;
        return 1;
    }

	//
	// 3. l�p�s: hozzunk l�tre egy renderel�t, rajzol�t
	//

    SDL_Renderer *ren = 0;
    ren = SDL_CreateRenderer(	win, // melyik ablakhoz rendelj�k hozz� a renderert
								-1,  // melyik index� renderert inicializ�ljuka
									 // a -1 a harmadik param�terben meghat�rozott ig�nyeinknek megfelel� els� renderel�t jelenti
								SDL_RENDERER_ACCELERATED | SDL_RENDERER_PRESENTVSYNC);	// az ig�nyeink, azaz
																						// hardveresen gyors�tott �s vsync-et bev�r�
    if (ren == 0)
	{
        std::cout << "[Renderer l�trehoz�sa]Hiba az SDL inicializ�l�sa k�zben: " << SDL_GetError() << std::endl;
        return 1;
    }

	//
	// 3. l�p�s: t�lst�nk be egy k�pf�jlt
	//
	SDL_Texture* tex = IMG_LoadTexture( ren, "kep.png" );
	if ( tex == 0 )
	{
        std::cout << "[K�p bet�lt�se] Hiba: " << IMG_GetError() << std::endl;
		SDL_DestroyWindow( win );
        return 1;
	}


	//
	// 4. l�p�s: ind�tsuk el a f� �zenetfeldolgoz� ciklust
	// 

	// v�get kell-e �rjen a program fut�sa?
	bool quit = false;
	// feldolgozand� �zenet ide ker�l
	SDL_Event ev;
	// eg�r X �s Y koordin�t�i
	Sint32 mouseX = 0, mouseY = 0;

	SDL_Rect textRect;
	SDL_QueryTexture(tex, nullptr, nullptr, &textRect.w, &textRect.h);
	textRect.x = 0; textRect.y = 0;

	while (!quit)
	{
		// am�g van feldolgozand� �zenet dolgozzuk fel mindet:
		while ( SDL_PollEvent(&ev) )
		{
			switch (ev.type)
			{
			case SDL_QUIT:
				quit = true;
				break;
			case SDL_KEYDOWN:
				if (ev.key.keysym.sym == SDLK_UP)
				{
					--textRect.w;
					--textRect.h;
				}
				else if (ev.key.keysym.sym == SDLK_DOWN)
				{
					++textRect.w;
					++textRect.h;
				}
				if ( ev.key.keysym.sym == SDLK_ESCAPE )
					quit = true;
				break;
			case SDL_MOUSEMOTION:
				mouseX = ev.motion.x;
				mouseY = ev.motion.y;
				break;
			case SDL_MOUSEBUTTONUP:
				// eg�rgomb felenged�s�nek esem�nye; a felengedett gomb a ev.button.button -ban tal�lhat�
				// a lehets�ges gombok a k�vetkez�ek: SDL_BUTTON_LEFT, SDL_BUTTON_MIDDLE, 
				//		SDL_BUTTON_RIGHT, SDL_BUTTON_WHEELUP, SDL_BUTTON_WHEELDOWN
				break;
			}
		}

		// t�r�lj�k a h�tteret feh�rre
		SDL_SetRenderDrawColor(ren, 255, 255, 255, 255);
		SDL_RenderClear(ren);

		// rajzoljuk ki a bet�lt�tt k�pet az eg�kurzor k�r�!
		SDL_Rect cursor_rect;
		SDL_QueryTexture( tex, 0, 0, &cursor_rect.w, &cursor_rect.h );
		cursor_rect.x = mouseX - cursor_rect.w / 2;
		cursor_rect.y = mouseY - cursor_rect.h / 2;
		
		SDL_RenderCopy( ren,				// melyik renderel�re rajzoljunk
						tex,				// melyik text�r�t rajzoljuk r�
						&textRect,					// a text�ra melyik al-rect-j�t
						&cursor_rect );		// a renderel� fel�let�nek mely r�sz�re

		// 1. feladat: pattogtassuk a k�perny�n a kirajzolt k�pet! Induljon el a k�p
		//    a k�perny� k�zep�r�l egy ir�nyba �s amikor valamelyik sz�le az ablak sz�l�hez
		//    k�zeledik, pattanjon vissza!

		// 2. feladat: az animation_sheet.gif-ben tal�lhat� anim�ci�t rajzoljuk ki �gy,
		//    hogy a fut�s egy f�zisa 3 mp-ig tartson! Tipp: a source rect-et kell m�dos�tani!

		// 3. feladat: ne legyen pattog�s, a felhaszn�l� tudjon jobbra-balra futtatni a 
		//    figur�t a balra/jobbra billenty�k lenyom�s�val. Ha elengedi a billenty�t,
		//    akkor �lljon meg a figura, ahol van (tipp: kell �j k�pf�jl)

		// jelen�ts�k meg a backbuffer tartalm�t
		SDL_RenderPresent(ren);
	}



	//
	// 4. l�p�s: l�pj�nk ki
	// 

	SDL_DestroyTexture( tex );
	SDL_DestroyRenderer( ren );
	SDL_DestroyWindow( win );

	SDL_Quit();

	return 0;
}