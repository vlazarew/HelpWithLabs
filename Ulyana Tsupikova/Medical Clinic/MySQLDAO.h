#pragma once

#include "pch.h"
#include <mysql.h>
#include "stdafx.h"
#include <iostream>
#include<string>

using namespace std;

class MySQLDAO
{
public:
	static MYSQL createConnection()
	{
		MYSQL connection;

		mysql_init(&connection);
		mysql_options(&connection, MYSQL_READ_DEFAULT_GROUP, "Medical Clinic");
		mysql_options(&connection, MYSQL_SET_CHARSET_NAME, "utf8");
		mysql_real_connect(&connection, "localhost", "admin", "admin", "medical_clinic", 3306, NULL, 0);

		if (!&connection)
		{
			throw "Ќе удалось установить соединение с базой";
		}

		mysql_query(&connection, "set names cp1251");

		return connection;
	};
};