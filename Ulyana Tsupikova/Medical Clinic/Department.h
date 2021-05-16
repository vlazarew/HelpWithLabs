#pragma once

#include <string>

using namespace std;

class Department
{
public:
	Department(string name, string description);
	Department(int id, string name, string description);
	int getId();
	string getName();
	string getDescription();
	void setName(string value);
	void setDescription(string value);

private:
	int id;
	string name;
	string description;
};

Department::Department(string name, string description)
{
	this->name = name;
	this->description = description;
}

Department::Department(int id, string name, string description)
{
	this->id = id;
	this->name = name;
	this->description = description;
}

inline string Department::getName()
{
	return this->name;
}

inline string Department::getDescription()
{
	return this->description;
}

inline void Department::setName(string value)
{
	this->name = value;
}

inline void Department::setDescription(string value)
{
	this->description = value;
}

int Department::getId()
{
	return this->id;
}
