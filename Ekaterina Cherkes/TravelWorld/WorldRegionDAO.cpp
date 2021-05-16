#include "WorldRegion.h"
#include "WorldRegionDAO.h"
#include <mysql.h>
#include "stdafx.h"
#include <iostream>
#include<string>
#include <list>
#include "MySQLDAO.h"

list<WorldRegion> WorldRegionDAO::getAllRegions()
{
	list<WorldRegion> result = list<WorldRegion>();
	/*MYSQL* connection = MySQLDAO::createConnection();

	string query = "select * from region";

	int queryState = mysql_query(connection, query.c_str());
	if (!queryState) {
		MYSQL_ROW row;
		MYSQL_RES* result;
		result = mysql_store_result(connection);

		while (row = mysql_fetch_row(result))
		{
			printf("ID: %s, Name: %s\n", row[0], row[1]);
		}
	}
	else
	{
		string pattern = "Ошибка выполнения запроса ";
		string error = mysql_error(connection);
		throw pattern + error;
	}*/

	return result;
}
