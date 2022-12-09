using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Classes_with_monogame___Hunter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D tribbleBrownTexture;
        Texture2D tribbleCreamTexture;
        Texture2D tribbleGreyTexture;
        Texture2D tribbleOrangeTexture;
        List<tribble> tribbleList;
        List<Texture2D> tribbleTextureList;
        public static Random ranGen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            this.Window.Title = "Hunter is the GOAT";
            ranGen = new Random();
            tribbleList = new List<tribble>();
            tribbleTextureList = new List<Texture2D>();
            base.Initialize();
            tribbleTextureList.Add(tribbleOrangeTexture);
            tribbleTextureList.Add(tribbleGreyTexture);
            tribbleTextureList.Add(tribbleCreamTexture);
            tribbleTextureList.Add(tribbleBrownTexture);
            for (int i = 0; i < 300; i++)
            {
                int speedFlipX = ranGen.Next(1, 3);

                if (speedFlipX == 1)
                    speedFlipX = 4;
                else if (speedFlipX == 2)
                    speedFlipX = -4;

                int speedFlipY = ranGen.Next(1, 3);

                if (speedFlipY == 1)
                    speedFlipY = 4;
                else if (speedFlipY == 2)
                    speedFlipY = -4;

                tribbleList.Add(new tribble(new Rectangle(ranGen.Next(1, _graphics.PreferredBackBufferWidth - 100), ranGen.Next(1, _graphics.PreferredBackBufferHeight - 100), 100, 100), new Vector2(speedFlipX, speedFlipY), tribbleTextureList[ranGen.Next(tribbleTextureList.Count)]));
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (tribble trib in tribbleList)
            {
                trib.Move(_graphics);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            foreach (tribble trib in tribbleList)
            {
                trib.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}