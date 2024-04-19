using System.Numerics;
using Calcium;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Fruits;

class Program {
    static void Main(string[] args) {
        InitWindow(Global.WindowWidth, Global.WindowHeight, "Fruits");
        SetTargetFPS(60);

        var Fruits = new List<Fruit>();
        var Dead = new List<Fruit>();
        var New = new List<Fruit>();

        var NextFruit = RNG.Range(0, 4);
        
        // var Timer = 0;
        // var TimeToSet = 5;

        while (!WindowShouldClose()) {
            // Update
            if (IsMouseButtonPressed(MouseButton.Left)) {
                var MousePos = GetMousePosition();
                Fruits.Add(new Fruit(MousePos, NextFruit));
                NextFruit = RNG.Range(0, 4);
            }

            // if (Timer == 0) {
            //     var Pos = new Vector2(RNG.Range(0, Global.WindowWidth), 40);
            //     Fruits.Add(new Fruit(Pos, NextFruit));
            //     NextFruit = RNG.Range(0, 4);
            //     Timer = TimeToSet;
            // } else {
            //     Timer--;
            // }

            var Delta = GetFrameTime();

            for (var i = Fruits.Count - 1; i >= 0; i--) {
                var F = Fruits[i];
                foreach (var Fruit in Fruits) {
                    if (Fruit != F) {
                        if (F.Collision(Fruit) && F.Stage == Fruit.Stage && !Dead.Contains(F) && !Dead.Contains(Fruit)) {
                            Dead.Add(F);
                            Dead.Add(Fruit);
                            if (F.Stage < 10) {
                                New.Add(new Fruit((F.Position + Fruit.Position) / 2, F.Stage + 1));
                            }
                        }
                    }
                }

                F.Update(Delta);
            }

            foreach (var F in Dead) {
                Fruits.Remove(F);
            }

            foreach (var F in New) {
                Fruits.Add(F);
            }

            Dead.Clear();
            New.Clear();

            // Draw
            BeginDrawing();
            ClearBackground(Color.Black);

            DrawLineV(GetMousePosition(), new Vector2(GetMouseX(), Global.WindowHeight), Color.White);

            for (var i = Fruits.Count - 1; i >= 0; i--) {
                var F = Fruits[i];
                F.Draw();
            }

            DrawCircleV(new Vector2(Global.WindowCenter.X, 40), Global.StageSizes[NextFruit], Global.StageColors[NextFruit]);

            DrawText($"FPS: {GetFPS()}", 10, 10, 10, Color.White);

            EndDrawing();
        }

        CloseWindow();
    }
}