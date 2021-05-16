#pragma once

#include <string>

using namespace std;

class Registration
{
public:
	Registration(time_t date, int credentialsId, int employeeId, int serviceId);
	Registration(int id, time_t date, int credentialsId, int employeeId, int serviceId);
	int getId();
	time_t getDate();
	int getCredentialsId();
	int getEmployeeId();
	int getServiceId();
	void setDate(time_t value);
	void setCredentialsId(int value);
	void setEmployeeId(int value);
	void setServiceId(int value);

private:
	int id;
	time_t date;
	int credentialsId;
	int employeeId;
	int serviceId;
};

Registration::Registration(time_t date, int credentialsId, int employeeId, int serviceId)
{
	this->date = date;
	this->credentialsId = credentialsId;
	this->employeeId = employeeId;
	this->serviceId = serviceId;
}

Registration::Registration(int id, time_t date, int credentialsId, int employeeId, int serviceId)
{
	this->id = id;
	this->date = date;
	this->credentialsId = credentialsId;
	this->employeeId = employeeId;
	this->serviceId = serviceId;
}

inline int Registration::getId()
{
	return this->id;
}

inline time_t Registration::getDate()
{
	return this->date;
}

inline int Registration::getCredentialsId()
{
	return this->credentialsId;
}

inline int Registration::getEmployeeId()
{
	return this->employeeId;
}

inline int Registration::getServiceId()
{
	return this->serviceId;
}

inline void Registration::setDate(time_t value)
{
	this->date = value;
}

inline void Registration::setCredentialsId(int value)
{
	this->credentialsId = value;
}

inline void Registration::setEmployeeId(int value)
{
	this->employeeId = value;
}

inline void Registration::setServiceId(int value)
{
	this->serviceId = value;
}


