# RocketAutomationMod
## Installation
1. Make shure you have BepinEx installed
2. Download the latest release file from https://github.com/RogerWaters/Stationeers.RocketAutomationMod/releases
3. Put it in your BepinEx Plugin folder (e.g. C:\Program Files (x86)\Steam\steamapps\common\Stationeers\BepInEx\plugins)

## Features
Added abillity to remove generated nodes from spacemap.

- Send Avionics.ClearMemory with the ID of the node
- Node will only be removed if:
  - No Rocket is there
  - No Rocket has this node as destination
  - it has to be a generated node
