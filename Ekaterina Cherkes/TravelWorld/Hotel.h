#pragma once

#include <string>

using namespace std;

class Hotel
{
public:
	Hotel(string name, int rating, int countryId, string description);
	Hotel(int id, string name, int rating, int countryId, string description);
	int getId();
	string getName();
	int getCountryId();
	int getRating();
	string getDescription();
	void setName(string value);
	void setRating(int value);
	void setCountryId(int value);
	void setDescription(string value);

private:
	int id;
	string name;
	int rating;
	int countryId;
	string description;
};

Hotel::Hotel(string name, int rating, int countryId, string description)
{
	this->name = name;
	this->rating = rating;
	this->countryId = countryId;
	this->description = description;
}

Hotel::Hotel(int id, string name, int rating, int countryId, string description)
{
	this->id = id;
	this->name = name;
	this->rating = rating;
	this->countryId = countryId;
	this->description = description;
}

int Hotel::getId()
{
	return this->id;
}

string Hotel::getName()
{
	return this->name;
}

int Hotel::getCountryId()
{
	return this->countryId;
}

inline int Hotel::getRating()
{
	return this->rating;
}

inline string Hotel::getDescription()
{
	return this->description;
}

void Hotel::setName(string value)
{
	this->name = value;
}

inline void Hotel::setRating(int value)
{
	this->rating = value;
}

void Hotel::setCountryId(int value)
{
	this->countryId = value;
}

inline void Hotel::setDescription(string value)
{
	this->description= value;
}
