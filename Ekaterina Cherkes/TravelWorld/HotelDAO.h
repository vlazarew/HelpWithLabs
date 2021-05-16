#include <mysql.h>
#include "stdafx.h"
#include <iostream>
#include<string>
#include <vector>
#include "MySQLDAO.h"
#include "Hotel.h"

using namespace std;

class HotelDAO {
public:
	static vector<Hotel> getAllHotels()
	{
		vector<Hotel> resultList = vector<Hotel>();
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

	static Hotel getHotelById(int id)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from hotel where hotel.id='%s'", to_string(id).c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				return Hotel::Hotel(atoi(row[0]), row[1], atoi(row[2]), atoi(row[3]), row[4]);
			}
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}

		return Hotel::Hotel(-10, "", 0, 0, "");
	};

	static Hotel getHotelByName(string name)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from hotel where hotel.name=\"%s\"", name.c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				return Hotel::Hotel(atoi(row[0]), row[1], atoi(row[2]), atoi(row[3]), row[4]);
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