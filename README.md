# BridgeEngine
An engine usable with MonoGame

Hello,

This is a modular engine designed to be expanded upon. You can choose to use some or all the modules in your project.


Todo List:
Animations
More UI Components
Finish Off Map System
Full Entity design (its quite specific to a tileset at the moment)

Directions for use:

Create a new BridgeEngine instance:
BridgeEngine.BridgeEngine engine = new BridgeEngine.BridgeEngine();

Add Modules to it:
engine.AddModule(new SceneManager(true));
engine.AddModule(new AssetManager(true, Content));
engine.AddModule(new InputManager(true));

In your Games Draw method, simply add
engine.Draw(spriteBatch);

And Update method:
engine.Update(gameTime);
