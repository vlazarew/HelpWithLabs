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

	static Employee getEmployeeByFIO(string FIO)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Employee where Employee.FIO='%s'", FIO.c_str());

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

	static vector<Employee> getAllEmployees()
	{
		vector<Employee> resultList;
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "select * from Employee");

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

	static bool deleteEmployee(Employee employee)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "delete from employee where employee.id='%s'", to_string(employee.getId()).c_str());

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

	static bool saveEmployee(Employee employee)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "insert into employee (FIO, department_id) values('%s', '%s')", employee.getFIO().c_str(), to_string(employee.getDepartmentId()).c_str());

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

	static bool updateEmployee(Employee employee)
	{
		MYSQL connection = MySQLDAO::createConnection();
		char query[1024];

		sprintf(query, "update employee set employee.FIO = '%s',  employee.department_id='%s' where employee.id='%s'", employee.getFIO().c_str(), to_string(employee.getDepartmentId()).c_str(),
			to_string(employee.getId()).c_str());

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