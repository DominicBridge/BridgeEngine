using BridgeEngine.Asset;
using BridgeEngine.Cameras;
using BridgeEngine.Display;
using BridgeEngine.Input;
using BridgeEngine.Maps;
using BridgeEngine.Network;
using BridgeEngine.Scene;
using BridgeEngine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeEngine
{
    public class BridgeEngine
    {
        Dictionary<String, Module> modules = new Dictionary<string, Module>();

        public BridgeEngine()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            foreach(Module module in modules.Values)
            {
                if (module.IsEnabled())
                {
                    module.Update(gameTime);
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Module module in modules.Values)
            {
                if (module.IsEnabled())
                {
                    module.Draw(spriteBatch);
                }
            }
        }

        public void AddModule(Module module)
        {
            modules.Add(module.GetName(), module);
        }

        public void RemoveModule(string key)
        {
            modules.Remove(key);
        }

        public Module GetModule(string key)
        {
            if (modules.ContainsKey(key))
                return modules[key];
            
            return null;
        }

        public SceneManager GetSceneManager()
        {
            if (modules.ContainsKey(SceneManager.name))
                return modules[SceneManager.name] as SceneManager;

            return null;
        }

        public AssetManager GetAssetManager()
        {
            if (modules.ContainsKey(AssetManager.name))
                return modules[AssetManager.name] as AssetManager;

            return null;
        }

        public InputManager GetInputManager()
        {
            if (modules.ContainsKey(InputManager.name))
                return modules[InputManager.name] as InputManager;

            return null;
        }

        public DisplayManager GetDisplayManager()
        {
            if (modules.ContainsKey(DisplayManager.name))
                return modules[DisplayManager.name] as DisplayManager;

            return null;
        }

        public ConnectionManager GetConnectionManager()
        {
            if (modules.ContainsKey(ConnectionManager.name))
                return modules[ConnectionManager.name] as ConnectionManager;

            return null;
        }

        public UIManager GetUIManager()
        {
            if (modules.ContainsKey(UIManager.name))
                return modules[UIManager.name] as UIManager;

            return null;
        }

        public CameraManager GetCameraManager()
        {
            if (modules.ContainsKey(CameraManager.name))
                return modules[CameraManager.name] as CameraManager;

            return null;
        }

        public MapManager GetMapManager()
        {
            if (modules.ContainsKey(MapManager.name))
                return modules[MapManager.name] as MapManager;

            return null;
        }
    }
}