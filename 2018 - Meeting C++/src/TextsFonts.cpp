#include <SFML/Graphics.hpp>

int main()
{
    sf::RenderWindow window{ { 800, 800 }, "Texts & Fonts - Meeting C++ 2018" };
    window.setFramerateLimit(60);

    sf::Font font;
    if (!font.loadFromFile("DejaVuSans.ttf"))
    {
        return -1;
    }

    sf::Text meeting_cpp{ "Meeting C++ 2018", font, 60 };
	meeting_cpp.setPosition({ 100.f, 300.f });
	meeting_cpp.setStyle(sf::Text::Bold);
	meeting_cpp.rotate(20.f);

    sf::Text sfml{ "SFML", font, 80 };
	sfml.setPosition({ 300.f, 100.f });
	sfml.setFillColor(sf::Color::White);
	sfml.setOutlineColor(sf::Color{ 0x8ECF3CFF });
	sfml.setOutlineThickness(5.f);
	sfml.setLetterSpacing(1.5f);

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
        window.draw(meeting_cpp);
        window.draw(sfml);
        window.display();
    }
}
