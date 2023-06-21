using SFML.Graphics;
using SFML.System;
using SFML.Window;

var contextSettings = new ContextSettings(0, 0, 8);
var window = new RenderWindow(new VideoMode(800, 800), "Sprites & Textures - Team Meeting 2023", Styles.Default, contextSettings);

window.SetFramerateLimit(120);

var texture = new Texture("sfml-logo.png");

var fullLogo = new Sprite(texture);
fullLogo.Position = new Vector2f(300f, 300f);

var partialLogo = new Sprite(texture);
partialLogo.TextureRect = new IntRect(100, 50, 100, 100);
partialLogo.Position = new Vector2f(100, 200);

window.Closed += (_, _) => window.Close();

while (window.IsOpen)
{
    window.DispatchEvents();

    window.Clear();
    window.Draw(fullLogo);
    window.Draw(partialLogo);
    window.Display();
}