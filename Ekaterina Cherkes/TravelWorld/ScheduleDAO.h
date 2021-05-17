#include <mysql.h>
#include "stdafx.h"
#include <iostream>
#include<string>
#include <vector>
#include <time.h>
#include "MySQLDAO.h"
#include "Schedule.h"

using namespace std;

class ScheduleDAO {
private:
	static time_t createTS(char* timeString)
	{
		int yy, month, dd;
		struct tm time;
		sscanf(timeString, "%d-%d-%d", &yy, &month, &dd);
		time.tm_year = yy - 1900;
		time.tm_mon = month - 1;
		time.tm_mday = dd;
		time.tm_hour = 0;
		time.tm_min = 0;
		time.tm_sec = 0;
		time.tm_isdst = -1;

		return mktime(&time);
	}
	static string timeStampToHReadble(const time_t rawtime)
	{
		struct tm* dt;
		char buffer[30];
		dt = localtime(&rawtime);
		//strftime(buffer, sizeof(buffer), "%d/%m/%Y", dt);
		strftime(buffer, sizeof(buffer), "%Y-%m-%d", dt);
		return std::string(buffer);
	}
public:
	static vector<Schedule> getAllSchedules()
	{
		vector<Schedule> resultList = vector<Schedule>();
		MYSQL connection = MySQLDAO::createConnection();

		string query = "select * from schedule";

		int queryState = mysql_query(&connection, query.c_str());
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				resultList.push_back(Schedule::Schedule(atoi(row[0]), createTS(row[1]), createTS(row[2]), atoi(row[3]), stof(row[4])));
			}
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}

		return resultList;
	};

	static Schedule getScheduleByFromToPriceHotelId(string from, string to, int price)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from schedule where schedule.from_date='%s' and schedule.to_date='%s' and schedule.price='%s'", from.c_str(), to.c_str(), to_string(price).c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				return Schedule::Schedule(atoi(row[0]), createTS(row[1]), createTS(row[2]), atoi(row[3]), stof(row[4]));
			}
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}
	};

	static bool deleteSchedule(Schedule schedule)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "delete from schedule where schedule.id='%s'", to_string(schedule.getId()).c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			return true;
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}

		return false;
	};


	static bool saveSchedule(Schedule schedule)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "insert into schedule (from_date, to_date, price, hotel_id) values('%s', '%s', '%s', '%s')",
			timeStampToHReadble(schedule.getFromDate()).c_str(), timeStampToHReadble(schedule.getToDate()).c_str(), to_string(schedule.getPrice()).c_str(), to_string(schedule.getHotelId()).c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			return true;
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}

		return false;
	};

	static bool updateSchedule(Schedule schedule)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "update schedule set schedule.from_date = '%s', schedule.to_date = '%s', schedule.price = '%s', schedule.hotel_id = '%s' where schedule.id = '%s'",
			timeStampToHReadble(schedule.getFromDate()).c_str(), timeStampToHReadble(schedule.getToDate()).c_str(), to_string(schedule.getPrice()).c_str(), to_string(schedule.getHotelId()).c_str(),
			to_string(schedule.getId()).c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			return true;
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}

		return false;
	};
};