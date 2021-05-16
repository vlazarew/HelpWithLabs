#include "pch.h"
#include "stdafx.h"
#include "LoginForm.h"

using namespace System;
using namespace System::Windows::Forms;

int main()
{
	setlocale(LC_ALL, "Rus");
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	MedicalClinic::LoginForm loginForm;
	Application::Run(% loginForm);
	return 0;
}
