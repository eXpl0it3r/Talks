using SFML.Graphics;
using SFML.System;
using SFML.Window;

var contextSettings = new ContextSettings(0, 0, 8);
var window = new RenderWindow(new VideoMode(800, 800), "Texts & Fonts - Team Meeting 2023", Styles.Default, contextSettings);

window.SetFramerateLimit(120);

var font = new Font("DejaVuSans.ttf");

var teamMeeting = new Text("Team Meeting 2023", font, 60);
teamMeeting.Position = new Vector2f(100, 300);
teamMeeting.Style = Text.Styles.Bold;
teamMeeting.Rotation = 20f;

var sfml = new Text("SFML", font, 80);
sfml.Position = new Vector2f(300f, 100f);
sfml.FillColor = Color.White;
sfml.OutlineColor = new Color(0x8ECF3CFF);
sfml.OutlineThickness = 5f;
sfml.LetterSpacing = 1.5f;

window.Closed += (_, _) => window.Close();

while (window.IsOpen)
{
    window.DispatchEvents();

    window.Clear();
    window.Draw(teamMeeting);
    window.Draw(sfml);
    window.Display();
}