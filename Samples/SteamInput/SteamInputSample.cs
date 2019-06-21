using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using System;
using System.Linq;
using Utils;

namespace SteamInputSample
{
    public class SteamInputSample : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private SpriteFont _Font;

        private Controller _CurrentController;
        private bool _FirePressed;
        private Vector2 _MoveVector;

        public SteamInputSample()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            Exiting += SteamInput_Exiting;

            try
            {
                SteamClient.Init(480);

                Functions.IsSteamRunning = true;
                
                var controllerList = SteamInput.Controllers.ToList();
                if (controllerList != null && controllerList.Count > 0)
                {
                    _CurrentController = SteamInput.Controllers.ToList()[0];

                    _CurrentController.ActionSet = "TestSet";

                    #region simple testing

                    var testSet = _CurrentController.GetActionSetHandle("TestSet");
                    var test0 = _CurrentController.GetCurrentActionSetLayer();
                    var test1 = _CurrentController.GetStringForActionOrigin(InputActionOrigin.XBox360_X);
                    var test2 = _CurrentController.GetGlyphForActionOrigin(InputActionOrigin.Switch_RightTrigger_Pull);
                    var test3 = _CurrentController.GetGlyphForXboxOrigin(XboxOrigin.RightTrigger_Pull);

                    #endregion
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.ToString());
            }

            Functions.LoadContent(Content);
        }
        private void SteamInput_Exiting(object sender, EventArgs e)
        {
            if (Functions.IsSteamRunning) Functions.ShutdownSteamClient();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _Font = Content.Load<SpriteFont>(@"Font");
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Functions.IsSteamRunning)
            {
                if (_CurrentController != null)
                {
                    SteamInput.RunFrame();

                    if (_CurrentController.GetDigitalState("Fire").Pressed)
                    {
                        _FirePressed = true;
                    }
                    else _FirePressed = false;

                    var move = _CurrentController.GetAnalogState("Move");
                    _MoveVector = new Vector2(move.X, move.Y);
                }

                SteamClient.RunCallbacks();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.DrawString(_Font, $"Fire Pressed: {_FirePressed}", new Vector2(200, 200), Color.Yellow);
            spriteBatch.DrawString(_Font, $"Move Vector: {_MoveVector}", new Vector2(200, 230), Color.Yellow);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
