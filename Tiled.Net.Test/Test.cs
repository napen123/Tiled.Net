using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tiled.Net.Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void SimpleTest()
        {
            // Write
            {
                new TiledMap
                {
                    TileWidth = 16,
                    TileHeight = 16,
                    Layers = new List<TiledBaseLayer> {new TiledTileLayer {Name = "Tile Layer"}}
                }.Save("simple.tmx");
            }

            // Read
            {
                var map = new TiledMap("simple.tmx");
                
                Assert.AreEqual(16, map.TileWidth);
                Assert.AreEqual(16, map.TileHeight);

                Assert.IsNotNull(map.Layers);
                Assert.AreEqual(1, map.Layers.Count);

                var layer = map.Layers[0] as TiledTileLayer;

                Assert.IsNotNull(layer);
                Assert.AreEqual("Tile Layer", layer.Name);
            }
        }
    }
}
