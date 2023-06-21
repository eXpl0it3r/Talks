using SFML.Graphics;
using SFML.System;
using SFML.Window;

var contextSettings = new ContextSettings(0, 0, 8);
var window = new RenderWindow(new VideoMode(800, 800), "Shapes - Team Meeting 2023", Styles.Default, contextSettings);
window.SetFramerateLimit(120);

var rectangle = new RectangleShape(new Vector2f(220f, 160f));
rectangle.FillColor = Color.White;
rectangle.Position = new Vector2f(150f, 20f);
rectangle.Rotation = 20f;

var circle = new CircleShape(100f);
circle.FillColor = new Color(0x006495FF);
circle.OutlineColor = new Color(224, 160, 37, 255);
circle.OutlineThickness = 5f;
circle.Position = new Vector2f(300f, 395f);

var trapezoid = new ConvexShape(4);
trapezoid.SetPoint(0, new Vector2f(100f, 0f));
trapezoid.SetPoint(1, new Vector2f(0f, 200f));
trapezoid.SetPoint(2, new Vector2f(600f, 200f));
trapezoid.SetPoint(3, new Vector2f(500f, 0f));
trapezoid.FillColor = new Color(0xF2635FFF);
trapezoid.Position = new Vector2f(100f, 600f);

window.Closed += (_, _) => window.Close();

while (window.IsOpen)
{
    window.DispatchEvents();

    window.Clear();
    window.Draw(rectangle);
    window.Draw(circle);
    window.Draw(trapezoid);
    window.Display();
}