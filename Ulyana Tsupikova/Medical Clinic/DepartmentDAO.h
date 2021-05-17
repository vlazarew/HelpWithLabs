#include <mysql.h>
#include "stdafx.h"
#include <iostream>
#include<string>
#include <vector>
#include "MySQLDAO.h"
#include "Department.h"

using namespace std;

class DepartmentDAO {
public:
	static Department getDepartmentById(int id)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Department where Department.id='%s'", to_string(id).c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				return Department::Department(atoi(row[0]), row[1], row[2]);
			}
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}
	};

	static Department getDepartmentByName(string name)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Department where Department.name='%s'", name.c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				return Department::Department(atoi(row[0]), row[1], row[2]);
			}
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}
	};

	static vector<Department> getAllDepartments()
	{
		vector<Department> resultList;
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Department");

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			MYSQL_ROW row;
			MYSQL_RES* result;
			result = mysql_store_result(&connection);

			while (row = mysql_fetch_row(result))
			{
				resultList.push_back(Department::Department(atoi(row[0]), row[1], row[2]));
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

	static bool deleteDepartment(Department department)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "delete from department where department.id='%s'", to_string(department.getId()).c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			return true;
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}

		return false;
	};

	static bool saveDepartment(Department department)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "insert into department (name, description) values('%s', '%s')", department.getName().c_str(), department.getDescription().c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			return true;
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}

		return false;
	};

	static bool updateDepartment(Department department)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "update department set department.name = '%s',  department.description='%s' where department.id='%s'", department.getName().c_str(), department.getDescription().c_str(),
			to_string(department.getId()).c_str());

		int queryState = mysql_query(&connection, query);
		if (!queryState) {
			return true;
		}
		else
		{
			string pattern = "Ошибка выполнения запроса ";
			string error = mysql_error(&connection);
			throw pattern + error;
		}

		return false;
	};

};