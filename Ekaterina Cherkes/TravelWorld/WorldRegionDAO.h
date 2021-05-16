#include <mysql.h>
#include "stdafx.h"
#include <iostream>
#include<string>
#include <list>
#include "WorldRegion.h"
#include "MySQLDAO.h"

using namespace std;

class WorldRegionDAO {
public:
	static list<WorldRegion> getAllRegions()
	{
		list<WorldRegion> resultList = list<WorldRegion>();
		MYSQL connection = MySQLDAO::createConnection();

		string query = "select * from region";

		int queryState = mysql_query(&connection, query.c_str());
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				resultList.push_back(WorldRegion::WorldRegion(atoi(row[0]),  row[1]));
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