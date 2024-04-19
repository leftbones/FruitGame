using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Fruits;

class Fruit {
    public Vector2 Position { get; set; }
    public int Stage { get; set; }

    public Vector2 Velocity { get; set; }

    public float Size => Global.StageSizes[Stage];
    public Color Color => Global.StageColors[Stage];

    public Fruit(Vector2 position, int stage) {
        Position = position;
        Stage = stage;
        Velocity = Vector2.Zero;
    }

    public bool Collision(Fruit other) {
        var Distance = Vector2.Distance(Position, other.Position);
        if (Distance <= Size + other.Size) {
            var Dir = Vector2.Normalize(other.Position - Position);
            var RV = Velocity - other.Velocity;
            var Mass = 1;

            float I = 1 * Vector2.Dot(RV, Dir) / Mass;
            Velocity -= I * Mass * Dir * Global.Bounce;
            other.Velocity += I * Mass * Dir * Global.Bounce;

            var Overlap = 0.5f * (Distance - Size - other.Size);
            Position += Overlap * Dir;
            other.Position -= Overlap * Dir;

            return true;
        }

        return false;
    }

    public void Update(float delta) {
        Velocity += new Vector2(0, Global.Gravity);
        Position += Velocity * delta;

        if (Position.Y + Size > Global.WindowHeight) {
            Position = new Vector2(
                Position.X,
                Global.WindowHeight - Size
            );
            Velocity *= new Vector2(1, -Global.Bounce);
        }

        if (Position.X + Size > Global.WindowWidth) {
            Position = new Vector2(
                Global.WindowWidth - Size,
                Position.Y
            );
            Velocity *= new Vector2(-Global.Bounce, 1);
        }

        if (Position.X - Size < 0) {
            Position = new Vector2(
                Size,
                Position.Y
            );
            Velocity *= new Vector2(-Global.Bounce, 1);
        }
    }

    public void Draw() {
        DrawCircleV(Position, Size, Color);
    }
}