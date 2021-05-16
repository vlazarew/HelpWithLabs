#pragma once

#include <string>

using namespace std;

class TypeOfService
{
public:
	TypeOfService(string name);
	TypeOfService(int id, string name);
	int getId();
	string getName();
	void setName(string value);

private:
	int id;
	string name;
};

TypeOfService::TypeOfService(string name)
{
	this->name = name;
}

TypeOfService::TypeOfService(int id, string name)
{
	this->id = id;
	this->name = name;
}

inline int TypeOfService::getId()
{
	return this->id;
}

inline string TypeOfService::getName()
{
	return this->name;
}


inline void TypeOfService::setName(string value)
{
	this->name = value;
}

