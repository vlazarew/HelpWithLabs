
namespace Buildings
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewCustomer = new System.Windows.Forms.DataGridView();
            this.groupBoxCustomer = new System.Windows.Forms.GroupBox();
            this.ColumnContractId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWorked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTypeOfPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPaymentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonEditCustomer = new System.Windows.Forms.Button();
            this.buttonDeleteCustomer = new System.Windows.Forms.Button();
            this.buttonAddCustomer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonEditObject = new System.Windows.Forms.Button();
            this.buttonDeleteObject = new System.Windows.Forms.Button();
            this.buttonAddObject = new System.Windows.Forms.Button();
            this.dataGridViewObjects = new System.Windows.Forms.DataGridView();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewMaterials = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxBuildingType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnMaterialsAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnTypeOfMeaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewOffice = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnBuildingNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnBuildName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomer)).BeginInit();
            this.groupBoxCustomer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObjects)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOffice)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCustomer
            // 
            this.dataGridViewCustomer.AllowUserToAddRows = false;
            this.dataGridViewCustomer.AllowUserToDeleteRows = false;
            this.dataGridViewCustomer.AllowUserToOrderColumns = true;
            this.dataGridViewCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnContractId,
            this.ColumnName,
            this.ColumnWorked,
            this.ColumnTypeOfPayment,
            this.ColumnPaymentAmount});
            this.dataGridViewCustomer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridViewCustomer.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewCustomer.MultiSelect = false;
            this.dataGridViewCustomer.Name = "dataGridViewCustomer";
            this.dataGridViewCustomer.ReadOnly = true;
            this.dataGridViewCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCustomer.Size = new System.Drawing.Size(770, 287);
            this.dataGridViewCustomer.TabIndex = 7;
            // 
            // groupBoxCustomer
            // 
            this.groupBoxCustomer.Controls.Add(this.buttonEditCustomer);
            this.groupBoxCustomer.Controls.Add(this.buttonDeleteCustomer);
            this.groupBoxCustomer.Controls.Add(this.buttonAddCustomer);
            this.groupBoxCustomer.Controls.Add(this.dataGridViewCustomer);
            this.groupBoxCustomer.Location = new System.Drawing.Point(6, 6);
            this.groupBoxCustomer.Name = "groupBoxCustomer";
            this.groupBoxCustomer.Size = new System.Drawing.Size(1003, 312);
            this.groupBoxCustomer.TabIndex = 8;
            this.groupBoxCustomer.TabStop = false;
            this.groupBoxCustomer.Text = "Клиенты";
            // 
            // ColumnContractId
            // 
            this.ColumnContractId.HeaderText = "Номер контракта";
            this.ColumnContractId.Name = "ColumnContractId";
            this.ColumnContractId.ReadOnly = true;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Наименование";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnWorked
            // 
            this.ColumnWorked.HeaderText = "Отработано часов";
            this.ColumnWorked.Name = "ColumnWorked";
            this.ColumnWorked.ReadOnly = true;
            // 
            // ColumnTypeOfPayment
            // 
            this.ColumnTypeOfPayment.HeaderText = "Тип оплаты";
            this.ColumnTypeOfPayment.Name = "ColumnTypeOfPayment";
            this.ColumnTypeOfPayment.ReadOnly = true;
            // 
            // ColumnPaymentAmount
            // 
            this.ColumnPaymentAmount.HeaderText = "Стоимость";
            this.ColumnPaymentAmount.Name = "ColumnPaymentAmount";
            this.ColumnPaymentAmount.ReadOnly = true;
            // 
            // buttonEditCustomer
            // 
            this.buttonEditCustomer.Location = new System.Drawing.Point(782, 48);
            this.buttonEditCustomer.Name = "buttonEditCustomer";
            this.buttonEditCustomer.Size = new System.Drawing.Size(213, 23);
            this.buttonEditCustomer.TabIndex = 13;
            this.buttonEditCustomer.Text = "Изменить";
            this.buttonEditCustomer.UseVisualStyleBackColor = true;
            this.buttonEditCustomer.Click += new System.EventHandler(this.buttonEditCustomer_Click);
            // 
            // buttonDeleteCustomer
            // 
            this.buttonDeleteCustomer.Location = new System.Drawing.Point(782, 77);
            this.buttonDeleteCustomer.Name = "buttonDeleteCustomer";
            this.buttonDeleteCustomer.Size = new System.Drawing.Size(213, 23);
            this.buttonDeleteCustomer.TabIndex = 12;
            this.buttonDeleteCustomer.Text = "Удалить";
            this.buttonDeleteCustomer.UseVisualStyleBackColor = true;
            this.buttonDeleteCustomer.Click += new System.EventHandler(this.buttonDeleteCustomer_Click);
            // 
            // buttonAddCustomer
            // 
            this.buttonAddCustomer.Location = new System.Drawing.Point(782, 19);
            this.buttonAddCustomer.Name = "buttonAddCustomer";
            this.buttonAddCustomer.Size = new System.Drawing.Size(213, 23);
            this.buttonAddCustomer.TabIndex = 11;
            this.buttonAddCustomer.Text = "Добавить";
            this.buttonAddCustomer.UseVisualStyleBackColor = true;
            this.buttonAddCustomer.Click += new System.EventHandler(this.buttonAddCustomer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonEditObject);
            this.groupBox1.Controls.Add(this.buttonDeleteObject);
            this.groupBox1.Controls.Add(this.buttonAddObject);
            this.groupBox1.Controls.Add(this.dataGridViewObjects);
            this.groupBox1.Location = new System.Drawing.Point(6, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1003, 312);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Объекты";
            // 
            // buttonEditObject
            // 
            this.buttonEditObject.Location = new System.Drawing.Point(782, 48);
            this.buttonEditObject.Name = "buttonEditObject";
            this.buttonEditObject.Size = new System.Drawing.Size(213, 23);
            this.buttonEditObject.TabIndex = 13;
            this.buttonEditObject.Text = "Изменить";
            this.buttonEditObject.UseVisualStyleBackColor = true;
            this.buttonEditObject.Click += new System.EventHandler(this.buttonEditObject_Click);
            // 
            // buttonDeleteObject
            // 
            this.buttonDeleteObject.Location = new System.Drawing.Point(782, 77);
            this.buttonDeleteObject.Name = "buttonDeleteObject";
            this.buttonDeleteObject.Size = new System.Drawing.Size(213, 23);
            this.buttonDeleteObject.TabIndex = 12;
            this.buttonDeleteObject.Text = "Удалить";
            this.buttonDeleteObject.UseVisualStyleBackColor = true;
            this.buttonDeleteObject.Click += new System.EventHandler(this.buttonDeleteObject_Click);
            // 
            // buttonAddObject
            // 
            this.buttonAddObject.Location = new System.Drawing.Point(782, 19);
            this.buttonAddObject.Name = "buttonAddObject";
            this.buttonAddObject.Size = new System.Drawing.Size(213, 23);
            this.buttonAddObject.TabIndex = 11;
            this.buttonAddObject.Text = "Добавить";
            this.buttonAddObject.UseVisualStyleBackColor = true;
            this.buttonAddObject.Click += new System.EventHandler(this.buttonAddObject_Click);
            // 
            // dataGridViewObjects
            // 
            this.dataGridViewObjects.AllowUserToAddRows = false;
            this.dataGridViewObjects.AllowUserToDeleteRows = false;
            this.dataGridViewObjects.AllowUserToOrderColumns = true;
            this.dataGridViewObjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewObjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumnBuildName,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Column1,
            this.Column2});
            this.dataGridViewObjects.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewObjects.MultiSelect = false;
            this.dataGridViewObjects.Name = "dataGridViewObjects";
            this.dataGridViewObjects.ReadOnly = true;
            this.dataGridViewObjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewObjects.Size = new System.Drawing.Size(770, 287);
            this.dataGridViewObjects.TabIndex = 7;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Controls.Add(this.tabPage3);
            this.tabControlMain.Location = new System.Drawing.Point(12, 4);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1140, 665);
            this.tabControlMain.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxCustomer);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1132, 639);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Главное";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewMaterials);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1132, 639);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Материалы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewOffice);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1132, 639);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Офисы";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewMaterials
            // 
            this.dataGridViewMaterials.AllowUserToAddRows = false;
            this.dataGridViewMaterials.AllowUserToDeleteRows = false;
            this.dataGridViewMaterials.AllowUserToOrderColumns = true;
            this.dataGridViewMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaterials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxId,
            this.dataGridViewTextBoxBuildingType,
            this.dataGridViewTextBoxColumnMaterialsAmount,
            this.dataGridViewTextBoxColumnTypeOfMeaterial,
            this.ContractId});
            this.dataGridViewMaterials.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewMaterials.Name = "dataGridViewMaterials";
            this.dataGridViewMaterials.ReadOnly = true;
            this.dataGridViewMaterials.Size = new System.Drawing.Size(998, 626);
            this.dataGridViewMaterials.TabIndex = 8;
            // 
            // dataGridViewTextBoxId
            // 
            this.dataGridViewTextBoxId.HeaderText = "Id";
            this.dataGridViewTextBoxId.Name = "dataGridViewTextBoxId";
            this.dataGridViewTextBoxId.ReadOnly = true;
            // 
            // dataGridViewTextBoxBuildingType
            // 
            this.dataGridViewTextBoxBuildingType.HeaderText = "Тип постройки";
            this.dataGridViewTextBoxBuildingType.Name = "dataGridViewTextBoxBuildingType";
            this.dataGridViewTextBoxBuildingType.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnMaterialsAmount
            // 
            this.dataGridViewTextBoxColumnMaterialsAmount.HeaderText = "Материалов всего";
            this.dataGridViewTextBoxColumnMaterialsAmount.Name = "dataGridViewTextBoxColumnMaterialsAmount";
            this.dataGridViewTextBoxColumnMaterialsAmount.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnTypeOfMeaterial
            // 
            this.dataGridViewTextBoxColumnTypeOfMeaterial.HeaderText = "Тип материалов";
            this.dataGridViewTextBoxColumnTypeOfMeaterial.Name = "dataGridViewTextBoxColumnTypeOfMeaterial";
            this.dataGridViewTextBoxColumnTypeOfMeaterial.ReadOnly = true;
            // 
            // ContractId
            // 
            this.ContractId.HeaderText = "Номер контракта";
            this.ContractId.Name = "ContractId";
            this.ContractId.ReadOnly = true;
            // 
            // dataGridViewOffice
            // 
            this.dataGridViewOffice.AllowUserToAddRows = false;
            this.dataGridViewOffice.AllowUserToDeleteRows = false;
            this.dataGridViewOffice.AllowUserToOrderColumns = true;
            this.dataGridViewOffice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOffice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumnBuildingNames,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumnPayment,
            this.dataGridViewTextBoxColumnName});
            this.dataGridViewOffice.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewOffice.Name = "dataGridViewOffice";
            this.dataGridViewOffice.ReadOnly = true;
            this.dataGridViewOffice.Size = new System.Drawing.Size(998, 626);
            this.dataGridViewOffice.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Id";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnBuildingNames
            // 
            this.dataGridViewTextBoxColumnBuildingNames.HeaderText = "Наименование постройки";
            this.dataGridViewTextBoxColumnBuildingNames.Name = "dataGridViewTextBoxColumnBuildingNames";
            this.dataGridViewTextBoxColumnBuildingNames.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Номер контракта";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnPayment
            // 
            this.dataGridViewTextBoxColumnPayment.HeaderText = "Оплата";
            this.dataGridViewTextBoxColumnPayment.Name = "dataGridViewTextBoxColumnPayment";
            this.dataGridViewTextBoxColumnPayment.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnName
            // 
            this.dataGridViewTextBoxColumnName.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumnName.Name = "dataGridViewTextBoxColumnName";
            this.dataGridViewTextBoxColumnName.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnBuildName
            // 
            this.dataGridViewTextBoxColumnBuildName.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumnBuildName.Name = "dataGridViewTextBoxColumnBuildName";
            this.dataGridViewTextBoxColumnBuildName.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Тип постройки";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Год постройки";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Локация";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Состояние";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Номер контракта";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Команда";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 670);
            this.Controls.Add(this.tabControlMain);
            this.Name = "MainForm";
            this.Text = "Главная форма";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomer)).EndInit();
            this.groupBoxCustomer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObjects)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOffice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContractId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWorked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTypeOfPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPaymentAmount;
        private System.Windows.Forms.GroupBox groupBoxCustomer;
        private System.Windows.Forms.Button buttonEditCustomer;
        private System.Windows.Forms.Button buttonDeleteCustomer;
        private System.Windows.Forms.Button buttonAddCustomer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonEditObject;
        private System.Windows.Forms.Button buttonDeleteObject;
        private System.Windows.Forms.Button buttonAddObject;
        private System.Windows.Forms.DataGridView dataGridViewObjects;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewMaterials;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxBuildingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnMaterialsAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnTypeOfMeaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractId;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridViewOffice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnBuildingNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnBuildName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}

