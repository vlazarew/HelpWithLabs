#pragma once
#include <list>
#include "WorldRegion.h"
#include "WorldRegionDAO.h"

using namespace std;

namespace TravelWorld {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// ������ ��� MainForm
	/// </summary>
	public ref class MainForm : public System::Windows::Forms::Form
	{
	public:
		MainForm(void)
		{
			InitializeComponent();
			//
			//TODO: �������� ��� ������������
		}

	protected:
		/// <summary>
		/// ���������� ��� ������������ �������.
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
		/// ������������ ���������� ������������.
		/// </summary>
		System::ComponentModel::Container^ components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// ��������� ����� ��� ��������� ������������ � �� ��������� 
		/// ���������� ����� ������ � ������� ��������� ����.
		/// </summary>
		void InitializeComponent(void)
		{
			this->dataGridViewConsumerCard = (gcnew System::Windows::Forms::DataGridView());
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
			this->dataGridViewConsumerCard->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->dataGridViewConsumerCard->Columns->AddRange(gcnew cli::array< System::Windows::Forms::DataGridViewColumn^  >(8)
			{
				this->ColumnRegion,
					this->ColumnCountry, this->ColumnHotel, this->ColumnRating, this->ColumnFromDate, this->ColumnToDate, this->ColumnPrice, this->ColumnDescription
			});
			this->dataGridViewConsumerCard->Location = System::Drawing::Point(12, 12);
			this->dataGridViewConsumerCard->Name = L"dataGridViewConsumerCard";
			this->dataGridViewConsumerCard->ReadOnly = true;
			this->dataGridViewConsumerCard->Size = System::Drawing::Size(871, 389);
			this->dataGridViewConsumerCard->TabIndex = 7;
			// 
			// ColumnRegion
			// 
			this->ColumnRegion->HeaderText = L"����� �����";
			this->ColumnRegion->Name = L"ColumnRegion";
			this->ColumnRegion->ReadOnly = true;
			// 
			// ColumnCountry
			// 
			this->ColumnCountry->HeaderText = L"������";
			this->ColumnCountry->Name = L"ColumnCountry";
			this->ColumnCountry->ReadOnly = true;
			// 
			// ColumnHotel
			// 
			this->ColumnHotel->HeaderText = L"�����";
			this->ColumnHotel->Name = L"ColumnHotel";
			this->ColumnHotel->ReadOnly = true;
			// 
			// ColumnRating
			// 
			this->ColumnRating->HeaderText = L"�������";
			this->ColumnRating->Name = L"ColumnRating";
			this->ColumnRating->ReadOnly = true;
			// 
			// ColumnFromDate
			// 
			this->ColumnFromDate->HeaderText = L"���� ������";
			this->ColumnFromDate->Name = L"ColumnFromDate";
			this->ColumnFromDate->ReadOnly = true;
			// 
			// ColumnToDate
			// 
			this->ColumnToDate->HeaderText = L"���� ���������";
			this->ColumnToDate->Name = L"ColumnToDate";
			this->ColumnToDate->ReadOnly = true;
			// 
			// ColumnPrice
			// 
			this->ColumnPrice->HeaderText = L"���������";
			this->ColumnPrice->Name = L"ColumnPrice";
			this->ColumnPrice->ReadOnly = true;
			// 
			// ColumnDescription
			// 
			this->ColumnDescription->HeaderText = L"��������";
			this->ColumnDescription->Name = L"ColumnDescription";
			this->ColumnDescription->ReadOnly = true;
			// 
			// MainForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(1188, 413);
			this->Controls->Add(this->dataGridViewConsumerCard);
			this->Name = L"MainForm";
			this->Text = L"����� ����� ����";
			this->Load += gcnew System::EventHandler(this, &MainForm::MainForm_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridViewConsumerCard))->EndInit();
			this->ResumeLayout(false);

		};
	private: System::Void MainForm_Load(System::Object^ sender, System::EventArgs^ e)
	{
		list<WorldRegion> regions = WorldRegionDAO::getAllRegions();
		int i = 1;
	}
	};
#pragma endregion
};