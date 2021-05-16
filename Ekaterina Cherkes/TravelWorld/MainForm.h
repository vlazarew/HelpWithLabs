#pragma once
#include <vector>
#include "WorldRegion.h"
#include "WorldRegionDAO.h"
#include "Schedule.h"
#include "ScheduleDAO.h"
#include "Hotel.h"
#include "HotelDAO.h"
#include "Country.h"
#include "CountryDAO.h"
#include <msclr\marshal_cppstd.h>
#include "EditForm.h"

using namespace std;

namespace TravelWorld {

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
		bool isLogged = false;
	public:
		MainForm(void)
		{
			InitializeComponent();
			changeVisibility();
			//
			//TODO: добавьте код конструктора
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
	private: System::Windows::Forms::DataGridView^ dataGridViewConsumerCard;
	protected:








	private: System::Windows::Forms::Button^ buttonAdd;
	private: System::Windows::Forms::Button^ buttonEdit;
	private: System::Windows::Forms::Button^ buttonDelete;
	private: System::Windows::Forms::Button^ buttonExit;
	private: System::Windows::Forms::Button^ buttonLogin;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnRegion;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnCountry;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnHotel;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnRating;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnFromDate;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnToDate;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnPrice;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ ColumnDescription;

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
			this->dataGridViewConsumerCard = (gcnew System::Windows::Forms::DataGridView());
			this->buttonAdd = (gcnew System::Windows::Forms::Button());
			this->buttonEdit = (gcnew System::Windows::Forms::Button());
			this->buttonDelete = (gcnew System::Windows::Forms::Button());
			this->buttonExit = (gcnew System::Windows::Forms::Button());
			this->buttonLogin = (gcnew System::Windows::Forms::Button());
			this->ColumnRegion = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->ColumnCountry = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->ColumnHotel = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->ColumnRating = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->ColumnFromDate = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->ColumnToDate = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->ColumnPrice = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->ColumnDescription = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridViewConsumerCard))->BeginInit();
			this->SuspendLayout();
			// 
			// dataGridViewConsumerCard
			// 
			this->dataGridViewConsumerCard->AllowUserToAddRows = false;
			this->dataGridViewConsumerCard->AllowUserToDeleteRows = false;
			this->dataGridViewConsumerCard->AllowUserToOrderColumns = true;
			this->dataGridViewConsumerCard->AutoSizeColumnsMode = System::Windows::Forms::DataGridViewAutoSizeColumnsMode::AllCells;
			this->dataGridViewConsumerCard->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->dataGridViewConsumerCard->Columns->AddRange(gcnew cli::array< System::Windows::Forms::DataGridViewColumn^  >(8)
			{
				this->ColumnRegion,
					this->ColumnCountry, this->ColumnHotel, this->ColumnRating, this->ColumnFromDate, this->ColumnToDate, this->ColumnPrice, this->ColumnDescription
			});
			this->dataGridViewConsumerCard->Location = System::Drawing::Point(12, 12);
			this->dataGridViewConsumerCard->Name = L"dataGridViewConsumerCard";
			this->dataGridViewConsumerCard->ReadOnly = true;
			this->dataGridViewConsumerCard->SelectionMode = System::Windows::Forms::DataGridViewSelectionMode::FullRowSelect;
			this->dataGridViewConsumerCard->Size = System::Drawing::Size(702, 389);
			this->dataGridViewConsumerCard->TabIndex = 7;
			// 
			// buttonAdd
			// 
			this->buttonAdd->Enabled = false;
			this->buttonAdd->Location = System::Drawing::Point(720, 12);
			this->buttonAdd->Name = L"buttonAdd";
			this->buttonAdd->Size = System::Drawing::Size(184, 23);
			this->buttonAdd->TabIndex = 8;
			this->buttonAdd->Text = L"Добавить тур";
			this->buttonAdd->UseVisualStyleBackColor = true;
			this->buttonAdd->Click += gcnew System::EventHandler(this, &MainForm::buttonAdd_Click);
			// 
			// buttonEdit
			// 
			this->buttonEdit->Enabled = false;
			this->buttonEdit->Location = System::Drawing::Point(720, 41);
			this->buttonEdit->Name = L"buttonEdit";
			this->buttonEdit->Size = System::Drawing::Size(184, 23);
			this->buttonEdit->TabIndex = 9;
			this->buttonEdit->Text = L"Редактировать тур";
			this->buttonEdit->UseVisualStyleBackColor = true;
			this->buttonEdit->Click += gcnew System::EventHandler(this, &MainForm::buttonEdit_Click);
			// 
			// buttonDelete
			// 
			this->buttonDelete->Enabled = false;
			this->buttonDelete->Location = System::Drawing::Point(720, 70);
			this->buttonDelete->Name = L"buttonDelete";
			this->buttonDelete->Size = System::Drawing::Size(184, 23);
			this->buttonDelete->TabIndex = 10;
			this->buttonDelete->Text = L"Удалить тур";
			this->buttonDelete->UseVisualStyleBackColor = true;
			this->buttonDelete->Click += gcnew System::EventHandler(this, &MainForm::buttonDelete_Click);
			// 
			// buttonExit
			// 
			this->buttonExit->Location = System::Drawing::Point(720, 378);
			this->buttonExit->Name = L"buttonExit";
			this->buttonExit->Size = System::Drawing::Size(184, 23);
			this->buttonExit->TabIndex = 11;
			this->buttonExit->Text = L"Выход";
			this->buttonExit->UseVisualStyleBackColor = true;
			this->buttonExit->Click += gcnew System::EventHandler(this, &MainForm::buttonExit_Click);
			// 
			// buttonLogin
			// 
			this->buttonLogin->Location = System::Drawing::Point(720, 120);
			this->buttonLogin->Name = L"buttonLogin";
			this->buttonLogin->Size = System::Drawing::Size(184, 23);
			this->buttonLogin->TabIndex = 12;
			this->buttonLogin->Text = L"Логин";
			this->buttonLogin->UseVisualStyleBackColor = true;
			this->buttonLogin->Click += gcnew System::EventHandler(this, &MainForm::buttonLogin_Click);
			// 
			// ColumnRegion
			// 
			this->ColumnRegion->HeaderText = L"Часть света";
			this->ColumnRegion->Name = L"ColumnRegion";
			this->ColumnRegion->ReadOnly = true;
			this->ColumnRegion->Width = 95;
			// 
			// ColumnCountry
			// 
			this->ColumnCountry->HeaderText = L"Страна";
			this->ColumnCountry->Name = L"ColumnCountry";
			this->ColumnCountry->ReadOnly = true;
			this->ColumnCountry->Width = 68;
			// 
			// ColumnHotel
			// 
			this->ColumnHotel->HeaderText = L"Отель";
			this->ColumnHotel->Name = L"ColumnHotel";
			this->ColumnHotel->ReadOnly = true;
			this->ColumnHotel->Width = 63;
			// 
			// ColumnRating
			// 
			this->ColumnRating->HeaderText = L"Рейтинг";
			this->ColumnRating->Name = L"ColumnRating";
			this->ColumnRating->ReadOnly = true;
			this->ColumnRating->Width = 73;
			// 
			// ColumnFromDate
			// 
			this->ColumnFromDate->HeaderText = L"Дата начала";
			this->ColumnFromDate->Name = L"ColumnFromDate";
			this->ColumnFromDate->ReadOnly = true;
			this->ColumnFromDate->Width = 96;
			// 
			// ColumnToDate
			// 
			this->ColumnToDate->HeaderText = L"Дата окончания";
			this->ColumnToDate->Name = L"ColumnToDate";
			this->ColumnToDate->ReadOnly = true;
			this->ColumnToDate->Width = 105;
			// 
			// ColumnPrice
			// 
			this->ColumnPrice->HeaderText = L"Стоимость";
			this->ColumnPrice->Name = L"ColumnPrice";
			this->ColumnPrice->ReadOnly = true;
			this->ColumnPrice->Width = 87;
			// 
			// ColumnDescription
			// 
			this->ColumnDescription->HeaderText = L"Описание";
			this->ColumnDescription->Name = L"ColumnDescription";
			this->ColumnDescription->ReadOnly = true;
			this->ColumnDescription->Visible = false;
			this->ColumnDescription->Width = 82;
			// 
			// MainForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(916, 413);
			this->Controls->Add(this->buttonLogin);
			this->Controls->Add(this->buttonExit);
			this->Controls->Add(this->buttonDelete);
			this->Controls->Add(this->buttonEdit);
			this->Controls->Add(this->buttonAdd);
			this->Controls->Add(this->dataGridViewConsumerCard);
			this->Name = L"MainForm";
			this->Text = L"Отели всего мира";
			this->Load += gcnew System::EventHandler(this, &MainForm::MainForm_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridViewConsumerCard))->EndInit();
			this->ResumeLayout(false);

		};
	private:

		std::string timeStampToHReadble(const time_t rawtime)
		{
			struct tm* dt;
			char buffer[30];
			dt = localtime(&rawtime);
			//strftime(buffer, sizeof(buffer), "%d/%m/%Y", dt);
			strftime(buffer, sizeof(buffer), "%Y-%m-%d", dt);
			return std::string(buffer);
		}

		System::Void MainForm_Load(System::Object^ sender, System::EventArgs^ e)
		{
			updateTable();
		}

		void updateTable()
		{
			this->dataGridViewConsumerCard->Rows->Clear();

			vector<Schedule> schedules = ScheduleDAO::getAllSchedules();
			for (size_t i = 0; i < schedules.size(); i++)
			{
				Hotel hotel = HotelDAO::getHotelById(schedules.at(i).getHotelId());
				Country country = CountryDAO::getCountryById(hotel.getCountryId());
				WorldRegion region = WorldRegionDAO::getWorldRegionById(country.getRegionId());

				this->dataGridViewConsumerCard->Rows->Add(1);
				this->dataGridViewConsumerCard->Rows[i]->Cells[0]->Value = gcnew String(region.getName().c_str());
				this->dataGridViewConsumerCard->Rows[i]->Cells[1]->Value = gcnew String(country.getName().c_str());
				this->dataGridViewConsumerCard->Rows[i]->Cells[2]->Value = gcnew String(hotel.getName().c_str());
				this->dataGridViewConsumerCard->Rows[i]->Cells[3]->Value = Convert::ToString(hotel.getRating());
				this->dataGridViewConsumerCard->Rows[i]->Cells[4]->Value = gcnew String(timeStampToHReadble(schedules.at(i).getFromDate()).c_str());
				this->dataGridViewConsumerCard->Rows[i]->Cells[5]->Value = gcnew String(timeStampToHReadble(schedules.at(i).getToDate()).c_str());
				this->dataGridViewConsumerCard->Rows[i]->Cells[6]->Value = Convert::ToString(schedules.at(i).getPrice());
				//this->dataGridViewConsumerCard->Rows[i]->Cells[7]->Value = gcnew String(hotel.getDescription().c_str());
				this->dataGridViewConsumerCard->Rows[i]->Selected = false;
			}
		}

	private: System::Void buttonExit_Click(System::Object^ sender, System::EventArgs^ e)
	{
		Application::Exit();
	}
		   void changeVisibility()
		   {
			   buttonAdd->Enabled = isLogged;
			   buttonEdit->Enabled = isLogged;
			   buttonDelete->Enabled = isLogged;
		   }

	private: System::Void buttonLogin_Click(System::Object^ sender, System::EventArgs^ e)
	{
		LoginForm^ loginForm = gcnew LoginForm;

		if (loginForm->ShowDialog(this) == System::Windows::Forms::DialogResult::OK) {
			isLogged = true;
			changeVisibility();
		}

	}
	private: System::Void buttonDelete_Click(System::Object^ sender, System::EventArgs^ e)
	{
		if (this->dataGridViewConsumerCard->SelectedRows->Count == 1)
		{
			DataGridViewRow^ row = this->dataGridViewConsumerCard->SelectedRows[0];

			// перезагрузим таблицу (для обновления данных)
			if (ScheduleDAO::deleteSchedule(ScheduleDAO::getScheduleByFromToPriceHotelId(msclr::interop::marshal_as<string>(row->Cells[4]->Value->ToString()),
				msclr::interop::marshal_as<string>(row->Cells[5]->Value->ToString()),
				stof(msclr::interop::marshal_as<string>(row->Cells[6]->Value->ToString()))))) {
				updateTable();
			}
		}
	}
	private: System::Void buttonAdd_Click(System::Object^ sender, System::EventArgs^ e)
	{
		// Создаем вспомогательную форму
		EditForm^ editForm = gcnew EditForm;

		// Если результат ОК, то перезагрузим таблицу (для обновления данных)
		if (editForm->ShowDialog(this) == System::Windows::Forms::DialogResult::OK) {
			isLogged = true;
			changeVisibility();
			updateTable();
		}
	}
	private: System::Void buttonEdit_Click(System::Object^ sender, System::EventArgs^ e)
	{
		// Если выделена одна строчка
		if (this->dataGridViewConsumerCard->SelectedRows->Count == 1)
		{
			// Создаем вспомогательную форму
			DataGridViewRow^ row = dataGridViewConsumerCard->SelectedRows[0];

			Schedule schedule = ScheduleDAO::getScheduleByFromToPriceHotelId(msclr::interop::marshal_as<string>(row->Cells[4]->Value->ToString()),
				msclr::interop::marshal_as<string>(row->Cells[5]->Value->ToString()),
				stof(msclr::interop::marshal_as<string>(row->Cells[6]->Value->ToString())));

			EditForm^ editForm = gcnew EditForm(schedule);
			// Если результат ОК, то перезагрузим таблицу (для обновления данных)
			if (editForm->ShowDialog(this) == System::Windows::Forms::DialogResult::OK) {
				isLogged = true;
				changeVisibility();
				updateTable();
			}
		}
	}
	};
#pragma endregion
};