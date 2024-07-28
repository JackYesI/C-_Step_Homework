#pragma once

#include "MainMenuState.h"

class OptionState : public GameState {
public:
    OptionState();
    ~OptionState();
    void handleEvent(Game& game, sf::Event event) override;
    void update(Game& game, sf::Time deltaTime) override;
    void render(Game& game, sf::RenderWindow& window) override;

private:
    sf::Font font;
    sf::Text optionText;
    sf::Text backText;
    sf::Text text;
    std::vector<sf::VideoMode> modes;
    size_t i;

};
