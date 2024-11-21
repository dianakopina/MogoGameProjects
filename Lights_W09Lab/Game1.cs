using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lights_W09Lab
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Light _redLight, _orangeLight, _greenLight;
        private TrafficLight _trafficLight;
        private MouseState _currentMouseState, _previousMouseState;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _redLight = new Light(new Point(50, 50), 30f, Color.Red);
            _orangeLight = new Light(new Point(110, 50), 30f, Color.Orange);
            _greenLight = new Light(new Point(170, 50), 30f, Color.Green);

            _trafficLight = new TrafficLight(new Point(100, 150));

            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content herex
        }

        private void SetMouseStates()
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            
        }

        private bool IsMouseClicked()
        {
            return _currentMouseState.LeftButton == ButtonState.Pressed 
                && _previousMouseState.LeftButton ==ButtonState.Released;
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _trafficLight.Update(gameTime);

            // TODO: Add your update logic here
            SetMouseStates();

            if (IsMouseClicked())
            {
                _redLight.ToggleLightWithMouse(_currentMouseState.Position.X, _currentMouseState.Position.Y);
                _orangeLight.ToggleLightWithMouse(_currentMouseState.Position.X, _currentMouseState.Position.Y);
                _greenLight.ToggleLightWithMouse(_currentMouseState.Position.X, _currentMouseState.Position.Y);
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _trafficLight.Draw(_spriteBatch);

            _redLight.Draw(_spriteBatch);
            _orangeLight.Draw(_spriteBatch);
            _greenLight.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
