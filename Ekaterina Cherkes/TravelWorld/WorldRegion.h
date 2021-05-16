#pragma once

#include <string>

using namespace std;

class WorldRegion
{
public:
	WorldRegion(string name);
	WorldRegion(int id, string name);
	int getId();
	string getName();
	void setName(string value);

private:
	int id;
	string name;
};

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