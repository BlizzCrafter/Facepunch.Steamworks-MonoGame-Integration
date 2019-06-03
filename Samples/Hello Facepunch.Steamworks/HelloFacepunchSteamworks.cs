using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using System;
using Utils;

namespace Hello_Facepunch.Steamworks
{
    public class HelloFacepunchSteamworks : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private string _WelcomeMessage = "Error: Please start your Steam Client before you run this example!";
        private const string WelcomeNote = "- Press [Shift + Tab] to open the Steam Overlay -";

        public HelloFacepunchSteamworks()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            Exiting += HelloFacepunchSteamworks_Exiting;

            try
            {
                SteamClient.Init(480);

                Functions.IsSteamRunning = true;

                SteamUtils.OverlayNotificationPosition = NotificationPosition.BottomRight;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.ToString());
            }

            Functions.LoadContent(Content);
            if (Functions.IsSteamRunning) _WelcomeMessage = $"Hello {Functions.UserName}!";
        }
        private void HelloFacepunchSteamworks_Exiting(object sender, EventArgs e)
        {
            if (Functions.IsSteamRunning)
            {
                Functions.ShutdownSteamClient();
            }
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Functions.IsSteamRunning) SteamClient.RunCallbacks();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            // Draw WelcomeMessage
            spriteBatch.DrawString(Functions.Font, _WelcomeMessage, 
                new Vector2(
                    graphics.PreferredBackBufferWidth / 2f - Functions.Font.MeasureString(_WelcomeMessage).X / 2f,
                    graphics.PreferredBackBufferHeight / 2f - Functions.Font.MeasureString(_WelcomeMessage).Y / 2f -
                    (Functions.IsSteamRunning ? 20 : 0)), Color.GreenYellow);

            if (Functions.IsSteamRunning)
            {
                // Draw WelcomeNote
                spriteBatch.DrawString(Functions.Font, WelcomeNote,
                    new Vector2(
                        graphics.PreferredBackBufferWidth / 2f - Functions.Font.MeasureString(WelcomeNote).X / 2f,
                        graphics.PreferredBackBufferHeight / 2f - Functions.Font.MeasureString(WelcomeNote).Y / 2f + 20),
                    Color.GreenYellow);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
