using Godot;

public partial class Parameters : Node {

  [ExportCategory("Distribution")]
  [Export] public float CircleWeight    { get; set; } = 0.5f;
  [Export] public float RectangleWeight { get; set; } = 0.3f;
  [Export] public float BeepWeight      { get; set; } = 0.2f;

  [ExportCategory("Speed")]
  [Export] public float Interval    { get; set; } = 3.0f;
  [Export] public float Decrement   { get; set; } = 0.05f;
  [Export] public float MinInterval { get; set; } = 1.0f;
  [Export] public float DisplayTime { get; set; } = 0.5f;

}
