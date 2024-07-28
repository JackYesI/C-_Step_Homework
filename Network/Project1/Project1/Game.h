#pragma once
#include <SFML/Graphics.hpp>
#include <memory>
#include <stack>
#include "States_Game_ABS.h"

class Game {
public:
    Game();
    void run();

    void changeState(std::unique_ptr<GameState> state);
    void pushState(std::unique_ptr<GameState> state);
    void popState();

    sf::RenderWindow& getWindow() { return window; }

private:
    void processEvents();
    void update(sf::Time deltaTime);
    void render();

    sf::RenderWindow window;
    std::stack<std::unique_ptr<GameState>> states;
};