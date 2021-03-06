#include <mysql.h>
#include "stdafx.h"
#include <iostream>
#include<string>
#include <vector>
#include "MySQLDAO.h"
#include "Credentials.h"

using namespace std;

class CredentialsDAO {
public:
	static vector<Credentials> getCredentialsByLogin(string login)
	{
		vector<Credentials> resultList = vector<Credentials>();
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Credentials where Credentials.login='%s'", login.c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				resultList.push_back(Credentials::Credentials(atoi(row[0]), row[1], row[2], (*row[3] != '0')));
			}
		}
		else
		{
			string pattern = "?????? ?????????? ??????? ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}

		return resultList;
	};

	static Credentials getCredentialsByLoginAndPassword(string login, string password)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Credentials where Credentials.login='%s' and Credentials.password='%s'", login.c_str(), password.c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				return Credentials::Credentials(atoi(row[0]), row[1], row[2], (*row[3] != '0'));
			}
		}
		else
		{
			string pattern = "?????? ?????????? ??????? ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}

		return Credentials::Credentials(-10, "", "", false);
	};

	static Credentials getCredentialsById(int id)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Credentials where Credentials.id='%s'", to_string(id).c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				return Credentials::Credentials(atoi(row[0]), row[1], row[2], (*row[3] != '0'));
			}
		}
		else
		{
			string pattern = "?????? ?????????? ??????? ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}

		return Credentials::Credentials(-10, "", "", false);
	};

};