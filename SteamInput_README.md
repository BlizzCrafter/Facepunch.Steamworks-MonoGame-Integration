#### This README should help you to successfully receive input data from the SteamApi. Please read it carefully!

1. The correct directory for the default ingame-actions-file (IGA) is `Steam Install Directory\controller_config` not the game directory itself.
2. This file should be named `game_actions_X.vdf` where X stands for the AppID. 
> **Example:** `D:\Programs\Steam\controller_config\game_actions_480.vdf`
3. It is also necessarry to create a user config which is based on the IGA file.
> **Example:** Start App. Open Overlay. Click Controller Configuration. Define Actions.

> **Tip:** If the actions described in the default IGA appearing in the controller configuration overlay, then your file was taken / loaded correctly by steam (it's a good indicator for success).
4. The steam documentation recommends to create a user config from within BigPicture. However I successfully created and used the config without BigPicture, but it seems to be necessary to export the configuration through BigPicture when you are done with the whole setup. At least for the final release build / setting the official default configuration with the steam backend.
5. From the steam documentation: **"Make sure you set defaults for all your in-game action sets, not just the first one."**
6. Launch your steam client with the following command line parameter: `-forcecontrollerappid your_game's_AppID `. This ensures that controllers are bound to the game window and nothing else, which could interfere with your debugging session.
> **Example:** `D:\Programs\Steam\Steam.exe -forcecontrollerappid 480`
7. In your code make sure that you activate an ActionSet before trying to receive input data from this set.

---

**More Information:**
> **Getting Started:** https://partner.steamgames.com/doc/features/steam_controller/getting_started_for_devs

> **IGA-File:** https://partner.steamgames.com/doc/features/steam_controller/iga_file
