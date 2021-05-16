#include <mysql.h>
#include "stdafx.h"
#include <iostream>
#include<string>
#include <list>
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
public:
	static list<Schedule> getAllShedules()
	{
		list<Schedule> resultList = list<Schedule>();
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
};