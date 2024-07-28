#pragma once

#include "States_Game_ABS.h"

class MainMenuState : public GameState {
public:
    MainMenuState();
    void handleEvent(Game& game, sf::Event event) override;
    void update(Game& game, sf::Time deltaTime) override;
    void render(Game& game, sf::RenderWindow& window) override;

private:
    sf::Font font;
    sf::Text title;
    sf::Text playText;
    sf::Text optionsText; // Новий текст для опцій
    sf::Text exitText;
};
