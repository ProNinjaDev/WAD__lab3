namespace third_product_lab3
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
            this.components = new System.ComponentModel.Container();
            this.TableCar = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьСписокМарокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewCarInTableBtn = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TableCar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // TableCar
            // 
            this.TableCar.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.TableCar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableCar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableCar.Location = new System.Drawing.Point(0, 28);
            this.TableCar.Name = "TableCar";
            this.TableCar.RowHeadersWidth = 51;
            this.TableCar.RowTemplate.Height = 24;
            this.TableCar.Size = new System.Drawing.Size(800, 226);
            this.TableCar.TabIndex = 0;
            this.TableCar.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableCar_CellValueChanged);
            this.TableCar.SelectionChanged += new System.EventHandler(this.TableCar_SelectionChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьСписокМарокToolStripMenuItem,
            this.загрузитьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьСписокМарокToolStripMenuItem
            // 
            this.сохранитьСписокМарокToolStripMenuItem.Name = "сохранитьСписокМарокToolStripMenuItem";
            this.сохранитьСписокМарокToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.сохранитьСписокМарокToolStripMenuItem.Text = "Сохранить список марок";
            this.сохранитьСписокМарокToolStripMenuItem.Click += new System.EventHandler(this.сохранитьСписокМарокToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // AddNewCarInTableBtn
            // 
            this.AddNewCarInTableBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddNewCarInTableBtn.Font = new System.Drawing.Font("TT Firs Neue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddNewCarInTableBtn.Location = new System.Drawing.Point(0, 392);
            this.AddNewCarInTableBtn.Name = "AddNewCarInTableBtn";
            this.AddNewCarInTableBtn.Size = new System.Drawing.Size(800, 58);
            this.AddNewCarInTableBtn.TabIndex = 2;
            this.AddNewCarInTableBtn.Text = "Добавить";
            this.AddNewCarInTableBtn.UseVisualStyleBackColor = true;
            this.AddNewCarInTableBtn.Click += new System.EventHandler(this.AddNewCarInTableBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddNewCarInTableBtn);
            this.Controls.Add(this.TableCar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Главная";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.TableCar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TableCar;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьСписокМарокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Button AddNewCarInTableBtn;
    }
}

