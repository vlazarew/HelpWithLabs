#pragma once

#include <string>

using namespace std;

class Employee
{
public:
	Employee(string FIO, int departmentId);
	Employee(int id, string FIO, int departmentId);
	int getId();
	string getFIO();
	int getDepartmentId();
	void setFIO(string value);
	void setDepartmentId(int value);

private:
	int id;
	string FIO;
	int departmentId;
};

Employee::Employee(string FIO, int departmentId)
{
	this->FIO = FIO;
	this->departmentId = departmentId;
}

Employee::Employee(int id, string FIO, int departmentId)
{
	this->id = id;
	this->FIO = FIO;
	this->departmentId = departmentId;
}

inline string Employee::getFIO()
{
	return this->FIO;
}

inline int Employee::getDepartmentId()
{
	return this->departmentId;
}

inline void Employee::setFIO(string value)
{
	this->FIO = value;
}

inline void Employee::setDepartmentId(int value)
{
	this->departmentId = value;
}

int Employee::getId()
{
	return this->id;
}
