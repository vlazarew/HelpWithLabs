#pragma once
#include <msclr\marshal_cppstd.h>
#include "CredentialsDAO.h"
using namespace std;

namespace TravelWorld {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для LoginForm
	/// </summary>
	public ref class LoginForm : public System::Windows::Forms::Form
	{
	public:
		LoginForm(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~LoginForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^ labelBadLogin;
	protected:
	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::TextBox^ textBoxPassword;
	private: System::Windows::Forms::TextBox^ textBoxLogin;

	private: System::Windows::Forms::Button^ buttonExit;
	private: System::Windows::Forms::Button^ buttonLogin;

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
			this->labelBadLogin = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->textBoxPassword = (gcnew System::Windows::Forms::TextBox());
			this->textBoxLogin = (gcnew System::Windows::Forms::TextBox());
			this->buttonExit = (gcnew System::Windows::Forms::Button());
			this->buttonLogin = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// labelBadLogin
			// 
			this->labelBadLogin->AutoSize = true;
			this->labelBadLogin->Location = System::Drawing::Point(50, 94);
			this->labelBadLogin->Name = L"labelBadLogin";
			this->labelBadLogin->Size = System::Drawing::Size(155, 13);
			this->labelBadLogin->TabIndex = 15;
			this->labelBadLogin->Text = L"Некорректный логин/пароль";
			this->labelBadLogin->Visible = false;
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(46, 55);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(45, 13);
			this->label2->TabIndex = 14;
			this->label2->Text = L"Пароль";
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(46, 11);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(38, 13);
			this->label1->TabIndex = 12;
			this->label1->Text = L"Логин";
			// 
			// textBoxPassword
			// 
			this->textBoxPassword->Location = System::Drawing::Point(49, 71);
			this->textBoxPassword->Name = L"textBoxPassword";
			this->textBoxPassword->Size = System::Drawing::Size(156, 20);
			this->textBoxPassword->TabIndex = 9;
			this->textBoxPassword->TextChanged += gcnew System::EventHandler(this, &LoginForm::textBoxPassword_TextChanged);
			// 
			// textBoxLogin
			// 
			this->textBoxLogin->Location = System::Drawing::Point(49, 27);
			this->textBoxLogin->Name = L"textBoxLogin";
			this->textBoxLogin->Size = System::Drawing::Size(156, 20);
			this->textBoxLogin->TabIndex = 8;
			this->textBoxLogin->TextChanged += gcnew System::EventHandler(this, &LoginForm::textBoxLogin_TextChanged);
			// 
			// buttonExit
			// 
			this->buttonExit->Location = System::Drawing::Point(130, 118);
			this->buttonExit->Name = L"buttonExit";
			this->buttonExit->Size = System::Drawing::Size(75, 23);
			this->buttonExit->TabIndex = 11;
			this->buttonExit->Text = L"Выход";
			this->buttonExit->UseVisualStyleBackColor = true;
			this->buttonExit->Click += gcnew System::EventHandler(this, &LoginForm::buttonExit_Click);
			// 
			// buttonLogin
			// 
			this->buttonLogin->Enabled = false;
			this->buttonLogin->Location = System::Drawing::Point(49, 118);
			this->buttonLogin->Name = L"buttonLogin";
			this->buttonLogin->Size = System::Drawing::Size(75, 23);
			this->buttonLogin->TabIndex = 10;
			this->buttonLogin->Text = L"Войти";
			this->buttonLogin->UseVisualStyleBackColor = true;
			this->buttonLogin->Click += gcnew System::EventHandler(this, &LoginForm::buttonLogin_Click);
			// 
			// LoginForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(261, 152);
			this->Controls->Add(this->labelBadLogin);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->textBoxPassword);
			this->Controls->Add(this->textBoxLogin);
			this->Controls->Add(this->buttonExit);
			this->Controls->Add(this->buttonLogin);
			this->Name = L"LoginForm";
			this->Text = L"Авторизация";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void buttonLogin_Click(System::Object^ sender, System::EventArgs^ e)
	{
		Credentials credentials = CredentialsDAO::getCredentialsByLoginAndPassword(msclr::interop::marshal_as<string>(this->textBoxLogin->Text->ToString()->Trim()),
			msclr::interop::marshal_as<string>(this->textBoxPassword->Text->Trim()));

		labelBadLogin->Visible = credentials.getId() == -10;

		if (credentials.getId() != -10)
		{
			DialogResult = System::Windows::Forms::DialogResult::OK;
			this->Close();
		}
	}
	private: System::Void buttonExit_Click(System::Object^ sender, System::EventArgs^ e)
	{
		DialogResult = System::Windows::Forms::DialogResult::Cancel;
		this->Close();
	}
	private: System::Void textBoxLogin_TextChanged(System::Object^ sender, System::EventArgs^ e)
	{
		buttonLogin->Enabled = textBoxLogin->Text->Length != 0 && textBoxPassword->Text->Length != 0;
	}
	private: System::Void textBoxPassword_TextChanged(System::Object^ sender, System::EventArgs^ e)
	{
		buttonLogin->Enabled = textBoxLogin->Text->Length != 0 && textBoxPassword->Text->Length != 0;
	}
	};
}
