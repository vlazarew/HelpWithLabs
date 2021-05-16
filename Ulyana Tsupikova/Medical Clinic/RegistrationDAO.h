#include <mysql.h>
#include "stdafx.h"
#include <iostream>
#include<string>
#include <vector>
#include "MySQLDAO.h"
#include "Registration.h"

using namespace std;

class RegistrationDAO {
private:
	static time_t createTS(char* timeString)
	{
		int yy, month, dd, hh, mm, ss;
		struct tm time;
		sscanf(timeString, "%d-%d-%d %d:%d:%d", &yy, &month, &dd, &hh, &mm, &ss);
		time.tm_year = yy - 1900;
		time.tm_mon = month - 1;
		time.tm_mday = dd;
		time.tm_hour = hh;
		time.tm_min = mm;
		time.tm_sec = ss;
		time.tm_isdst = -1;

		return mktime(&time);
	}
	static string timeStampToHReadble(const time_t rawtime)
	{
		struct tm* dt;
		char buffer[30];
		dt = localtime(&rawtime);
		strftime(buffer, sizeof(buffer), "%Y-%m-%d %H:%M:%S", dt);
		return std::string(buffer);
	}
public:
	static vector<Registration> getRegistrationsByCredentialsId(int credentialsId)
	{
		vector<Registration> resultList;
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Registration where Registration.credentials_Id='%s'", to_string(credentialsId).c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				resultList.push_back(Registration::Registration(atoi(row[0]), createTS(row[1]), atoi(row[2]), atoi(row[3]), atoi(row[4])));
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

	/*static Registration getRegistrationByLoginAndPassword(string login, string password)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Registration where Registration.login='%s' and Registration.password='%s'", login.c_str(), password.c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				return Registration::Registration(atoi(row[0]), row[1], row[2]);
			}
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}

		return Registration::Registration(-10, "", "");
	};*/
};