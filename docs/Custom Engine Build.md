For a complete non-euclidean game we will need to use a custom build of godot, with the main reason being godot's lack of support for oblique near-clipping planes on cameras. This change itself should not be very heavy and the use of a custom build will be supported by Fanta who is dedicated dev ops. This will be their primary focus from Week 5+.

The development cycle for the custom build should be relatively infrequent as everyone updating to a new editor is always painful (even if Fanta makes it as easy as possible), and frequent changes should ideally be kept in `non_euclidean_gdext/`.


Relative Links:
* [Building for Windows](https://docs.godotengine.org/en/4.4/contributing/development/compiling/compiling_for_windows.html)
* [Compilation with .NET](https://docs.godotengine.org/en/4.4/contributing/development/compiling/compiling_with_dotnet.html) (`scons ... module_mono=yes ...`)
* [Custom build of Godot 4.5 with oblique near-clipping plane support](https://github.com/V-Sekai/godot/tree/override_projection_4.2)