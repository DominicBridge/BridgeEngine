using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Timers;

namespace BridgeEngine.UI
{
    public class Button : UIComponent
    {
        bool enabled = true;
        Action<Button> onClick;

        Texture2D texture;

        bool onCooldown = false;
        double cooldownTime = 0;
        private readonly int cooldownInterval = 100;
        private ButtonType buttonType = ButtonType.NORMAL;

        public Button(BridgeEngine bridgeEngine, Rectangle position, string text, Action<Button> onClick) : base(bridgeEngine)
        {
            base.position = position;
            base.text = text;
            this.onClick = onClick;
        }

        public Button(BridgeEngine bridgeEngine, Rectangle position, Texture2D texture, Action<Button> onClick) : base(bridgeEngine)
        {
            base.position = position;
            this.texture = texture;
            this.onClick = onClick;
        }

        public Button(BridgeEngine bridgeEngine, Rectangle position, ButtonType buttonType, Action<Button> onClick) : base(bridgeEngine)
        {           
            base.position = position;            
            this.onClick = onClick;
            this.buttonType = buttonType;
            switch (buttonType)
            {
                case ButtonType.TRANSPARENT:
                    text = "";
                   base.backgroundColor = new Color(Color.White, 0);
                    base.borderColor = new Color(Color.White, 0);
                    base.foregroundColor = new Color(Color.White, 0);                    
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (onCooldown)
            {
                cooldownTime += gameTime.ElapsedGameTime.TotalMilliseconds;
                if(cooldownTime >= cooldownInterval)
                {
                    onCooldown = false;
                    cooldownTime = 0;
                }
            }
            if (enabled)
                if (HasFocus() && !onCooldown)
                {
                    onClick?.Invoke(this);
                    onCooldown = true;
                    hasFocus = false;
                }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (buttonType == ButtonType.TRANSPARENT)
                return;

            if (texture == null)
            {
                base.Draw(spriteBatch);
            }
            else
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
        }

        public void SetEnabled(bool enabled)
        {
            this.enabled = enabled;
        }

        public void SetBackgroundColor(Color color)
        {
            backgroundColor = color;
        }
    }

    public enum ButtonType
    {
        NORMAL,
        TRANSPARENT,        
    }

}