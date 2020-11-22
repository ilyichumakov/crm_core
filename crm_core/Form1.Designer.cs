namespace crm_core
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.preloader_picture = new System.Windows.Forms.PictureBox();
            this.loading_label = new System.Windows.Forms.Label();
            this.app_name_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.preloader_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // preloader_picture
            // 
            this.preloader_picture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.preloader_picture.Image = ((System.Drawing.Image)(resources.GetObject("preloader_picture.Image")));
            this.preloader_picture.Location = new System.Drawing.Point(315, 170);
            this.preloader_picture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.preloader_picture.Name = "preloader_picture";
            this.preloader_picture.Size = new System.Drawing.Size(303, 213);
            this.preloader_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.preloader_picture.TabIndex = 0;
            this.preloader_picture.TabStop = false;
            // 
            // loading_label
            // 
            this.loading_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loading_label.Font = new System.Drawing.Font("Perpetua", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loading_label.ForeColor = System.Drawing.SystemColors.InfoText;
            this.loading_label.Location = new System.Drawing.Point(366, 324);
            this.loading_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loading_label.Name = "loading_label";
            this.loading_label.Size = new System.Drawing.Size(211, 29);
            this.loading_label.TabIndex = 1;
            this.loading_label.Text = "Loading";
            this.loading_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // app_name_label
            // 
            this.app_name_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.app_name_label.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.app_name_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(168)))), ((int)(((byte)(237)))));
            this.app_name_label.Location = new System.Drawing.Point(366, 170);
            this.app_name_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.app_name_label.Name = "app_name_label";
            this.app_name_label.Size = new System.Drawing.Size(211, 81);
            this.app_name_label.TabIndex = 1;
            this.app_name_label.Text = "Light CRM";
            this.app_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(236)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(915, 510);
            this.Controls.Add(this.app_name_label);
            this.Controls.Add(this.loading_label);
            this.Controls.Add(this.preloader_picture);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(417, 317);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Light CRM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Click += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.preloader_picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox preloader_picture;
        private System.Windows.Forms.Label loading_label;
        private System.Windows.Forms.Label app_name_label;
    }
}

