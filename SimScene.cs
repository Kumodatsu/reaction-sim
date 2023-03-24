using Godot;
using System;

public partial class SimScene : Node2D {
  public static Random RNG { get; private set; } = new();

  [ExportCategory("Distribution")]
  [Export] public float CircleWeight    { get; set; } = 0.5f;
  [Export] public float RectangleWeight { get; set; } = 0.3f;
  [Export] public float BeepWeight      { get; set; } = 0.2f;

  [ExportCategory("Speed")]
  [Export] public float Interval    { get; set; } = 3.0f;
  [Export] public float Decrement   { get; set; } = 0.05f;
  [Export] public float MinInterval { get; set; } = 1.0f;
  [Export] public float DisplayTime { get; set; } = 0.5f;

  private float TotalWeight
    => CircleWeight + RectangleWeight + BeepWeight;

  private Timer       timer;
  private CanvasLayer canvas;

  public override void _Ready() {
    base._Ready();
    timer  = GetNode<Timer>("Timer");
    canvas = GetNode<CanvasLayer>("Canvas");
    timer.Timeout += NewSignal;
    timer.WaitTime = Interval;
    timer.Start();
  }

  private void NewSignal() {
    timer.WaitTime -= Decrement;
    if (timer.WaitTime < MinInterval) {
      timer.WaitTime = MinInterval;
    }

    var r = TotalWeight * (float) RNG.NextDouble();
    if (r < CircleWeight) {
      var circles = GetTree().GetNodesInGroup("circles");
      var circle  = circles[RNG.Next(0, circles.Count)] as Circle;
      circle.ActivateFor(DisplayTime);
      return;
    }
    r -= CircleWeight;
    if (r < RectangleWeight) {
      var rectangles = GetTree().GetNodesInGroup("rectangles");
      var rectangle  = rectangles[RNG.Next(0, rectangles.Count)] as Rectangle;
      rectangle.ActivateFor(DisplayTime);
      return;
    }
    r -= RectangleWeight;
    if (r < BeepWeight) {
      var beeps = GetTree().GetNodesInGroup("beeps");
      var beep  = beeps[RNG.Next(0, beeps.Count)] as Beep;
      beep.Activate();
      return;
    }
  }
}
