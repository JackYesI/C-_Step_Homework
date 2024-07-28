#pragma once
#include <SFML/Graphics.hpp>

#define MAX_main_menu 4

class GameState
{
protected:
	int MainMenuSelected = 0;
	int MAX_Main_Menu;
	bool isEnter = false;
public:
	~GameState() {}
	virtual void handleInput(sf::RenderWindow& window) = 0;
	virtual void draw(sf::RenderWindow& window) = 0;
	int getMainMenuSelected() const;
	bool getIsEnter() const;
	void setIsEnter();
};

class MainManuState : public GameState
{
public:
	MainManuState(float wight, float height);

	void draw(sf::RenderWindow& window) override;
	void handleInput(sf::RenderWindow& window) override;
	void MoveUp();
	void MoveDown();
	bool getIsEnter() const;
	void setIsEnter();
private:
	sf::Font font;
	sf::Text mainMenu[MAX_main_menu];
};


class OptionsState : public GameState
{
public:
	OptionsState() { MAX_Main_Menu = 1; }
	void handleInput(sf::RenderWindow& window) override;
	void draw(sf::RenderWindow& window) override;
};
