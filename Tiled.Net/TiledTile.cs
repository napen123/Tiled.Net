﻿using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Tiled
{
    /// <summary>
    /// Represents a tile within a tileset.
    /// </summary>
    /// <remarks>Not to be confused with a tile within a tile layer (<see cref="TiledTileData"/>).</remarks>
    /// <see cref="TiledTileset"/>
    public class TiledTile
    {
        /// <summary>
        /// The terrain type of each corner of a tile.
        /// </summary>
        public enum TerrainType
        {
            NoTerrain,

            [XmlEnum("top-left")]
            TopLeft,

            [XmlEnum("top-right")]
            TopRight,

            [XmlEnum("bottom-left")]
            BottomLeft,

            [XmlEnum("bottom-right")]
            BottomRight
        }

        /// <summary>
        /// The local tile ID within its tileset.
        /// </summary>
        [XmlAttribute("id")]
        public int Id;

        /// <summary>
        /// The type of the tile. Refers to an object type and is used by tile objects.
        /// </summary>
        [XmlAttribute("type")]
        public string Type;

        /// <summary>
        /// Defines the terrain type of each corner of the tile.
        /// </summary>
        [XmlAttribute("terrain")]
        public TerrainType Terrain;

        /// <summary>
        /// A percentage indicating the probability that this tile is chosen when it competes with others while editing with the terrain tool.
        /// This is optional.
        /// </summary>
        [XmlAttribute("probability")]
        public float Probability = 1;

        /// <summary>
        /// A list of animation frames.
        /// </summary>
        /// <remarks>
        /// Currently, only one animation can be associated with a tile.
        /// </remarks>
        [XmlArray("animation")]
        [XmlArrayItem("frame")]
        public List<TiledAnimationFrame> Animation;

        /// <summary>
        /// Custom properties for the tile. These are arbitrary and are meant for the user.
        /// </summary>
        [XmlArray("properties")]
        [XmlArrayItem("property")]
        public List<TiledProperty> Properties;

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeType()
        {
            return !string.IsNullOrWhiteSpace(Type);
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeTerrain()
        {
            return Terrain != TerrainType.NoTerrain;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeProbability()
        {
            return Math.Abs(Probability - 1.0f) > float.Epsilon;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeProperties()
        {
            return Properties != null && Properties.Count > 0;
        }

        /// <summary>
        /// Nothing to see here. Used for serialization.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeAnimation()
        {
            return Animation != null && Animation.Count > 0;
        }
    }
}
