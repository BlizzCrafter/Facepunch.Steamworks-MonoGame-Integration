[![Twitter Follow](https://img.shields.io/twitter/follow/SandboxBlizz.svg?style=flat-square&label=Follow&logo=twitter)](https://twitter.com/SandboxBlizz)

# Facepunch.Steamworks MonoGame Integration
Facepunch.Steamworks + MonoGame.Framework = the easiest SteamAPI Integration for your app!

![Hello Facepunch.Steamworks](Documentation/Hello_FacepunchSteamworks_00.png)
![Hello Facepunch.Steamworks](Documentation/Hello_FacepunchSteamworks_01.png)

### Building

The following is required to successfully compile the solution:

- 64 bit OS (no x86 support)
- .NET Framework 4.7.2
- [MonoGame.Framework.DesktopGL.Core 3.7.0.7](https://www.nuget.org/packages/MonoGame.Framework.DesktopGL.Core/) (included per nuget)
- [Facepunch.Steamworks](https://github.com/Facepunch/Facepunch.Steamworks) (included per nuget)

### How To

To set up your own MonoGame with Facepunch.Steamworks integration project you need to do the following steps:

- Add the **Facepunch.Steamworks.dll** per [NuGet](https://www.nuget.org/packages/Facepunch.Steamworks/)
- Add **[steam_api64.dll](https://github.com/sqrMin1/Facepunch.Steamworks-MonoGame-Integration/tree/master/libs)** as a link to your project and set "copy to output directory" to "copy if newer"
- Add **[steam_appid.txt](https://github.com/sqrMin1/Facepunch.Steamworks-MonoGame-Integration/tree/master/shared)** as a link to your project and set "copy to output directory" to "copy if newer"

  - Don't forget to add that last file as a ```FileExclusion``` to your Steamworks build-script since you don't want that file to be copied to your customer's destination directory, since it's for debugging purposes only (it lets you try all the steam-stuff without actually having that game listed and active on steam and is important for debugging directly from out of Visual Studio).
    Your ```depot_build_xxxxxx.vdf``` you're referencing in your ```app_build_xxxxxx.vdf``` should end like this:

    ``````
    	// but exclude all symbol files  
    	// This can be a full path, or a path relative to ContentRoot
      "FileExclusion" "*.pdb"
      "FileExclusion" "steam_appid.txt"
    }
    ``````

- Add your desired **Steamworks AppID** to the steam_appid.txt file

- Initialize the API with the method **SteamClient.Init();** like this:

```cs
using Steamworks;

protected override void Initialize()
{
    try
    {
         SteamClient.Init(480);
         IsSteamRunning = true;
         SteamUtils.OverlayNotificationPosition = NotificationPosition.BottomRight;
    }
    catch (Exception e)
    {
        Console.Out.WriteLine(e.ToString());
    }
}
```

- Update callbacks with **SteamClient.RunCallbacks();** like this:

```cs
protected override void Update(GameTime gameTime)
{
    base.Update(gameTime);
    
    if (IsSteamRunning) SteamClient.RunCallbacks();
}
```

- ShutDown the Api with **SteamClient.Shutdown();** like this:

```cs
private void Game1_Exiting(object sender, EventArgs e)
{
    if (IsSteamRunning) SteamClient.Shutdown();
}
```

> Add the EventHandler **Exiting += Game1_Exiting** and then the SteamClient.Shutdown() method.

## Samples

The greatest thing about Facepunch.Steamworks is, that you can write code in native C#! 
Say bye bye to manual function calling and finally code like this again:

```cs
foreach ( var friend in SteamFriends.GetFriends() )
{
    Console.WriteLine( "{friend.Id}: {friend.Name}" );
    Console.WriteLine( "{friend.IsOnline} / {friend.SteamLevel}" );
    
    friend.SendMessage( "Hello Friend" );
}
```

```cs
public static async Task<Texture2D> GetUserImage(SteamId id, GraphicsDevice device)
{
    var image = await SteamFriends.GetMediumAvatarAsync(id);

    if (image.HasValue)
    {
        Texture2D avatarTexture = new Texture2D(device, (int)image.Value.Width, (int)image.Value.Height, false, SurfaceFormat.Color);
        avatarTexture.SetData(image.Value.Data, 0, image.Value.Data.Length);
        return avatarTexture;
    }
    else return null;
}

UserAvatar = GetUserImage(UserID, GraphicsDevice).Result;

```

More samples here:
https://github.com/Facepunch/Facepunch.Steamworks

### Included Sample Projects

- **Hello Facepunch.Steamworks**: Simple sample which sets up bare basics of Steamworks.Net and displaying a welcome message which includes your steam user name.
- **AchievementHunter**: Simple sample which shows you the correct way of implementing achievements and stats as well as storing them on the steam server. It's based upon the Steamworks Example 'SpaceWar' included with the Steamworks SDK. 
- **Facepunch.Steamworks MonoGame Integration**: Extendend sample which shows some features of the SteamAPI like UserStats, PersonaState, LeaderboardData, NumberOfCurrentPlayers, Steam User Avatar and so on.

> Note: You need to start your steam client before executing the examples. Otherwise you won't receive any data -obviously ;)

**Have fun!**

[![Twitter Follow](https://img.shields.io/twitter/follow/SandboxBlizz.svg?style=flat-square&label=Follow&logo=twitter)](https://twitter.com/SandboxBlizz)
