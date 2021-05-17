#pragma once
#include <vector>
#include "DepartmentEditForm.h"

using namespace std;

namespace MedicalClinic {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для DepartmentForm
	/// </summary>
	public ref class DepartmentForm : public System::Windows::Forms::Form
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
		DepartmentForm(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}
		DepartmentForm(bool isAdmim)
		{
			InitializeComponent();
			this->isAdmin = isAdmim;
			changeVisibility();
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~DepartmentForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::DataGridView^ dataGridViewDepartments;
	protected:

	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnEmployee;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnCountOfEmployees;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnDescription;
	private: System::Windows::Forms::Button^ buttonExit;
	private: System::Windows::Forms::Button^ buttonDelete;
	private: System::Windows::Forms::Button^ buttonEdit;
	private: System::Windows::Forms::Button^ buttonAdd;
	protected:







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
			this->dataGridViewDepartments = (gcnew System::Windows::Forms::DataGridView());
			this->ColumnEmployee = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->ColumnCountOfEmployees = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->ColumnDescription = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->buttonExit = (gcnew System::Windows::Forms::Button());
			this->buttonDelete = (gcnew System::Windows::Forms::Button());
			this->buttonEdit = (gcnew System::Windows::Forms::Button());
			this->buttonAdd = (gcnew System::Windows::Forms::Button());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridViewDepartments))->BeginInit();
			this->SuspendLayout();
			// 
			// dataGridViewDepartments
			// 
			this->dataGridViewDepartments->AllowUserToAddRows = false;
			this->dataGridViewDepartments->AllowUserToDeleteRows = false;
			this->dataGridViewDepartments->AllowUserToOrderColumns = true;
			this->dataGridViewDepartments->AutoSizeColumnsMode = System::Windows::Forms::DataGridViewAutoSizeColumnsMode::AllCells;
			this->dataGridViewDepartments->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->dataGridViewDepartments->Columns->AddRange(gcnew cli::array< System::Windows::Forms::DataGridViewColumn^  >(3)
			{
				this->ColumnEmployee,
					this->ColumnCountOfEmployees, this->ColumnDescription
			});
			this->dataGridViewDepartments->Location = System::Drawing::Point(12, 12);
			this->dataGridViewDepartments->Name = L"dataGridViewDepartments";
			this->dataGridViewDepartments->ReadOnly = true;
			this->dataGridViewDepartments->SelectionMode = System::Windows::Forms::DataGridViewSelectionMode::FullRowSelect;
			this->dataGridViewDepartments->Size = System::Drawing::Size(702, 389);
			this->dataGridViewDepartments->TabIndex = 14;
			// 
			// ColumnEmployee
			// 
			this->ColumnEmployee->HeaderText = L"Название отдела";
			this->ColumnEmployee->Name = L"ColumnEmployee";
			this->ColumnEmployee->ReadOnly = true;
			this->ColumnEmployee->Width = 110;
			// 
			// ColumnCountOfEmployees
			// 
			this->ColumnCountOfEmployees->HeaderText = L"Количество персонала";
			this->ColumnCountOfEmployees->Name = L"ColumnCountOfEmployees";
			this->ColumnCountOfEmployees->ReadOnly = true;
			this->ColumnCountOfEmployees->Width = 135;
			// 
			// ColumnDescription
			// 
			this->ColumnDescription->HeaderText = L"Описание отделения";
			this->ColumnDescription->Name = L"ColumnDescription";
			this->ColumnDescription->ReadOnly = true;
			this->ColumnDescription->Width = 126;
			// 
			// buttonExit
			// 
			this->buttonExit->Location = System::Drawing::Point(720, 378);
			this->buttonExit->Name = L"buttonExit";
			this->buttonExit->Size = System::Drawing::Size(184, 23);
			this->buttonExit->TabIndex = 18;
			this->buttonExit->Text = L"Выход";
			this->buttonExit->UseVisualStyleBackColor = true;
			this->buttonExit->Click += gcnew System::EventHandler(this, &DepartmentForm::buttonExit_Click);
			// 
			// buttonDelete
			// 
			this->buttonDelete->Location = System::Drawing::Point(720, 70);
			this->buttonDelete->Name = L"buttonDelete";
			this->buttonDelete->Size = System::Drawing::Size(184, 23);
			this->buttonDelete->TabIndex = 21;
			this->buttonDelete->Text = L"Удалить отдел";
			this->buttonDelete->UseVisualStyleBackColor = true;
			this->buttonDelete->Click += gcnew System::EventHandler(this, &DepartmentForm::buttonDelete_Click);
			// 
			// buttonEdit
			// 
			this->buttonEdit->Location = System::Drawing::Point(720, 41);
			this->buttonEdit->Name = L"buttonEdit";
			this->buttonEdit->Size = System::Drawing::Size(184, 23);
			this->buttonEdit->TabIndex = 20;
			this->buttonEdit->Text = L"Редактировать отдел";
			this->buttonEdit->UseVisualStyleBackColor = true;
			this->buttonEdit->Click += gcnew System::EventHandler(this, &DepartmentForm::buttonEdit_Click);
			// 
			// buttonAdd
			// 
			this->buttonAdd->Location = System::Drawing::Point(720, 12);
			this->buttonAdd->Name = L"buttonAdd";
			this->buttonAdd->Size = System::Drawing::Size(184, 23);
			this->buttonAdd->TabIndex = 19;
			this->buttonAdd->Text = L"Добавить отдел";
			this->buttonAdd->UseVisualStyleBackColor = true;
			this->buttonAdd->Click += gcnew System::EventHandler(this, &DepartmentForm::buttonAdd_Click);
			// 
			// DepartmentForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(912, 410);
			this->Controls->Add(this->buttonDelete);
			this->Controls->Add(this->buttonEdit);
			this->Controls->Add(this->buttonAdd);
			this->Controls->Add(this->buttonExit);
			this->Controls->Add(this->dataGridViewDepartments);
			this->Name = L"DepartmentForm";
			this->Text = L"Перечень отделов";
			this->Load += gcnew System::EventHandler(this, &DepartmentForm::DepartmentForm_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridViewDepartments))->EndInit();
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void DepartmentForm_Load(System::Object^ sender, System::EventArgs^ e)
	{
		updateTable();
	}
		   void updateTable()
		   {
			   this->dataGridViewDepartments->Rows->Clear();

			   vector<Department> departments = DepartmentDAO::getAllDepartments();
			   for (size_t i = 0; i < departments.size(); i++)
			   {
				   vector<Employee> employees = EmployeeDAO::getEmployeesByDepartmentId(departments.at(i).getId());

				   this->dataGridViewDepartments->Rows->Add(1);
				   this->dataGridViewDepartments->Rows[i]->Cells[0]->Value = gcnew String(departments.at(i).getName().c_str());
				   this->dataGridViewDepartments->Rows[i]->Cells[1]->Value = gcnew String(to_string(employees.size()).c_str());
				   this->dataGridViewDepartments->Rows[i]->Cells[2]->Value = gcnew String(departments.at(i).getDescription().c_str());
				   this->dataGridViewDepartments->Rows[i]->Selected = false;
			   }
		   }
	private: System::Void buttonExit_Click(System::Object^ sender, System::EventArgs^ e)
	{
		this->Hide();
	}
	private: System::Void buttonDelete_Click(System::Object^ sender, System::EventArgs^ e)
	{
		if (this->dataGridViewDepartments->SelectedRows->Count == 1)
		{
			DataGridViewRow^ row = this->dataGridViewDepartments->SelectedRows[0];

			// перезагрузим таблицу (для обновления данных)
			if (DepartmentDAO::deleteDepartment(DepartmentDAO::getDepartmentByName(msclr::interop::marshal_as<string>(row->Cells[0]->Value->ToString())))) {
				updateTable();
			}
		}
	}
	private: System::Void buttonAdd_Click(System::Object^ sender, System::EventArgs^ e)
	{
		// Создаем вспомогательную форму
		DepartmentEditForm^ editForm = gcnew DepartmentEditForm;

		// Если результат ОК, то перезагрузим таблицу (для обновления данных)
		if (editForm->ShowDialog(this) == System::Windows::Forms::DialogResult::OK) {
			updateTable();
		}
	}
	private: System::Void buttonEdit_Click(System::Object^ sender, System::EventArgs^ e)
	{
		// Если выделена одна dataGridViewDepartments
		if (this->dataGridViewDepartments->SelectedRows->Count == 1)
		{
			// Создаем вспомогательную форму
			DataGridViewRow^ row = dataGridViewDepartments->SelectedRows[0];

			Department department = DepartmentDAO::getDepartmentByName(msclr::interop::marshal_as<string>(row->Cells[0]->Value->ToString()));

			DepartmentEditForm^ editForm = gcnew DepartmentEditForm(department);
			// Если результат ОК, то перезагрузим таблицу (для обновления данных)
			if (editForm->ShowDialog(this) == System::Windows::Forms::DialogResult::OK) {
				updateTable();
			}
		}
	}
	};
}
