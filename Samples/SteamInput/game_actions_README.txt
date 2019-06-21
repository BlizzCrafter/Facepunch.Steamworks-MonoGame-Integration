1. The correct directory for the default ingame-actions-file (IGA) is "Steam Install Directory\controller_config" not the game directory itself.

2. This file should be named "game_actions_X.vdf" where "X" stands for the AppID.
Example: D:\Programs\Steam\controller_config\game_actions_480.vdf

It is also necessarry to create a user config which is based on the IGA file.
Example: Start App. Open Overlay. Click Controller Configuration. Define Actions.
Tip: If the actions described in the default IGA appearing in the controller configuration overlay, then your file was taken / loaded correctly by steam (it's a good indicator for success).

More Information:
Getting Started: https://partner.steamgames.com/doc/features/steam_controller/getting_started_for_devs
IGA-File: https://partner.steamgames.com/doc/features/steam_controller/iga_file