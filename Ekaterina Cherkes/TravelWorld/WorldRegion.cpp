#include <string>
#include "WorldRegion.h"

using namespace std;

WorldRegion::WorldRegion(string name)
{
	this->name = name;
}

WorldRegion::WorldRegion(int id, string name)
{
	this->id = id;
	this->name = name;
}

int WorldRegion::getId()
{
	return this->id;
}

string WorldRegion::getName()
{
	return this->name;
}

void WorldRegion::setName(string value)
{
	this->name = value;
}
