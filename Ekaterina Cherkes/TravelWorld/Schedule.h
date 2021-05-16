#pragma once

#include <string>
#include <ctime>

using namespace std;

class Schedule
{
public:
	Schedule(time_t fromDate, time_t toDate, int price, int hotelId);
	Schedule(int id, time_t fromDate, time_t toDate, int price, int hotelId);
	int getId();
	time_t getFromDate();
	time_t getToDate();
	int getHotelId();
	int getPrice();
	void setFromDate(time_t value);
	void setToDate(time_t value);
	void setPrice(int value);
	void setHotelId(int value);

private:
	int id;
	time_t fromDate;
	time_t toDate;
	int price;
	int hotelId;
};

Schedule::Schedule(time_t fromDate, time_t toDate, int price, int hotelId)
{
	this->fromDate = fromDate;
	this->toDate = toDate;
	this->hotelId = hotelId;
	this->price = price;
}

Schedule::Schedule(int id, time_t fromDate, time_t toDate, int price, int hotelId)
{
	this->id = id;
	this->fromDate = fromDate;
	this->toDate = toDate;
	this->hotelId = hotelId;
	this->price = price;
}

int Schedule::getId()
{
	return this->id;
}

inline time_t Schedule::getFromDate()
{
	return this->fromDate;
}

inline time_t Schedule::getToDate()
{
	return this->toDate;
}

inline int Schedule::getHotelId()
{
	return this->hotelId;
}

inline int Schedule::getPrice()
{
	return this->price;
}

inline void Schedule::setFromDate(time_t value)
{
	this->fromDate = value;
}

inline void Schedule::setToDate(time_t value)
{
	this->toDate = value;
}

inline void Schedule::setPrice(int value)
{
	this->price = value;
}

inline void Schedule::setHotelId(int value)
{
	this->hotelId = value;
}

