using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D palTex, balTex, GOtex, BG;
        Vector2 palPos, balPos, GOpos;

        bool GO;
        float balXv, balYv, palv;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 600;
        }


        protected override void Initialize()
        {
            palTex = Content.Load<Texture2D>("paddle");
            balTex = Content.Load<Texture2D>("ball");
            GOtex = Content.Load<Texture2D>("GO");
            BG = Content.Load<Texture2D>("tree");

            balXv = 10; balYv = 10; palv = 15;

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
                if (Keyboard.GetState().IsKeyDown(Keys.Left)) { palPos.X -= palv; }
                if (Keyboard.GetState().IsKeyDown(Keys.Right)) { palPos.X += palv; }

                if (balPos.X <= 0) { balXv *= -1; }
                if (balPos.X >= GraphicsDevice.Viewport.Width - balTex.Width) { balXv *= -1; }
                if (balPos.Y <= 0) { balYv *= -1; }
                if (balPos.Y >= GraphicsDevice.Viewport.Height - balTex.Height) { GO = true; }
                if (balPos.Y >= palPos.Y - balTex.Width & balPos.Y <= palPos.Y + palTex.Width / 2)
                {
                    if (balPos.X + balTex.Width >= palPos.X & balPos.X <= palPos.X + palTex.Width) { balYv *= -1; }
                }

            }

            if(GO)
            {
                balPos = new Vector2(GraphicsDevice.Viewport.Width / 2 - balTex.Width / 2, 0);
                palPos = new Vector2(GraphicsDevice.Viewport.Width / 2 - palTex.Width / 2, GraphicsDevice.Viewport.Height - palTex.Height * 1.5f);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(BG, Vector2.Zero, null);
            if(!GO)
            {
                spriteBatch.Draw(balTex, balPos, null);
                spriteBatch.Draw(palTex, palPos, null);
            }
            if(GO)
            {
                spriteBatch.Draw(GOtex, GOpos, null);
                if (Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    GO = false;
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
