#pragma once
#include "MainMenuState.h"
#include "Game.h"
#include "PlayState.h"
#include "Option_State.h"

MainMenuState::MainMenuState() {
    font.loadFromFile("fonts\\alvina\\Alvina_Demo.ttf");

    title.setFont(font);
    title.setString("Main Menu");
    title.setCharacterSize(40);

    playText.setFont(font);
    playText.setString("Play");
    playText.setCharacterSize(30);

    optionsText.setFont(font);
    optionsText.setString("Options"); // Новий текст
    optionsText.setCharacterSize(30);

    exitText.setFont(font);
    exitText.setString("Exit");
    exitText.setCharacterSize(30);
}

void MainMenuState::handleEvent(Game& game, sf::Event event) {
    playText.setFillColor(sf::Color::White);
    optionsText.setFillColor(sf::Color::White);
    exitText.setFillColor(sf::Color::White);
    if (event.type == sf::Event::MouseButtonPressed) {
        if (playText.getGlobalBounds().contains(event.mouseButton.x, event.mouseButton.y)) {
            game.changeState(std::make_unique<PlayState>());
        }
        else if (optionsText.getGlobalBounds().contains(event.mouseButton.x, event.mouseButton.y)) {
            game.changeState(std::make_unique<OptionState>());
        }
        else if (exitText.getGlobalBounds().contains(event.mouseButton.x, event.mouseButton.y)) {
            game.getWindow().close();
        }
    }

    sf::Vector2i mousePos = sf::Mouse::getPosition(game.getWindow());

    if (event.type == sf::Event::MouseMoved) {
        if (playText.getGlobalBounds().contains(static_cast<float>(mousePos.x), static_cast<float>(mousePos.y))) {
            playText.setFillColor(sf::Color::Blue);  
        }
        else if (optionsText.getGlobalBounds().contains(static_cast<float>(mousePos.x), static_cast<float>(mousePos.y))) {
            optionsText.setFillColor(sf::Color::Blue);
        }
        else if (exitText.getGlobalBounds().contains(static_cast<float>(mousePos.x), static_cast<float>(mousePos.y))) {
            exitText.setFillColor(sf::Color::Blue);
        }
    }
}

void MainMenuState::update(Game& game, sf::Time deltaTime) {}

void MainMenuState::render(Game& game, sf::RenderWindow& window) {
    centerText(title, window.getSize().x * 0.4, window.getSize().y * 0.2);
    centerText(playText, window.getSize().x * 0.45, window.getSize().y * 0.4);
    centerText(optionsText, window.getSize().x * 0.45, window.getSize().y * 0.6);
    centerText(exitText, window.getSize().x * 0.45, window.getSize().y * 0.8);

    window.draw(title);
    window.draw(playText);
    window.draw(optionsText); // Відображення тексту опцій
    window.draw(exitText);
}


