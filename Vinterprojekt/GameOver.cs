using Raylib_cs;

public class GameOver
{
    public static void GameEnd()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
            Raylib.DrawText("Game Over", Raylib.GetScreenWidth() / 2 - 375, Raylib.GetScreenHeight() / 2 - 80, 150, Color.RED);
            Raylib.DrawText("Press 'Enter' to continue", Raylib.GetScreenWidth() / 2 - 310, Raylib.GetScreenHeight() / 2 + 150, 50, Color.RED);
            Raylib.EndDrawing();



            if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
            {
                vars.end = false;
                vars.menu = true;
                return;
            }
        }
    }
}