namespace third_product_lab3
{
    partial class AddCarForm
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
            this.brandTextBox = new System.Windows.Forms.TextBox();
            this.modelTextBox = new System.Windows.Forms.TextBox();
            this.powerTextBox = new System.Windows.Forms.TextBox();
            this.maxSpeedTextBox = new System.Windows.Forms.TextBox();
            this.carTypeComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // brandTextBox
            // 
            this.brandTextBox.Location = new System.Drawing.Point(96, 184);
            this.brandTextBox.Name = "brandTextBox";
            this.brandTextBox.Size = new System.Drawing.Size(100, 22);
            this.brandTextBox.TabIndex = 0;
            // 
            // modelTextBox
            // 
            this.modelTextBox.Location = new System.Drawing.Point(232, 184);
            this.modelTextBox.Name = "modelTextBox";
            this.modelTextBox.Size = new System.Drawing.Size(100, 22);
            this.modelTextBox.TabIndex = 1;
            // 
            // powerTextBox
            // 
            this.powerTextBox.Location = new System.Drawing.Point(379, 184);
            this.powerTextBox.Name = "powerTextBox";
            this.powerTextBox.Size = new System.Drawing.Size(100, 22);
            this.powerTextBox.TabIndex = 2;
            this.powerTextBox.TextChanged += new System.EventHandler(this.powerTextBox_TextChanged);
            // 
            // maxSpeedTextBox
            // 
            this.maxSpeedTextBox.Location = new System.Drawing.Point(533, 184);
            this.maxSpeedTextBox.Name = "maxSpeedTextBox";
            this.maxSpeedTextBox.Size = new System.Drawing.Size(100, 22);
            this.maxSpeedTextBox.TabIndex = 3;
            // 
            // carTypeComboBox
            // 
            this.carTypeComboBox.FormattingEnabled = true;
            this.carTypeComboBox.Items.AddRange(new object[] {
            "PassengerCar",
            "Truck"});
            this.carTypeComboBox.Location = new System.Drawing.Point(312, 271);
            this.carTypeComboBox.Name = "carTypeComboBox";
            this.carTypeComboBox.Size = new System.Drawing.Size(189, 24);
            this.carTypeComboBox.TabIndex = 4;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(256, 363);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(107, 54);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "Принять";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(454, 363);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(106, 54);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TT Firs Neue", 7.799999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(118, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Бренд:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TT Firs Neue", 7.799999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(253, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Модель:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TT Firs Neue", 7.799999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(376, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Мощность (л.с.):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("TT Firs Neue", 7.799999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(530, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Макс. скорость:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("TT Firs Neue", 7.799999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(350, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Тип автомобиля:";
            // 
            // AddCarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.carTypeComboBox);
            this.Controls.Add(this.maxSpeedTextBox);
            this.Controls.Add(this.powerTextBox);
            this.Controls.Add(this.modelTextBox);
            this.Controls.Add(this.brandTextBox);
            this.Name = "AddCarForm";
            this.Text = "AddCarForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox brandTextBox;
        private System.Windows.Forms.TextBox modelTextBox;
        private System.Windows.Forms.TextBox powerTextBox;
        private System.Windows.Forms.TextBox maxSpeedTextBox;
        private System.Windows.Forms.ComboBox carTypeComboBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}