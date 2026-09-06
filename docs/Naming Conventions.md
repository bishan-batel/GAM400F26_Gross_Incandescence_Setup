The naming convention for folders and files will be 90% snake_case, with the only exceptions being:
* Markdown files in `docs/`, whose name should just be a title
* C# Files, where the name should match the class they are implementing (eg. Player.cs, etc), meanig these will always be PascalCase


For godot resource files, do not use the optional specific naming such as *.mesh, *.material, *.shape, etc, just use .tres (or .res for extremely large things that need to be in binary format).