using Encog.Neural.Networks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using KinectProject.Source;
using KinectProject.Source.Graphics;

namespace KinectProject
{
    public class MainGame : Game
    {
        //Setup Graphics
        Render render;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        //Game file
        private GameController game;
        
        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            //Display
            spriteBatch = new SpriteBatch(GraphicsDevice);
            render = new Render(spriteBatch, graphics.GraphicsDevice, Content);
            
            graphics.PreferredBackBufferWidth = 600;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 600;   // set this value to the desired height of your window

            IsMouseVisible = true;

            graphics.ApplyChanges();
            
            game = new GameController();

            base.Initialize();
        }
        
        protected override void Update(GameTime gameTime)
        {
            game.update();
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            render.start();

            game.draw(render);

            render.end();

            base.Draw(gameTime);
        }
    }
}
