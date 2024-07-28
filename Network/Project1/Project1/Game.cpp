#pragma once
#include "Game.h"
#include "MainMenuState.h"

Game::Game() : window(sf::VideoMode(800, 600), "State Pattern Game", sf::Style::None) {
    // Початковий стан
    changeState(std::make_unique<MainMenuState>());
}

void Game::run() {
    sf::Clock clock;
    while (window.isOpen()) {
        sf::Time deltaTime = clock.restart();
        processEvents();
        update(deltaTime);
        render();
    }
}

void Game::changeState(std::unique_ptr<GameState> state) {
    while (!states.empty()) {
        states.pop();
    }
    states.push(std::move(state));
}

void Game::pushState(std::unique_ptr<GameState> state) {
    states.push(std::move(state));
}

void Game::popState() {
    if (!states.empty()) {
        states.pop();
    }
}

void Game::processEvents() {
    sf::Event event;
    while (window.pollEvent(event)) {
        if (!states.empty()) {
            states.top()->handleEvent(*this, event);
        }
        if (event.type == sf::Event::Closed) {
            window.close();
        }
    }
}

void Game::update(sf::Time deltaTime) {
    if (!states.empty()) {
        states.top()->update(*this, deltaTime);
    }
}

void Game::render() {
    window.clear();
    if (!states.empty()) {
        states.top()->render(*this, window);
    }
    window.display();
}