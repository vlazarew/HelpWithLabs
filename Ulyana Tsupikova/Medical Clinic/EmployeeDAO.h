#include <mysql.h>
#include "stdafx.h"
#include <iostream>
#include<string>
#include <vector>
#include "MySQLDAO.h"
#include "Employee.h"

using namespace std;

class EmployeeDAO {
public:
	static Employee getEmployeeById(int id)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Employee where Employee.id='%s'", to_string(id).c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				return Employee::Employee(atoi(row[0]), row[1], atoi(row[2]));
			}
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}
	};

	static vector<Employee> getEmployeesByDepartmentId(int departmentId)
	{
		vector<Employee> resultList;
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Employee where Employee.department_id='%s'", to_string(departmentId).c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				resultList.push_back(Employee::Employee(atoi(row[0]), row[1], atoi(row[2])));
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

	/*static Employee getEmployeeByLoginAndPassword(string login, string password)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Employee where Employee.login='%s' and Employee.password='%s'", login.c_str(), password.c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				return Employee::Employee(atoi(row[0]), row[1], row[2]);
			}
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}

		return Employee::Employee(-10, "", "");
	};*/
};