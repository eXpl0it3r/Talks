using SFML.Graphics;
using SFML.System;

namespace VertexArraysBuffers;

public class TileMap : Drawable
{
    private readonly Texture _tileset;
    private readonly Transform _transform;
    private readonly List<Vertex> _verticies;
    private VertexBuffer? _vertexBuffer;


    public TileMap(Texture tileset)
    {
        _tileset = tileset;
        _verticies = new List<Vertex>();

        _transform = Transform.Identity;
        _transform.Translate(new Vector2f(200f, 200f));
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
        states.Transform *= _transform;
        states.Texture = _tileset;
        target.Draw(_vertexBuffer, states);
    }

    public bool Load(List<int> tiles, Vector2u mapDimension, Vector2u tileDimension)
    {
        if (tiles.Count / mapDimension.X != mapDimension.Y)
        {
            return false;
        }

        _vertexBuffer = new VertexBuffer((uint) tiles.Count * 4,
            PrimitiveType.Quads,
            VertexBuffer.UsageSpecifier.Static);

        for (var x = 0; x < mapDimension.X; ++x)
        {
            for (var y = 0; y < mapDimension.Y; y++)
            {
                var tileNumber = tiles[x + y * (int) mapDimension.X];

                var tu = (int) (tileNumber % (_tileset.Size.X / tileDimension.X));
                var tv = (int) (tileNumber / (_tileset.Size.X / tileDimension.X));

                _verticies.Add(new Vertex(new Vector2f(x * tileDimension.X, y * tileDimension.Y), new Vector2f(tu * tileDimension.X, tv * tileDimension.Y)));
                _verticies.Add(new Vertex(new Vector2f((x + 1) * tileDimension.X, y * tileDimension.Y), new Vector2f((tu + 1) * tileDimension.X, tv * tileDimension.Y)));
                _verticies.Add(new Vertex(new Vector2f((x + 1) * tileDimension.X, (y + 1) * tileDimension.Y), new Vector2f((tu + 1) * tileDimension.X, (tv + 1) * tileDimension.Y)));
                _verticies.Add(new Vertex(new Vector2f(x * tileDimension.X, (y + 1) * tileDimension.Y), new Vector2f(tu * tileDimension.X, (tv + 1) * tileDimension.Y)));
            }
        }

        _vertexBuffer.Update(_verticies.ToArray());

        return true;
    }
}