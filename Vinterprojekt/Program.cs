using Raylib_cs;

//Skapar ett fönster
Raylib.InitWindow(1280, 720, "Breakout");
Raylib.SetTargetFPS(60);

bool quit = false;

// Laddar in menyn eller spelet beroende på vilken bool som är sann / falsk.
while(quit == false){
    if(vars.menu)
    {
        MainMenu();
    }
    if(vars.gameStart)
    {
        Game.RunGame();
    }
    if (vars.end)
    {
        GameOver.GameEnd();
    }
}

void MainMenu()
{
    //Knapparna
    Rectangle play = new Rectangle(Raylib.GetScreenWidth() / 2 - 160,  350, 300, 100);
    Rectangle exit = new Rectangle(Raylib.GetScreenWidth() / 2 - 160, 500, 300, 100);

    while(!Raylib.WindowShouldClose() && quit == false)
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawText("Breakout", Raylib.GetScreenWidth() / 2 - 240, 150, 100, Color.GREEN);

        Raylib.DrawText("Alpha " + vars.version, 30, Raylib.GetScreenHeight() - 50, 30, Color.WHITE);

        Raylib.DrawRectangleRec(play, vars.playColor);
        Raylib.DrawText("Start", Raylib.GetScreenWidth() / 2 - 80, 375, 50, Color.WHITE);

        Raylib.DrawRectangleRec(exit, vars.exitColor);
        Raylib.DrawText("Exit", Raylib.GetScreenWidth() / 2 - 50, 525, 50, Color.WHITE);

        Raylib.EndDrawing();
        
        // Kollar om muspekaren är på en knapp och ändrar färgen om den är på en knapp
        if (Raylib.GetMouseX() >= Raylib.GetScreenWidth() / 2 - 160 && Raylib.GetMouseX() <= Raylib.GetScreenWidth() / 2 + 140 && Raylib.GetMouseY() >= 350 && Raylib.GetMouseY() <= 450)
        {
            vars.playColor = Color.DARKBLUE;

            //Laddar in spelet om man klickar på "start" knappen
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                vars.gameStart = true;
                vars.menu = false;
                return;
            }
        } else
        {
            vars.playColor = Color.BLUE;
        }

        if (Raylib.GetMouseX() >= Raylib.GetScreenWidth() / 2 - 160 && Raylib.GetMouseX() <= Raylib.GetScreenWidth() / 2 + 140 && Raylib.GetMouseY() >= 500 && Raylib.GetMouseY() <= 600)
        {
            vars.exitColor = Color.DARKBLUE;

            // Stänger ner spelet om man trycker på "exit knappen"
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                quit = true;
                System.Console.WriteLine(quit);
                return;
            }
        }
        else
        {
            vars.exitColor = Color.BLUE;
        }
    }
}