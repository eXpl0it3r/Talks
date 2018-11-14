#include <SFML/Graphics.hpp>

int main()
{
    sf::ContextSettings settings;
    settings.antialiasingLevel = 8;

    sf::RenderWindow window{ { 800, 800 }, "Shapes - Meeting C++ 2018", sf::Style::Default, settings };
    window.setFramerateLimit(60);

    sf::RectangleShape rectangle{ { 220.f, 160.f } };
    rectangle.setFillColor(sf::Color::White);
    rectangle.setPosition({ 150.f, 20.f });
    rectangle.rotate(20.f);

    sf::CircleShape circle{ 100.f };
    circle.setFillColor(sf::Color{ 0x006495FF });
    circle.setOutlineColor(sf::Color{ 224, 160, 37, 255 });
    circle.setOutlineThickness(5.f);
    circle.setPosition({ 300.f, 395.f });

    sf::ConvexShape trapezoid{ 4 };
    trapezoid.setPoint(0, { 100.f, 0.f });
    trapezoid.setPoint(1, { 0.f, 200.f });
    trapezoid.setPoint(2, { 600.f, 200.f });
    trapezoid.setPoint(3, { 500.f, 0.f });
    trapezoid.setFillColor(sf::Color{ 0xF2635FFF });
    trapezoid.setPosition({ 100.f, 600.f });

    while (window.isOpen())
    {
        sf::Event event;
        while (window.pollEvent(event))
        {
            if (event.type == sf::Event::Closed)
            {
                window.close();
            }
        }

        window.clear();
		window.draw(rectangle);
		window.draw(circle);
		window.draw(trapezoid);
        window.display();
    }
}