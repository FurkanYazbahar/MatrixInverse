namespace KareOlmayanMatrisinSözdeTersi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.textboxflowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRowCount = new System.Windows.Forms.TextBox();
            this.textBoxColCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.freshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textboxflowPanel
            // 
            this.textboxflowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.textboxflowPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textboxflowPanel.Location = new System.Drawing.Point(16, 66);
            this.textboxflowPanel.Name = "textboxflowPanel";
            this.textboxflowPanel.Size = new System.Drawing.Size(166, 10);
            this.textboxflowPanel.TabIndex = 50;
            this.textboxflowPanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "satır sayısı:";
            // 
            // textBoxRowCount
            // 
            this.textBoxRowCount.Location = new System.Drawing.Point(77, 13);
            this.textBoxRowCount.MaxLength = 1;
            this.textBoxRowCount.Name = "textBoxRowCount";
            this.textBoxRowCount.Size = new System.Drawing.Size(34, 20);
            this.textBoxRowCount.TabIndex = 0;
            this.textBoxRowCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRowCount_KeyPress);
            // 
            // textBoxColCount
            // 
            this.textBoxColCount.Location = new System.Drawing.Point(77, 36);
            this.textBoxColCount.MaxLength = 1;
            this.textBoxColCount.Name = "textBoxColCount";
            this.textBoxColCount.Size = new System.Drawing.Size(34, 20);
            this.textBoxColCount.TabIndex = 1;
            this.textBoxColCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxColCount_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "sütun sayısı:";
            // 
            // freshButton
            // 
            this.freshButton.Location = new System.Drawing.Point(126, 13);
            this.freshButton.Name = "freshButton";
            this.freshButton.Size = new System.Drawing.Size(56, 43);
            this.freshButton.TabIndex = 2;
            this.freshButton.Text = "Yenile";
            this.freshButton.UseVisualStyleBackColor = true;
            this.freshButton.Click += new System.EventHandler(this.freshButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 92);
            this.Controls.Add(this.freshButton);
            this.Controls.Add(this.textBoxColCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRowCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textboxflowPanel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel textboxflowPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRowCount;
        private System.Windows.Forms.TextBox textBoxColCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button freshButton;
    }
}

