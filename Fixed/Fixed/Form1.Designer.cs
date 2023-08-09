namespace Fixed
{
    partial class FixedForm
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
            this.FixCaps = new System.Windows.Forms.Button();
            this.TranslateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FixCaps
            // 
            this.FixCaps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.FixCaps.Font = new System.Drawing.Font("Oldtimer", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FixCaps.ForeColor = System.Drawing.Color.White;
            this.FixCaps.Location = new System.Drawing.Point(13, 13);
            this.FixCaps.Margin = new System.Windows.Forms.Padding(4);
            this.FixCaps.Name = "FixCaps";
            this.FixCaps.Size = new System.Drawing.Size(235, 44);
            this.FixCaps.TabIndex = 0;
            this.FixCaps.Text = "FixCaps";
            this.FixCaps.UseVisualStyleBackColor = false;
            this.FixCaps.Click += new System.EventHandler(this.FixCaps_Click);
            // 
            // TranslateButton
            // 
            this.TranslateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.TranslateButton.Font = new System.Drawing.Font("Oldtimer", 10.8F);
            this.TranslateButton.ForeColor = System.Drawing.Color.White;
            this.TranslateButton.Location = new System.Drawing.Point(13, 65);
            this.TranslateButton.Margin = new System.Windows.Forms.Padding(4);
            this.TranslateButton.Name = "TranslateButton";
            this.TranslateButton.Size = new System.Drawing.Size(235, 44);
            this.TranslateButton.TabIndex = 1;
            this.TranslateButton.Text = "FixTranslate";
            this.TranslateButton.UseVisualStyleBackColor = false;
            this.TranslateButton.Click += new System.EventHandler(this.TranslateButton_Click);
            // 
            // FixedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(261, 125);
            this.Controls.Add(this.TranslateButton);
            this.Controls.Add(this.FixCaps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FixedForm";
            this.Text = "Fixed";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FixCaps;
        private System.Windows.Forms.Button TranslateButton;
    }
}

