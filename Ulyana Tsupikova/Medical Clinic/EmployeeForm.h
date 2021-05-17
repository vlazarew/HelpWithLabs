#pragma once
#include <vector>
#include "EmployeeEditForm.h"


using namespace std;

namespace MedicalClinic {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для EmployeeForm
	/// </summary>
	public ref class EmployeeForm : public System::Windows::Forms::Form
	{
	private:
		bool isAdmin;
		void changeVisibility()
		{
			buttonAdd->Visible = this->isAdmin;
			buttonEdit->Visible = this->isAdmin;
			buttonDelete->Visible = this->isAdmin;
		}
	public:
		EmployeeForm(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

		EmployeeForm(bool isAdmin)
		{
			InitializeComponent();
			this->isAdmin = isAdmin;
			changeVisibility();
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~EmployeeForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^ buttonDelete;
	protected:
	private: System::Windows::Forms::Button^ buttonEdit;
	private: System::Windows::Forms::Button^ buttonAdd;
	private: System::Windows::Forms::Button^ buttonExit;
	private: System::Windows::Forms::DataGridView^ dataGridViewEmployees;

	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnFIO;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnDepartment;

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
			this->buttonDelete = (gcnew System::Windows::Forms::Button());
			this->buttonEdit = (gcnew System::Windows::Forms::Button());
			this->buttonAdd = (gcnew System::Windows::Forms::Button());
			this->buttonExit = (gcnew System::Windows::Forms::Button());
			this->dataGridViewEmployees = (gcnew System::Windows::Forms::DataGridView());
			this->ColumnFIO = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->ColumnDepartment = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridViewEmployees))->BeginInit();
			this->SuspendLayout();
			// 
			// buttonDelete
			// 
			this->buttonDelete->Location = System::Drawing::Point(720, 70);
			this->buttonDelete->Name = L"buttonDelete";
			this->buttonDelete->Size = System::Drawing::Size(184, 23);
			this->buttonDelete->TabIndex = 26;
			this->buttonDelete->Text = L"Удалить врача";
			this->buttonDelete->UseVisualStyleBackColor = true;
			this->buttonDelete->Click += gcnew System::EventHandler(this, &EmployeeForm::buttonDelete_Click);
			// 
			// buttonEdit
			// 
			this->buttonEdit->Location = System::Drawing::Point(720, 41);
			this->buttonEdit->Name = L"buttonEdit";
			this->buttonEdit->Size = System::Drawing::Size(184, 23);
			this->buttonEdit->TabIndex = 25;
			this->buttonEdit->Text = L"Редактировать врача";
			this->buttonEdit->UseVisualStyleBackColor = true;
			this->buttonEdit->Click += gcnew System::EventHandler(this, &EmployeeForm::buttonEdit_Click);
			// 
			// buttonAdd
			// 
			this->buttonAdd->Location = System::Drawing::Point(720, 12);
			this->buttonAdd->Name = L"buttonAdd";
			this->buttonAdd->Size = System::Drawing::Size(184, 23);
			this->buttonAdd->TabIndex = 24;
			this->buttonAdd->Text = L"Добавить врача";
			this->buttonAdd->UseVisualStyleBackColor = true;
			this->buttonAdd->Click += gcnew System::EventHandler(this, &EmployeeForm::buttonAdd_Click);
			// 
			// buttonExit
			// 
			this->buttonExit->Location = System::Drawing::Point(720, 378);
			this->buttonExit->Name = L"buttonExit";
			this->buttonExit->Size = System::Drawing::Size(184, 23);
			this->buttonExit->TabIndex = 23;
			this->buttonExit->Text = L"Выход";
			this->buttonExit->UseVisualStyleBackColor = true;
			this->buttonExit->Click += gcnew System::EventHandler(this, &EmployeeForm::buttonExit_Click);
			// 
			// dataGridViewEmployees
			// 
			this->dataGridViewEmployees->AllowUserToAddRows = false;
			this->dataGridViewEmployees->AllowUserToDeleteRows = false;
			this->dataGridViewEmployees->AllowUserToOrderColumns = true;
			this->dataGridViewEmployees->AutoSizeColumnsMode = System::Windows::Forms::DataGridViewAutoSizeColumnsMode::AllCells;
			this->dataGridViewEmployees->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->dataGridViewEmployees->Columns->AddRange(gcnew cli::array< System::Windows::Forms::DataGridViewColumn^  >(2)
			{
				this->ColumnFIO,
					this->ColumnDepartment
			});
			this->dataGridViewEmployees->Location = System::Drawing::Point(12, 12);
			this->dataGridViewEmployees->Name = L"dataGridViewEmployees";
			this->dataGridViewEmployees->ReadOnly = true;
			this->dataGridViewEmployees->SelectionMode = System::Windows::Forms::DataGridViewSelectionMode::FullRowSelect;
			this->dataGridViewEmployees->Size = System::Drawing::Size(702, 389);
			this->dataGridViewEmployees->TabIndex = 22;
			// 
			// ColumnFIO
			// 
			this->ColumnFIO->HeaderText = L"ФИО";
			this->ColumnFIO->Name = L"ColumnFIO";
			this->ColumnFIO->ReadOnly = true;
			this->ColumnFIO->Width = 59;
			// 
			// ColumnDepartment
			// 
			this->ColumnDepartment->HeaderText = L"Отделение";
			this->ColumnDepartment->Name = L"ColumnDepartment";
			this->ColumnDepartment->ReadOnly = true;
			this->ColumnDepartment->Width = 87;
			// 
			// EmployeeForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(911, 412);
			this->Controls->Add(this->buttonDelete);
			this->Controls->Add(this->buttonEdit);
			this->Controls->Add(this->buttonAdd);
			this->Controls->Add(this->buttonExit);
			this->Controls->Add(this->dataGridViewEmployees);
			this->Name = L"EmployeeForm";
			this->Text = L"Перечень врачей";
			this->Load += gcnew System::EventHandler(this, &EmployeeForm::EmployeeForm_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridViewEmployees))->EndInit();
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void EmployeeForm_Load(System::Object^ sender, System::EventArgs^ e)
	{
		updateTable();
	}
		   void updateTable()
		   {
			   this->dataGridViewEmployees->Rows->Clear();

			   vector<Employee> employees = EmployeeDAO::getAllEmployees();
			   for (size_t i = 0; i < employees.size(); i++)
			   {
				   Department department = DepartmentDAO::getDepartmentById(employees.at(i).getDepartmentId());

				   this->dataGridViewEmployees->Rows->Add(1);
				   this->dataGridViewEmployees->Rows[i]->Cells[0]->Value = gcnew String(employees.at(i).getFIO().c_str());
				   this->dataGridViewEmployees->Rows[i]->Cells[1]->Value = gcnew String(department.getName().c_str());
				   this->dataGridViewEmployees->Rows[i]->Selected = false;
			   }
		   }
	private: System::Void buttonExit_Click(System::Object^ sender, System::EventArgs^ e)
	{
		this->Hide();
	}
	private: System::Void buttonDelete_Click(System::Object^ sender, System::EventArgs^ e)
	{
		if (this->dataGridViewEmployees->SelectedRows->Count == 1)
		{
			DataGridViewRow^ row = this->dataGridViewEmployees->SelectedRows[0];

			// перезагрузим таблицу (для обновления данных)
			if (EmployeeDAO::deleteEmployee(EmployeeDAO::getEmployeeByFIO(msclr::interop::marshal_as<string>(row->Cells[0]->Value->ToString())))) {
				updateTable();
			}
		}
	}
	private: System::Void buttonEdit_Click(System::Object^ sender, System::EventArgs^ e)
	{
		// Если выделена одна dataGridViewDepartments
		if (this->dataGridViewEmployees->SelectedRows->Count == 1)
		{
			// Создаем вспомогательную форму
			DataGridViewRow^ row = dataGridViewEmployees->SelectedRows[0];

			Employee employee = EmployeeDAO::getEmployeeByFIO(msclr::interop::marshal_as<string>(row->Cells[0]->Value->ToString()));

			EmployeeEditForm^ editForm = gcnew EmployeeEditForm(employee);
			// Если результат ОК, то перезагрузим таблицу (для обновления данных)
			if (editForm->ShowDialog(this) == System::Windows::Forms::DialogResult::OK) {
				updateTable();
			}
		}
	}
	private: System::Void buttonAdd_Click(System::Object^ sender, System::EventArgs^ e)
	{
		// Создаем вспомогательную форму
		EmployeeEditForm^ editForm = gcnew EmployeeEditForm;

		// Если результат ОК, то перезагрузим таблицу (для обновления данных)
		if (editForm->ShowDialog(this) == System::Windows::Forms::DialogResult::OK) {
			updateTable();
		}
	}
	};
}
