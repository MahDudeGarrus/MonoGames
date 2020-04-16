using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media; //ADDED HERE!!
using Microsoft.Xna.Framework.Audio; //ADDED HERE!!
using Microsoft.Xna.Framework.Input;
using System;

namespace BalloonGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class BalloonGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D balloon, background, cannonBarrel; // ADDED HERE!!
        Vector2 balloonPosition, barrelPosition, barrelOrigin; // ADDED HERE!!
        float angle;


        public BalloonGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;  //Added Here!!
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            balloon = Content.Load<Texture2D>("spr_lives");
            background = Content.Load<Texture2D>("spr_background");
            cannonBarrel = Content.Load<Texture2D>("spr_cannon_barrel");  //ADDED FROM HERE!!
            barrelPosition = new Vector2(72, 405);
            barrelOrigin = new Vector2(cannonBarrel.Height, cannonBarrel.Height) / 2;

            MediaPlayer.Play(Content.Load<Song>("snd_music"));  //ADDED HERE!!


            //SoundEffect mySound = Content.Load<SoundEffect>("scream"); //ADDED HERE!!

        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            //balloonPosition = Vector2.Zero;       ADDED HERE!!            
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState currentMouseState = Mouse.GetState();
            balloonPosition = new Vector2(currentMouseState.X, currentMouseState.Y);

            ButtonState left = currentMouseState.LeftButton;

            if (left == ButtonState.Pressed)
            {
                double opposite = currentMouseState.Y - barrelPosition.Y;
                double adjacent = currentMouseState.X - barrelPosition.X;
                angle = (float)Math.Atan2(opposite, adjacent);
            }

            if (left != ButtonState.Pressed)
            {
                angle = 0;
            }



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.Draw(balloon, balloonPosition, Color.White);
            spriteBatch.Draw(cannonBarrel, barrelPosition, null, Color.White,
                angle, barrelOrigin, 1.0f, SpriteEffects.None,0);  //Will need to ask where to put angle float
            
            spriteBatch.End();




            // TODO: Add your drawing code here



            base.Draw(gameTime);
        }
    }
}
