namespace WinGridView
{
    partial class EditForm
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
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(31, 24);
            label1.Name = "label1";
            label1.Size = new Size(51, 32);
            label1.TabIndex = 0;
            label1.Text = "ПІБ";
            // 
            // txtPIB
            // 
            txtPIB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtPIB.Location = new Point(31, 59);
            txtPIB.Name = "txtPIB";
            txtPIB.Size = new Size(734, 39);
            txtPIB.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(31, 114);
            label2.Name = "label2";
            label2.Size = new Size(110, 32);
            label2.TabIndex = 0;
            label2.Text = "Телефон";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtPhone.Location = new Point(31, 149);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(734, 39);
            txtPhone.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(31, 214);
            label3.Name = "label3";
            label3.Size = new Size(46, 32);
            label3.TabIndex = 0;
            label3.Text = "Вік";
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtAge.Location = new Point(31, 249);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(734, 39);
            txtAge.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSave.Location = new Point(186, 317);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(172, 66);
            btnSave.TabIndex = 2;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(426, 317);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(172, 66);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 416);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtAge);
            Controls.Add(label3);
            Controls.Add(txtPhone);
            Controls.Add(label2);
            Controls.Add(txtPIB);
            Controls.Add(label1);
            Name = "EditForm";
            Text = "EditForm";
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