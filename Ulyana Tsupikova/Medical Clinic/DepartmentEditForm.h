#pragma once

namespace MedicalClinic {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для EditForm
	/// </summary>
	public ref class DepartmentEditForm : public System::Windows::Forms::Form
	{
	private:
		Department* currentDepartment;
	public:
		DepartmentEditForm(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

		DepartmentEditForm(Department department)
		{
			InitializeComponent();
			this->currentDepartment = &department;
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~DepartmentEditForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^ label1;
	protected:
	private: System::Windows::Forms::TextBox^ textBoxName;
	private: System::Windows::Forms::TextBox^ textBoxDescription;
	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::Button^ buttonCancel;
	private: System::Windows::Forms::Button^ buttonOK;

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
			this->textBoxName = (gcnew System::Windows::Forms::TextBox());
			this->textBoxDescription = (gcnew System::Windows::Forms::TextBox());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->buttonCancel = (gcnew System::Windows::Forms::Button());
			this->buttonOK = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(12, 18);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(83, 13);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Наименование";
			// 
			// textBoxName
			// 
			this->textBoxName->Location = System::Drawing::Point(101, 15);
			this->textBoxName->Name = L"textBoxName";
			this->textBoxName->Size = System::Drawing::Size(284, 20);
			this->textBoxName->TabIndex = 1;
			this->textBoxName->TextChanged += gcnew System::EventHandler(this, &DepartmentEditForm::textBoxName_TextChanged);
			// 
			// textBoxDescription
			// 
			this->textBoxDescription->Location = System::Drawing::Point(101, 44);
			this->textBoxDescription->Multiline = true;
			this->textBoxDescription->Name = L"textBoxDescription";
			this->textBoxDescription->Size = System::Drawing::Size(284, 110);
			this->textBoxDescription->TabIndex = 3;
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(12, 47);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(57, 13);
			this->label2->TabIndex = 2;
			this->label2->Text = L"Описание";
			// 
			// buttonCancel
			// 
			this->buttonCancel->Location = System::Drawing::Point(310, 160);
			this->buttonCancel->Name = L"buttonCancel";
			this->buttonCancel->Size = System::Drawing::Size(75, 23);
			this->buttonCancel->TabIndex = 15;
			this->buttonCancel->Text = L"Отмена";
			this->buttonCancel->UseVisualStyleBackColor = true;
			this->buttonCancel->Click += gcnew System::EventHandler(this, &DepartmentEditForm::buttonCancel_Click);
			// 
			// buttonOK
			// 
			this->buttonOK->Enabled = false;
			this->buttonOK->Location = System::Drawing::Point(229, 160);
			this->buttonOK->Name = L"buttonOK";
			this->buttonOK->Size = System::Drawing::Size(75, 23);
			this->buttonOK->TabIndex = 14;
			this->buttonOK->Text = L"OK";
			this->buttonOK->UseVisualStyleBackColor = true;
			this->buttonOK->Click += gcnew System::EventHandler(this, &DepartmentEditForm::buttonOK_Click);
			// 
			// DepartmentEditForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(397, 192);
			this->Controls->Add(this->buttonCancel);
			this->Controls->Add(this->buttonOK);
			this->Controls->Add(this->textBoxDescription);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->textBoxName);
			this->Controls->Add(this->label1);
			this->Name = L"DepartmentEditForm";
			this->Text = L"Добавление/редактирование отдела";
			this->Load += gcnew System::EventHandler(this, &DepartmentEditForm::DepartmentEditForm_Load);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void buttonCancel_Click(System::Object^ sender, System::EventArgs^ e)
	{
		DialogResult = System::Windows::Forms::DialogResult::Cancel;
		this->Close();
	}
	private: System::Void DepartmentEditForm_Load(System::Object^ sender, System::EventArgs^ e)
	{
		if (this->currentDepartment != nullptr) {
			Department department = DepartmentDAO::getDepartmentById(this->currentDepartment->getId());
			this->textBoxName->Text = gcnew String(department.getName().c_str());
			this->textBoxDescription->Text = gcnew String(department.getDescription().c_str());
		}
	}
	private: System::Void buttonOK_Click(System::Object^ sender, System::EventArgs^ e)
	{
		string newName = msclr::interop::marshal_as<string>(textBoxName->Text->Trim());
		string newDescription = msclr::interop::marshal_as<string>(textBoxDescription->Text->Trim());

		// Если добавление
		if (this->currentDepartment == nullptr) {
			Department newDepartment = Department::Department(newName, newDescription);

			if (!DepartmentDAO::saveDepartment(newDepartment)) {
				MessageBox::Show("Ошибка при сохранении отделения");
				return;
			}

			DialogResult = System::Windows::Forms::DialogResult::OK;
			this->Close();
		}
		// Если обновляем
		else {
			this->currentDepartment->setName(newName);
			this->currentDepartment->setDescription(newDescription);

			if (!DepartmentDAO::updateDepartment(*currentDepartment)) {
				MessageBox::Show("Ошибка при обновлении отделения");
				return;
			}

			DialogResult = System::Windows::Forms::DialogResult::OK;
			this->Close();
		}
	}
	private: System::Void textBoxName_TextChanged(System::Object^ sender, System::EventArgs^ e)
	{
		buttonOK->Enabled = textBoxName->Text->Length != 0;
	}
	};
}
