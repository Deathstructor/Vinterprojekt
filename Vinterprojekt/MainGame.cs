using Raylib_cs;

public class Game
{
    public static void runGame()
    {
        int playerPos = Raylib.GetScreenWidth() / 2 - 100;
        Rectangle player = new Rectangle(playerPos, 650, 160, 20);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);
            Raylib.DrawRectangleRec(player, Color.WHITE);

            Raylib.EndDrawing();



            if (Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                playerPos--;
            }
        }
    }
}