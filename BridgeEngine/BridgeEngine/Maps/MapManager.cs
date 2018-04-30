using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BridgeEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BridgeEngine.Cameras;
using BridgeEngine.Asset;

namespace BridgeEngine.Maps
{
    public class MapManager : Module
    {
        public static string name = "MapManager";

        public Map currentMap;
        private CameraManager cameraManager;

        public MapManager(CameraManager cameraManager, AssetManager assetManager) : base(name, false)
        {
            this.cameraManager = cameraManager;
            LoadMap(assetManager, Vector2.Zero);
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            currentMap.Draw(spriteBatch, cameraManager);
        }

        public override void Update(GameTime gameTime)
        {
            currentMap.Update(gameTime);
        }

        public void LoadMap(AssetManager assetmanager, Vector2 Position)
        {            
            currentMap = assetmanager.LoadMap("C:/Users/Dominic/Desktop/map.txt");
        }
    }
}
