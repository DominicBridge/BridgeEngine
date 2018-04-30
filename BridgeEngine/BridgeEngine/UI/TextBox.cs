using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeEngine.UI
{
    public class TextBox : UIComponent
    {
        private bool password = false;
        private string passwordText = "*";

        private Action onEnter;
        private Action onTab;

        public TextBox(BridgeEngine bridgeEngine, Rectangle position) : base(bridgeEngine)
        {
            base.position = position;
        }

        public TextBox(BridgeEngine bridgeEngine, Rectangle position, bool focus) : base(bridgeEngine)
        {
            base.position = position;
            SetFocus(focus);
        }


        public override void Update(GameTime gameTime)
        {
            
        }

        internal void AddToText(string v)
        {
            text += v;
        }

        internal void Backspace()
        {
            if(!String.IsNullOrEmpty(text))
                text = text.Remove(text.Length - 1);
        }

        public void OnEnterPressed()
        {
            onEnter?.Invoke();
        }

        public void SetOnEnter(Action onEnter)
        {
            this.onEnter = onEnter;
        }
        public string GetText()
        {
            return text;
        }

        public void SetText(string v)
        {
            text = v;
        }

        internal void OnTabPressed()
        {
            onTab?.Invoke(); ;
        }

        public void SetOnTab(Action onTab)
        {
            this.onTab = onTab;
        }
    }
}
