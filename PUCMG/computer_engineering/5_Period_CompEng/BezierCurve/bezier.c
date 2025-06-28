/**
*   Pontifícia Universidade Católica de Minas Gerais
*   Engenharia de Computação
*   Ryan Lemes Bezerra
**/

#include<stdio.h>
#include<stdlib.h>
#include<math.h>
#include<SDL2/SDL.h>

SDL_Window* window = NULL;
SDL_Renderer* renderer = NULL;
int mousePosX , mousePosY ;
int xnew , ynew ;

/*Função responsável por desenhar os pixels na tela*/
void drawCircle(int xc, int yc, int x, int y)
{
    SDL_RenderDrawPoint(renderer,xc+x,yc+y) ;
    SDL_RenderDrawPoint(renderer,xc-x,yc+y);
    SDL_RenderDrawPoint(renderer,xc+x,yc-y);
    SDL_RenderDrawPoint(renderer,xc-x,yc-y);
    SDL_RenderDrawPoint(renderer,xc+y,yc+x);
    SDL_RenderDrawPoint(renderer,xc-y,yc+x);
    SDL_RenderDrawPoint(renderer,xc+y,yc-x);
    SDL_RenderDrawPoint(renderer,xc-y,yc-x);
}

/*Função para desenho de circulo usando o algoritmo de Bresenham*/
void calcBresenhamCircle(int xc, int yc, int r)
{
    int x = 0, y = r;
    int d = 3 - 2 * r;
    while (y >= x)
    {
        /*para cada pixel nós desenhamos todos os 8 pixels*/
        drawCircle(xc, yc, x, y);
        x++;

        /*Verifica o parametro de decisão, para que assim atualize o valor de d*/
        if (d > 0)
        {
            y--;
            d = d + 4 * (x - y) + 10;
        }
        else
            d = d + 4 * x + 6;
        drawCircle(xc, yc, x, y);
    }
}

/* Função que recebe de entrada x pontos de controle e y pontos de controle e retorna a curva de bezier */
void bezierCurve(int x[] , int y[])
{
    double xu = 0.0 , yu = 0.0 , u = 0.0 ;
    int i = 0 ;
    for(u = 0.0 ; u <= 1.0 ; u += 0.0001)
    {
        xu = pow(1-u,3)*x[0]+3*u*pow(1-u,2)*x[1]+3*pow(u,2)*(1-u)*x[2]
             +pow(u,3)*x[3];
        yu = pow(1-u,3)*y[0]+3*u*pow(1-u,2)*y[1]+3*pow(u,2)*(1-u)*y[2]
            +pow(u,3)*y[3];
        SDL_RenderDrawPoint(renderer , (int)xu , (int)yu) ;
    }
}
int main(int argc, char* argv[])
{
    /*Inicializa sdl*/
    if (SDL_Init(SDL_INIT_EVERYTHING) == 0)
    {
        if(SDL_CreateWindowAndRenderer(640, 480, 0, &window, &renderer) == 0)
        {
            SDL_bool done = SDL_FALSE;

            int i = 0 ;
            int x[4] , y[4] , flagDrawn = 0 ;

            while (!done)
            {
                SDL_Event event;

                /*Seta a cor do fundo*/
                SDL_SetRenderDrawColor(renderer, 0, 0, 0, SDL_ALPHA_OPAQUE);
                SDL_RenderClear(renderer);

                /*Seta a cor da curva*/
                SDL_SetRenderDrawColor(renderer, 255, 255, 255, SDL_ALPHA_OPAQUE);

                /*
                    Criando uma curva de bezier com 4 pontos de controle
                    A quantidade do valor i adicionado aqui configura a quantidade de pontos de controle
                */
                if(i==4)
                {
                    bezierCurve(x , y) ;
                    flagDrawn = 1 ;
                }

                /*seta o circulo de controle P0, com suas configurações como cor e opacidade*/
                SDL_SetRenderDrawColor(renderer, 128, 128, 128, SDL_ALPHA_OPAQUE);
                calcBresenhamCircle(x[0] , y[0] , 8) ;

                /*seta a linha entre os pontos de controle P0 e P1, com suas configurações como cor e opacidade*/
                SDL_SetRenderDrawColor(renderer, 255, 0, 0, SDL_ALPHA_OPAQUE);
                SDL_RenderDrawLine(renderer , x[0] , y[0] , x[1] , y[1]) ;

                /*seta o circulo de controle P1, com suas configurações como cor e opacidade*/
                SDL_SetRenderDrawColor(renderer, 128, 128, 128, SDL_ALPHA_OPAQUE);
                calcBresenhamCircle(x[1] , y[1] , 8) ;

                /*seta a linha entre os pontos de controle P1 e P2, com suas configurações como cor e opacidade*/
                SDL_SetRenderDrawColor(renderer, 255, 0, 0, SDL_ALPHA_OPAQUE);
                SDL_RenderDrawLine(renderer , x[1] , y[1] , x[2] , y[2]) ;

                /*seta o circulo de controle P2, com suas configurações como cor e opacidade*/
                SDL_SetRenderDrawColor(renderer, 128, 128, 128, SDL_ALPHA_OPAQUE);
                calcBresenhamCircle(x[2] , y[2] , 8) ;

                /*seta a linha entre os pontos de controle P2 e P3, com suas configurações como cor e opacidade*/
                SDL_SetRenderDrawColor(renderer, 255, 0, 0, SDL_ALPHA_OPAQUE);
                SDL_RenderDrawLine(renderer , x[2] , y[2] , x[3] , y[3]) ;

                /*seta o circulo de controle P3, com suas configurações como cor e opacidade*/
                SDL_SetRenderDrawColor(renderer, 128, 128, 128, SDL_ALPHA_OPAQUE);
                calcBresenhamCircle(x[3] , y[3] , 8) ;

                /*pesquisando eventos do mouse sdl*/
                if (SDL_PollEvent(&event))
                {
                    /* caso selecione o botão x encerra a tela */
                    if (event.type == SDL_QUIT)
                    {
                        done = SDL_TRUE;
                    }
                    /*quando o botão do mouse está pressionado*/
                    if(event.type == SDL_MOUSEBUTTONDOWN)
                    {
                        /*Caso o o otão esteja pressionado, armazena o ponto clicado como ponto de controle*/
                        if(event.button.button == SDL_BUTTON_LEFT)
                        {
                            /*Salva somente 4 pontos de controle*/
                            if(i < 4)
                            {
                                printf("Control Point(P%d):(%d,%d)\n"
                                ,i,mousePosX,mousePosY) ;

                                /* salva as posições x e y do mouse nos vetores de controle.*/
                                x[i] = mousePosX ;
                                y[i] = mousePosY ;
                                i++ ;
                            }
                        }
                    }
                    /*evento quando o mouse está em movimento*/
                    if(event.type == SDL_MOUSEMOTION)
                    {
                        /*captura a posição x e y do mouse*/
                        xnew = event.motion.x ;
                        ynew = event.motion.y ;

                        int j ;

                        /* Depois que a curva de bezier é calculada altera as coordenadas do ponto de controle  */
                        if(flagDrawn == 1)
                        {
                            for(j = 0 ; j < i ; j++)
                            {
                                /*Verifica se o mouse está em uma posição dentro dos circulos de controle
                                e troca a posição do ponto de controle para a nova posição do mouse */
                                if((float)sqrt(abs(xnew-x[j]) * abs(xnew-x[j])
                                     + abs(ynew-y[j]) * abs(ynew-y[j])) < 8.0)
                                {
                                    /*troca a posição do jésimo ponto de controle*/
                                    x[j] = xnew ;
                                    y[j] = ynew ;
                                    printf("Changed Control Point(P%d):(%d,%d)\n"
                                           ,j,xnew,ynew) ;
                                }
                            }
                        }
                        /*atualiza a posição do mouse de acordo com a posição que vem capturado*/
                        mousePosX = xnew ;
                        mousePosY = ynew ;
                    }
                }
                /*Renderiza a tela*/
                SDL_RenderPresent(renderer);
            }
        }
        /*destroy a tela renderizada*/
        if (renderer)
        {
            SDL_DestroyRenderer(renderer);
        }
        if (window)
        {
            SDL_DestroyWindow(window);
        }
    }
    SDL_Quit();
    return 0;
}
