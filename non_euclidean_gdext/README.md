This subfolder contains the source code for the GDExtension for non euclidean features, note this is seperate from the eventual custom build of Godot we are going to use.

Requirements to work on this are:
* [SCONS](https://github.com/SCons/scons)
* Some C++ Compiler (preferrably clang, as LLVM tends to just be nicer)

## Build Instructions
```bash 
# Make sure you have the git submodules expanded
git submodule update --init --recursive

cd non_euclidean_gdext/

scons use_llvm=yes compiledb=yes
# You can opmit use_llvm if you wish to use another compiler. After compilation, it will dump the gdextension library files in `./project/addons/non_euclidean/bin/`
# Compiledb will generate a compile_commands file that lets intellisense work in your editor
```


## Test Project
The `project/` folder here is meant to be a test project isolated to just this GDExtension. Eventually there should be automation to move the `non_euclidean_gdext/project/addons/non_euclidean` into the root project, `project/addons/non_euclidean`.


## Links for Fanta 
* [Example Tutorial that includes more detailed build instructions](https://docs.godotengine.org/en/stable/tutorials/scripting/cpp/gdextension_cpp_example.html)
