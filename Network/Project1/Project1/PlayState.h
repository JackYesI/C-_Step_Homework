#pragma once

#include "States_Game_ABS.h"

class PlayState : public GameState {
public:
    PlayState();
    void handleEvent(Game& game, sf::Event event) override;
    void update(Game& game, sf::Time deltaTime) override;
    void render(Game& game, sf::RenderWindow& window) override;
};
