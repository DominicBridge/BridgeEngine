using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BridgeEngine.Cameras;
using BridgeEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BridgeEngine.Maps
{
    public class Layer
    {
        private List<List<Tile>> tileMap;
        private LayerType layerType;

        public Layer(LayerType layerType, List<List<Tile>> tiles)
        {
            this.layerType = layerType;
            tileMap = tiles;
        }
        public void Update(GameTime gameTime)
        {
            for (int y = 0; y < Map.MAPHEIGHT; y++)
            {
                for (int x = 0; x < Map.MAPWIDTH; x++)
                {
                    tileMap[y][x].Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, CameraManager cameraManager, Texture2D tilesheet)
        {
           
            for(int y = 0; y < Map.MAPHEIGHT; y++) { 
                for(int x =0; x< Map.MAPWIDTH; x++) {
                    Rectangle position = new Rectangle(y * cameraManager.GetCamera().GetDrawSize(), x * cameraManager.GetCamera().GetDrawSize(), cameraManager.GetCamera().GetDrawSize(), cameraManager.GetCamera().GetDrawSize());
                    tileMap[y][x].Draw(spriteBatch, cameraManager, tilesheet, position);
                }
            }
        }
    }

    public class LayerType
    {
        public static readonly LayerType GROUND = new LayerType(0);
        public static readonly LayerType OBJECT = new LayerType(1);
        public static readonly LayerType COLLISION = new LayerType(2);
        public static readonly LayerType FRINGE = new LayerType(3);
        public static readonly LayerType HOUSING = new LayerType(4);
        public static readonly LayerType TREE = new LayerType(5);
        public static readonly LayerType LIGHTING = new LayerType(6);

        public static IEnumerable<LayerType> Values
        {
            get
            {
                yield return GROUND;
                yield return OBJECT;
                yield return COLLISION;
                yield return FRINGE;
                yield return HOUSING;
                yield return TREE;
                yield return LIGHTING;
            }
        }

        private readonly int id;

        public LayerType(int id)
        {
            this.id = id;
        }

        public int GetId()
        {
            return id;
        }
        public static LayerType FromId(int v)
        {
            foreach(LayerType type in Values)
            {
                if(type.GetId() == v)
                {
                    return type;
                }
            }

            return GROUND;
        }
    }
}
