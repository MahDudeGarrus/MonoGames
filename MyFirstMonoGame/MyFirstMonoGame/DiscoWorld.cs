using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMonoGame
{
    class DiscoWorld : Game
    {
        GraphicsDeviceManager graphics;
        Color background;


        public DiscoWorld()
        {
            graphics = new GraphicsDeviceManager(this);
        }

        protected override void LoadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            int redComponent = gameTime.TotalGameTime.Milliseconds / 16;
            background = new Color(redComponent, 2, redComponent);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(background);
        }
    }
}

