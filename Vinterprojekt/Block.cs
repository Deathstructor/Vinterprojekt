using Raylib_cs;

public class Block
{
    int x;
    int y;
    int w = 60;
    int h = 30;
    bool exist = true;

    public Block(int x_, int y_)
    {
        x = x_;
        y = y_;
    }

    public void Display()
    {
        if (exist)
        {
            Raylib.DrawRectangle(x, y, w, h, Color.WHITE);
        }
    }

    public (int, int) Collision(int ballX, int ballY, int ballSize, (int, int) xy)
    {
        if (exist)
        {
            bool bottom = this.y + this.h >= ballY - ballSize,
            top = this.y <= ballY + ballSize,
            right = this.x + this.w >= ballX - ballSize,
            left = this.x <= ballX + ballSize;

            if (top && bottom && right && left)
            {
                if (ballX < x || ballX > x + w)
                {
                    exist = false;
                    return (xy.Item1 * -1, xy.Item2);
                } else
                {
                    exist = false;
                    return (xy.Item1, xy.Item2 * -1);
                }
            }

            // if (right && left)
            // {
            //     exist = false;
            //     return (xy.Item1 * -1, xy.Item2);
            // } else if (bottom && top)
            // {
            //     exist = false;
            //     return (xy.Item1, xy.Item2 * -1);
            // }
        }

        return xy;
    }
}