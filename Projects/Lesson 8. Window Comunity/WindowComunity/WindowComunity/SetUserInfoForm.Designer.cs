namespace WindowComunity
{
    partial class SetUserInfoForm
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
            txtPIB = new TextBox();
            label2 = new Label();
            txtPhone = new TextBox();
            label3 = new Label();
            txtAge = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(30, 27);
            label1.Name = "label1";
            label1.Size = new Size(65, 38);
            label1.TabIndex = 0;
            label1.Text = "ПІБ";
            // 
            // txtPIB
            // 
            txtPIB.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtPIB.Location = new Point(183, 24);
            txtPIB.Name = "txtPIB";
            txtPIB.Size = new Size(592, 45);
            txtPIB.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(30, 99);
            label2.Name = "label2";
            label2.Size = new Size(134, 38);
            label2.TabIndex = 0;
            label2.Text = "Телефон";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtPhone.Location = new Point(183, 96);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(592, 45);
            txtPhone.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(30, 171);
            label3.Name = "label3";
            label3.Size = new Size(59, 38);
            label3.TabIndex = 0;
            label3.Text = "Вік";
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtAge.Location = new Point(183, 168);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(592, 45);
            txtAge.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSave.Location = new Point(148, 304);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(193, 80);
            btnSave.TabIndex = 2;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(477, 304);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(193, 80);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // SetUserInfoForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtAge);
            Controls.Add(label3);
            Controls.Add(txtPhone);
            Controls.Add(label2);
            Controls.Add(txtPIB);
            Controls.Add(label1);
            Name = "SetUserInfoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Вказати інфомрацію";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPIB;
        private Label label2;
        private TextBox txtPhone;
        private Label label3;
        private TextBox txtAge;
        private Button btnSave;
        private Button btnCancel;
    }
}