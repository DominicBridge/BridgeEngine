using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeEngine.Scene
{
    public class SceneManager : Module
    {
        public static String name = "SceneManager";
        private Scene currentScene;

        public SceneManager(bool enabled) : base(name, enabled) {        }

        public override void Update(GameTime gameTime)
        {
            currentScene.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            currentScene.Draw(spriteBatch);
        }

        public void ChangeScene(Scene newScene)
        {
            newScene.OnJoin();
            currentScene = newScene;
        }

        public Scene GetCurrentScene()
        {
            return currentScene;
        }

        public void LeaveCurrentScene()
        {
            currentScene.OnLeave();
        }
    }
}
