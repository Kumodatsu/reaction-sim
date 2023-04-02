using System.Collections.Generic;
using Godot;

public partial class ParameterSelect : Node2D {

  [Export] public PackedScene MainScene { get; set; }

  private const string font_color = "theme_override_colors/font_color";
  private List<LineEdit> edits = new();

  public override void _Ready() {
    base._Ready();
    var @params = GetNode<Parameters>("/root/Parameters");
    foreach (LineEdit edit in GetTree().GetNodesInGroup("edits")) {
      edits.Add(edit);
      edit.TextChanged += str => {
        if (float.TryParse(str, out var val)) {
          edit.Set(font_color, Colors.White);
          @params.Set(edit.GetParent().Name, val);
        } else {
          edit.Set(font_color, Colors.Red);
        }
      };
    }
    GetNode<Button>("Canvas/ReferenceRect/Button").Pressed += () => {
      foreach (var edit in edits) {
        if (!float.TryParse(edit.Text, out _)) {
          return;
        }
      }
      GetTree().ChangeSceneToPacked(MainScene);
    };
  }



}
