using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BridgeEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BridgeEngine.Cameras
{
    public class CameraManager : Module
    {
        public static string name = "CameraManager";
        Camera currentCamera;

        public CameraManager(Camera camera) : base(name)
        {
            this.currentCamera = camera;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            currentCamera.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            currentCamera.Update(gameTime);
        }

        public void SetCamera(Camera camera)
        {
            currentCamera = camera;
        }

        public Camera GetCamera()
        {
            return currentCamera;
        }
    }
}
