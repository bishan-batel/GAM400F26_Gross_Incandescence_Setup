
Requirements pertaining to devops (in order of importance):
* GDExtension for rendering / automation to build this, maybe commit the binaries for the gdextension when they are in the addon folder?
* Workflow for automatically building / deploying the project itself & unit tests
* Custom Build of Godot-Mono (requires generation of Mono Glue -> generation of GDExtension api bindings)
  * A script that gets the right version of prebuilt godot.exe, script would also need to run 'dotnet add ...' for you to allow for the right NUPKG to be used for the solution.