using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.Xna.Framework.Content;

namespace BalloonGame
{
    class Balloon
    {

        private Texture2D balloon;
        private Vector2 balloonPosition;
        private Vector2 balloonOrigin;
        private ContentManager content;

        public Balloon(ContentManager content)
        {
            this.content = content;

            this.balloon = this.content.Load<Texture2D>("spr_lives");
            this.balloonOrigin = new Vector2(balloon.Width / 2, balloon.Height);
        }


        public Texture2D BalloonSprite { get {return balloon;} set {this.balloon=value;} }

        public Vector2 BalloonPosition { get {return balloonPosition;} set { this.balloonPosition = value; } }

        public Vector2 BalloonOrigin { get {return balloonOrigin;} set { this.balloonOrigin = value; } }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            spriteBatch.Draw(BalloonSprite, BalloonPosition, Color.White);
        }
    }
}
