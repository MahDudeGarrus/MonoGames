using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace BalloonGame
{
    class Cannon
    {

        private Texture2D cannonBarrel;
        private Texture2D colorRed;
        private Texture2D colorBlue;
        private Texture2D colorGreen;
        private Texture2D currentSprite;
        private Vector2 barrelPosition;
        private Vector2 barrelOrigin;
        private Vector2 colorOrigin;
        private float angle;
        private Color currentColor;
        private ContentManager content;

        public Cannon(ContentManager content)
        {
            this.content = content;
            cannonBarrel = content.Load<Texture2D>("spr_cannon_barrel");
            barrelPosition = new Vector2(72, 405);
            barrelOrigin = new Vector2(cannonBarrel.Height, cannonBarrel.Height) / 2;
            colorRed = content.Load<Texture2D>("spr_cannon_red");
            colorBlue = content.Load<Texture2D>("spr_cannon_blue");
            colorGreen = content.Load<Texture2D>("spr_cannon_green");
            colorOrigin = new Vector2(colorRed.Width, colorRed.Height) / 2;
            currentColor = Color.Blue;
        }

        public Texture2D CannonBarrel { get => cannonBarrel; set => cannonBarrel = value; }
        public Vector2 BarrelPosition { get => barrelPosition; set => barrelPosition = value; }
        public Vector2 BarrelOrigin { get => barrelOrigin; set => barrelOrigin = value; }
        public float Angle { get => angle; set => angle = value; }
        public Color CurrentColor { get => currentColor; set => currentColor = value; }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            if (currentColor == Color.Red)
            {
                currentSprite = colorRed;
            }

            else if (currentColor == Color.Blue)
            {
                currentSprite = colorBlue;
            }

            else
            {
                currentSprite = colorGreen;
            }


            spriteBatch.Draw(cannonBarrel, barrelPosition, null, Color.White,
                angle, barrelOrigin, 1.0f, SpriteEffects.None, 0);
            spriteBatch.Draw(currentSprite, barrelPosition, null, Color.White, 0f,
                colorOrigin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
