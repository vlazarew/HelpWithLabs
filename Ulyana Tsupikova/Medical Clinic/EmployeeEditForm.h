#pragma once

namespace MedicalClinic {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для EmployeeEditForm
	/// </summary>
	public ref class EmployeeEditForm : public System::Windows::Forms::Form
	{
	private:
		Employee* currentEmployee;
	public:
		EmployeeEditForm(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

		EmployeeEditForm(Employee employee)
		{
			InitializeComponent();
			this->currentEmployee = &employee;
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~EmployeeEditForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^ buttonCancel;
	protected:
	private: System::Windows::Forms::Button^ buttonOK;
	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::TextBox^ textBoxFIO;
	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::ComboBox^ comboBoxDepartment;

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
			this->buttonCancel = (gcnew System::Windows::Forms::Button());
			this->buttonOK = (gcnew System::Windows::Forms::Button());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->textBoxFIO = (gcnew System::Windows::Forms::TextBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->comboBoxDepartment = (gcnew System::Windows::Forms::ComboBox());
			this->SuspendLayout();
			// 
			// buttonCancel
			// 
			this->buttonCancel->Location = System::Drawing::Point(310, 71);
			this->buttonCancel->Name = L"buttonCancel";
			this->buttonCancel->Size = System::Drawing::Size(75, 23);
			this->buttonCancel->TabIndex = 21;
			this->buttonCancel->Text = L"Отмена";
			this->buttonCancel->UseVisualStyleBackColor = true;
			this->buttonCancel->Click += gcnew System::EventHandler(this, &EmployeeEditForm::buttonCancel_Click);
			// 
			// buttonOK
			// 
			this->buttonOK->Enabled = false;
			this->buttonOK->Location = System::Drawing::Point(229, 71);
			this->buttonOK->Name = L"buttonOK";
			this->buttonOK->Size = System::Drawing::Size(75, 23);
			this->buttonOK->TabIndex = 20;
			this->buttonOK->Text = L"OK";
			this->buttonOK->UseVisualStyleBackColor = true;
			this->buttonOK->Click += gcnew System::EventHandler(this, &EmployeeEditForm::buttonOK_Click);
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(12, 44);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(38, 13);
			this->label2->TabIndex = 18;
			this->label2->Text = L"Отдел";
			// 
			// textBoxFIO
			// 
			this->textBoxFIO->Location = System::Drawing::Point(101, 12);
			this->textBoxFIO->Name = L"textBoxFIO";
			this->textBoxFIO->Size = System::Drawing::Size(284, 20);
			this->textBoxFIO->TabIndex = 17;
			this->textBoxFIO->TextChanged += gcnew System::EventHandler(this, &EmployeeEditForm::textBoxFIO_TextChanged);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(12, 15);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(34, 13);
			this->label1->TabIndex = 16;
			this->label1->Text = L"ФИО";
			// 
			// comboBoxDepartment
			// 
			this->comboBoxDepartment->FormattingEnabled = true;
			this->comboBoxDepartment->Location = System::Drawing::Point(101, 44);
			this->comboBoxDepartment->Name = L"comboBoxDepartment";
			this->comboBoxDepartment->Size = System::Drawing::Size(284, 21);
			this->comboBoxDepartment->TabIndex = 22;
			this->comboBoxDepartment->SelectedIndexChanged += gcnew System::EventHandler(this, &EmployeeEditForm::comboBoxDepartment_SelectedIndexChanged);
			this->comboBoxDepartment->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &EmployeeEditForm::comboBoxDepartment_KeyPress);
			// 
			// EmployeeEditForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(407, 105);
			this->Controls->Add(this->comboBoxDepartment);
			this->Controls->Add(this->buttonCancel);
			this->Controls->Add(this->buttonOK);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->textBoxFIO);
			this->Controls->Add(this->label1);
			this->Name = L"EmployeeEditForm";
			this->Text = L"Добавление/редактирование врача";
			this->Load += gcnew System::EventHandler(this, &EmployeeEditForm::EmployeeEditForm_Load);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void buttonCancel_Click(System::Object^ sender, System::EventArgs^ e)
	{
		DialogResult = System::Windows::Forms::DialogResult::Cancel;
		this->Close();
	}
	private: System::Void EmployeeEditForm_Load(System::Object^ sender, System::EventArgs^ e)
	{
		vector<Department> allDepartments = DepartmentDAO::getAllDepartments();
		for (int i = 0; i < allDepartments.size(); i++) {
			this->comboBoxDepartment->Items->Add(gcnew String(allDepartments.at(i).getName().c_str()));
		}

		if (this->currentEmployee != nullptr) {
			Employee employee = EmployeeDAO::getEmployeeById(this->currentEmployee->getId());
			this->textBoxFIO->Text = gcnew String(employee.getFIO().c_str());

			Department department = DepartmentDAO::getDepartmentById(employee.getDepartmentId());
			this->comboBoxDepartment->Text = gcnew String(department.getName().c_str());
		}
	}
	private: System::Void comboBoxDepartment_SelectedIndexChanged(System::Object^ sender, System::EventArgs^ e)
	{
		buttonOK->Enabled = comboBoxDepartment->Text->Length != 0 && textBoxFIO->Text->Length != 0;
	}
	private: System::Void comboBoxDepartment_KeyPress(System::Object^ sender, System::Windows::Forms::KeyPressEventArgs^ e)
	{
		e->Handled = true;
	}
	private: System::Void textBoxFIO_TextChanged(System::Object^ sender, System::EventArgs^ e)
	{
		buttonOK->Enabled = comboBoxDepartment->Text->Length != 0 && textBoxFIO->Text->Length != 0;
	}
	private: System::Void buttonOK_Click(System::Object^ sender, System::EventArgs^ e)
	{
		string newFIO = msclr::interop::marshal_as<string>(textBoxFIO->Text->Trim());
		string newDepartmentName = msclr::interop::marshal_as<string>(comboBoxDepartment->Text->Trim());
		Department newDepartment = DepartmentDAO::getDepartmentByName(newDepartmentName);

		// Если добавление
		if (this->currentEmployee == nullptr) {
			Employee newEmployee = Employee::Employee(newFIO, newDepartment.getId());

			if (!EmployeeDAO::saveEmployee(newEmployee)) {
				MessageBox::Show("Ошибка при сохранении врача");
				return;
			}

			DialogResult = System::Windows::Forms::DialogResult::OK;
			this->Close();
		}
		// Если обновляем
		else {
			this->currentEmployee->setFIO(newFIO);
			this->currentEmployee->setDepartmentId(newDepartment.getId());

			if (!EmployeeDAO::updateEmployee(*currentEmployee)) {
				MessageBox::Show("Ошибка при обновлении врача");
				return;
			}

			DialogResult = System::Windows::Forms::DialogResult::OK;
			this->Close();
		}
	}
	};
}
