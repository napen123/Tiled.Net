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

        [TestMethod]
        public void ReadTest()
        {
            var map = new TiledMap("test.tmx");

            Assert.AreEqual(16, map.TileWidth);
            Assert.AreEqual(16, map.TileHeight);
            Assert.AreEqual("#14323c", map.BackgroundColorHex.ToLower());
            
            Assert.IsNotNull(map.Layers);
            Assert.AreEqual(3, map.Layers.Count);

            var background = map.Layers[0] as TiledTileLayer;
            var middleground = map.Layers[1] as TiledObjectGroup;
            var foreground = map.Layers[2] as TiledTileLayer;

            Assert.IsNotNull(background);
            Assert.IsNotNull(middleground);
            Assert.IsNotNull(foreground);

            Assert.AreEqual("Background", background.Name);
            Assert.AreEqual("Middleground", middleground.Name);
            Assert.AreEqual("Foreground", foreground.Name);

            Assert.IsNotNull(middleground.Objects);
            Assert.AreEqual(3, middleground.Objects.Count);

            var rect1 = middleground.Objects[0];
            var rect2 = middleground.Objects[1];

            Assert.AreEqual(16, rect1.X);
            Assert.AreEqual(128, rect2.X);

            Assert.AreEqual(36, rect1.Y);
            Assert.AreEqual(36, rect2.Y);

            Assert.AreEqual(16, rect1.Width);
            Assert.AreEqual(16, rect2.Width);

            Assert.AreEqual(85, rect1.Height);
            Assert.AreEqual(85, rect2.Height);
        }

        [TestMethod]
        public void LayerAccessTest()
        {
            var map = new TiledMap("test.tmx");
            
            Assert.IsNotNull(map.Layers[0] as TiledTileLayer);
            Assert.IsNotNull(map.Layers[1] as TiledObjectGroup);
            Assert.IsNotNull(map.Layers[2] as TiledTileLayer);

            Assert.IsNotNull(map["Background"] as TiledTileLayer);
            Assert.IsNotNull(map["Middleground"] as TiledObjectGroup);
            Assert.IsNotNull(map["Foreground"] as TiledTileLayer);

            map["Middleground"] = new TiledTileLayer {Name = "Middleground" };

            Assert.IsNotNull(map["Middleground"]);
        }

        [TestMethod]
        public void ObjectAccessTest()
        {
            var map = new TiledMap("test.tmx");
            var middle = map["Middleground"] as TiledObjectGroup;

            Assert.IsNotNull(middle);

            Assert.IsNotNull(middle["LeftRectangle"]);
            Assert.IsNotNull(middle["RightRectangle"]);

            Assert.IsNotNull(middle[1]);
            Assert.IsNotNull(middle[2]);
        }
    }
}
