namespace AbonentsApp
{
    partial class AbonentCreateForm
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
            label1 = new Label();
            label2 = new Label();
            txtLastname = new TextBox();
            label3 = new Label();
            txtFirstname = new TextBox();
            label4 = new Label();
            txtSecondname = new TextBox();
            label5 = new Label();
            txtPhone = new TextBox();
            btnCreate = new Button();
            btnCancel = new Button();
            lbInvalidLastname = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(281, 23);
            label1.Name = "label1";
            label1.Size = new Size(280, 38);
            label1.TabIndex = 0;
            label1.Text = "Створити абонента";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(12, 87);
            label2.Name = "label2";
            label2.Size = new Size(122, 32);
            label2.TabIndex = 1;
            label2.Text = "Прізвище";
            // 
            // txtLastname
            // 
            txtLastname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtLastname.Location = new Point(211, 87);
            txtLastname.Name = "txtLastname";
            txtLastname.Size = new Size(441, 39);
            txtLastname.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(12, 157);
            label3.Name = "label3";
            label3.Size = new Size(55, 32);
            label3.TabIndex = 1;
            label3.Text = "Ім'я";
            // 
            // txtFirstname
            // 
            txtFirstname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtFirstname.Location = new Point(211, 157);
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new Size(441, 39);
            txtFirstname.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.Blue;
            label4.Location = new Point(12, 216);
            label4.Name = "label4";
            label4.Size = new Size(138, 32);
            label4.TabIndex = 1;
            label4.Text = "Побатькові";
            // 
            // txtSecondname
            // 
            txtSecondname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtSecondname.Location = new Point(211, 216);
            txtSecondname.Name = "txtSecondname";
            txtSecondname.Size = new Size(441, 39);
            txtSecondname.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.ForeColor = Color.Blue;
            label5.Location = new Point(12, 278);
            label5.Name = "label5";
            label5.Size = new Size(110, 32);
            label5.TabIndex = 1;
            label5.Text = "Телефон";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtPhone.Location = new Point(211, 278);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(441, 39);
            txtPhone.TabIndex = 2;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(155, 351);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(170, 59);
            btnCreate.TabIndex = 3;
            btnCreate.Text = "Створити";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(420, 351);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(170, 59);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lbInvalidLastname
            // 
            lbInvalidLastname.AutoSize = true;
            lbInvalidLastname.ForeColor = Color.Red;
            lbInvalidLastname.Location = new Point(211, 129);
            lbInvalidLastname.Name = "lbInvalidLastname";
            lbInvalidLastname.Size = new Size(155, 25);
            lbInvalidLastname.TabIndex = 4;
            lbInvalidLastname.Text = "Вкажіть прізвище";
            lbInvalidLastname.Visible = false;
            // 
            // AbonentCreateForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 472);
            Controls.Add(lbInvalidLastname);
            Controls.Add(btnCancel);
            Controls.Add(btnCreate);
            Controls.Add(txtPhone);
            Controls.Add(label5);
            Controls.Add(txtSecondname);
            Controls.Add(label4);
            Controls.Add(txtFirstname);
            Controls.Add(label3);
            Controls.Add(txtLastname);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AbonentCreateForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cтворити абонента";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtLastname;
        private Label label3;
        private TextBox txtFirstname;
        private Label label4;
        private TextBox txtSecondname;
        private Label label5;
        private TextBox txtPhone;
        private Button btnCreate;
        private Button btnCancel;
        private Label lbInvalidLastname;
    }
}