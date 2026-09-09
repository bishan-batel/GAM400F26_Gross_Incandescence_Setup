// Copyright Digipen 2026
// Created 09/07/2026 by Kishan S Patel
// Team Gross Incandescence

using Godot;
using project.content.photo;

namespace project.content.camera;

/// <summary>
///   Camera used by the player to take photos
/// </summary>
public partial class Camera : Node {
  public Photo TakePhoto() {
    Image image = GetCameraViewport().GetTexture().GetImage();


    GetViewport().GetTexture().GetImage().SavePng("user://photo.png");

    return new Photo(image, GeneratePhotoName());
  }

  /// <summary>
  ///   Gets the viewport used for the photo, this is separate from the
  ///   global viewport which includes UI and the such
  /// </summary>
  /// <returns></returns>
  public Viewport GetCameraViewport() {
    return GetViewport();
  }

  /// <summary>
  /// Generates a semi-unique photo name from the current date
  /// </summary>
  /// <returns></returns>
  public static string GeneratePhotoName() {
    return Time.GetDatetimeStringFromSystem(false, true);
  }
}