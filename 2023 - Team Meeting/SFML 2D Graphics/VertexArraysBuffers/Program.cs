using SFML.Graphics;
using SFML.System;
using SFML.Window;
using VertexArraysBuffers;

var contextSettings = new ContextSettings(0, 0, 8);
var window = new RenderWindow(new VideoMode(800, 800), "VertexArrays & VertexBuffers - Team Meeting 2023", Styles.Default, contextSettings);

window.SetFramerateLimit(120);

var triangle = new VertexArray(PrimitiveType.Triangles);
triangle.Append(new Vertex(new Vector2f(200f, 50f), Color.Green));
triangle.Append(new Vertex(new Vector2f(100f, 150f), Color.White));
triangle.Append(new Vertex(new Vector2f(300f, 150f), new Color(0x73AE27FF)));

var texture = new Texture("sfml-logo.png");

var sfmlLogo = new VertexArray(PrimitiveType.Triangles);
sfmlLogo.Append(new Vertex(new Vector2f(200f, 480f), new Vector2f(0f, 0f)));
sfmlLogo.Append(new Vertex(new Vector2f(200f, 780f), new Vector2f(0f, 300f)));
sfmlLogo.Append(new Vertex(new Vector2f(500f, 780f), new Vector2f(300f, 300f)));
sfmlLogo.Append(new Vertex(new Vector2f(500f, 780f), new Vector2f(300f, 300f)));
sfmlLogo.Append(new Vertex(new Vector2f(500f, 480f), new Vector2f(300f, 0f)));
sfmlLogo.Append(new Vertex(new Vector2f(200f, 480f), new Vector2f(0f, 0f)));

var tileset = new Texture("tileset.png");

var level = new List<int>
{
    0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
    0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 2, 0, 0, 0, 0,
    1, 1, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3,
    0, 1, 0, 0, 2, 0, 3, 3, 3, 0, 1, 1, 1, 0, 0, 0,
    0, 1, 1, 0, 3, 3, 3, 0, 0, 0, 1, 1, 1, 2, 0, 0,
    0, 0, 1, 0, 3, 0, 2, 2, 0, 0, 1, 1, 1, 1, 2, 0,
    2, 0, 1, 0, 3, 0, 2, 2, 2, 0, 1, 1, 1, 1, 1, 1,
    0, 0, 1, 0, 3, 2, 2, 2, 0, 0, 0, 0, 1, 1, 1, 1
};

var tileMap = new TileMap(tileset);
tileMap.Load(level, new Vector2u(16, 8), new Vector2u(32, 32));

window.Closed += (_, _) => window.Close();

while (window.IsOpen)
{
    window.DispatchEvents();

    window.Clear();
    window.Draw(triangle);
    window.Draw(sfmlLogo, new RenderStates(texture));
    window.Draw(tileMap);
    window.Display();
}