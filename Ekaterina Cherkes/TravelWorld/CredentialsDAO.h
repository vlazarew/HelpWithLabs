#include <mysql.h>
#include "stdafx.h"
#include <iostream>
#include<string>
#include <list>
#include "MySQLDAO.h"
#include "Credentials.h"

using namespace std;

class CredentialsDAO {
public:
	static list<Credentials> getCredentialsByLogin(string login)
	{
		list<Credentials> resultList = list<Credentials>();
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from credentials where credentials.login='%s'", login.c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				resultList.push_back(Credentials::Credentials(atoi(row[0]), row[1], row[2]));
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

	static list<Credentials> getCredentialsByLoginAndPassword(string login, string password)
	{
		list<Credentials> resultList = list<Credentials>();
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from credentials where credentials.login='%s' and credentials.password='%s'", login.c_str(), password.c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				resultList.push_back(Credentials::Credentials(atoi(row[0]), row[1], row[2]));
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