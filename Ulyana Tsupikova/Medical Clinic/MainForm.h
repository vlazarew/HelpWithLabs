#pragma once
#include "RegistrationDAO.h"
#include "EmployeeDAO.h"
#include "DepartmentDAO.h"
#include "ServiceDAO.h"
#include "TypeOfServiceDAO.h"
#include "DepartmentForm.h"

namespace MedicalClinic {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для MainForm
	/// </summary>
	public ref class MainForm : public System::Windows::Forms::Form
	{
	private:
		Credentials* currentCredentials;
	public:
		MainForm(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}
		MainForm(Credentials credentials)
		{
			InitializeComponent();
			this->currentCredentials = &credentials;
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~MainForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^ buttonExit;
	protected:
	private: System::Windows::Forms::Button^ buttonDelete;
	private: System::Windows::Forms::Button^ buttonEdit;
	private: System::Windows::Forms::Button^ buttonAdd;
	private: System::Windows::Forms::DataGridView^ dataGridViewClientCard;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnEmployee;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnDateTime;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnDepartment;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnService;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnTypeOfService;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnDescription;
	private: System::Windows::Forms::Button^ buttonWatchDepartments;
	private: System::Windows::Forms::Button^ buttonMakeRegistration;






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
			this->buttonExit = (gcnew System::Windows::Forms::Button());
			this->buttonDelete = (gcnew System::Windows::Forms::Button());
			this->buttonEdit = (gcnew System::Windows::Forms::Button());
			this->buttonAdd = (gcnew System::Windows::Forms::Button());
			this->dataGridViewClientCard = (gcnew System::Windows::Forms::DataGridView());
			this->ColumnEmployee = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->ColumnDateTime = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->ColumnDepartment = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->ColumnService = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->ColumnTypeOfService = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->ColumnDescription = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->buttonWatchDepartments = (gcnew System::Windows::Forms::Button());
			this->buttonMakeRegistration = (gcnew System::Windows::Forms::Button());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridViewClientCard))->BeginInit();
			this->SuspendLayout();
			// 
			// buttonExit
			// 
			this->buttonExit->Location = System::Drawing::Point(720, 378);
			this->buttonExit->Name = L"buttonExit";
			this->buttonExit->Size = System::Drawing::Size(184, 23);
			this->buttonExit->TabIndex = 17;
			this->buttonExit->Text = L"Выход";
			this->buttonExit->UseVisualStyleBackColor = true;
			this->buttonExit->Click += gcnew System::EventHandler(this, &MainForm::buttonExit_Click);
			// 
			// buttonDelete
			// 
			this->buttonDelete->Enabled = false;
			this->buttonDelete->Location = System::Drawing::Point(720, 321);
			this->buttonDelete->Name = L"buttonDelete";
			this->buttonDelete->Size = System::Drawing::Size(184, 23);
			this->buttonDelete->TabIndex = 16;
			this->buttonDelete->Text = L"Удалить тур";
			this->buttonDelete->UseVisualStyleBackColor = true;
			// 
			// buttonEdit
			// 
			this->buttonEdit->Enabled = false;
			this->buttonEdit->Location = System::Drawing::Point(720, 292);
			this->buttonEdit->Name = L"buttonEdit";
			this->buttonEdit->Size = System::Drawing::Size(184, 23);
			this->buttonEdit->TabIndex = 15;
			this->buttonEdit->Text = L"Редактировать тур";
			this->buttonEdit->UseVisualStyleBackColor = true;
			// 
			// buttonAdd
			// 
			this->buttonAdd->Enabled = false;
			this->buttonAdd->Location = System::Drawing::Point(720, 263);
			this->buttonAdd->Name = L"buttonAdd";
			this->buttonAdd->Size = System::Drawing::Size(184, 23);
			this->buttonAdd->TabIndex = 14;
			this->buttonAdd->Text = L"Добавить тур";
			this->buttonAdd->UseVisualStyleBackColor = true;
			// 
			// dataGridViewClientCard
			// 
			this->dataGridViewClientCard->AllowUserToAddRows = false;
			this->dataGridViewClientCard->AllowUserToDeleteRows = false;
			this->dataGridViewClientCard->AllowUserToOrderColumns = true;
			this->dataGridViewClientCard->AutoSizeColumnsMode = System::Windows::Forms::DataGridViewAutoSizeColumnsMode::AllCells;
			this->dataGridViewClientCard->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->dataGridViewClientCard->Columns->AddRange(gcnew cli::array< System::Windows::Forms::DataGridViewColumn^  >(6)
			{
				this->ColumnEmployee,
					this->ColumnDateTime, this->ColumnDepartment, this->ColumnService, this->ColumnTypeOfService, this->ColumnDescription
			});
			this->dataGridViewClientCard->Location = System::Drawing::Point(12, 12);
			this->dataGridViewClientCard->Name = L"dataGridViewClientCard";
			this->dataGridViewClientCard->ReadOnly = true;
			this->dataGridViewClientCard->SelectionMode = System::Windows::Forms::DataGridViewSelectionMode::FullRowSelect;
			this->dataGridViewClientCard->Size = System::Drawing::Size(702, 389);
			this->dataGridViewClientCard->TabIndex = 13;
			// 
			// ColumnEmployee
			// 
			this->ColumnEmployee->HeaderText = L"Врач";
			this->ColumnEmployee->Name = L"ColumnEmployee";
			this->ColumnEmployee->ReadOnly = true;
			this->ColumnEmployee->Width = 56;
			// 
			// ColumnDateTime
			// 
			this->ColumnDateTime->HeaderText = L"Дата и время приема";
			this->ColumnDateTime->Name = L"ColumnDateTime";
			this->ColumnDateTime->ReadOnly = true;
			this->ColumnDateTime->Width = 131;
			// 
			// ColumnDepartment
			// 
			this->ColumnDepartment->HeaderText = L"Отделение";
			this->ColumnDepartment->Name = L"ColumnDepartment";
			this->ColumnDepartment->ReadOnly = true;
			this->ColumnDepartment->Width = 87;
			// 
			// ColumnService
			// 
			this->ColumnService->HeaderText = L"Услуга";
			this->ColumnService->Name = L"ColumnService";
			this->ColumnService->ReadOnly = true;
			this->ColumnService->Width = 68;
			// 
			// ColumnTypeOfService
			// 
			this->ColumnTypeOfService->HeaderText = L"Тип услуги";
			this->ColumnTypeOfService->Name = L"ColumnTypeOfService";
			this->ColumnTypeOfService->ReadOnly = true;
			this->ColumnTypeOfService->Width = 80;
			// 
			// ColumnDescription
			// 
			this->ColumnDescription->HeaderText = L"Описание отделения";
			this->ColumnDescription->Name = L"ColumnDescription";
			this->ColumnDescription->ReadOnly = true;
			this->ColumnDescription->Width = 126;
			// 
			// buttonWatchDepartments
			// 
			this->buttonWatchDepartments->Location = System::Drawing::Point(721, 12);
			this->buttonWatchDepartments->Name = L"buttonWatchDepartments";
			this->buttonWatchDepartments->Size = System::Drawing::Size(184, 23);
			this->buttonWatchDepartments->TabIndex = 18;
			this->buttonWatchDepartments->Text = L"Просмотреть все отделы";
			this->buttonWatchDepartments->UseVisualStyleBackColor = true;
			this->buttonWatchDepartments->Click += gcnew System::EventHandler(this, &MainForm::buttonWatchDepartments_Click);
			// 
			// buttonMakeRegistration
			// 
			this->buttonMakeRegistration->Location = System::Drawing::Point(720, 41);
			this->buttonMakeRegistration->Name = L"buttonMakeRegistration";
			this->buttonMakeRegistration->Size = System::Drawing::Size(184, 23);
			this->buttonMakeRegistration->TabIndex = 19;
			this->buttonMakeRegistration->Text = L"Записаться на прием";
			this->buttonMakeRegistration->UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(917, 406);
			this->Controls->Add(this->buttonMakeRegistration);
			this->Controls->Add(this->buttonWatchDepartments);
			this->Controls->Add(this->buttonExit);
			this->Controls->Add(this->buttonDelete);
			this->Controls->Add(this->buttonEdit);
			this->Controls->Add(this->buttonAdd);
			this->Controls->Add(this->dataGridViewClientCard);
			this->Name = L"MainForm";
			this->Text = L"Информационная система частной медицинской клиники";
			this->FormClosed += gcnew System::Windows::Forms::FormClosedEventHandler(this, &MainForm::MainForm_FormClosed);
			this->Load += gcnew System::EventHandler(this, &MainForm::MainForm_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridViewClientCard))->EndInit();
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void MainForm_Load(System::Object^ sender, System::EventArgs^ e)
	{
		updateTable();
	}
		   static string timeStampToHReadble(const time_t rawtime)
		   {
			   struct tm* dt;
			   char buffer[30];
			   dt = localtime(&rawtime);
			   strftime(buffer, sizeof(buffer), "%Y-%m-%d %H:%M:%S", dt);
			   return std::string(buffer);
		   }

		   void updateTable()
		   {
			   this->dataGridViewClientCard->Rows->Clear();

			   vector<Registration> registrations = RegistrationDAO::getRegistrationsByCredentialsId(this->currentCredentials->getId());
			   for (size_t i = 0; i < registrations.size(); i++)
			   {
				   Employee employee = EmployeeDAO::getEmployeeById(registrations.at(i).getEmployeeId());
				   Department department = DepartmentDAO::getDepartmentById(employee.getDepartmentId());
				   Service service = ServiceDAO::getServiceById(registrations.at(i).getServiceId());
				   TypeOfService typeOfService = TypeOfServiceDAO::getTypeOfServiceById(service.getTypeOfServiceId());

				   this->dataGridViewClientCard->Rows->Add(1);
				   this->dataGridViewClientCard->Rows[i]->Cells[0]->Value = gcnew String(employee.getFIO().c_str());
				   this->dataGridViewClientCard->Rows[i]->Cells[1]->Value = gcnew String(timeStampToHReadble(registrations.at(i).getDate()).c_str());
				   this->dataGridViewClientCard->Rows[i]->Cells[2]->Value = gcnew String(department.getName().c_str());
				   this->dataGridViewClientCard->Rows[i]->Cells[3]->Value = gcnew String(service.getName().c_str());
				   this->dataGridViewClientCard->Rows[i]->Cells[4]->Value = gcnew String(typeOfService.getName().c_str());
				   this->dataGridViewClientCard->Rows[i]->Cells[5]->Value = gcnew String(department.getDescription().c_str());
				   this->dataGridViewClientCard->Rows[i]->Selected = false;
			   }
		   }
	private: System::Void buttonExit_Click(System::Object^ sender, System::EventArgs^ e)
	{
		Application::Exit();
	}
	private: System::Void MainForm_FormClosed(System::Object^ sender, System::Windows::Forms::FormClosedEventArgs^ e)
	{
		Application::Exit();
	}
	private: System::Void buttonWatchDepartments_Click(System::Object^ sender, System::EventArgs^ e)
	{
		DepartmentForm^ departmentForm = gcnew DepartmentForm();
		departmentForm->Show();
	}
		   void changeVisibility()
		   {
			   buttonAdd->Visible = this->currentCredentials->getIsAdmin();
			   buttonEdit->Visible = this->currentCredentials->getIsAdmin();
			   buttonDelete->Visible = this->currentCredentials->getIsAdmin();
		   }
	};
}
