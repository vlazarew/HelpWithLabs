#pragma once
#include <chrono>

#include <chrono>

using namespace std::chrono;

namespace TravelWorld {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для EditForm
	/// </summary>
	public ref class EditForm : public System::Windows::Forms::Form
	{
	private:
		Schedule* currentSchedule;
	public:
		EditForm(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}
		EditForm(Schedule schedule)
		{
			InitializeComponent();
			this->currentSchedule = &schedule;
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~EditForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::ComboBox^ comboBoxHotel;
	protected:

	protected:
	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::Label^ labelWorldRegion;
	private: System::Windows::Forms::Label^ labelCountry;
	private: System::Windows::Forms::Label^ label4;
	private: System::Windows::Forms::TextBox^ textBoxPrice;

	private: System::Windows::Forms::Label^ label3;
	private: System::Windows::Forms::MonthCalendar^ monthCalendarFrom;
	private: System::Windows::Forms::MonthCalendar^ monthCalendarTo;


	private: System::Windows::Forms::Label^ label5;
	private: System::Windows::Forms::Label^ label6;
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
			this->comboBoxHotel = (gcnew System::Windows::Forms::ComboBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->labelWorldRegion = (gcnew System::Windows::Forms::Label());
			this->labelCountry = (gcnew System::Windows::Forms::Label());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->textBoxPrice = (gcnew System::Windows::Forms::TextBox());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->monthCalendarFrom = (gcnew System::Windows::Forms::MonthCalendar());
			this->monthCalendarTo = (gcnew System::Windows::Forms::MonthCalendar());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->buttonCancel = (gcnew System::Windows::Forms::Button());
			this->buttonOK = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// comboBoxHotel
			// 
			this->comboBoxHotel->Location = System::Drawing::Point(83, 59);
			this->comboBoxHotel->Name = L"comboBoxHotel";
			this->comboBoxHotel->Size = System::Drawing::Size(121, 21);
			this->comboBoxHotel->TabIndex = 0;
			this->comboBoxHotel->SelectedIndexChanged += gcnew System::EventHandler(this, &EditForm::comboBoxHotel_SelectedIndexChanged);
			this->comboBoxHotel->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &EditForm::comboBoxHotel_KeyPress);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(15, 62);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(38, 13);
			this->label1->TabIndex = 1;
			this->label1->Text = L"Отель";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(13, 9);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(76, 13);
			this->label2->TabIndex = 2;
			this->label2->Text = L"Часть света: ";
			// 
			// labelWorldRegion
			// 
			this->labelWorldRegion->AutoSize = true;
			this->labelWorldRegion->Location = System::Drawing::Point(95, 9);
			this->labelWorldRegion->Name = L"labelWorldRegion";
			this->labelWorldRegion->Size = System::Drawing::Size(0, 13);
			this->labelWorldRegion->TabIndex = 3;
			// 
			// labelCountry
			// 
			this->labelCountry->AutoSize = true;
			this->labelCountry->Location = System::Drawing::Point(95, 34);
			this->labelCountry->Name = L"labelCountry";
			this->labelCountry->Size = System::Drawing::Size(0, 13);
			this->labelCountry->TabIndex = 5;
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Location = System::Drawing::Point(15, 34);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(49, 13);
			this->label4->TabIndex = 4;
			this->label4->Text = L"Страна: ";
			// 
			// textBoxPrice
			// 
			this->textBoxPrice->Location = System::Drawing::Point(83, 96);
			this->textBoxPrice->Name = L"textBoxPrice";
			this->textBoxPrice->Size = System::Drawing::Size(100, 20);
			this->textBoxPrice->TabIndex = 6;
			this->textBoxPrice->TextChanged += gcnew System::EventHandler(this, &EditForm::textBoxPrice_TextChanged);
			this->textBoxPrice->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &EditForm::textBoxPrice_KeyPress);
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(15, 99);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(62, 13);
			this->label3->TabIndex = 7;
			this->label3->Text = L"Стоимость";
			// 
			// monthCalendarFrom
			// 
			this->monthCalendarFrom->Location = System::Drawing::Point(19, 168);
			this->monthCalendarFrom->Name = L"monthCalendarFrom";
			this->monthCalendarFrom->TabIndex = 8;
			// 
			// monthCalendarTo
			// 
			this->monthCalendarTo->Location = System::Drawing::Point(217, 168);
			this->monthCalendarTo->Name = L"monthCalendarTo";
			this->monthCalendarTo->TabIndex = 9;
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Location = System::Drawing::Point(15, 143);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(73, 13);
			this->label5->TabIndex = 10;
			this->label5->Text = L"Дата вылета";
			// 
			// label6
			// 
			this->label6->AutoSize = true;
			this->label6->Location = System::Drawing::Point(214, 143);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(83, 13);
			this->label6->TabIndex = 11;
			this->label6->Text = L"Дата возврата";
			// 
			// buttonCancel
			// 
			this->buttonCancel->Location = System::Drawing::Point(210, 342);
			this->buttonCancel->Name = L"buttonCancel";
			this->buttonCancel->Size = System::Drawing::Size(75, 23);
			this->buttonCancel->TabIndex = 13;
			this->buttonCancel->Text = L"Отмена";
			this->buttonCancel->UseVisualStyleBackColor = true;
			this->buttonCancel->Click += gcnew System::EventHandler(this, &EditForm::buttonCancel_Click);
			// 
			// buttonOK
			// 
			this->buttonOK->Enabled = false;
			this->buttonOK->Location = System::Drawing::Point(129, 342);
			this->buttonOK->Name = L"buttonOK";
			this->buttonOK->Size = System::Drawing::Size(75, 23);
			this->buttonOK->TabIndex = 12;
			this->buttonOK->Text = L"OK";
			this->buttonOK->UseVisualStyleBackColor = true;
			this->buttonOK->Click += gcnew System::EventHandler(this, &EditForm::buttonOK_Click);
			// 
			// EditForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(417, 370);
			this->Controls->Add(this->buttonCancel);
			this->Controls->Add(this->buttonOK);
			this->Controls->Add(this->label6);
			this->Controls->Add(this->label5);
			this->Controls->Add(this->monthCalendarTo);
			this->Controls->Add(this->monthCalendarFrom);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->textBoxPrice);
			this->Controls->Add(this->labelCountry);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->labelWorldRegion);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->comboBoxHotel);
			this->Name = L"EditForm";
			this->Text = L"Добавление/редактирование тура";
			this->Load += gcnew System::EventHandler(this, &EditForm::EditForm_Load);
			this->ResumeLayout(false);
			this->PerformLayout();

		}

	private:
		static time_t createTS(const char* timeString)
		{
			int yy, month, dd;
			struct tm time;
			sscanf(timeString, "%d.%d.%d", &dd, &month, &yy);
			time.tm_year = yy - 1900;
			time.tm_mon = month - 1;
			time.tm_mday = dd;
			time.tm_hour = 0;
			time.tm_min = 0;
			time.tm_sec = 0;
			time.tm_isdst = -1;

			return mktime(&time);
		}


#pragma endregion
	private: System::Void buttonCancel_Click(System::Object^ sender, System::EventArgs^ e)
	{
		DialogResult = System::Windows::Forms::DialogResult::Cancel;
		this->Close();
	}
	private: System::Void buttonOK_Click(System::Object^ sender, System::EventArgs^ e)
	{
		int price;

		try {
			price = atoi(msclr::interop::marshal_as<string>(this->textBoxPrice->Text->Trim()).c_str());
		}
		catch (...) {
			MessageBox::Show("Некорректное значение стоимости");
			return;
		}

		time_t from = createTS(msclr::interop::marshal_as<string>(monthCalendarFrom->SelectionStart.Date.ToString()).c_str());
		time_t to = createTS(msclr::interop::marshal_as<string>(monthCalendarTo->SelectionStart.Date.ToString()).c_str());
		if (to <= from) {
			MessageBox::Show("Дата возврата не может быть раньше даты вылета");
			return;
		}

		Hotel hotel = HotelDAO::getHotelByName(msclr::interop::marshal_as<string>(this->comboBoxHotel->Text->ToString()));

		// Если добавление
		if (this->currentSchedule == nullptr) {
			Schedule newSchedule = Schedule::Schedule(from, to, price, hotel.getId());

			if (!ScheduleDAO::saveSchedule(newSchedule)) {
				MessageBox::Show("Ошибка при сохранении тура");
				return;
			}

			DialogResult = System::Windows::Forms::DialogResult::OK;
			this->Close();
		}
		// Если обновляем
		else {
			this->currentSchedule->setPrice(price);
			this->currentSchedule->setFromDate(from);
			this->currentSchedule->setToDate(to);
			this->currentSchedule->setHotelId(hotel.getId());

			if (!ScheduleDAO::updateSchedule(*currentSchedule)) {
				MessageBox::Show("Ошибка при обновлении тура");
				return;
			}

			DialogResult = System::Windows::Forms::DialogResult::OK;
			this->Close();
		}
	}
	private: System::Void EditForm_Load(System::Object^ sender, System::EventArgs^ e)
	{
		vector<Hotel> allHotels = HotelDAO::getAllHotels();
		for (int i = 0; i < allHotels.size(); i++) {
			this->comboBoxHotel->Items->Add(gcnew String(allHotels.at(i).getName().c_str()));
		}

		if (this->currentSchedule != nullptr) {
			Hotel hotel = HotelDAO::getHotelById(currentSchedule->getHotelId());
			if (hotel.getId() != -10) {
				comboBoxHotel->Text = gcnew String(hotel.getName().c_str());
				textBoxPrice->Text = gcnew String(to_string(currentSchedule->getPrice()).c_str());
				updateCountryRegion(hotel);
			}

			//this->monthCalendarFrom->SetDate(DateTime(this->currentSchedule->getFromDate()));
			////this->monthCalendarTo->SetDate(DateTime(this->currentSchedule->getToDate()));
		}
	}
	private: System::Void comboBoxHotel_SelectedIndexChanged(System::Object^ sender, System::EventArgs^ e)
	{
		Hotel hotel = HotelDAO::getHotelByName(msclr::interop::marshal_as<string>(this->comboBoxHotel->Text->ToString()));
		updateCountryRegion(hotel);
	}

		   void updateCountryRegion(Hotel hotel)
		   {
			   Country country = CountryDAO::getCountryById(hotel.getCountryId());
			   labelCountry->Text = gcnew String(country.getName().c_str());
			   WorldRegion region = WorldRegionDAO::getWorldRegionById(country.getRegionId());
			   labelWorldRegion->Text = gcnew String(region.getName().c_str());
		   }

	private: System::Void textBoxPrice_KeyPress(System::Object^ sender, System::Windows::Forms::KeyPressEventArgs^ e)
	{
		char number = e->KeyChar;
		if (e->KeyChar <= 47 || e->KeyChar >= 58)
		{
			e->Handled = true;
		}
	}
	private: System::Void textBoxPrice_TextChanged(System::Object^ sender, System::EventArgs^ e)
	{
		buttonOK->Enabled = comboBoxHotel->Text->Length != 0 && textBoxPrice->Text->Length != 0;
	}
	private: System::Void comboBoxHotel_KeyPress(System::Object^ sender, System::Windows::Forms::KeyPressEventArgs^ e)
	{
		e->Handled = true;
	}
	};
};
