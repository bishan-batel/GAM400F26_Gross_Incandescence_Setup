{
  description = "Awesome development nix flake thats really just for Kishan";

  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs =
    {
      self,
      nixpkgs,
      flake-utils,
    }:
    flake-utils.lib.eachDefaultSystem (
      system:
      let
        pkgs = import nixpkgs { inherit system; };
        dotnetSdk = pkgs.dotnet-sdk_8;

        # Trenchbroom Package
        trenchbroom = pkgs.appimageTools.wrapType2 rec {
          pname = "TrenchBroom";
          version = "v2026.2";

          platformName = if pkgs.hostPlatform.isDarwin then "macOS-arm64" else "Linux-x86_64";

          src = "${
            pkgs.fetchzip {
              url = "https://github.com/TrenchBroom/TrenchBroom/releases/download/${version}/TrenchBroom-${platformName}-${version}-Release.zip";
              hash = "sha256-7YIon2C0sLi0dDD3oJJbRuP7F0JzHjWtD1eqwZKdwmk=";
            }
          }/TrenchBroom.AppImage";
        };
      in
      {
        devShells.default = pkgs.mkShell {
          buildInputs = [
            dotnetSdk
            pkgs.godot_4-mono
            trenchbroom
          ];

          shellHook = /* bash */ ''
            # no telemetry to dotnet >:[
            export DOTNET_CLI_TELEMETRY_OPTOUT=1

            # Explicitly points Godot's build pipeline to your flake's SDK location
            export DOTNET_ROOT="${dotnetSdk}"

            echo "Godot 4 .NET Environment Loaded!"
            echo "Run 'godot4-mono' to open the editor."
          '';
        };
      }
    );
}
