#pragma once

#include <SFML/Graphics.hpp>
#include <iostream>

#define MAX_main_menu 4
class MainMenu
{
public:
	MainMenu(float wight, float height);

	void draw(sf::RenderWindow& window);
	void MoveUp();
	void MoveDown();
	void MainLoop(sf::RenderWindow& window);

	int MainMenuPressed()
	{
		return MainMenuSelected;
	}
	~MainMenu();
private:
	int MainMenuSelected;
	sf::Font font;
	sf::Text mainMenu[MAX_main_menu];
};
