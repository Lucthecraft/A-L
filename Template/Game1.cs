﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D palTex, balTex, GOtex;
        Vector2 palPos, balPos, GOpos;

        bool GO;
        float balXv, balYv, palv;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 800;
        }


        protected override void Initialize()
        {
            palTex = Content.Load<Texture2D>("paddle");
            balTex = Content.Load<Texture2D>("ball");
            GOtex = Content.Load<Texture2D>("GO");

            balXv = 15; balYv = 15; palv = 15;

            balPos = new Vector2(GraphicsDevice.Viewport.Width / 2 - balTex.Width / 2, 0);
            palPos = new Vector2(GraphicsDevice.Viewport.Width / 2 - palTex.Width / 2, GraphicsDevice.Viewport.Height - palTex.Height * 1.5f);

            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(!GO)
            {
                balPos.X += balXv;
                balPos.Y += balYv;
                palPos.X += palv;
                if (balPos.X <= 0) { balXv *= -1; }
                if (balPos.X >= GraphicsDevice.Viewport.Width - balTex.Width) { balXv *= -1; }
                if (balPos.Y <= 0) { balYv *= -1; }
                if (balPos.Y >= GraphicsDevice.Viewport.Height - balTex.Height) { GO = true; }

            }

            if(GO)
            {

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if(!GO)
            {
                spriteBatch.Draw(balTex, balPos, null);
                spriteBatch.Draw(palTex, palPos, null);
            }
            if(GO)
            {
                spriteBatch.Draw(GOtex, GOpos, null);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
