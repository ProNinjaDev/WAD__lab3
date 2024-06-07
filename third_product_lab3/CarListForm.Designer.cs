namespace third_product_lab3
{
    partial class CarListForm
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
            this.components = new System.ComponentModel.Container();
            this.OnlyBrandTable = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ProgressTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OnlyBrandTable)).BeginInit();
            this.SuspendLayout();
            // 
            // OnlyBrandTable
            // 
            this.OnlyBrandTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OnlyBrandTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OnlyBrandTable.Location = new System.Drawing.Point(0, 0);
            this.OnlyBrandTable.Name = "OnlyBrandTable";
            this.OnlyBrandTable.RowHeadersWidth = 51;
            this.OnlyBrandTable.RowTemplate.Height = 24;
            this.OnlyBrandTable.Size = new System.Drawing.Size(699, 598);
            this.OnlyBrandTable.TabIndex = 0;
            this.OnlyBrandTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnlyBrandTable_CellContentClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(99, 470);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(465, 30);
            this.progressBar1.TabIndex = 1;
            // 
            // ProgressTimer
            // 
            this.ProgressTimer.Tick += new System.EventHandler(this.ProgressTimer_Tick);
            // 
            // CarListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 598);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.OnlyBrandTable);
            this.Name = "CarListForm";
            this.Text = "База данных";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CarListForm_FormClosing);
            this.Load += new System.EventHandler(this.CarListForm_Load);
            this.SizeChanged += new System.EventHandler(this.CarListForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.OnlyBrandTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView OnlyBrandTable;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer ProgressTimer;
    }
}