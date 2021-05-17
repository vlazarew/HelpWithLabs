#include <mysql.h>
#include "stdafx.h"
#include <iostream>
#include<string>
#include <vector>
#include "MySQLDAO.h"
#include "Service.h"

using namespace std;

class ServiceDAO {
public:
	static Service getServiceById(int id)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Service where Service.id='%s'", to_string(id).c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				return Service::Service(atoi(row[0]), row[1], atoi(row[2]), atoi(row[3]));
			}
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}
	};

	static Service getServiceByName(string name)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Service where Service.name='%s'", name.c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				return Service::Service(atoi(row[0]), row[1], atoi(row[2]), atoi(row[3]));
			}
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}
	};

	static vector<Service> getAllServices()
	{
		vector<Service> resultList;
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Service");

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				resultList.push_back(Service::Service(atoi(row[0]), row[1], atoi(row[2]), atoi(row[3])));
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