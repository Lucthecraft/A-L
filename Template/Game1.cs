using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D palTex, balTex;
        Vector2 palPos, balPos;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            palTex = Content.Load<Texture2D>("paddle");
            balTex = Content.Load<Texture2D>("ball");

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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(balTex, balPos, null);
            spriteBatch.Draw(palTex, palPos, null);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
