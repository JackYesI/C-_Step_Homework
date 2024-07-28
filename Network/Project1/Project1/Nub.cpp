#include "Nub.h"
#include <fstream>

Nub::Nub(const std::string& TileSet, const std::string& LevelSet)
{
	// texture
	texture.loadFromFile(TileSet);

	// file
	
	/*generateRandomLevels(LevelSet);*/
	readBinFromLevelFile(LevelSet);

	// create vertex

	vertex.setPrimitiveType(sf::Triangles);
	vertex.resize(900 * 6);

    for (unsigned int i = 0; i < 30; ++i)
        for (unsigned int j = 0; j < 30; ++j)
        {
            // get the current tile number
            int tileNumber = level[i + j * 30];

            //// find its position in the tileset texture
            //int tu = tileNumber % (texture.getSize().x / 32);
            //int tv = tileNumber / (texture.getSize().x / 32);

            // get a pointer to the triangles' vertices of the current tile
            sf::Vertex* triangles = &vertex[(i + j * 30) * 6];

            // define the 6 corners of the two triangles
            triangles[0].position = sf::Vector2f(i * 32, j * 32);
            triangles[1].position = sf::Vector2f((i + 1) * 32, j * 32);
            triangles[2].position = sf::Vector2f(i * 32, (j + 1) * 32);
            triangles[3].position = sf::Vector2f(i * 32, (j + 1) * 32);
            triangles[4].position = sf::Vector2f((i + 1) * 32, j * 32);
            triangles[5].position = sf::Vector2f((i + 1) * 32, (j + 1) * 32);

            // define the 6 matching texture coordinates
            if (tileNumber == 3)
            {
                triangles[0].texCoords = sf::Vector2f(0, 64);
                triangles[1].texCoords = sf::Vector2f(0, 96);
                triangles[2].texCoords = sf::Vector2f(32, 64);
                triangles[3].texCoords = sf::Vector2f(0, 96);
                triangles[4].texCoords = sf::Vector2f(32, 64);
                triangles[5].texCoords = sf::Vector2f(32, 96);
            }
            if (tileNumber == 0)
            {
                triangles[0].texCoords = sf::Vector2f(32, 64);
                triangles[1].texCoords = sf::Vector2f(32, 96);
                triangles[2].texCoords = sf::Vector2f(64, 64);
                triangles[3].texCoords = sf::Vector2f(32, 96);
                triangles[4].texCoords = sf::Vector2f(64, 64);
                triangles[5].texCoords = sf::Vector2f(64, 96);
            }
            if (tileNumber == 4)
            {
                triangles[0].texCoords = sf::Vector2f(64, 64);
                triangles[1].texCoords = sf::Vector2f(64, 96);
                triangles[2].texCoords = sf::Vector2f(96, 64);
                triangles[3].texCoords = sf::Vector2f(64, 96);
                triangles[4].texCoords = sf::Vector2f(96, 64);
                triangles[5].texCoords = sf::Vector2f(96, 96);
            }

            /*if (tileNumber == 1)
            {
                triangles[0].texCoords = sf::Vector2f(64, 64);
                triangles[1].texCoords = sf::Vector2f(64, 96);
                triangles[2].texCoords = sf::Vector2f(96, 64);
                triangles[3].texCoords = sf::Vector2f(64, 96);
                triangles[4].texCoords = sf::Vector2f(96, 64);
                triangles[5].texCoords = sf::Vector2f(96, 96);
            }
            if (tileNumber == 2)
            {
                triangles[0].texCoords = sf::Vector2f(0, 64);
                triangles[1].texCoords = sf::Vector2f(0, 96);
                triangles[2].texCoords = sf::Vector2f(32, 64);
                triangles[3].texCoords = sf::Vector2f(0, 96);
                triangles[4].texCoords = sf::Vector2f(32, 64);
                triangles[5].texCoords = sf::Vector2f(32, 96);

                triangles[0].texCoords = sf::Vector2f(0, 0);
                triangles[1].texCoords = sf::Vector2f(32, 0);
                triangles[2].texCoords = sf::Vector2f(0, 32);
                triangles[3].texCoords = sf::Vector2f(32, 0);
                triangles[4].texCoords = sf::Vector2f(0, 32);
                triangles[5].texCoords = sf::Vector2f(32, 32);
            }*/

            /*triangles[0].texCoords = sf::Vector2f(tu * 32, tv * 32);
            triangles[1].texCoords = sf::Vector2f((tu + 1) * 32, tv * 32);
            triangles[2].texCoords = sf::Vector2f(tu * 32, (tv + 1) * 32);
            triangles[3].texCoords = sf::Vector2f(tu * 32, (tv + 1) * 32);
            triangles[4].texCoords = sf::Vector2f((tu + 1) * 32, tv * 32);
            triangles[5].texCoords = sf::Vector2f((tu + 1) * 32, (tv + 1) * 32);*/
        }
}

void Nub::ShowLevel() const
{
	for (size_t i = 0; i < 30; i++)
	{
		std::cout << "\n";
		for (size_t j = 0; j < 30; j++)
		{
			std::cout << level[i] << " ";
		}
	}
}

void Nub::draw(sf::RenderTarget& target, sf::RenderStates states) const
{
	// apply the transform
	states.transform *= getTransform();

	// apply the tileset texture
	states.texture = &texture;

	// draw the vertex array
	target.draw(vertex, states);
}

void Nub::generateRandomLevels(const std::string& fileName) const
{
    const int size = 900;
    std::vector<int> array(size);

  

    /*std::srand(static_cast<unsigned int>(std::time(nullptr)));*/

    for (int i = 0; i < size; ++i) {
        array[i] = level[i];
    }

    std::ofstream outFile(fileName, std::ios::binary);
	outFile.write(reinterpret_cast<char*>(array.data()), size * sizeof(int));
    std::cout << "Writen";
	outFile.close();
}

void Nub::readBinFromLevelFile(const std::string& fileName)
{
	std::ifstream inFile(fileName, std::ios::binary);
	inFile.read(reinterpret_cast<char*>(level), 900 * sizeof(int));
	inFile.close();
}
