#pragma once

#include <string>

using namespace std;

class Credentials
{
public:
	Credentials(string login, string password, bool isAdmin);
	Credentials(int id, string login, string password, bool isAdmin);
	int getId();
	string getLogin();
	string getPassword();
	bool getIsAdmin();
	void setLogin(string value);
	void setPassword(string value);
	void setIsAdmin(bool value);

private:
	int id;
	string login;
	string password;
	bool isAdmin;
};

Credentials::Credentials(string login, string password, bool isAdmin)
{
	this->login = login;
	this->password = password;
	this->isAdmin = isAdmin;
}

Credentials::Credentials(int id, string login, string password, bool isAdmin)
{
	this->id = id;
	this->login = login;
	this->password = password;
	this->isAdmin = isAdmin;
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

inline bool Credentials::getIsAdmin()
{
	return this->isAdmin;
}

void Credentials::setLogin(string value)
{
	this->login = value;
}

inline void Credentials::setPassword(string value)
{
	this->password = value;
}

inline void Credentials::setIsAdmin(bool value)
{
	this->isAdmin = value;
}
