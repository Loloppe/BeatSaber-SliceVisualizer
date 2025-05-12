# Beat Saber Slice Visualizer mod

This plugin shows how your slice is offset from center.
Using that information, you can train your accuracy.

Demo: https://www.youtube.com/watch?v=mrq-uZ2JnXg

## Installation

- Install BSIPA and SiraUtil, recommended way is to use [Beat Saber Mod Assistant][mod_assistant]
- Copy SliceVisualizer.dll to `Beat Saber\Plugins` directory.

## Configuration

Edit `Beat Saber\UserData\SliceVizualizer.json`.
This file will be created automatically when you first launch the game with the plugin installed.

### Configuration options:
#### In game menu
- `Enabled` (default: true) -- Enable or disable the plugin
- `YPosition` (default: 1.0) -- Can be used to change the Y position (height) of the visualizer.

#### File only
- `SliceWidth` (default: 0.05) -- Width of the slice line as a proportion of note size
- `ScoreScaling` (default: `"Linear"`) -- Specify scaling function for cut offset. Possible values: `"Linear", "Log", "Sqrt"`.
This option, when set to `Log` or `Sqrt` allows you to exaggerate small offsets, and group large offsets together.
- `ScoreScaleMin` (default: 0.05) -- Minumum value for the scaling. When the offset is smaller than this value, it is rendered as zero.
- `ScoreScaleMax` (default: 0.5) -- Maximum value for scaling. When the cut offset is 1, the final render will equal this value.
- `ScoreScale` (default: 1.0) -- Multiplier for cut offset. Set to bigget value to exaggerate offset.
- `MissedAreaColor` (default: `[0.0, 0.0, 0.0, 0.5]`) -- RGBA color for the area between note center and cut line.
- `SliceColor` (default: `[1.0, 1.0, 1.0, 1.0]`) -- RGBA color for the cut line.
- `ArrowColor` (default: `[1.0, 1.0, 1.0, 1.0]`) -- RGBA color for the arrow image.
- `BadDirectionColor` (default: `[0.0, 0.0, 0.0, 1.0]`) -- RGBA color for the arrow, in case you cut the note from the wrong side.
- `CenterColor` (default: `[1.0, 1.0, 1.0, 1.0]`) -- RGBA color for the circle in the center of note.
- `UseCustomColors` (default: `false`) -- override the in-game colors for notes with the following:
- `LeftColor` (default: `[0.659, 0.125, 0.125, 1]`) -- Color for left notes.
- `RightColor` (default: `[0.125, 0.392, 0.659, 1]`) -- Color for right notes.
- `CubeLifetime` (default: 1.0) -- total lifetime of the visualization in seconds.
- `PopEnd` (default: 0.1) -- highlight time for the visualization in seconds. set to 0.0 to disable highlighting.
- `FadeStart` (default: 0.5) -- the time at which the visualization starts to fade out in seconds.
- `PopDistance` (default: 0.5) -- the visualization starts at a position close to the player, and moves away from the player for this distance.
Set to 0.0 to disable this effect.
- `PositionFromCubeTransform` (default: true) -- use render position of the note to calculate position of the visualiztion.
- `RotationFromCubeTransform` (default: true) -- use render rotation of the note to calculate note direction for the visualiztion.
- `CubeScale` (default: 0.9) -- note size for the visualization.
- `CenterScale` (default: 0.2) -- scale of the circle in the center, relative to note scale.
- `ArrowScale` (default: 0.6) -- scale of the note arrow, relative to note scale.
- `UIOpacity` (default: 1.0) -- Overall opacity for the UI.  Multiplicative with opacity/alpha of other colors.
- `CanvasOffset` (default: `[0.0, 0.0, 16.0]`) -- control `[x, y, z]` position of bottom center point of the visualization canvas.  
`x` is left to right, `y` is bottom to top, `z` is back to front.
- `CanvasScale` (default: 1.0) -- Control visualization canvas scaling. This affects note scaling as well.

## Setting up Development

Please read the [BSMT Wiki][bsmt_wiki] for more information on plugin development for BeatSaber.

In case you have troubles with setting up paths or references, please read:
[BSMT Wiki - Resolving References][bsmt_wiki_ref]

To develop this plugin, you'll need:

- Visual Studio 2019
- Beat Saber installed
- BSIPA and SiraUtil installed in Beat Saber directory, recommended way is to use [Beat Saber Mod Assistant][mod_assistant]
- Recommended to install Visual Studio extension `BeatSaberModdingTools.vsix` from [here][bsmg_tools_vsix]

Next:

- Clone this repo `git clone git@github.com:m1el/BeatSaber-SliceVisualizer.git`
- Copy `SliceVisualizer.csproj.user.example` to `SliceVisualizer.csproj.user`
- Edit `SliceVisualizer.csproj.user` to set your Beat Saber installation directory
- Build Solution

## LICENSE

The MIT License, copyright Igor null \<m1el.2027@gmail.com\>

[bsmt_wiki]: https://github.com/Zingabopp/BeatSaberModdingTools/wiki "Beat Saber Modding Tools Wiki"
[bsmt_wiki_ref]: https://github.com/Zingabopp/BeatSaberModdingTools/wiki/Resolving-References "Beat Saber Modding Tools Wiki - Resolving References"
[mod_assistant]: https://github.com/Assistant/ModAssistant/releases/latest "Beat Saber Mod Assistant latest release"
[bsmg_tools_vsix]: https://github.com/Zingabopp/BeatSaberModdingTools/releases/latest "Beat Saber Modding tools Visual Studio extension"
