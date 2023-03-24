using System.Collections.Generic;
using Godot;

[Tool]
public partial class Circle : Control {
  
  [Export] public float Radius { get; set; } = 30.0f;

  public static readonly List<Color> PossibleColors = new() {
    Colors.Red,
    Colors.Blue,
    Colors.White,
    Colors.Yellow,
    Colors.Green,
  };

  public bool IsActive { get; set; } = false;

  private Timer timer;

  public override void _Ready() {
    base._Ready();
    timer = GetNode<Timer>("Timer");
    timer.Timeout += () => {
      IsActive = false;
      QueueRedraw();
    };
  }

  public override void _Draw() {
    base._Draw();
    if (IsActive) {
      Color color = PossibleColors[SimScene.RNG.Next(0, PossibleColors.Count)];
      DrawCircle(Vector2.Zero, Radius, color);
    } else {
      DrawArc(Vector2.Zero, Radius, 0.0f, Mathf.Tau, 360, Colors.White);
    }
  }

  public void ActivateFor(float time_in_seconds) {
    IsActive = true;
    timer.Start(time_in_seconds);
    QueueRedraw();
  }
}
