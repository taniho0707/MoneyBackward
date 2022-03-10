
namespace MoneyBackward
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_load_csv = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textbox_load_csv = new System.Windows.Forms.TextBox();
            this.button_calc = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_load_csv
            // 
            this.button_load_csv.Location = new System.Drawing.Point(13, 13);
            this.button_load_csv.Name = "button_load_csv";
            this.button_load_csv.Size = new System.Drawing.Size(109, 23);
            this.button_load_csv.TabIndex = 0;
            this.button_load_csv.Text = "csvファイルを開く";
            this.button_load_csv.UseVisualStyleBackColor = true;
            this.button_load_csv.Click += new System.EventHandler(this.button_load_csv_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 72);
            this.dataGridView1.MaximumSize = new System.Drawing.Size(1920, 940);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1560, 777);
            this.dataGridView1.TabIndex = 1;
            // 
            // textbox_load_csv
            // 
            this.textbox_load_csv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox_load_csv.Enabled = false;
            this.textbox_load_csv.Location = new System.Drawing.Point(129, 13);
            this.textbox_load_csv.Name = "textbox_load_csv";
            this.textbox_load_csv.Size = new System.Drawing.Size(1443, 23);
            this.textbox_load_csv.TabIndex = 2;
            // 
            // button_calc
            // 
            this.button_calc.Enabled = false;
            this.button_calc.Location = new System.Drawing.Point(13, 43);
            this.button_calc.Name = "button_calc";
            this.button_calc.Size = new System.Drawing.Size(109, 23);
            this.button_calc.TabIndex = 3;
            this.button_calc.Text = "差し引きを計算";
            this.button_calc.UseVisualStyleBackColor = true;
            this.button_calc.Click += new System.EventHandler(this.button_calc_Click);
            // 
            // button_save
            // 
            this.button_save.Enabled = false;
            this.button_save.Location = new System.Drawing.Point(129, 43);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(109, 23);
            this.button_save.TabIndex = 4;
            this.button_save.Text = "結果を保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_calc);
            this.Controls.Add(this.textbox_load_csv);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_load_csv);
            this.MaximumSize = new System.Drawing.Size(5000, 3000);
            this.Name = "Form1";
            this.Text = "MoneyBackward";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_load_csv;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textbox_load_csv;
        private System.Windows.Forms.Button button_calc;
        private System.Windows.Forms.Button button_save;
    }
}

