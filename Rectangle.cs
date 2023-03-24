using Godot;

[Tool]
public partial class Rectangle : Control {

  [Export] public Vector2 Dimensions { get; set; } = new(60.0f, 80.0f);

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
    DrawRect(new Rect2(-0.5f * Dimensions, Dimensions), Colors.White, IsActive);
  }

  public void ActivateFor(float time_in_seconds) {
    IsActive = true;
    timer.Start(time_in_seconds);
    QueueRedraw();
  }
}
