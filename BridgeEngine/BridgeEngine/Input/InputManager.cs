using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BridgeEngine.Input
{
    public class InputManager : Module
    {
        public static String name = "InputManager";

        public InputManager(bool enabled) : base(name, enabled)
        {
        }

        public override void Draw(SpriteBatch spriteBatch){        }

        KeyboardState keyboardState, oldKeyboardState;
        MouseState mouseState, oldMouseState;
        GamePadState gamePadState, oldGamePadState;

        public override void Update(GameTime gameTime)
        {
            oldGamePadState = gamePadState;
            oldKeyboardState = keyboardState;
            oldMouseState = mouseState;

            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            gamePadState = GamePad.GetState(PlayerIndex.One);            

        }

        public Point GetMousePosition()
        {
            return mouseState.Position;
        }

        public bool HasLeftClicked()
        {
            return mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released;
        }

        public bool IsKeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        public bool IsKeyTriggered(Keys key)
        {
            if (keyboardState.IsKeyDown(key))
            {

            }
            return keyboardState.IsKeyDown(key) && (!oldKeyboardState.IsKeyDown(key));
        }
        
    }
}
