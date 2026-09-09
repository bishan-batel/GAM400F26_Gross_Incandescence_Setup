// Copyright Digipen 2026
// Created 09/07/2026 by Kishan S Patel
// Team Gross Incandescence

using Godot;

namespace project.content.camera;

/// <summary>
///   Camera used by the player to take photos
/// </summary>
public partial class Camera : Node {
  public Photo TakePhoto() {
    Image image = GetCameraViewport().GetTexture().GetImage();
    string name = GeneratePhotoName();

    return new Photo(image, name);
  }

  /// <summary>
  ///   Gets the viewport used for the photo, this is separate from the
  ///   global viewport which includes UI and the such
  /// </summary>
  /// <returns></returns>
  public Viewport GetCameraViewport() {
    return GetViewport();
  }

  public static string GeneratePhotoName() {
    return Time.GetDatetimeStringFromSystem(false, true);
  }
}