using Godot;

public partial class Beep : Node {
  [Export] public AudioStream Sound { get; set; } = null;

  private AudioStreamPlayer player;

  public override void _Ready() {
    base._Ready();
    player = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
    player.Stream = Sound;
  }

  public void Activate() => player.Play();
}