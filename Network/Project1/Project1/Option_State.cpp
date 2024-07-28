#pragma once
#include "Option_State.h"
#include "Game.h"
#include "MainMenuState.h"
#include <string>

OptionState::OptionState() {
    font.loadFromFile("fonts\\alvina\\Alvina_Demo.ttf");

    optionText.setFont(font);
    optionText.setString("Options");
    optionText.setCharacterSize(40);

    text.setFont(font);
    text.setCharacterSize(30);

    backText.setFont(font);
    backText.setString("Back");
    backText.setCharacterSize(30);

    // Video modes
    modes = sf::VideoMode::getFullscreenModes();
    std::string wigthCharArray = std::to_string(modes[0].width);
    std::string heightCharArray = std::to_string(modes[0].height);
    std::string bpp = std::to_string(modes[0].bitsPerPixel);
    text.setString(wigthCharArray + 'x' + heightCharArray + " - " + bpp + " bpp");

    // i
    i = 0;
}

void OptionState::handleEvent(Game& game, sf::Event event) {
    backText.setFillColor(sf::Color::White);
    text.setFillColor(sf::Color::White);

    if (event.type == sf::Event::MouseButtonPressed) {
        if (text.getGlobalBounds().contains(event.mouseButton.x, event.mouseButton.y)) {
            i++;
            if (!(modes.size() >= i + 1))
            {
                i = 0;
            }
            std::string wigthCharArray = std::to_string(modes[i].width);
            std::string heightCharArray = std::to_string(modes[i].height);
            std::string bpp = std::to_string(modes[i].bitsPerPixel);
            text.setString(wigthCharArray + "x" + heightCharArray + " - " + bpp + " bpp");
        }
        if (backText.getGlobalBounds().contains(event.mouseButton.x, event.mouseButton.y)) {
            game.getWindow().create(modes[i], "State Pattern Game", sf::Style::None);
            game.changeState(std::make_unique<MainMenuState>());
        }
    }

    sf::Vector2i mousePos = sf::Mouse::getPosition(game.getWindow());

    if (event.type == sf::Event::MouseMoved) {
        if (backText.getGlobalBounds().contains(static_cast<float>(mousePos.x), static_cast<float>(mousePos.y))) {
            backText.setFillColor(sf::Color::Blue);
        }
        else if (text.getGlobalBounds().contains(static_cast<float>(mousePos.x), static_cast<float>(mousePos.y)))
        {
            text.setFillColor(sf::Color::Blue);
        }
    }
}

void OptionState::update(Game& game, sf::Time deltaTime) {
    // Оновлення логіки для налаштувань (якщо потрібно)
}

void OptionState::render(Game& game, sf::RenderWindow& window) {
    centerText(optionText, window.getSize().x * 0.4, window.getSize().y * 0.2);
    centerText(text, window.getSize().x * 0.4, window.getSize().y * 0.5);
    centerText(backText, window.getSize().x * 0.45, window.getSize().y * 0.8);

    window.draw(optionText);
    window.draw(text);
    window.draw(backText);
}

OptionState::~OptionState()
{
    modes.clear();
    modes.shrink_to_fit();
}
