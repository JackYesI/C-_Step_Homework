#pragma once
#include "PlayState.h"
#include "Game.h"
#include "MainMenuState.h"

PlayState::PlayState() {
    // ����������� ������� �������
}

void PlayState::handleEvent(Game& game, sf::Event event) {
    if (event.type == sf::Event::KeyPressed && event.key.code == sf::Keyboard::Escape) {
        game.changeState(std::make_unique<MainMenuState>());
    }
}

void PlayState::update(Game& game, sf::Time deltaTime) {
    // ��������� ����� ���
}

void PlayState::render(Game& game, sf::RenderWindow& window) {
    // ³���������� ������� ��������
}