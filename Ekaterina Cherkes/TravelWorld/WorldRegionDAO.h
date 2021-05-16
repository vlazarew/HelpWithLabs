#include <mysql.h>
#include "stdafx.h"
#include <iostream>
#include<string>
#include <vector>
#include "WorldRegion.h"
#include "MySQLDAO.h"

using namespace std;

class WorldRegionDAO {
public:
	static vector<WorldRegion> getAllRegions()
	{
		vector<WorldRegion> resultList = vector<WorldRegion>();
		MYSQL connection = MySQLDAO::createConnection();

		string query = "select * from region";

		int queryState = mysql_query(&connection, query.c_str());
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				resultList.push_back(WorldRegion::WorldRegion(atoi(row[0]), row[1]));
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

	static WorldRegion getWorldRegionById(int id)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from region where region.id='%s'", to_string(id).c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				return WorldRegion::WorldRegion(atoi(row[0]), row[1]);
			}
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}
	};
};