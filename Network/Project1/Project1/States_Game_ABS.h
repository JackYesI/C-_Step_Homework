#pragma once
#include <SFML/Graphics.hpp>

class Game;

class GameState {
public:
    virtual ~GameState() {}
    virtual void handleEvent(Game& game, sf::Event event) = 0;
    virtual void update(Game& game, sf::Time deltaTime) = 0;
    virtual void render(Game& game, sf::RenderWindow& window) = 0;
    void centerText(sf::Text& text, float x, float y);
};
