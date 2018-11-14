#include <SFML/Graphics.hpp>

class TileMap : public sf::Drawable, public sf::Transformable
{
public:
	TileMap(sf::Texture& tileset)
		: m_tileset(tileset)
	{}

	bool load(const std::vector<int>& tiles, sf::Vector2u map_dimension, sf::Vector2u tile_dimension)
	{
		if (tiles.size() / map_dimension.x != map_dimension.y)
		{
			return false;
		}

		m_vertex_buffer.setUsage(sf::VertexBuffer::Usage::Static);
		m_vertex_buffer.setPrimitiveType(sf::Quads);
		m_vertex_buffer.create(tiles.size() * 4);
		m_vertices.resize(tiles.size() * 4);

		for (auto x = 0u; x < map_dimension.x; ++x)
		{
			for (auto y = 0u; y < map_dimension.y; ++y)
			{
				int tileNumber = tiles[x + y * map_dimension.x];

				int tu = tileNumber % (m_tileset.getSize().x / tile_dimension.x);
				int tv = tileNumber / (m_tileset.getSize().x / tile_dimension.x);

				sf::Vertex* quad = &m_vertices[(x + y * map_dimension.x) * 4];

				quad[0].position = sf::Vector2f(x * tile_dimension.x, y * tile_dimension.y);
				quad[1].position = sf::Vector2f((x + 1) * tile_dimension.x, y * tile_dimension.y);
				quad[2].position = sf::Vector2f((x + 1) * tile_dimension.x, (y + 1) * tile_dimension.y);
				quad[3].position = sf::Vector2f(x * tile_dimension.x, (y + 1) * tile_dimension.y);

				quad[0].texCoords = sf::Vector2f(tu * tile_dimension.x, tv * tile_dimension.y);
				quad[1].texCoords = sf::Vector2f((tu + 1) * tile_dimension.x, tv * tile_dimension.y);
				quad[2].texCoords = sf::Vector2f((tu + 1) * tile_dimension.x, (tv + 1) * tile_dimension.y);
				quad[3].texCoords = sf::Vector2f(tu * tile_dimension.x, (tv + 1) * tile_dimension.y);
			}
		}

		m_vertex_buffer.update(m_vertices.data());

		return true;
	}

private:

	virtual void draw(sf::RenderTarget& target, sf::RenderStates states) const
	{
		states.transform *= getTransform();
		states.texture = &m_tileset;
		target.draw(m_vertex_buffer, states);
	}

	std::vector<sf::Vertex> m_vertices;
	sf::VertexBuffer m_vertex_buffer;
	sf::Texture& m_tileset;
};

int main()
{
    sf::RenderWindow window{ { 800, 800 }, "VertexArrays & VertexBuffers - Meeting C++ 2018" };
    window.setFramerateLimit(60);
 
	sf::Texture texture;
	if (!texture.loadFromFile("sfml-logo.png"))
	{
		return -1;
	}

	sf::VertexArray triangle{ sf::PrimitiveType::Triangles, 3 };
	triangle[0].position = { 200.f, 50.f };
	triangle[0].color = sf::Color::Green;
	triangle[1].position = { 100.f, 150.f };
	triangle[1].color = sf::Color::White;
	triangle[2].position = { 300.f, 150.f };
	triangle[2].color = sf::Color{ 0x73AE27FF };

	sf::VertexArray sfml_logo{ sf::PrimitiveType::Triangles, 6};
	sfml_logo[0].position = { 200.f, 480.f };
	sfml_logo[1].position = { 200.f, 780.f };
	sfml_logo[2].position = { 500.f, 780.f };
	sfml_logo[3].position = { 500.f, 780.f };
	sfml_logo[4].position = { 500.f, 480.f };
	sfml_logo[5].position = { 200.f, 480.f };
	sfml_logo[0].texCoords = { 0.f, 0.f };
	sfml_logo[1].texCoords = { 0.f, 300.f };
	sfml_logo[2].texCoords = { 300.f, 300.f };
	sfml_logo[3].texCoords = { 300.f, 300.f };
	sfml_logo[4].texCoords = { 300.f, 0.f };
	sfml_logo[5].texCoords = { 0.f, 0.f };

	std::vector<int> level{
		0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 2, 0, 0, 0, 0,
		1, 1, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3,
		0, 1, 0, 0, 2, 0, 3, 3, 3, 0, 1, 1, 1, 0, 0, 0,
		0, 1, 1, 0, 3, 3, 3, 0, 0, 0, 1, 1, 1, 2, 0, 0,
		0, 0, 1, 0, 3, 0, 2, 2, 0, 0, 1, 1, 1, 1, 2, 0,
		2, 0, 1, 0, 3, 0, 2, 2, 2, 0, 1, 1, 1, 1, 1, 1,
		0, 0, 1, 0, 3, 2, 2, 2, 0, 0, 0, 0, 1, 1, 1, 1,
	};

	sf::Texture tileset;
	if (!tileset.loadFromFile("tileset.png"))
	{
		return -1;
	}

	TileMap map{ tileset };
	map.load(level, { 16u, 8u }, { 32u, 32u });
	map.setPosition({ 200.f, 200.f });

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
		window.draw(triangle);
		window.draw(sfml_logo, &texture);
		window.draw(map);
        window.display();
    }
}
