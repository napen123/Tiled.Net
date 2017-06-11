# Tiled.Net
A .NET library for reading Tiled maps.

## About Tiled.Net
Tiled.Net provides a general way of reading and writing TMX (Tiled Map XML) files. Tiled.Net aims to be usable everywhere, rather than being tied to things like XNA/MonoGame and Unity. 

Tiled.Net should be compatible with the official format, which can be viewed [here](http://doc.mapeditor.org/reference/tmx-map-format/).

## Dependencies
No external dependencies required other than .NET 4.5+.

## Usage
* Add the using statement

```csharp
using Tiled;
```

### Reading a Map File

* Create a new TiledMap object

```csharp
var map = new TiledMap("my-map.tmx");
```

### Accessing Layers
```csharp
var layer = map.Layers[0] as TiledTileLayer;
// or
var layer = map["My Layer"] as TiledTileLayer;
...
var layerName = layer.Name;
...
```

### Creating a Map File

* Create a new TiledMap object and initialize any necessary properties

```csharp
var map = new TiledMap
{
    TileWidth = 16,
    TileHeight = 16,
    Layers = new List<TiledBaseLayer>
    {
        new TiledTileLayer
        {
            Name = "Foreground"
        }
    }
    ...
};
```

* Save the map to a file

```csharp
// Save the map to be _readable_.
map.Save("my-map.tmx");

// Save the map to be _compact_.
map.SaveCompact("my-map.tmx");
```
