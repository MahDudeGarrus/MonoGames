using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media; 
using Microsoft.Xna.Framework.Audio; 
using Microsoft.Xna.Framework.Input;
using System;

namespace BalloonGame
{

    public class BalloonGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Texture2D background;
        Balloon balloon;
        Cannon cannon;

        public BalloonGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {

            // TODO: Add your initialization logic here

            base.Initialize();
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("spr_background");
            balloon = new Balloon(Content);
            cannon = new Cannon(Content);
            MediaPlayer.Play(Content.Load<Song>("snd_music"));  

        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {         
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
                

            MouseState currentMouseState = Mouse.GetState();
            balloon.BalloonPosition = new Vector2(currentMouseState.X, currentMouseState.Y);

            ButtonState left = currentMouseState.LeftButton;

            KeyboardState currentKBState = Keyboard.GetState();

            if (currentMouseState.LeftButton == ButtonState.Pressed)
            {
                double opposite = currentMouseState.Y - cannon.BarrelPosition.Y;
                double adjacent = currentMouseState.X - cannon.BarrelPosition.X;
                cannon.Angle = (float)Math.Atan2(opposite, adjacent);
            }

            if (left != ButtonState.Pressed)
            {
                cannon.Angle = 0;
            }

            if (currentKBState.IsKeyDown(Keys.R))
            {
                cannon.CurrentColor = Color.Red;
            }
            else if (currentKBState.IsKeyDown(Keys.G))
            {
                cannon.CurrentColor = Color.Green;
            }
            else if (currentKBState.IsKeyDown(Keys.B))
            {
                cannon.CurrentColor = Color.Blue;
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            balloon.Draw(spriteBatch, gameTime);
            cannon.Draw(spriteBatch, gameTime);
            spriteBatch.End();
           
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
