#pragma once
#include <SFML/Graphics.hpp>

class Cat : public sf::Drawable, public sf::Transformable
{
private:

	virtual void draw(sf::RenderTarget& target, sf::RenderStates states) const;

	sf::Texture texture_cat;
	sf::Sprite Sprite_cat;

	sf::IntRect frames_idle[16];
	sf::IntRect frames_move[8];
	sf::IntRect frames_fall_in_sleep[8];
	sf::IntRect frames_sleep[8];

	int current_frame;
	bool is_moving;
	bool is_facing_right;
	bool is_sleep;
	bool is_fall_in_sleep;

	sf::Time time_since_last_frame;
	sf::Time frame_duration;


public:
	Cat(const std::string& texture_set);
	void update(sf::Event& event);
	const sf::Vector2f getPosition() const;
	void animate(sf::Time deltaTime);
};