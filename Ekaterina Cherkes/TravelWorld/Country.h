#pragma once

#include <string>

using namespace std;

class Country
{
public:
	Country(string name, int regionId);
	Country(int id, string name, int regionId);
	int getId();
	string getName();
	int getRegionId();
	void setName(string value);
	void setRegionId(int value);

private:
	int id;
	string name;
	int regionId;
};

Country::Country(string name, int regionId)
{
	this->name = name;
	this->regionId = regionId;
}

Country::Country(int id, string name, int regionId)
{
	this->id = id;
	this->name = name;
	this->regionId = regionId;
}

int Country::getId()
{
	return this->id;
}

string Country::getName()
{
	return this->name;
}

int Country::getRegionId()
{
	return this->regionId;
}

void Country::setName(string value)
{
	this->name = value;
}

void Country::setRegionId(int value)
{
	this->regionId = value;
}