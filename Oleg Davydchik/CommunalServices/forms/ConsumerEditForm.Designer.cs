
namespace CommunalServices.forms
{
    partial class ConsumerEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxTypeOfUser = new System.Windows.Forms.GroupBox();
            this.radioButtonAdmin = new System.Windows.Forms.RadioButton();
            this.radioButtonConsumer = new System.Windows.Forms.RadioButton();
            this.groupBoxTypeOfUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(93, 87);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(12, 87);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 18;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Фамилия";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Имя";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(12, 61);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(156, 20);
            this.textBoxSurname.TabIndex = 15;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 25);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(156, 20);
            this.textBoxName.TabIndex = 14;
            // 
            // groupBoxTypeOfUser
            // 
            this.groupBoxTypeOfUser.Controls.Add(this.radioButtonAdmin);
            this.groupBoxTypeOfUser.Controls.Add(this.radioButtonConsumer);
            this.groupBoxTypeOfUser.Location = new System.Drawing.Point(174, 22);
            this.groupBoxTypeOfUser.Name = "groupBoxTypeOfUser";
            this.groupBoxTypeOfUser.Size = new System.Drawing.Size(177, 39);
            this.groupBoxTypeOfUser.TabIndex = 26;
            this.groupBoxTypeOfUser.TabStop = false;
            this.groupBoxTypeOfUser.Text = "Тип пользователя";
            // 
            // radioButtonAdmin
            // 
            this.radioButtonAdmin.AutoSize = true;
            this.radioButtonAdmin.Location = new System.Drawing.Point(73, 19);
            this.radioButtonAdmin.Name = "radioButtonAdmin";
            this.radioButtonAdmin.Size = new System.Drawing.Size(104, 17);
            this.radioButtonAdmin.TabIndex = 1;
            this.radioButtonAdmin.TabStop = true;
            this.radioButtonAdmin.Text = "Администратор";
            this.radioButtonAdmin.UseVisualStyleBackColor = true;
            // 
            // radioButtonConsumer
            // 
            this.radioButtonConsumer.AutoSize = true;
            this.radioButtonConsumer.Location = new System.Drawing.Point(6, 19);
            this.radioButtonConsumer.Name = "radioButtonConsumer";
            this.radioButtonConsumer.Size = new System.Drawing.Size(61, 17);
            this.radioButtonConsumer.TabIndex = 0;
            this.radioButtonConsumer.TabStop = true;
            this.radioButtonConsumer.Text = "Клиент";
            this.radioButtonConsumer.UseVisualStyleBackColor = true;
            // 
            // ConsumerEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 121);
            this.Controls.Add(this.groupBoxTypeOfUser);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.textBoxName);
            this.Name = "ConsumerEditForm";
            this.Text = "ConsumerEditform";
            this.groupBoxTypeOfUser.ResumeLayout(false);
            this.groupBoxTypeOfUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.GroupBox groupBoxTypeOfUser;
        private System.Windows.Forms.RadioButton radioButtonAdmin;
        private System.Windows.Forms.RadioButton radioButtonConsumer;
    }
}