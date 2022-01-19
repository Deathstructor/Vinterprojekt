using Raylib_cs;

bool menu = false, start = true;
Color playColor = Color.BLUE, exitColor = Color.BLUE;

Raylib.InitWindow(1280, 720, "Breakout");
Raylib.SetTargetFPS(60);

if(menu)
{
    MainMenu();
}
if(start)
{
    Game.runGame();
}

void MainMenu() 
{
    Rectangle play = new Rectangle(Raylib.GetScreenWidth() / 2 - 160,  350, 300, 100);
    Rectangle exit = new Rectangle(Raylib.GetScreenWidth() / 2 - 160, 500, 300, 100);

    while(!Raylib.WindowShouldClose())
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawText("Breakout", Raylib.GetScreenWidth() / 2 - 240, 150, 100, Color.GREEN);

        Raylib.DrawRectangleRec(play, playColor);
        Raylib.DrawText("Start", Raylib.GetScreenWidth() / 2 - 80, 375, 50, Color.WHITE);

        Raylib.DrawRectangleRec(exit, exitColor);
        Raylib.DrawText("Exit", Raylib.GetScreenWidth() / 2 - 50, 525, 50, Color.WHITE);

        Raylib.EndDrawing();
        
        if (Raylib.GetMouseX() >= Raylib.GetScreenWidth() / 2 - 160 && Raylib.GetMouseX() <= Raylib.GetScreenWidth() / 2 + 140 && Raylib.GetMouseY() >= 350 && Raylib.GetMouseY() <= 450)
        {
            playColor = Color.DARKBLUE;
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                start = true;
                menu = false;
                return;
            }
        } else
        {
            playColor = Color.BLUE;
        }

        if (Raylib.GetMouseX() >= Raylib.GetScreenWidth() / 2 - 160 && Raylib.GetMouseX() <= Raylib.GetScreenWidth() / 2 + 140 && Raylib.GetMouseY() >= 500 && Raylib.GetMouseY() <= 600)
        {
            exitColor = Color.DARKBLUE;
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                Raylib.CloseWindow();
                return;
            }
        }
        else
        {
            exitColor = Color.BLUE;
        }
    }

}