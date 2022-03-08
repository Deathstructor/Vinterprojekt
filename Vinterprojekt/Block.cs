using Raylib_cs;
using System.Numerics;

public class Block
{
    int x;
    int y;
    int w = 60;
    int h = 30;
    bool exist = true;

    // Blockets position och dimensioner
    Rectangle rectangle;

    public Block(int x_, int y_)
    {
        rectangle = new Rectangle(x_, y_, w, h);
        x = x_;
        y = y_;
    }

    // Kollar om blocket borde visas eller inte
    public void Display()
    {
        if (exist)
        {
            Raylib.DrawRectangleRec(rectangle, Color.WHITE);
        }
    }

    // Kollar kollisionen mellan bollen och blocken
    public int Collision(int ballX, int ballY, int ballSize)
    {
        if (!exist) return 0; // Säger att inget bör hända om blocket inte existerar

        if (Raylib.CheckCollisionCircleRec(new Vector2(ballX, ballY), ballSize, rectangle))
        {
            exist = false;

            // Kollar om kollisionen sker på en rad (horisontellt) eller en kollumn (vertikalt)
            if (ballX < rectangle.x || ballX > rectangle.x + rectangle.width)
            {
                return -1;
            }
            return 1;
        }

        return 0;
    }
}