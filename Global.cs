using System.Numerics;
using Raylib_cs;

namespace Fruits;

static class Global {
    public static int WindowWidth = 800;
    public static int WindowHeight = 600;

    public static Vector2 WindowCenter = new (WindowWidth / 2, WindowHeight / 2);

    public static float Gravity = 9.8f;
    public static float Bounce = 0.3f;

    public static float[] StageSizes = [
        10.0f,              // Cherry
        15.0f,              // Strawberry
        25.0f,              // Grape
        30.0f,              // Dekopon
        35.0f,              // Persimmon
        45.0f,              // Apple
        50.0f,              // Pear
        60.0f,              // Peach
        65.0f,              // Pineapple
        75.0f,              // Cantaloupe
        80.0f,              // Watermelon
    ];

    public static Color[] StageColors = [
        Color.Red,          // Cherry
        Color.Pink,         // Strawberry
        Color.Purple,       // Grape
        Color.Gold,         // Dekopon
        Color.Orange,       // Persimmon
        Color.Red,          // Apple
        Color.Yellow,       // Pear
        Color.Pink,         // Peach
        Color.Yellow,       // Pineapple
        Color.Beige,        // Cantaloupe
        Color.Green,        // Watermelon
    ];
}