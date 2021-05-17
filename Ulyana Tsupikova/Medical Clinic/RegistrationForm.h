#pragma once

namespace MedicalClinic {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для RegistrationForm
	/// </summary>
	public ref class RegistrationForm : public System::Windows::Forms::Form
	{
	private:
		Credentials* currentCredentials;
		int credentialsId;
	public:
		RegistrationForm(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

		RegistrationForm(Credentials credentials)
		{
			InitializeComponent();
			this->currentCredentials = &credentials;
			this->credentialsId = this->currentCredentials->getId();
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~RegistrationForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^ label1;
	protected:
	private: System::Windows::Forms::ComboBox^ comboBoxEmployee;
	private: System::Windows::Forms::ComboBox^ comboBoxService;
	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::DateTimePicker^ dateTimePicker1;
	private: System::Windows::Forms::Label^ label3;
	private: System::Windows::Forms::Button^ buttonCancel;
	private: System::Windows::Forms::Button^ buttonOK;
	private: System::Windows::Forms::Label^ label4;
	private: System::Windows::Forms::Label^ labelPrice;
	private: System::Windows::Forms::Label^ label6;
	private: System::Windows::Forms::Label^ labelTypeOfService;

	private:
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		System::ComponentModel::Container^ components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->comboBoxEmployee = (gcnew System::Windows::Forms::ComboBox());
			this->comboBoxService = (gcnew System::Windows::Forms::ComboBox());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->dateTimePicker1 = (gcnew System::Windows::Forms::DateTimePicker());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->buttonCancel = (gcnew System::Windows::Forms::Button());
			this->buttonOK = (gcnew System::Windows::Forms::Button());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->labelPrice = (gcnew System::Windows::Forms::Label());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->labelTypeOfService = (gcnew System::Windows::Forms::Label());
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(12, 9);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(31, 13);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Врач";
			// 
			// comboBoxEmployee
			// 
			this->comboBoxEmployee->FormattingEnabled = true;
			this->comboBoxEmployee->Location = System::Drawing::Point(118, 6);
			this->comboBoxEmployee->Name = L"comboBoxEmployee";
			this->comboBoxEmployee->Size = System::Drawing::Size(360, 21);
			this->comboBoxEmployee->TabIndex = 1;
			this->comboBoxEmployee->SelectedIndexChanged += gcnew System::EventHandler(this, &RegistrationForm::comboBoxEmployee_SelectedIndexChanged);
			this->comboBoxEmployee->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &RegistrationForm::comboBoxEmployee_KeyPress);
			// 
			// comboBoxService
			// 
			this->comboBoxService->FormattingEnabled = true;
			this->comboBoxService->Location = System::Drawing::Point(118, 33);
			this->comboBoxService->Name = L"comboBoxService";
			this->comboBoxService->Size = System::Drawing::Size(360, 21);
			this->comboBoxService->TabIndex = 3;
			this->comboBoxService->SelectedIndexChanged += gcnew System::EventHandler(this, &RegistrationForm::comboBoxService_SelectedIndexChanged);
			this->comboBoxService->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &RegistrationForm::comboBoxService_KeyPress);
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(12, 36);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(43, 13);
			this->label2->TabIndex = 2;
			this->label2->Text = L"Услуга";
			// 
			// dateTimePicker1
			// 
			this->dateTimePicker1->Location = System::Drawing::Point(118, 108);
			this->dateTimePicker1->Name = L"dateTimePicker1";
			this->dateTimePicker1->Size = System::Drawing::Size(360, 20);
			this->dateTimePicker1->TabIndex = 4;
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(12, 114);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(74, 13);
			this->label3->TabIndex = 5;
			this->label3->Text = L"Дата приема";
			// 
			// buttonCancel
			// 
			this->buttonCancel->Location = System::Drawing::Point(403, 153);
			this->buttonCancel->Name = L"buttonCancel";
			this->buttonCancel->Size = System::Drawing::Size(75, 23);
			this->buttonCancel->TabIndex = 17;
			this->buttonCancel->Text = L"Отмена";
			this->buttonCancel->UseVisualStyleBackColor = true;
			this->buttonCancel->Click += gcnew System::EventHandler(this, &RegistrationForm::buttonCancel_Click);
			// 
			// buttonOK
			// 
			this->buttonOK->Enabled = false;
			this->buttonOK->Location = System::Drawing::Point(322, 153);
			this->buttonOK->Name = L"buttonOK";
			this->buttonOK->Size = System::Drawing::Size(75, 23);
			this->buttonOK->TabIndex = 16;
			this->buttonOK->Text = L"OK";
			this->buttonOK->UseVisualStyleBackColor = true;
			this->buttonOK->Click += gcnew System::EventHandler(this, &RegistrationForm::buttonOK_Click);
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Location = System::Drawing::Point(12, 64);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(62, 13);
			this->label4->TabIndex = 18;
			this->label4->Text = L"Стоимость";
			// 
			// labelPrice
			// 
			this->labelPrice->AutoSize = true;
			this->labelPrice->Location = System::Drawing::Point(115, 64);
			this->labelPrice->Name = L"labelPrice";
			this->labelPrice->Size = System::Drawing::Size(0, 13);
			this->labelPrice->TabIndex = 19;
			// 
			// label6
			// 
			this->label6->AutoSize = true;
			this->label6->Location = System::Drawing::Point(12, 91);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(62, 13);
			this->label6->TabIndex = 20;
			this->label6->Text = L"Вид услуги";
			// 
			// labelTypeOfService
			// 
			this->labelTypeOfService->AutoSize = true;
			this->labelTypeOfService->Location = System::Drawing::Point(115, 91);
			this->labelTypeOfService->Name = L"labelTypeOfService";
			this->labelTypeOfService->Size = System::Drawing::Size(0, 13);
			this->labelTypeOfService->TabIndex = 21;
			// 
			// RegistrationForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(490, 184);
			this->Controls->Add(this->labelTypeOfService);
			this->Controls->Add(this->label6);
			this->Controls->Add(this->labelPrice);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->buttonCancel);
			this->Controls->Add(this->buttonOK);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->dateTimePicker1);
			this->Controls->Add(this->comboBoxService);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->comboBoxEmployee);
			this->Controls->Add(this->label1);
			this->Name = L"RegistrationForm";
			this->Text = L"Форма регистрации";
			this->Load += gcnew System::EventHandler(this, &RegistrationForm::RegistrationForm_Load);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void buttonCancel_Click(System::Object^ sender, System::EventArgs^ e)
	{
		DialogResult = System::Windows::Forms::DialogResult::Cancel;
		this->Close();
	}
	private: System::Void RegistrationForm_Load(System::Object^ sender, System::EventArgs^ e)
	{
		vector<Employee> allEmployees = EmployeeDAO::getAllEmployees();
		for (int i = 0; i < allEmployees.size(); i++) {
			this->comboBoxEmployee->Items->Add(gcnew String(allEmployees.at(i).getFIO().c_str()));
		}

		vector<Service> allServices = ServiceDAO::getAllServices();
		for (int i = 0; i < allServices.size(); i++) {
			this->comboBoxService->Items->Add(gcnew String(allServices.at(i).getName().c_str()));
		}
	}
	private: System::Void comboBoxService_SelectedIndexChanged(System::Object^ sender, System::EventArgs^ e)
	{
		Service service = ServiceDAO::getServiceByName(msclr::interop::marshal_as<string>(this->comboBoxService->Text->Trim()));
		this->labelPrice->Text = gcnew String(to_string(service.getPrice()).c_str());

		TypeOfService typeOfService = TypeOfServiceDAO::getTypeOfServiceById(service.getTypeOfServiceId());
		this->labelTypeOfService->Text = gcnew String(typeOfService.getName().c_str());

		buttonOK->Enabled = comboBoxService->Text->Length != 0 && comboBoxEmployee->Text->Length != 0;
	}
	private: System::Void comboBoxService_KeyPress(System::Object^ sender, System::Windows::Forms::KeyPressEventArgs^ e)
	{
		e->Handled = true;
	}
	private: System::Void comboBoxEmployee_KeyPress(System::Object^ sender, System::Windows::Forms::KeyPressEventArgs^ e)
	{
		e->Handled = true;
	}
	private: System::Void comboBoxEmployee_SelectedIndexChanged(System::Object^ sender, System::EventArgs^ e)
	{
		buttonOK->Enabled = comboBoxService->Text->Length != 0 && comboBoxEmployee->Text->Length != 0;
	}
	private: System::Void buttonOK_Click(System::Object^ sender, System::EventArgs^ e)
	{
		string newEmployeeStr = msclr::interop::marshal_as<string>(comboBoxEmployee->Text->Trim());
		string newServiceStr = msclr::interop::marshal_as<string>(comboBoxService->Text->Trim());

		Employee newEmployee = EmployeeDAO::getEmployeeByFIO(newEmployeeStr);
		Service newService = ServiceDAO::getServiceByName(newServiceStr);


		struct tm timeinfo;
		int year, month, day, hour, minute, second;
		timeinfo.tm_year = this->dateTimePicker1->Value.Year - 1900;
		timeinfo.tm_mon = this->dateTimePicker1->Value.Month - 1;
		timeinfo.tm_mday = this->dateTimePicker1->Value.Day;
		timeinfo.tm_hour = this->dateTimePicker1->Value.Hour;
		timeinfo.tm_min = this->dateTimePicker1->Value.Minute;
		timeinfo.tm_sec = this->dateTimePicker1->Value.Second;
		timeinfo.tm_isdst = -1;

		time_t date = mktime(&timeinfo);

		// Если добавление
		//if (this->currentEmployee == nullptr) {
		Registration newRegistration = Registration::Registration(date, this->credentialsId, newEmployee.getId(), newService.getId());

		if (!RegistrationDAO::saveRegistration(newRegistration)) {
			MessageBox::Show("Ошибка при сохранении записи к врачу");
			return;
		}

		DialogResult = System::Windows::Forms::DialogResult::OK;
		this->Close();
	}
		   // Если обновляем
		   /*else {
			   this->currentEmployee->setFIO(newFIO);
			   this->currentEmployee->setDepartmentId(newDepartment.getId());

			   if (!EmployeeDAO::updateEmployee(*currentEmployee)) {
				   MessageBox::Show("Ошибка при обновлении врача");
				   return;
			   }

			   DialogResult = System::Windows::Forms::DialogResult::OK;
			   this->Close();
		   }*/
	};

};
