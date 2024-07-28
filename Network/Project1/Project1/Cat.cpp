#include "Cat.h"
#include <iostream>

void Cat::draw(sf::RenderTarget& target, sf::RenderStates states) const
{
	states.transform *= getTransform();

	states.texture = &texture_cat;

	target.draw(Sprite_cat, states);
}

Cat::Cat(const std::string& texture_set) :
    frame_duration(sf::seconds(0.1f)), // Час між кадрами
    current_frame(0),
    is_moving(false),
    is_facing_right(true),
    is_sleep(false),
    is_fall_in_sleep(false),
    time_since_last_frame(sf::Time::Zero)
{
	texture_cat.loadFromFile(texture_set);

    Sprite_cat.setTexture(texture_cat);

    // Ініціалізація кадрів для анімації спокою
    for (size_t i = 0; i < 2; i++)
    {
        for (size_t j = 0; j < 8; j++)
        {
            frames_idle[i * 8 + j] = sf::IntRect(32 * j, 32 * i, 32, 32);
        }
    }

    // Ініціалізація кадрів для анімації руху
    for (size_t i = 0; i < 8; i++)
    {
        frames_move[i] = sf::IntRect(i * 32, 160, 32, 32);
    }

    for (size_t i = 0; i < 8; i++)
    {
        frames_fall_in_sleep[i] = sf::IntRect(i * 32, 320, 32, 32);
    }

    for (size_t i = 0; i < 8; i++)
    {
        frames_sleep[i] = sf::IntRect(i * 32, 352, 32, 32);
    }

    Sprite_cat.setTextureRect(frames_idle[0]);
    Sprite_cat.setPosition(256, 128);


	//vertex_cat.setPrimitiveType(sf::Triangles);
	//vertex_cat.resize(6);

	//vertex_cat[0].position = sf::Vector2f(256, 128);
	//vertex_cat[1].position = sf::Vector2f(288, 128);
	//vertex_cat[2].position = sf::Vector2f(256, 160);
	//vertex_cat[3].position = sf::Vector2f(256, 160);
	//vertex_cat[4].position = sf::Vector2f(288, 128);
	//vertex_cat[5].position = sf::Vector2f(288, 160);

	//int tile_x = 0; // Координата x тайла у текстурі
	//int tile_y = 0; // Координата y тайла у текстурі
	//int tile_width = 32; // Ширина тайла
	//int tile_height = 32; // Висота тайла

	//vertex_cat[0].texCoords = sf::Vector2f(tile_x, tile_y);
	//vertex_cat[1].texCoords = sf::Vector2f(tile_x + tile_width, tile_y);
	//vertex_cat[2].texCoords = sf::Vector2f(tile_x, tile_y + tile_height);
	//vertex_cat[3].texCoords = sf::Vector2f(tile_x, tile_y + tile_height);
	//vertex_cat[4].texCoords = sf::Vector2f(tile_x + tile_width, tile_y);
	//vertex_cat[5].texCoords = sf::Vector2f(tile_x + tile_width, tile_y + tile_height);
}

void Cat::update(sf::Event& event)
{
    if (event.type == sf::Event::KeyPressed)
    {
        if (event.key.scancode == sf::Keyboard::Scan::A)
        {
            is_sleep = false;
            is_fall_in_sleep = false;
            if (Sprite_cat.getPosition().x > 0)
            {
                Sprite_cat.move(-4.f, 0.f);
                is_moving = true;
                if (is_facing_right)
                {
                    Sprite_cat.setScale(-1.f, 1.f);
                    Sprite_cat.setPosition(Sprite_cat.getPosition().x + 32, Sprite_cat.getPosition().y);
                    is_facing_right = false;
                }
            }
        }
        if (event.key.scancode == sf::Keyboard::Scan::D)
        {
            is_sleep = false;
            is_fall_in_sleep = false;
            if (Sprite_cat.getPosition().x < 3164)
            {
                Sprite_cat.move(4.f, 0.f);
                is_moving = true;
                if (!is_facing_right)
                {
                    Sprite_cat.setScale(1.f, 1.f);
                    Sprite_cat.setPosition(Sprite_cat.getPosition().x - 32, Sprite_cat.getPosition().y);
                    is_facing_right = true;
                }
            }
                
        }
        if (event.key.scancode == sf::Keyboard::Scan::W)
        {
            is_sleep = false;
            if (Sprite_cat.getPosition().y > 0)
            {
                Sprite_cat.move(0.f, -4.f);
                is_moving = true;
                is_fall_in_sleep = false;
            }
        }
        if (event.key.scancode == sf::Keyboard::Scan::S)
        {
            is_sleep = false;
            if (Sprite_cat.getPosition().y < 3164)
            {
                Sprite_cat.move(0.f, 4.f);
                is_moving = true;
                is_fall_in_sleep = false;
            }
        }
        if (event.key.scancode == sf::Keyboard::Scan::Z)
        {
            is_fall_in_sleep = true;
        }
    }

}

const sf::Vector2f Cat::getPosition() const
{
    return Sprite_cat.getPosition();
}

void Cat::animate(sf::Time deltaTime)
{
    time_since_last_frame += deltaTime;

    if (time_since_last_frame >= frame_duration)
    {
        time_since_last_frame = sf::Time::Zero;
     
        /*if (current_frame >= 16) current_frame = 0;*/
        std::cout << "Current frame is " << current_frame << std::endl;
        if (is_moving)
        {
            current_frame = (current_frame + 1) % 8; // 4 кадри для руху
            Sprite_cat.setTextureRect(frames_move[current_frame]);
            is_moving = false;
        }
        else if (is_fall_in_sleep)
        {
            if (is_sleep)
            {
                current_frame = (current_frame + 1) % 8; // 4 кадри для руху
                Sprite_cat.setTextureRect(frames_sleep[current_frame]);
            }
            else
            {
                if (current_frame + 1 == 8)
                {
                    is_sleep = true;
                }
                current_frame = (current_frame + 1) % 8; // 4 кадри для руху
                Sprite_cat.setTextureRect(frames_fall_in_sleep[current_frame]);
            }
        }
        else
        {
            current_frame = (current_frame + 1) % 16; // 2 кадри для спокою
            Sprite_cat.setTextureRect(frames_idle[current_frame]);
        }
    }
}
