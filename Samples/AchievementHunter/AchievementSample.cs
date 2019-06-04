using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Steamworks;
using Steamworks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

using Color = Microsoft.Xna.Framework.Color;

namespace AchievementHunter
{
    public class AchievementSample : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private const string DESCRIPTION_MESSAGE = "Use [W] [A] [S] [D] to control the ship!";

        private Texture2D _ShipTexture, _Pixel;
        private Rectangle _ShipPosition, _WinGamePosition, _LoseGamePosition, _ResetAllPosition;

        private int _GamesPlayed;
        private int _Wins;
        private int _Losses;
        private float _FeetTraveled;
        private float _MaxFeetTraveled;
        private float _CurrentTraveled;

        private List<Achievement> _AchievementList = new List<Achievement>();

        public AchievementSample()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsFixedTimeStep = true;
            graphics.SynchronizeWithVerticalRetrace = true;

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            base.Initialize();

            Exiting += AchievementSample_Exiting;

            try
            {
                SteamClient.Init(480);

                Functions.IsSteamRunning = true;

                SteamFriends.OnGameOverlayActivated += Functions.SteamFriends_OnGameOverlayActivated;
                SteamUserStats.OnUserStatsReceived += SteamUserStats_OnUserStatsReceived;
                SteamUserStats.RequestCurrentStats();

                SteamUtils.OverlayNotificationPosition = NotificationPosition.BottomRight;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.ToString());
            }

            Functions.LoadContent(Content);
        }
        private void AchievementSample_Exiting(object sender, System.EventArgs e)
        {
            if (Functions.IsSteamRunning) Functions.ShutdownSteamClient();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _ShipTexture = Content.Load<Texture2D>(@"Ship");

            ResetShip(true);

            _WinGamePosition = new Rectangle(20, graphics.PreferredBackBufferHeight / 2, 150, 150);
            _LoseGamePosition = new Rectangle(20, (graphics.PreferredBackBufferHeight / 2) + 180, 150, 150);
            _ResetAllPosition = new Rectangle((graphics.PreferredBackBufferWidth / 2) - 75, 20, 150, 150);

            _Pixel = new Texture2D(GraphicsDevice, 1, 1);
            _Pixel.SetData(new[] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Functions.IsSteamRunning)
            {
                #region ShipMovement

                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    _ShipPosition.Y = MathHelper.Clamp(_ShipPosition.Y - 5, 0, graphics.PreferredBackBufferHeight);
                    _CurrentTraveled += 3f;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    _ShipPosition.X = MathHelper.Clamp(_ShipPosition.X - 5, 0, graphics.PreferredBackBufferWidth);
                    _CurrentTraveled += 3f;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    _ShipPosition.Y = MathHelper.Clamp(_ShipPosition.Y + 5, 0, graphics.PreferredBackBufferHeight - _ShipTexture.Height);
                    _CurrentTraveled += 3f;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    _ShipPosition.X = MathHelper.Clamp(_ShipPosition.X + 5, 0, graphics.PreferredBackBufferWidth - _ShipTexture.Width);
                    _CurrentTraveled += 3f;
                }

                #endregion

                #region ShipCollisionDetection

                if (_ShipPosition.Intersects(_ResetAllPosition))
                {
                    ResetShip(true);
                    ResetAllStats();
                }

                if (_ShipPosition.Intersects(_WinGamePosition))
                {
                    ResetShip(false);
                    EndGame(true);
                }

                if (_ShipPosition.Intersects(_LoseGamePosition))
                {
                    ResetShip(false);
                    EndGame(false);
                }

                #endregion

                foreach (Achievement achievement in _AchievementList)
                {
                    if (achievement.State == true) continue;

                    switch (achievement.Identifier)
                    {
                        case "ACH_WIN_ONE_GAME":
                            if (_Wins != 0) achievement.Trigger();
                            break;
                        case "ACH_WIN_100_GAMES":
                            if (_Wins >= 100) achievement.Trigger();
                            break;
                        case "ACH_TRAVEL_FAR_SINGLE":
                            if (_CurrentTraveled >= 500) achievement.Trigger();
                            break;
                        case "ACH_TRAVEL_FAR_ACCUM":
                            if (_FeetTraveled >= 5280) achievement.Trigger();
                            break;
                        case "NEW_ACHIEVEMENT_0_4":
                            if (_Losses >= 10) achievement.Trigger();
                            break;
                    }
                }

                SteamClient.RunCallbacks();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.LinearClamp,
                DepthStencilState.None, RasterizerState.CullCounterClockwise);

            if (Functions.IsSteamRunning)
            {
                #region Playfield

                // WinGame Rectangle
                spriteBatch.Draw(_Pixel, _WinGamePosition, Color.Blue);
                spriteBatch.DrawString(Functions.Font, "Win_Game!", new Vector2(
                    _WinGamePosition.X + (_WinGamePosition.Width / 2) - (Functions.Font.MeasureString("Win_Game!").X / 2),
                    _WinGamePosition.Y + (_WinGamePosition.Height / 2) - (Functions.Font.MeasureString("Win_Game!").Y / 2)), Color.White);

                // LoseGame Rectangle
                spriteBatch.Draw(_Pixel, _LoseGamePosition, Color.Red);
                spriteBatch.DrawString(Functions.Font, "Lose_Game!", new Vector2(
                    _LoseGamePosition.X + (_LoseGamePosition.Width / 2) - (Functions.Font.MeasureString("Lose_Game!").X / 2),
                    _LoseGamePosition.Y + (_LoseGamePosition.Height / 2) - (Functions.Font.MeasureString("Lose_Game!").Y / 2)), Color.White);

                // ResetAll Rectangle
                spriteBatch.Draw(_Pixel, _ResetAllPosition, Color.Yellow);
                spriteBatch.DrawString(Functions.Font, "Reset_ALL!", new Vector2(
                    _ResetAllPosition.X + (_ResetAllPosition.Width / 2) - (Functions.Font.MeasureString("Reset_ALL!").X / 2),
                    _ResetAllPosition.Y + (_ResetAllPosition.Height / 2) - (Functions.Font.MeasureString("Reset_ALL!").Y / 2)), Color.Black);

                // Draw the ship (MonoGame logo)
                spriteBatch.Draw(_ShipTexture, _ShipPosition, Color.White);

                // Description
                spriteBatch.DrawString(Functions.Font, DESCRIPTION_MESSAGE, new Vector2(
                    graphics.PreferredBackBufferWidth - (Functions.Font.MeasureString(DESCRIPTION_MESSAGE).X * 2),
                    graphics.PreferredBackBufferHeight - Functions.Font.MeasureString(DESCRIPTION_MESSAGE).Y - 20), Color.GreenYellow);

                #endregion

                #region StatsAndAchievement

                string stats = $@"
DistanceTraveled: {_CurrentTraveled}

NumGames: {_GamesPlayed}
NumWins: {_Wins}
NumLosses: {_Losses}
FeetTraveled: {_FeetTraveled}
MaxFeetTraveled: {_MaxFeetTraveled}";

                // Draw Stats
                spriteBatch.DrawString(Functions.Font, stats, new Vector2(20, 20), Color.White);

                //Draw Achievements
                for (int i = 0; i < _AchievementList.Count; i++)
                {
                    string achievements = $@"
ID: {_AchievementList[i].Identifier}
Name: {_AchievementList[i].Name}
Description: {_AchievementList[i].Description}
Achieved: {_AchievementList[i].State}
Date: {_AchievementList[i].UnlockTime}";

                    spriteBatch.DrawString(Functions.Font, achievements, new Vector2(
                            graphics.PreferredBackBufferWidth - Functions.Font.MeasureString(achievements).X - 20,
                            Functions.Font.MeasureString(achievements).Y * i), Color.White);
                }

                #endregion
            }
            else
            {
                // Error Message
                spriteBatch.DrawString(Functions.Font, Functions.STEAM_NOT_RUNNING_ERROR_MESSAGE, new Vector2(
                    (graphics.PreferredBackBufferWidth / 2) - (Functions.Font.MeasureString(Functions.STEAM_NOT_RUNNING_ERROR_MESSAGE).X / 2),
                    (graphics.PreferredBackBufferHeight / 2) - (Functions.Font.MeasureString(Functions.STEAM_NOT_RUNNING_ERROR_MESSAGE).Y / 2)), Color.GreenYellow);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void SteamUserStats_OnUserStatsReceived(SteamId id, Result result)
        {
            if (result == Result.OK)
            {
                _AchievementList = SteamUserStats.Achievements.ToList();

                _GamesPlayed = SteamUserStats.GetStatInt("NumGames");
                _Wins = SteamUserStats.GetStatInt("NumWins");
                _Losses = SteamUserStats.GetStatInt("NumLosses");
                _FeetTraveled = SteamUserStats.GetStatFloat("FeetTraveled");
                _MaxFeetTraveled = SteamUserStats.GetStatFloat("MaxFeetTraveled");
            }
        }

        /// <summary>
        /// End the game by winning or losing the round.
        /// </summary>
        /// <param name="win">Did we win?</param>
        private void EndGame(bool win)
        {
            SteamUserStats.AddStat("NumGames", 1);
            _GamesPlayed++;

            if (win)
            {
                SteamUserStats.AddStat("NumWins", 1);
                _Wins++;
            }
            else
            {
                SteamUserStats.AddStat("NumLosses", 1);
                _Losses++;
            }

            // Accumulate distances
            _FeetTraveled += _CurrentTraveled;

            // New max?
            if (_CurrentTraveled > _MaxFeetTraveled)
            {
                SteamUserStats.SetStat("MaxFeetTraveled", _CurrentTraveled);
                _MaxFeetTraveled = _CurrentTraveled;
            }

            _CurrentTraveled = 0f;

            SteamUserStats.StoreStats();
        }
        
        /// <summary>
        /// Reset the ship to the screen center.
        /// </summary>
        private void ResetShip(bool forceScreenCenter)
        {
            _ShipPosition = new Rectangle(
                _GamesPlayed > 7 && !forceScreenCenter ?
                // X
                200 : (graphics.PreferredBackBufferWidth / 2) - (_ShipTexture.Width / 2),
                // Y
                graphics.PreferredBackBufferHeight / 2,
                // Size
                _ShipTexture.Width, _ShipTexture.Height);
        }

        /// <summary>
        /// Reset all Steam Stats and Achievements
        /// </summary>
        private void ResetAllStats()
        {
            _GamesPlayed = 0;
            _Wins = 0;
            _Losses = 0;
            _FeetTraveled = 0;
            _MaxFeetTraveled = 0;
            _CurrentTraveled = 0;
            SteamUserStats.ResetAll(true);
            SteamUserStats.RequestCurrentStats();
        }
    }
}
