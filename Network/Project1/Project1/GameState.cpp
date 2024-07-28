#pragma once
#include <iostream>
#include <stack>
#include "GameState.h"

MainManuState::MainManuState(float wight, float height)
{
	if (!font.loadFromFile("fonts\\alvina\\Alvina_Demo.ttf"))
	{
		std::cout << "Don't load the font \"fonts\\alvina\\Alvina_Demo.ttf\"" << std::endl;
	}

	// Play
	mainMenu[0].setFont(font);
	mainMenu[0].setFillColor(sf::Color::White);
	mainMenu[0].setString("Play");
	mainMenu[0].setPosition(sf::Vector2f(wight * 0.5, height * 0.2));
	mainMenu[0].setCharacterSize(70);

	// Options
	mainMenu[1].setFont(font);
	mainMenu[1].setFillColor(sf::Color::White);
	mainMenu[1].setString("Options");
	mainMenu[1].setPosition(sf::Vector2f(wight * 0.5, height * 0.4));
	mainMenu[1].setCharacterSize(70);

	// Achives
	mainMenu[2].setFont(font);
	mainMenu[2].setFillColor(sf::Color::White);
	mainMenu[2].setString("Achives");
	mainMenu[2].setPosition(sf::Vector2f(wight * 0.5, height * 0.6));
	mainMenu[2].setCharacterSize(70);

	// Exit
	mainMenu[3].setFont(font);
	mainMenu[3].setFillColor(sf::Color::White);
	mainMenu[3].setString("Exit");
	mainMenu[3].setPosition(sf::Vector2f(wight * 0.5, height * 0.8));
	mainMenu[3].setCharacterSize(70);


	MainMenuSelected = 0;
}

void MainManuState::draw(sf::RenderWindow& window) 
{
	for (unsigned int i = 0; i < MAX_main_menu; i++)
	{
		window.draw(mainMenu[i]);
	}
	window.display();
}

void MainManuState::handleInput(sf::RenderWindow& window)
{
	mainMenu[MainMenuSelected].setFillColor(sf::Color::Blue);
	sf::Event event;
	while (window.pollEvent(event))
	{
		if (event.type == sf::Event::Closed)
			window.close();
		if (event.type == sf::Event::KeyReleased)
		{
			if (event.key.code == sf::Keyboard::Up)
			{
				MoveUp();

			}
			if (event.key.code == sf::Keyboard::Down)
			{
				MoveDown();

			}
			if (event.key.code == sf::Keyboard::Enter)
			{
				isEnter = true;
			}
		}
	}
}


void MainManuState::MoveUp()
{
	if (MainMenuSelected - 1 >= 0)
	{
		mainMenu[MainMenuSelected].setFillColor(sf::Color::White);
		MainMenuSelected--;
		mainMenu[MainMenuSelected].setFillColor(sf::Color::Blue);
	}
}

void MainManuState::MoveDown()
{
	if (MainMenuSelected + 1 < 4)
	{
		mainMenu[MainMenuSelected].setFillColor(sf::Color::White);
		MainMenuSelected++;
		mainMenu[MainMenuSelected].setFillColor(sf::Color::Blue);
	}
}

bool MainManuState::getIsEnter() const
{
	return this->isEnter;
}

void MainManuState::setIsEnter()
{
	this->isEnter = false;
}


void OptionsState::handleInput(sf::RenderWindow& window)
{
	sf::Event event;
	while (window.pollEvent(event))
	{
		if (event.type == sf::Event::Closed)
			window.close();
	}
}

void OptionsState::draw(sf::RenderWindow& window)
{
	window.clear(sf::Color(255, 192, 203)); // Pink background
	// Draw options UI here...
	window.display();
}


int GameState::getMainMenuSelected() const
{
	return MainMenuSelected;
}

bool GameState::getIsEnter() const
{
	return isEnter;
}

void GameState::setIsEnter()
{
	isEnter = true;
}
