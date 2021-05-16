#include "pch.h"
#include <mysql.h>
#include "stdafx.h"
#include <iostream>
#include<string>
#include "MySQLDAO.h"

using namespace std;

/*MYSQL* MySQLDAO::createConnection()
{
	MYSQL* connection;
	connection = mysql_init(0);
	connection = mysql_real_connect(connection, "localhost", "admin", "admin", "hotel_traveller", 3306, NULL, 0);

	if (!connection)
	{
		throw "Ќе удалось установить соединение с базой";
	}

	return connection;
}*/

/*MYSQL* MySQLDAO::createConnection()
{
	return nullptr;
}*/
