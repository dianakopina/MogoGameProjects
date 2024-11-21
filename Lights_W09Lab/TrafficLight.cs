using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using GeoSketch;
using Microsoft.Xna.Framework;

namespace Lights_W09Lab
{
    public class TrafficLight
    {
        private Light _redLight, _greenLight, _orangeLight;
        private float _timer;
        private int _currentLight; // 0 = red, 1 = green, 2 = orange
        private Rectangle _boundingRectangle;

        public TrafficLight(Point position)
        {
            _redLight = new Light(new Point(position.X, position.Y + 50), 30f, Color.Red);
            _orangeLight = new Light(new Point(position.X, position.Y + 110), 30f, Color.Orange);
            _greenLight = new Light(new Point(position.X, position.Y + 170), 30f, Color.Green);

            int width = (int)(_redLight.Radius * 2); // assuming all lights have the same radius
            int height = (int)(_redLight.Radius * 6); // total height for 3 lights + padding

            _boundingRectangle = new Rectangle(position.X - (int)_redLight.Radius, position.Y + 20, width, height);


            _timer = 0f;
            _currentLight = 0; // Start with the red light
            UpdateLights();
        }


        public void UpdateLights()
        {

            _redLight.isOn = false;
            _orangeLight.isOn = false;
            _greenLight.isOn = false;

            // Turn on the current light
            switch (_currentLight)
            {
                case 0:
                    _redLight.isOn = true;
                    break;
                case 1:
                    _orangeLight.isOn = true;
                    break;
                case 2:
                    _greenLight.isOn = true;
                    break;
            }
        }
        public void Update(GameTime gametime)
        {
            _timer += (float)gametime.ElapsedGameTime.TotalSeconds;

            // check timer for the light
            if (_currentLight == 0 && _timer >= 3f) // Red for 3 seconds
            {
                _currentLight = 1; // Switch to orange
                _timer = 0f;
                UpdateLights();
            }
            else if (_currentLight == 1 && _timer >= 1f) // Orange for 1 second
            {
                _currentLight = 2; // Switch to green
                _timer = 0f;
                UpdateLights();
            }
            else if (_currentLight == 2 && _timer >= 3f) // Green for 3 seconds
            {
                _currentLight = 0; // Switch back to red
                _timer = 0f;
                UpdateLights();

            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D rectangleTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            rectangleTexture.SetData(new[] { Color.Black });
            spriteBatch.Draw(rectangleTexture, _boundingRectangle, Color.Black);

            _redLight.Draw(spriteBatch);
            _orangeLight.Draw(spriteBatch);
            _greenLight.Draw(spriteBatch);
        }
    }
}
