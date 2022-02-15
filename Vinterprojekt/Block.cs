using Raylib_cs;
using System.Numerics;

public class Block
{
    int x;
    int y;
    int w = 60;
    int h = 30;
    bool exist = true;

    Rectangle rectangle;

    public Block(int x_, int y_)
    {
        rectangle = new Rectangle(x_, y_, w, h);
        x = x_;
        y = y_;
    }

    public void Display()
    {
        if (exist)
        {
            Raylib.DrawRectangleRec(rectangle, Color.WHITE);
        }
    }

    public int Collision(int ballX, int ballY, int ballSize)
    {
        if (!exist) return 0;

        if (Raylib.CheckCollisionCircleRec(new Vector2(ballX, ballY), ballSize, rectangle))
        {
            exist = false;
            if (ballX < rectangle.x || ballX > rectangle.x + rectangle.width)
            {
                return -1;
            }
            return 1;
        }

        return 0;
    }
}