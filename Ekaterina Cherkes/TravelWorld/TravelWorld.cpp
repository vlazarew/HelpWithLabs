#include "pch.h"
#include "stdafx.h"

using namespace System;
using namespace System::Windows::Forms;

int main()
{
	//setlocale(LC_ALL, "Russian");
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	TravelWorld::MainForm mainForm;
	Application::Run(% mainForm);
	return 0;
}
