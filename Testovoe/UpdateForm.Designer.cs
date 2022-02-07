namespace Testovoe
{
    partial class UpdateForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbEmployeeType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRate = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.UptadeBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbEmployeeType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbRate);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 339);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tbEmployeeType
            // 
            this.tbEmployeeType.FormattingEnabled = true;
            this.tbEmployeeType.Items.AddRange(new object[] {
            "HourlyPayEmployee",
            "FixedPayEmployee"});
            this.tbEmployeeType.Location = new System.Drawing.Point(259, 181);
            this.tbEmployeeType.Name = "tbEmployeeType";
            this.tbEmployeeType.Size = new System.Drawing.Size(150, 23);
            this.tbEmployeeType.TabIndex = 11;
            this.tbEmployeeType.SelectedIndexChanged += new System.EventHandler(this.tbEmployeeType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(0, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(253, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = " Почасовой или Фиксированый";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(20, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Зарплата";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(21, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Имя";
            // 
            // tbRate
            // 
            this.tbRate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbRate.Location = new System.Drawing.Point(111, 127);
            this.tbRate.Name = "tbRate";
            this.tbRate.Size = new System.Drawing.Size(298, 29);
            this.tbRate.TabIndex = 3;
            this.tbRate.TextChanged += new System.EventHandler(this.tbRate_TextChanged);
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbName.Location = new System.Drawing.Point(111, 73);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(298, 29);
            this.tbName.TabIndex = 1;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Добавление записи";
            // 
            // CloseBtn
            // 
            this.CloseBtn.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CloseBtn.Location = new System.Drawing.Point(306, 357);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(115, 39);
            this.CloseBtn.TabIndex = 10;
            this.CloseBtn.Text = "Закрыть";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // UptadeBtn
            // 
            this.UptadeBtn.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UptadeBtn.Location = new System.Drawing.Point(33, 357);
            this.UptadeBtn.Name = "UptadeBtn";
            this.UptadeBtn.Size = new System.Drawing.Size(115, 39);
            this.UptadeBtn.TabIndex = 9;
            this.UptadeBtn.Text = "Обновить";
            this.UptadeBtn.UseVisualStyleBackColor = true;
            this.UptadeBtn.Click += new System.EventHandler(this.UptadeBtn_Click);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 450);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.UptadeBtn);
            this.Controls.Add(this.groupBox1);
            this.Name = "UpdateForm";
            this.Text = "UpdateForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox tbEmployeeType;
        private Label label5;
        private Label label4;
        private Label label2;
        private TextBox tbRate;
        private TextBox tbName;
        private Label label1;
        private Button CloseBtn;
        private Button UptadeBtn;
    }
}