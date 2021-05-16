#include <mysql.h>
#include "stdafx.h"
#include <iostream>
#include<string>
#include <vector>
#include "MySQLDAO.h"
#include "Country.h"

using namespace std;

class CountryDAO {
public:
	static vector<Country> getAllCountries()
	{
		vector<Country> resultList = vector<Country>();
		MYSQL connection = MySQLDAO::createConnection();

		string query = "select * from country";

		int queryState = mysql_query(&connection, query.c_str());
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				resultList.push_back(Country::Country(atoi(row[0]), row[1], atoi(row[2])));
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

	static Country getCountryById(int id)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from country where country.id='%s'", to_string(id).c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				return Country::Country(atoi(row[0]), row[1], atoi(row[2]));
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