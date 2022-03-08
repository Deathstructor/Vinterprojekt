using System;
using System.Threading;
using System.Numerics;
using Raylib_cs;

public class Game
{
    public static void RunGame()
    {
        int playerPos = Raylib.GetScreenWidth() / 2 - 80; // Spelarens position
        int ballPosX = Raylib.GetScreenWidth() / 2, ballPosY = 634; // Bollens position
        float ballSpeedX = 4, ballSpeedY = -4;  // Bollens hastighet och riktning
        bool start = false; // Bool som säger att spelet har startat - används för att inte loopa en if sats
        Random rdm = new Random(); // Slumpgenerator
        Block[,] b = new Block[17, 10];



        for (var i = 0; i < b.GetLength(0); i++)
        {
            for (var j = 0; j < b.GetLength(1); j++)
            {
                b[i, j] = new Block(i * Raylib.GetScreenWidth() / 20 + 100, j * Raylib.GetScreenHeight() / 20 + 25);
            }
        }



        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();

            // Ritar ut spelaren
            Raylib.ClearBackground(Color.BLACK);
            Raylib.DrawRectangle(playerPos, 650, 160, 20, Color.WHITE);

            // Ritar ut bollen
            Raylib.DrawCircle(ballPosX, ballPosY, 15, Color.WHITE);

            // Ritar ut block
            for (var i = 0; i < b.GetLength(0); i++)
            {
                for (var j = 0; j < b.GetLength(1); j++)
                {
                    b[i, j].Display();
                }
            }

            Raylib.EndDrawing();

            bool hasBouncedH = false;
            bool hasBouncedV = false;
            // Kollar om bollen kolliderar med blocken
            for (var i = 0; i < b.GetLength(0); i++)
            {
                for (var j = 0; j < b.GetLength(1); j++)
                {
                    Block block = b[i, j];
                    int c = block.Collision(ballPosX, ballPosY, 15);
                    if (c < 0 && !hasBouncedH) // horizontal
                    {
                        ballSpeedX = -ballSpeedX;
                        hasBouncedH = true;
                    }
                    else if (c > 0 && !hasBouncedV) // vertical
                    {
                        ballSpeedY = -ballSpeedY;
                        hasBouncedV = true;
                    }
                }
            }



            // Kollar om man trycker på D, A, högerpil, eller vänsterpil och förflyttar spelaren om en av dessa är nedtryckt
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && playerPos > 0 || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && playerPos > 0)
            {
                playerPos -= 7;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && playerPos + 160 < Raylib.GetScreenWidth() || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && playerPos + 160 < Raylib.GetScreenWidth())
            {
                playerPos += 7;
            }

            // Slumpar en riktning som bollen ska åka åt när man startar rundan
            if (start == false)
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));

                // En vektor som bestämmer vilker riktning bollen ska åka åt
                float arcVar = rdm.Next(-171, 171) / 100f;
                var v2 = new Vector2(arcVar, 2 - Math.Abs(arcVar));

                if (rdm.Next(2) == 1) { ballSpeedX *= -1; } // Slumpar om bollen ska åka åt höger eller vänster

                ballSpeedX += v2.X; // Får bollen att åka åt det bestämda hållet
                start = true;
            }

            // Får bollen att att studsa om den når en kant, inklusive spelaren
            if (ballPosX >= Raylib.GetScreenWidth() - 15 || ballPosX <= 15)
            {
                ballSpeedX *= -1;
            }
            if (ballPosY <= 15 || ballPosX >= playerPos && ballPosX <= playerPos + 160 && ballPosY >= 635 && ballPosY <= 685)
            {
                ballSpeedY *= -1;
            }
            if (ballPosY >= Raylib.GetScreenHeight() + 15)
            {
                vars.gameStart = false;
                vars.end = true;
                return;
            }

            // Får bollen att röra på sig
            ballPosY += (int)ballSpeedY;
            ballPosX += (int)ballSpeedX;
        }
    }
}