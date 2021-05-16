#include <mysql.h>
#include "stdafx.h"
#include <iostream>
#include<string>
#include <list>
#include "MySQLDAO.h"
#include "Hotel.h"

using namespace std;

class HotelDAO {
public:
	static list<Hotel> getAllHotels()
	{
		list<Hotel> resultList = list<Hotel>();
		MYSQL connection = MySQLDAO::createConnection();

		string query = "select * from hotel";

		int queryState = mysql_query(&connection, query.c_str());
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				resultList.push_back(Hotel::Hotel(atoi(row[0]), row[1], atoi(row[2]), atoi(row[3]), row[4]));
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