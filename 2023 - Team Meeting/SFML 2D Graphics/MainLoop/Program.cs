using SFML.Graphics;
using SFML.Window;

var window = new RenderWindow(new VideoMode(800, 800), "Main Loop - Team Meeting 2023");
window.SetFramerateLimit(120);

window.Closed += (_, _) => window.Close();

while (window.IsOpen)
{
    window.DispatchEvents();

    window.Clear();
    window.Display();
}