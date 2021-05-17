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

	static Registration getRegistrationByDateCredentialsEmployeeService(string date, int credentialsId, int employeeId, int serviceId)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Registration where Registration.date='%s' and Registration.credentials_Id='%s' and Registration.employee_Id='%s' and Registration.service_Id='%s'", 
			date.c_str(), to_string(credentialsId).c_str(), to_string(employeeId).c_str(), to_string(serviceId).c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				return Registration::Registration(atoi(row[0]), createTS(row[1]), atoi(row[2]), atoi(row[3]), atoi(row[4]));
			}
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}
	}

	static bool saveRegistration(Registration registration)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "insert into registration (date, credentials_id, employee_id, service_id) values('%s', '%s', '%s', '%s')", timeStampToHReadble(registration.getDate()).c_str(),
			to_string(registration.getCredentialsId()).c_str(), to_string(registration.getEmployeeId()).c_str(), to_string(registration.getServiceId()).c_str());

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

	static bool deleteRegistration(Registration registration)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "delete from registration where registration.id='%s'", to_string(registration.getId()).c_str());

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