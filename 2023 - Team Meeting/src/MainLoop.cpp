#include <SFML/Graphics.hpp>

int main()
{
    sf::RenderWindow window{ { 800, 800 }, "Main Loop - Meeting C++ 2018" };
    window.setFramerateLimit(60);

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
        window.display();
    }
}