// Copyright Digipen 2026
// Created 09/07/2026 by Kishan S Patel
// Team Gross Incandescence

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Godot;

namespace project.content.camera;

/// <summary>
///   A photo taken by <see cref="Camera" />
/// </summary>
/// <param name="contents">Pixel contents of the photo</param>
/// <param name="name">Name of the photo, used to determine filepath</param>
public partial class Photo(Image contents, string name) : GodotObject {
  /// <summary>
  ///   User directory containing all saved photos
  /// </summary>
  public const string PhotoFolderPath = "user://photos";

  /// <summary>
  ///   File extension for photos, we only support PNG
  /// </summary>
  public const string PhotoExtension = "png";

  /// <summary>
  ///   Pixel contents of the photo
  /// </summary>
  public Image Contents { set; get; } = contents;

  /// <summary>
  ///   Name of the photo
  /// </summary>
  public string Name { set; get; } = name;

  /// <summary>
  ///   Save this photo to the users computer
  /// </summary>
  public void Save() {
    EnsurePhotoDirectory();
    Contents.SavePng(PhotoFolderPath.PathJoin($"{Name}.png"));
  }

  /// <summary>
  ///   Ensures that the photo folder exists, creating it if
  ///   required
  /// </summary>
  static void EnsurePhotoDirectory() {
    if (DirAccess.DirExistsAbsolute(PhotoFolderPath)) return;
    DirAccess.MakeDirRecursiveAbsolute(PhotoFolderPath);
  }


  /// <summary>
  ///   Attempts to load a folder from a path
  /// </summary>
  /// <param name="path"></param>
  /// <returns></returns>
  public static Photo? LoadFromPath(string path) {
    if (!FileAccess.FileExists(path)) return null;

    Image? image = Image.LoadFromFile(path);

    if (image is null) return null;

    string name = path.GetBaseName();

    return new Photo(image, name);
  }

  public static async Task<Photo[]> LoadAllPhotosAsync() {
    return await Task.Run(LoadAllPhotos);
  }

  /// <summary>
  ///   Loads all photos in the photo directory
  /// </summary>
  /// <returns>Array of all photos that were loaded properly</returns>
  public static Photo[] LoadAllPhotos() {
    EnsurePhotoDirectory();

    DirAccess? dir = DirAccess.Open(PhotoFolderPath);

    if (dir is null) {
      GD.PushWarning("Failed to open Photo folder: ", DirAccess.GetOpenError());
      return [];
    }

    Photo[] files = ListDirEnumerable(dir)
      .Select(relativePath => PhotoFolderPath.PathJoin(relativePath))
      .Where(FileAccess.FileExists) // filter for only files, not directories
      .Where(file => file.GetExtension() == PhotoExtension)
      .Select(LoadFromPath)
      .OfType<Photo>() // Filters out Photo? / null values
      .ToArray();

    return files;
  }

  /// <summary>
  ///   Lists all files/directory paths inside a directory through the IEnumerable API
  /// </summary>
  /// <param name="dir"></param>
  /// <returns></returns>
  public static IEnumerable<string> ListDirEnumerable(DirAccess dir) {
    dir.ListDirBegin();

    string? path = dir.GetNext();

    while (!string.IsNullOrEmpty(path)) yield return path;


    dir.ListDirEnd();
  }
}