using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using Steamworks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

using Color = Microsoft.Xna.Framework.Color;

namespace Facepunch.Steamworks_MonoGame_Integration
{
#pragma warning disable 4014
    public class SteamworksIntegration : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D _UserAvatar;
        private int _UserLevel;
        private SteamId _UserID;
        private string _CurrentLanguage = "";
        private string _InstallDir = "";
        private int _PlayerCount;
        private List<LeaderboardEntry> _Scores = new List<LeaderboardEntry>();

        private int _GamesPlayed;
        private int _Wins;
        private int _Losses;
        private float _FeetTraveled;
        private float _MaxFeetTraveled;

        private bool _OwnsApp;
        private bool _OwnsAppThroughFamilySharing;
        private bool _OwnsAppThroughFreeWeekend;
        private SteamId _OwnerID;
        private Friend _OwnerFriend;

        public SteamworksIntegration()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            Exiting += SteamworksIntegration_Exiting;

            try
            {
                SteamClient.Init(480);

                Functions.IsSteamRunning = true;

                SteamFriends.OnGameOverlayActivated += Functions.SteamFriends_OnGameOverlayActivated;
                SteamUserStats.OnUserStatsReceived += SteamUserStats_OnUserStatsReceived;
                SteamUserStats.RequestCurrentStats();

                SteamUtils.OverlayNotificationPosition = NotificationPosition.TopRight;
                // Uncomment the next line to adjust the OverlayNotificationPosition.
                //SteamUtils.SetOverlayNotificationInset(400, 0);

                _CurrentLanguage = SteamApps.GameLanguage;
                _UserLevel = SteamUser.SteamLevel;
                _UserID = SteamClient.SteamId;
                _InstallDir = SteamApps.AppInstallDir();

                _Scores = Functions.FindLeaderboard("Quickest Win", 9).Result;
                _UserAvatar = Functions.GetUserImage(_UserID, GraphicsDevice).Result;
                _PlayerCount = Functions.GetPlayerCount().Result;

                //The following lines can be helpful to know more about the user of your application
                //
                // Check if the user basically owns this app
                _OwnsApp = SteamApps.IsSubscribed;

                // Check if the user owns this app through Family Sharing
                _OwnsAppThroughFamilySharing = SteamApps.IsSubscribedFromFamilySharing;

                // Check if the user owns this app because of a Free Weekend
                _OwnsAppThroughFreeWeekend = SteamApps.IsSubscribedFromFreeWeekend;

                // The ownder SteamID of this app. It will be different from the users ID who started this application, when he just borrowed
                // this app through Family Sharing
                _OwnerID = SteamApps.AppOwner;

                // More information about the original app owner, which could be a Steam Friend (Family Sharing)
                try
                {
                    _OwnerFriend = SteamFriends.GetFriends().Where(x => x.Id == _OwnerID).First();
                }
                catch { }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.ToString());
            }

            Functions.LoadContent(Content);
        }
        private void SteamworksIntegration_Exiting(object sender, EventArgs e)
        {
            if (Functions.IsSteamRunning)
            {
                SteamUserStats.OnUserStatsReceived -= SteamUserStats_OnUserStatsReceived;
                _UserAvatar.Dispose();
                Functions.ShutdownSteamClient();
            }
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Functions.IsSteamRunning) SteamClient.RunCallbacks();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            if (Functions.IsSteamRunning)
            {
                //Draw your Steam Avatar and Steam Name
                if (_UserAvatar != null)
                {
                    spriteBatch.Draw(_UserAvatar, new Vector2(10, 10), null, Color.White);
                    spriteBatch.DrawString(Functions.Font, 
$@"Name: {Functions.UserName}
Level: { _UserLevel}
Status: {SteamClient.State}",
                    new Vector2(15 + _UserAvatar.Width, 10), Color.Yellow);
                }
                else spriteBatch.DrawString(Functions.Font, "Loading Avatar...", new Vector2(15, 15), Color.White);

                string detailsLeft =
$@"AppID: {SteamClient.AppId}
InstallDir: {_InstallDir}
OwnsApp: {_OwnsApp}
OwnsAppThroughFamilySharing: {_OwnsAppThroughFamilySharing}
FamilyFriend: {_OwnerFriend.Name}
OwnsAppThroughFreeWeekend: {_OwnsAppThroughFreeWeekend}
Players: {_PlayerCount}
Playtime: {SteamUtils.SecondsSinceAppActive},
InactiveTime: {SteamUtils.SecondsSinceComputerActive}
ServerTime: {SteamUtils.SteamServerTime}
OverlayActive: {Functions.IsOverlayActive}

Games: {_GamesPlayed}
Wins: {_Wins}
Losses: {_Losses}
Traveled: {_FeetTraveled}
Traveled (Max): {_MaxFeetTraveled}";

                string detailsRight = "Leaderboard:\n";
                for (int i = 0; i < _Scores.Count; i++)
                {
                    detailsRight += _Scores[i].GlobalRank + ". " + _Scores[i].User.Name + ": " + _Scores[i].Score.ToString() + "\n";
                }

                // Details
                spriteBatch.DrawString(Functions.Font, detailsLeft, new Vector2(15, 100), Color.White);
                spriteBatch.DrawString(Functions.Font, detailsRight, new Vector2(Functions.Font.MeasureString(detailsLeft).X / 1.25f, 175), Color.White);
            }
            else
            {
                spriteBatch.DrawString(Functions.Font, Functions.STEAM_NOT_RUNNING_ERROR_MESSAGE,
                    new Vector2(
                        graphics.PreferredBackBufferWidth / 2f - Functions.Font.MeasureString(Functions.STEAM_NOT_RUNNING_ERROR_MESSAGE).X / 2f,
                        graphics.PreferredBackBufferHeight / 2f - Functions.Font.MeasureString(Functions.STEAM_NOT_RUNNING_ERROR_MESSAGE).Y / 2f), Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void SteamUserStats_OnUserStatsReceived(SteamId id, Result result)
        {
            if (result == Result.OK)
            {
                _GamesPlayed = SteamUserStats.GetStatInt("NumGames");
                _Wins = SteamUserStats.GetStatInt("NumWins");
                _Losses = SteamUserStats.GetStatInt("NumLosses");
                _FeetTraveled = SteamUserStats.GetStatFloat("FeetTraveled");
                _MaxFeetTraveled = SteamUserStats.GetStatFloat("MaxFeetTraveled");
            }
        }
    }
}
