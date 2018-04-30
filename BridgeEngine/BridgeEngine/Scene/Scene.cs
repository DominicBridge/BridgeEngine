using BridgeEngine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BridgeEngine.Scene
{
    public abstract class Scene
    {
        public bool isActive = true;
        protected BridgeEngine bridgeEngine;
        public Scene(BridgeEngine bridgeEngine )
        {            
            this.bridgeEngine = bridgeEngine;
            SetupUI(bridgeEngine.GetUIManager());
        }
        protected bool isLeaving, isJoining;
        public virtual void Leaving(GameTime gameTime)
        {

        }
        public virtual void Joining(GameTime gameTime)
        {

        }
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);
        public abstract void OnJoin();
        public abstract void OnLeave();
        public abstract void SetupUI(UIManager uiManager);
        public void SetIsActive(bool active)
        {
            isActive = active; 
        }
    }
}
