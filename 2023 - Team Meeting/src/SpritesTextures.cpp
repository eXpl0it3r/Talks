#include <SFML/Graphics.hpp>

int main()
{
    sf::RenderWindow window{ { 800, 800 }, "Sprites & Textures - Meeting C++ 2018" };
    window.setFramerateLimit(60);

    sf::Texture texture;
    if (!texture.loadFromFile("sfml-logo.png"))
    {
        return -1;
    }

    sf::Sprite full_logo{ texture };
    full_logo.setPosition({ 300.f, 300.f });

    sf::Sprite partial_logo{ texture };
    partial_logo.setTextureRect({ 100, 50, 100, 100 });
    partial_logo.setPosition({ 100.f, 200.f });

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
		window.draw(full_logo);
		window.draw(partial_logo);
        window.display();
    }
}
