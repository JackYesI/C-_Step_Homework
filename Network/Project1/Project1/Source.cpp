////////#include <SFML/Graphics.hpp>
////////#include <vector>
////////
////////using namespace std;
////////
////////const int MAP_SIZE = 5; // Розмір карти
////////const int PIXEL_SIZE = 50; // Розмір пікселя
////////
////////int main() {
////////    // Створюємо вікно SFML
////////    sf::RenderWindow window(sf::VideoMode(MAP_SIZE * PIXEL_SIZE, MAP_SIZE * PIXEL_SIZE), "SFML Map");
////////
////////    // Створюємо матрицю для представлення картини
////////    vector<vector<bool>> map(MAP_SIZE, vector<bool>(MAP_SIZE, true));
////////
////////    // Встановлюємо камені на карті
////////    map[1][2] = false;
////////    map[2][2] = false;
////////    map[2][1] = false;
////////
////////    // Основний цикл вікна
////////    while (window.isOpen()) {
////////        sf::Event event;
////////        while (window.pollEvent(event)) {
////////            if (event.type == sf::Event::Closed)
////////                window.close();
////////        }
////////
////////        // Відображення карти
////////        window.clear();
////////
////////        // Проходимо по кожному пікселю на карті
////////        for (int i = 0; i < MAP_SIZE; ++i) {
////////            for (int j = 0; j < MAP_SIZE; ++j) {
////////                sf::RectangleShape pixel(sf::Vector2f(PIXEL_SIZE, PIXEL_SIZE));
////////
////////                // Зелений колір для трави, сірий для каменів
////////                if (map[i][j]) {
////////                    pixel.setFillColor(sf::Color::Green);
////////                }
////////                else {
////////                    pixel.setFillColor(sf::Color(128, 128, 128)); // Сірий колір
////////                }
////////
////////                // Розміщення пікселю на карті
////////                pixel.setPosition(j * PIXEL_SIZE, i * PIXEL_SIZE);
////////                window.draw(pixel);
////////            }
////////        }
////////
////////        window.display();
////////    }
////////
////////    return 0;
////////}
//////
//////
//////////#include "String_Jack.h"
//////////#include <iostream>
//////////int main()
//////////{
//////////	string_jw str_1 = "1+";
//////////	string_jw str_2 = "1=2";
//////////	string_jw str = (str_1 + str_2);
//////////	str.write_jw();
//////////	str.write_Bin_jw();
//////////	string_jw* strings = new string_jw[3];
//////////	strings[0] = str;
//////////	strings[1] = str_1;
//////////	strings[2] = str_2;
//////////	str.writeAll_Bin_jw(strings , 3);
//////////	str = str_1;
//////////	std::cout << str.c_str() << "\t" << str_1.c_str() << "\t" << str_2.c_str();
//////////	return 0;
//////////}
//////
////////#include <iostream>
////////using namespace std;
////////
////////enum Unit_Enum
////////{
////////	Ork = 1,
////////	Elf,
////////	Mag
////////};
////////
////////class IgetDamege
////////{
////////protected:
////////	virtual void getDamege(size_t damage = 0) = 0;
////////	virtual ~IgetDamege() = default;
////////};
////////
////////class Unit : public IgetDamege
////////{
////////protected:
////////	size_t health;
////////	size_t damage;
////////	float foodDamage;
////////	// check this fuckin things 
////////public:
////////	void getDamege(size_t damege) override
////////	{
////////		health -= foodDamage * damege;
////////		cout << "got a damege !!!" << endl;
////////	}
////////public:
////////	Unit(const Unit_Enum& unit) 
////////	{
////////		int unit_ = static_cast<int>(unit);
////////		switch (unit_)
////////		{
////////		case 1:
////////			health = 100;
////////			damage = 50;
////////			foodDamage = 0.25;
////////			break;
////////		case 2:
////////			health = 75;
////////			damage = 75;
////////			foodDamage = 0.5;
////////			break;
////////		case 3:
////////			health = 50;
////////			damage = 100;
////////			foodDamage = 0.75;
////////			break;
////////		default:
////////			break;
////////		}
////////	}
////////	Unit() : Unit(Ork) {}
////////	Unit(Unit& other) { health = other.health; damage = other.damage; foodDamage = other.foodDamage; }
////////	Unit& operator=(const Unit& other)
////////	{
////////		if (this == &other) {
////////			return *this;
////////		}
////////		health = other.health;
////////		damage = other.damage;
////////		foodDamage = other.foodDamage;
////////		return *this;
////////	}
////////	void ShowResult()
////////	{
////////		cout << "Healt: " << health << endl;
////////	}
////////};
////////
////////class Ork : public Unit
////////{
////////private:
////////	size_t force;
////////public:
////////	Ork() : Unit(Unit_Enum::Ork) { force = 1; }
////////	Ork(size_t force) : Unit(Unit_Enum::Ork) { this->force = force; }
////////	void Attak(Unit& unit)
////////	{
////////		unit.getDamege(force * damage);
////////	}
////////};
////////
////////void main()
////////{
////////	class::Ork ork, ork_underAttak(5);
////////	Unit* arr[] = { &ork, &ork_underAttak };
////////	class::Ork* prt_ork = dynamic_cast<class::Ork*>(arr[0]);
////////	if (prt_ork != nullptr)
////////		prt_ork->Attak(*dynamic_cast<class::Ork*>(arr[1]));
////////	arr[0]->ShowResult();
////////	arr[1]->ShowResult();
////////}
//////
//////
////////#include <SFML/System.hpp>
////////#include <iostream>
////////
////////sf::Mutex mutex;
////////
////////void task() {
////////    for (int i = 0; i < 5; ++i) {
////////        {
////////            sf::Lock lock(mutex);
////////            std::cout << "Thread: " << i << std::endl;
////////        }
////////        sf::sleep(sf::seconds(1)); // Імітація затримки
////////    }
////////}
////////
////////int main() {
////////    sf::Thread thread(&task);
////////    thread.launch();
////////    thread.wait();
////////
////////    return 0;
////////}
//////
////////#include <iostream>
////////#include <typeinfo>
////////
////////// Перевантаження оператора << для std::type_info
////////std::ostream& operator<<(std::ostream& os, const std::type_info& type) {
////////	os << type.name();
////////	return os;
////////}
////////
////////template <typename T>
////////class Base
////////{
////////public:
////////	void Show()
////////	{
////////		std::cout << "type is " << typeid(T) << std::endl;
////////	}
////////};
////////
////////template <typename T>
////////class A : private Base<T>
////////{
////////public:
////////	void Print()
////////	{
////////		this->Show();
////////	}
////////};
////////
////////int main()
////////{
////////	A<int> a;
////////	a.Print();
////////	return 0;
////////}
//////
//////
////////#include <iostream>
////////using namespace std;
////////
////////template <typename Derived>
////////class Base {
////////public:
////////    void interface() {
////////        static_cast<Derived*>(this)->implementation();
////////    }
////////};
////////
////////class Derived : public Base<Derived> {
////////public:
////////    void implementation() {
////////        cout << "Implementation in Derived" << endl;
////////    }
////////};
////////
////////int main() {
////////    Derived obj;
////////    obj.interface();
////////    return 0;
////////}
//////
//////
//////
//////
////////#include <SFML/Graphics.hpp>
////////#include <vector>
////////
////////using namespace std;
////////
////////int main()
////////{
////////    sf::RenderWindow window(sf::VideoMode(800, 600), "Tile Map Example");
////////
////////    // Завантаження текстури
////////    sf::Texture texture;
////////    if (!texture.loadFromFile("C:\\Users\\Денис\\Downloads\\TileSet.png")) {
////////        return -1;
////////    }
////////
////////    // Визначення розміру тайлів
////////    const int tileSize = 32;
////////
////////    // Створення тайлової карти (простий приклад)
////////    std::vector<std::vector<int>> map = {
////////        { 0, 0, 1, 1, 1, 0, 0, 5, 8 },
////////        { 0, 1, 2, 2, 2, 1, 0, 10, 4 },
////////        { 1, 2, 3, 3, 3, 2, 1, 2, 3 },
////////        { 1, 2, 3, 3, 3, 2, 1, 4, 5 },
////////        { 0, 1, 2, 2, 2, 1, 0,6 ,7 },
////////        { 0, 0, 1, 1, 1, 0, 0, 8, 9 },
////////        { 0, 0, 1, 1, 1, 0, 0, 8, 9 },
////////        { 0, 0, 1, 1, 1, 0, 0, 8, 9 },
////////        { 0, 0, 1, 1, 1, 0, 0, 8, 9 },
////////        { 0, 0, 1, 1, 1, 0, 0, 8, 9 }
////////    };
////////
////////    // Створення вершинного масиву для тайлів
////////    sf::VertexArray vertices(sf::Quads, map.size() * map[0].size() * 4);
////////
////////    for (size_t i = 0; i < map.size(); ++i) {
////////        for (size_t j = 0; j < map[i].size(); ++j) {
////////            int tileNumber = map[i][j];
////////
////////            int tu = tileNumber % (texture.getSize().x / tileSize);
////////            int tv = tileNumber / (texture.getSize().x / tileSize);
////////
////////            sf::Vertex* quad = &vertices[(i + j * map.size()) * 4];
////////
////////            quad[0].position = sf::Vector2f(i * tileSize, j * tileSize);
////////            quad[1].position = sf::Vector2f((i + 1) * tileSize, j * tileSize);
////////            quad[2].position = sf::Vector2f((i + 1) * tileSize, (j + 1) * tileSize);
////////            quad[3].position = sf::Vector2f(i * tileSize, (j + 1) * tileSize);
////////
////////            quad[0].texCoords = sf::Vector2f(tu * tileSize, tv * tileSize);
////////            quad[1].texCoords = sf::Vector2f((tu + 1) * tileSize, tv * tileSize);
////////            quad[2].texCoords = sf::Vector2f((tu + 1) * tileSize, (tv + 1) * tileSize);
////////            quad[3].texCoords = sf::Vector2f(tu * tileSize, (tv + 1) * tileSize);
////////        }
////////    }
////////
////////    while (window.isOpen()) {
////////        sf::Event event;
////////        while (window.pollEvent(event)) {
////////            if (event.type == sf::Event::Closed)
////////                window.close();
////////        }
////////
////////        window.clear();
////////        window.draw(vertices, &texture);
////////        window.display();
////////    }
////////
////////    return 0;
////////}
//////
//////
//#include <iostream>
//#include <SFML/Graphics.hpp>
//#include "Map_Test.h"
//////
//////void Draw_Grape(sf::VertexArray &arr, sf::RenderWindow &win, sf::RenderStates &state, unsigned int x = 16, unsigned int y = 12)
//////{
//////	// define its texture area to be a 25x50 rectangle starting at (0, 0)
//////	arr[0].texCoords = sf::Vector2f(0.f, 32.f);
//////	arr[1].texCoords = sf::Vector2f(0.f, 64.f);
//////	arr[2].texCoords = sf::Vector2f(32.f, 32.f);
//////	arr[3].texCoords = sf::Vector2f(32.f, 64.f);
//////	for (size_t i = 0; i < y; i++)
//////	{
//////		for (size_t j = 0; j < x; j++)
//////		{
//////			if (y == 3)
//////			{
//////				arr[0].texCoords = sf::Vector2f(32.f, 32.f);
//////				arr[1].texCoords = sf::Vector2f(32.f, 64.f);
//////				arr[2].texCoords = sf::Vector2f(64.f, 32.f);
//////				arr[3].texCoords = sf::Vector2f(64.f, 64.f);
//////
//////				arr[0].position = sf::Vector2f(50.f * j, 50.f * i);
//////				arr[1].position = sf::Vector2f(50.f * j, 100.f * i);
//////				arr[2].position = sf::Vector2f(100.f * j, 50.f * i);
//////				arr[3].position = sf::Vector2f(100.f * j, 100.f * i);
//////
//////				win.draw(arr, state);
//////
//////				arr[0].texCoords = sf::Vector2f(0.f, 32.f);
//////				arr[1].texCoords = sf::Vector2f(0.f, 64.f);
//////				arr[2].texCoords = sf::Vector2f(32.f, 32.f);
//////				arr[3].texCoords = sf::Vector2f(32.f, 64.f);
//////			}
//////			else
//////			{
//////				// define it as a rectangle, located at (10, 10) and with size 100x100
//////				arr[0].position = sf::Vector2f(50.f * j, 50.f * i);
//////				arr[1].position = sf::Vector2f(50.f * j, 100.f * i);
//////				arr[2].position = sf::Vector2f(100.f * j, 50.f * i);
//////				arr[3].position = sf::Vector2f(100.f * j, 100.f * i);
//////				win.draw(arr, state);
//////			}
//////		}
//////	}
//////}
//////
//////int main()
//////{
//////	//// create the window
//////	//sf::RenderWindow window(sf::VideoMode(800, 600), "My window (2:42 20.06.2024)");
//////	//sf::CircleShape circle(200.f);
//////	//circle.setFillColor((sf::Color::Blue));
//////
//////
//////	//// texture
//////	//sf::Texture texture;
//////	//if (!texture.loadFromFile("C:\\Users\\Денис\\Downloads\\TileSet.png"))
//////	//	return 1;
//////
//////	//// sprite
//////	//sf::Sprite sprite;
//////	//sprite.setTexture(texture);
//////	////sprite.setTextureRect(sf::IntRect(10, 10, 32, 32));
//////	//sprite.setColor(sf::Color(255, 255, 255, 128));
//////	/////*sprite.setPosition(sf::Vector2f(10.f, 50.f));*/
//////	////sprite.move(sf::Vector2f(5.f, 10.f));
//////	//
//////	//// Vertex
//////	//sf::VertexArray triangleStrip(sf::TriangleStrip, 4);
//////
//////	//// define it as a rectangle, located at (10, 10) and with size 100x100
//////	//triangleStrip[0].position = sf::Vector2f(0.f, 0.f);
//////	//triangleStrip[1].position = sf::Vector2f(0.f, 50.f);
//////	//triangleStrip[2].position = sf::Vector2f(50.f, 0.f);
//////	//triangleStrip[3].position = sf::Vector2f(50.f, 50.f);
//////
//////	//// define its texture area to be a 25x50 rectangle starting at (0, 0)
//////	//triangleStrip[0].texCoords = sf::Vector2f(0.f, 32.f);
//////	//triangleStrip[1].texCoords = sf::Vector2f(0.f, 64.f);
//////	//triangleStrip[2].texCoords = sf::Vector2f(32.f, 32.f);
//////	//triangleStrip[3].texCoords = sf::Vector2f(32.f, 64.f);
//////
//////	//sf::RenderStates states;
//////	//states.texture = &texture;
//////
//////	//// run the program as long as the windo is open
//////	//while (window.isOpen())
//////	//{
//////	//	// cheak all the window's events that were triggered since the last iteration of the loop
//////	//	sf::Event event;
//////	//	while (window.pollEvent(event))
//////	//	{
//////	//		// "close requested" event: we close the window
//////	//		if (event.type == sf::Event::Closed)
//////	//			window.close();
//////	//	}
//////
//////	//	// clear the window with black color
//////	//	window.clear(sf::Color::Black);
//////
//////	//	// draw everything here...
//////	//	// window.draw(...);
//////
//////	//	/*circle.setTexture(&texture);*/
//////	//	
//////	//	circle.setPosition(100.f, 100.f);
//////	//	circle.setPointCount(24);
//////	//	/*window.draw(sprite);*/
//////	//	/*window.draw(circle);*/
//////	//	/*Draw_Grape(triangleStrip, window, states);*/
//////	//	window.draw(triangleStrip, states);
//////	//	triangleStrip[0].texCoords = sf::Vector2f(32.f, 32.f);
//////	//	triangleStrip[1].texCoords = sf::Vector2f(32.f, 64.f);
//////	//	triangleStrip[2].texCoords = sf::Vector2f(64.f, 32.f);
//////	//	triangleStrip[3].texCoords = sf::Vector2f(64.f, 64.f);
//////	//	triangleStrip[0].position = sf::Vector2f(100.f, 100.f);
//////	//	triangleStrip[1].position = sf::Vector2f(100.f, 150.f);
//////	//	triangleStrip[2].position = sf::Vector2f(150.f, 100.f);
//////	//	triangleStrip[3].position = sf::Vector2f(150.f, 150.f);
//////	//	window.draw(triangleStrip, states);
//////	//	triangleStrip[0].position = sf::Vector2f(0.f, 0.f);
//////	//	triangleStrip[1].position = sf::Vector2f(0.f, 50.f);
//////	//	triangleStrip[2].position = sf::Vector2f(50.f, 0.f);
//////	//	triangleStrip[3].position = sf::Vector2f(50.f, 50.f);
//////	//	triangleStrip[0].texCoords = sf::Vector2f(0.f, 32.f);
//////	//	triangleStrip[1].texCoords = sf::Vector2f(0.f, 64.f);
//////	//	triangleStrip[2].texCoords = sf::Vector2f(32.f, 32.f);
//////	//	triangleStrip[3].texCoords = sf::Vector2f(32.f, 64.f);
//////	//	// end the carrent frame
//////	//	window.display();
//////	//}
//////	//return 0;
//////
//////	// create the window
//////	sf::RenderWindow window(sf::VideoMode(512, 256), "Tilemap");
//////
//////	// define the level with an array of tile indices
//////	const int level[] =
//////	{
//////		0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
//////		0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 2, 0, 0, 0, 0,
//////		1, 1, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3,
//////		0, 1, 0, 0, 2, 0, 3, 3, 3, 0, 1, 1, 1, 0, 0, 0,
//////		0, 1, 1, 0, 3, 3, 3, 0, 0, 0, 1, 1, 1, 2, 0, 0,
//////		0, 0, 1, 0, 3, 0, 2, 2, 0, 0, 1, 1, 1, 1, 2, 0,
//////		2, 0, 1, 0, 3, 0, 2, 2, 2, 0, 1, 1, 1, 1, 1, 1,
//////		0, 0, 1, 0, 3, 2, 2, 2, 0, 0, 0, 0, 1, 1, 1, 1,
//////	};
//////
//////	// create the tilemap from the level definition
//int main()
//{
//	sf::RenderWindow window(sf::VideoMode(512, 256), "My window (2:42 20.06.2024)");
//	sf::View view2;
//	view2.setCenter(sf::Vector2f(256, 128));
//	view2.setSize(sf::Vector2f(512.f, 256.f));
//	MyEntity map;
//
//	window.setView(view2);
//
//	const int level[] =
//			{
//				0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
//				0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 2, 0, 0, 0, 0,
//				1, 1, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3,
//				0, 1, 0, 0, 2, 0, 3, 3, 3, 0, 1, 1, 1, 0, 0, 0,
//				0, 1, 1, 0, 3, 3, 3, 0, 0, 0, 1, 1, 1, 2, 0, 0,
//				0, 0, 1, 0, 3, 0, 2, 2, 0, 0, 1, 1, 1, 1, 2, 0,
//				2, 0, 1, 0, 3, 0, 2, 2, 2, 0, 1, 1, 1, 1, 1, 1,
//				0, 0, 1, 0, 3, 2, 2, 2, 0, 0, 0, 0, 1, 1, 1, 1,
//			};
//
//	if (!map.load("C:\\Users\\Денис\\Downloads\\graphics-vertex-array-tilemap-tileset (1).png", sf::Vector2u(32, 32), level, 16, 8))
//		return -1;
//
//	// run the main loop
//	while (window.isOpen())
//	{
//		// handle events
//		sf::Event event;
//		while (window.pollEvent(event))
//		{
//			if (event.type == sf::Event::Closed)
//				window.close();
//
//			if (event.type == sf::Event::MouseWheelScrolled)
//			{
//				if (event.mouseWheelScroll.wheel == sf::Mouse::VerticalWheel)
//				{
//					if (event.mouseWheelScroll.delta > 0)
//					{
//						sf::Vector2f vec = view2.getSize();
//						view2.setSize(vec.x + 5, vec.y + 5);
//						std::cout << "up" << std::endl;
//					}
//					else if (event.mouseWheelScroll.delta < 0)
//					{
//						sf::Vector2f vec = view2.getSize();
//						view2.setSize(vec.x - 5, vec.y - 5);
//						std::cout << "down" << std::endl;
//					}
//				}
//				
//			}
//			if (event.type == sf::Event::KeyPressed)
//			{
//				if (event.key.scancode == sf::Keyboard::Scan::A)
//				{
//					view2.move(-10.f, 0.f);
//					std::cout << "A preseed" << std::endl;
//				}
//				if (event.key.scancode == sf::Keyboard::Scan::D)
//				{
//					view2.move(10.f, 0.f);
//					std::cout << "D preseed" << std::endl;
//				}
//				if (event.key.scancode == sf::Keyboard::Scan::W)
//				{
//					view2.move(0.f, -10.f);
//					std::cout << "W preseed" << std::endl;
//				}
//				if (event.key.scancode == sf::Keyboard::Scan::S)
//				{
//					view2.move(0.f, 10.f);
//					std::cout << "S preseed" << std::endl;
//				}
//			}
//			window.setView(view2);
//		}
//
//		// draw the map
//		window.clear();
//		window.draw(map);
//		window.display();
//	}
//
//	return 0;
//}
//////
////
//#include <SFML/Graphics.hpp>
//
//class ParticleSystem : public sf::Drawable, public sf::Transformable
//{
//public:
//
//    ParticleSystem(unsigned int count) :
//        m_particles(count),
//        m_vertices(sf::Points, count),
//        m_lifetime(sf::seconds(3.f)),
//        m_emitter(0.f, 0.f)
//    {
//    }
//
//    void setEmitter(sf::Vector2f position)
//    {
//        m_emitter = position;
//    }
//
//    void update(sf::Time elapsed)
//    {
//        for (std::size_t i = 0; i < m_particles.size(); ++i)
//        {
//            // update the particle lifetime
//            Particle& p = m_particles[i];
//            p.lifetime -= elapsed;
//
//            // if the particle is dead, respawn it
//            if (p.lifetime <= sf::Time::Zero)
//                resetParticle(i);
//
//            // update the position of the corresponding vertex
//            m_vertices[i].position += p.velocity * elapsed.asSeconds();
//
//            // update the alpha (transparency) of the particle according to its lifetime
//            float ratio = p.lifetime.asSeconds() / m_lifetime.asSeconds();
//            m_vertices[i].color.a = static_cast<sf::Uint8>(ratio * 255);
//        }
//    }
//
//private:
//
//    virtual void draw(sf::RenderTarget& target, sf::RenderStates states) const
//    {
//        // apply the transform
//        states.transform *= getTransform();
//
//        // our particles don't use a texture
//        states.texture = NULL;
//
//        // draw the vertex array
//        target.draw(m_vertices, states);
//    }
//
//private:
//
//    struct Particle
//    {
//        sf::Vector2f velocity;
//        sf::Time lifetime;
//    };
//
//    void resetParticle(std::size_t index)
//    {
//        // give a random velocity and lifetime to the particle
//        float angle = (std::rand() % 360) * 3.14f / 180.f;
//        float speed = (std::rand() % 50) + 50.f;
//        m_particles[index].velocity = sf::Vector2f(std::cos(angle) * speed, std::sin(angle) * speed);
//        m_particles[index].lifetime = sf::milliseconds((std::rand() % 2000) + 1000);
//
//        // reset the position of the corresponding vertex
//        m_vertices[index].position = m_emitter;
//    }
//
//    std::vector<Particle> m_particles;
//    sf::VertexArray m_vertices;
//    sf::Time m_lifetime;
//    sf::Vector2f m_emitter;
//};
//
//
//int main()
//{
//    // create the window
//    sf::RenderWindow window(sf::VideoMode(512, 256), "Particles");
//
//    // create the particle system
//    ParticleSystem particles(100000);
//
//    // create a clock to track the elapsed time
//    sf::Clock clock;
//
//    // run the main loop
//    while (window.isOpen())
//    {
//        // handle events
//        sf::Event event;
//        while (window.pollEvent(event))
//        {
//            if (event.type == sf::Event::Closed)
//                window.close();
//        }
//
//        // make the particle system emitter follow the mouse
//        sf::Vector2i mouse = sf::Mouse::getPosition(window);
//        particles.setEmitter(window.mapPixelToCoords(mouse));
//
//        // update it
//        sf::Time elapsed = clock.restart();
//        particles.update(elapsed);
//
//        // draw it
//        window.clear();
//        window.draw(particles);
//        window.display();
//    }
//
//    return 0;
//}
//
////#include <iostream>
////#include <SFML/Graphics.hpp>
////
////int main()
////{
////	std::cout << sf::Shader::isAvailable();
////	return 0;
////}
//
//#include <SFML/Graphics.hpp>
//
//class My_Map : public sf::Drawable, public sf::Transformable
//{
//private:
//	sf::Texture my_texture;
//	sf::VertexArray my_vertex;
//
//	virtual void draw(sf::RenderTarget& target, sf::RenderStates state) const
//	{
//		state.transform *= getTransform();
//
//		state.texture = &my_texture;
//
//		target.draw(my_vertex, &my_texture);
//	}
//
//public:
//	bool load(const std::string& tileset, sf::Vector2u tilesize, const int* tiles, unsigned int width, unsigned int height)
//	{
//		if (!my_texture.loadFromFile(tileset))
//			return false;
//
//		my_vertex.setPrimitiveType(sf::PrimitiveType::Triangles);
//		my_vertex.resize(width * height * 6);
//
//
//	}
//};


//#include <SFML/Graphics.hpp>
//#include <iostream>
//#include "GameState.h"
//#include <stack>
//#include "Game.h"
//#include "Nub.h"
//#include "Cat.h"
//
//int main()
//{
//    /*sf::RenderWindow window(sf::VideoMode(800, 400), "Menu Window");
//    MainMenu menu(window.getSize().x, window.getSize().y);
//    menu.MainLoop(window);*/
//    //// Отримання списку всіх доступних відеорежимів для повноекранного режиму
//    //std::vector<sf::VideoMode> modes = sf::VideoMode::getFullscreenModes();
//
//    //// Вивід усіх відеорежимів
//    //for (std::size_t i = 0; i < modes.size(); ++i)
//    //{
//    //    sf::VideoMode mode = modes[i];
//    //    std::cout << "Mode " << i << ": "
//    //        << mode.width << "x" << mode.height << " - "
//    //        << mode.bitsPerPixel << " bpp" << std::endl;
//    //}
//
//    //sf::RenderWindow window(modes[0], "my_win");
//
//    //while (window.isOpen())
//    //{
//    //    sf::Event event;
//    //    while (window.pollEvent(event))
//    //    {
//    //        if (event.type == sf::Event::Closed)
//    //            window.close();
//    //    }
//
//    //    window.clear();
//    //    window.draw(sf::CircleShape(50.f));
//    //    window.display();
//    //}
//
//    // state
//
//    /*sf::RenderWindow window(sf::VideoMode(800, 600), "game");
//    std::stack<std::unique_ptr<GameState>> states;
//
//    states.push(std::make_unique<MainManuState>(window.getSize().x, window.getSize().y));
//
//    
//
//    while (window.isOpen())
//    {
//        if (!states.empty())
//        {
//            states.top()->handleInput(window);
//            states.top()->draw(window);
//        }
//
//        if (states.top()->getIsEnter())
//        {
//            
//        }
//    }*/
//
//    /*Game game;
//    game.run();*/
//    sf::RenderWindow window(sf::VideoMode(512, 256), "Tilemap");
//    Nub nub("img\\graphics-vertex-array-tilemap-tileset.png", "levels\\level_1.bin");
//
//    sf::View view2;
//    view2.setCenter(sf::Vector2f(256, 128));
//    view2.setSize(sf::Vector2f(512.f, 256.f));
//    
//    sf::Sprite sprite;
//    sf::Texture texture;
//    texture.loadFromFile("img\\graphics-vertex-array-tilemap-tileset.png");
//    sprite.setTexture(texture);
//    sprite.setTextureRect(sf::IntRect(96, 0, 32, 32));
//    sprite.setPosition(256, 128);
//
//    /*Cat cat("img\\Cat-Sheet.png");*/
//
//    while (window.isOpen())
//    {
//        // handle events
//        sf::Event event;
//        while (window.pollEvent(event))
//        {
//            if (event.type == sf::Event::Closed)
//                window.close();
//            if (event.type == sf::Event::KeyPressed)
//   			{
//                sf::Vector2f viewPos = view2.getCenter();
//                sf::Vector2f viewSize = view2.getSize();
//                float mapWidth = 3200; // Ширина карти
//                float mapHeight = 3200; // Висота карти
//   				if (event.key.scancode == sf::Keyboard::Scan::A)
//   				{
//                    if ((viewPos.x - viewSize.x / 2 > 0) && (sprite.getPosition().x < 2944))
//                    {
//                        view2.move(-10.f, 0.f);
//                    }
//                    if (sprite.getPosition().x > 0)
//                        sprite.move(-10.f, 0.f);
//   					std::cout << "A preseed" << std::endl;
//   				}
//   				if (event.key.scancode == sf::Keyboard::Scan::D)
//   				{
//                    if ((viewPos.x + viewSize.x / 2 < mapWidth) && (sprite.getPosition().x > 256))
//                    {
//                        view2.move(10.f, 0.f);
//                    }
//                    if (sprite.getPosition().x < 3164)
//                        sprite.move(10.f, 0.f);
//   					std::cout << "D preseed" << std::endl;
//   				}
//   				if (event.key.scancode == sf::Keyboard::Scan::W)
//   				{
//                    if ((viewPos.y - viewSize.y / 2 > 0) && (sprite.getPosition().y < 3072))
//                    {
//                        view2.move(0.f, -10.f);
//                    }
//                    if (sprite.getPosition().y > 0)
//                        sprite.move(0.f, -10.f);
//   					std::cout << "W preseed" << std::endl;
//   				}
//   				if (event.key.scancode == sf::Keyboard::Scan::S)
//   				{
//                    if ((viewPos.y + viewSize.y / 2 < mapHeight) && (sprite.getPosition().y > 128))
//                    {
//                        view2.move(0.f, 10.f);
//                    }
//                    if (sprite.getPosition().y < 3164)
//                        sprite.move(0.f, 10.f);
//   					std::cout << "S preseed" << std::endl;
//   				}
//   			}
//   			window.setView(view2);
//        }
//
//        // draw the map
//        window.clear();
//        window.draw(nub);
//        window.draw(sprite);
//        window.display();
//    }
//
//    return 0;
//}

#include "Cat.h"
#include "Nub.h"
#include <SFML/Graphics.hpp>

int main()
{
    Cat cat("img\\Cat-Sheet.png");
    sf::RenderWindow window(sf::VideoMode(512, 256), "Tilemap");
    Nub nub("img\\RPG Nature Tileset.png", "levels\\level_1.bin");

    sf::View view2;
    view2.setCenter(sf::Vector2f(256, 128));
    view2.setSize(sf::Vector2f(512.f, 256.f));

    sf::Clock clock;
    while (window.isOpen())
    {
        sf::Event event;
        while (window.pollEvent(event))
        {
            if (event.type == sf::Event::Closed)
                window.close();
            cat.update(event);
            if (event.type == sf::Event::KeyPressed)
            {
                sf::Vector2f viewPos = view2.getCenter();
                sf::Vector2f viewSize = view2.getSize();
                float mapWidth = 3200; // Ширина карти
                float mapHeight = 3200; // Висота карти
                if (event.key.scancode == sf::Keyboard::Scan::A)
                {
                    if ((viewPos.x - viewSize.x / 2 > 0) && (cat.getPosition().x < 2944))
                    {
                        view2.move(-4.f, 0.f);
                    }
                    /*cat.update(event);*/
                    std::cout << "A preseed" << std::endl;
                }
                if (event.key.scancode == sf::Keyboard::Scan::D)
                {
                    if ((viewPos.x + viewSize.x / 2 < mapWidth) && (cat.getPosition().x > 256))
                    {
                        view2.move(4.f, 0.f);
                    }
                    /*cat.update(event);*/
                    std::cout << "D preseed" << std::endl;
                }
                if (event.key.scancode == sf::Keyboard::Scan::W)
                {
                    if ((viewPos.y - viewSize.y / 2 > 0) && (cat.getPosition().y < 3072))
                    {
                        view2.move(0.f, -4.f);
                    }
                    /*cat.update(event);*/
                    std::cout << "W preseed" << std::endl;
                }
                if (event.key.scancode == sf::Keyboard::Scan::S)
                {
                    if ((viewPos.y + viewSize.y / 2 < mapHeight) && (cat.getPosition().y > 128))
                    {
                        view2.move(0.f, 4.f);
                    }
                    /*cat.update(event);*/
                    std::cout << "S preseed" << std::endl;
                }
            }
            window.setView(view2);
        }

        sf::Time deltaTime = clock.restart();
        cat.animate(deltaTime);


        window.clear();
        window.draw(nub);
        window.draw(cat);
        window.display();
       
    }
    return 0;
}
