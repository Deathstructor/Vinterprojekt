using Raylib_cs;

bool menu = false, start = true; // Bools för att ladda in menyn eller själva spelet
Color playColor = Color.BLUE, exitColor = Color.BLUE; // Variabler för knapparnas färg (underlättar för att göra "hover" effekten)

//Skapar ett fönster
Raylib.InitWindow(1280, 720, "Breakout");
Raylib.SetTargetFPS(60);

// Laddar in menyn eller spelet beroende på vilken bool som är sann / falsk.
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
    //Knapparna
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
        
        // Kollar om muspekaren är på en knapp och ändrar färgen om den är på en knapp
        if (Raylib.GetMouseX() >= Raylib.GetScreenWidth() / 2 - 160 && Raylib.GetMouseX() <= Raylib.GetScreenWidth() / 2 + 140 && Raylib.GetMouseY() >= 350 && Raylib.GetMouseY() <= 450)
        {
            playColor = Color.DARKBLUE;

            //Laddar in spelet om man klickar på "start" knappen
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

            // Stänger ner spelet om man trycker på "exit knappen"
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