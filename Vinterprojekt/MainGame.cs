using System;
using System.Threading;
using System.Numerics;
using Raylib_cs;

public class Game
{
    public static void runGame()
    {
        // Variabel för spelarens position - används för att förflytta spelaren
        int playerPos = Raylib.GetScreenWidth() / 2 - 80;
        int ballPosX = Raylib.GetScreenWidth() / 2, ballPosY = 635;
        float ballSpeedX = 3, ballSpeedY = -3;
        bool start = false;
        Random rdm = new Random();

        while (!Raylib.WindowShouldClose())
        {

            Raylib.BeginDrawing();

            // Ritar ut spelaren
            Raylib.ClearBackground(Color.BLACK);
            Raylib.DrawRectangle(playerPos, 650, 160, 20, Color.WHITE);

            // Ritar ut bollen
            Raylib.DrawCircle(ballPosX, ballPosY, 15, Color.WHITE);

            Raylib.EndDrawing();



            // Kollar om man trycker på D, A, högerpil, eller vänsterpil och förflyttar spelaren om en av dessa är nedtryckt
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && playerPos > 0 || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && playerPos > 0)
            {
                playerPos -= 5;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && playerPos + 160 < Raylib.GetScreenWidth() || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && playerPos + 160 < Raylib.GetScreenWidth())
            {
                playerPos += 5;
            }

            if (start == false)
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));

                //Om man gör rmd.NextDouble så kommer det bara vara mellan 0 och 1, så vi vill ha 0.3 till 1.7
                float arcVar = rdm.Next(-171, 171) / 100f;
                var v2 = new Vector2(arcVar, 2 - Math.Abs(arcVar));

                if (rdm.Next(2) == 1) { ballSpeedX *= -1; }

                ballSpeedX += v2.X;
                start = true;
            }

            if (ballPosX >= Raylib.GetScreenWidth() - 15 || ballPosX <= 15)
            {
                ballSpeedX *= -1;
            }
            if (ballPosY <= 15 || ballPosX >= playerPos && ballPosX <= playerPos + 160 && ballPosY >= 650)
            {
                ballSpeedY *= -1;
            }

            ballPosY += (int) ballSpeedY;
            ballPosX += (int) ballSpeedX;
        }
    }
}