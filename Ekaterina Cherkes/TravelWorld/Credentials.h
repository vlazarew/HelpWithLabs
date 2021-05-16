#pragma once

#include <string>

using namespace std;

class Credentials
{
public:
	Credentials(string login, string password);
	Credentials(int id, string login, string password);
	int getId();
	string getLogin();
	string getPassword();
	void setLogin(string value);
	void setPassword(string value);

private:
	int id;
	string login;
	string password;
};

Credentials::Credentials(string login, string password)
{
	this->login = login;
	this->password = password;
}

Credentials::Credentials(int id, string login, string password)
{
	this->id = id;
	this->login = login;
	this->password = password;
}

int Credentials::getId()
{
	return this->id;
}

string Credentials::getLogin()
{
	return this->login;
}

inline string Credentials::getPassword()
{
	return this->password;
}

void Credentials::setLogin(string value)
{
	this->login = value;
}

inline void Credentials::setPassword(string value)
{
	this->password = value;
}
