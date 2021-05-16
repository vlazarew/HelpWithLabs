#pragma once

#include <string>

using namespace std;

class Service
{
public:
	Service(string name, int price, int typeOfServiceId);
	Service(int id, string name, int price, int typeOfServiceId);
	int getId();
	string getName();
	int getPrice();
	int getTypeOfServiceId();
	void setName(string value);
	void setPrice(int value);
	void setTypeOfServiceId(int value);

private:
	int id;
	string name;
	int price;
	int typeOfServiceId;
};

Service::Service(string name, int price, int typeOfServiceId)
{
	this->name = name;
	this->price = price;
	this->typeOfServiceId = typeOfServiceId;
}

Service::Service(int id, string name, int price, int typeOfServiceId)
{
	this->id = id;
	this->name = name;
	this->price = price;
	this->typeOfServiceId = typeOfServiceId;
}

inline int Service::getPrice()
{
	return this->price;
}

inline int Service::getTypeOfServiceId()
{
	return this->typeOfServiceId;
}

inline void Service::setPrice(int value)
{
	this->price = value;
}

inline void Service::setTypeOfServiceId(int value)
{
	this->typeOfServiceId = value;
}

inline int Service::getId()
{
	return this->id;
}

inline string Service::getName()
{
	return this->name;
}


inline void Service::setName(string value)
{
	this->name = value;
}

