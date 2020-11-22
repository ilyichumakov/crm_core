namespace crm_core
{
    partial class ListForm
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
            this.data_panel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.next_page = new System.Windows.Forms.Button();
            this.prev_page = new System.Windows.Forms.Button();
            this.pages_label = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // data_panel
            // 
            this.data_panel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.data_panel.AutoScroll = true;
            this.data_panel.Location = new System.Drawing.Point(12, 27);
            this.data_panel.Name = "data_panel";
            this.data_panel.Size = new System.Drawing.Size(891, 416);
            this.data_panel.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(915, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // next_page
            // 
            this.next_page.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.next_page.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.next_page.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.next_page.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSeaGreen;
            this.next_page.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GreenYellow;
            this.next_page.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next_page.Location = new System.Drawing.Point(609, 462);
            this.next_page.Name = "next_page";
            this.next_page.Size = new System.Drawing.Size(115, 26);
            this.next_page.TabIndex = 2;
            this.next_page.Text = "Далее";
            this.next_page.UseVisualStyleBackColor = false;
            this.next_page.Click += new System.EventHandler(this.next_page_Click);
            // 
            // prev_page
            // 
            this.prev_page.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.prev_page.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.prev_page.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.prev_page.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSeaGreen;
            this.prev_page.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GreenYellow;
            this.prev_page.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prev_page.Location = new System.Drawing.Point(171, 462);
            this.prev_page.Name = "prev_page";
            this.prev_page.Size = new System.Drawing.Size(115, 26);
            this.prev_page.TabIndex = 2;
            this.prev_page.Text = "Назад";
            this.prev_page.UseVisualStyleBackColor = false;
            this.prev_page.Click += new System.EventHandler(this.prev_page_Click);
            // 
            // pages_label
            // 
            this.pages_label.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pages_label.AutoSize = true;
            this.pages_label.Location = new System.Drawing.Point(432, 468);
            this.pages_label.Name = "pages_label";
            this.pages_label.Size = new System.Drawing.Size(0, 15);
            this.pages_label.TabIndex = 3;
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(236)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(915, 510);
            this.Controls.Add(this.pages_label);
            this.Controls.Add(this.prev_page);
            this.Controls.Add(this.next_page);
            this.Controls.Add(this.data_panel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 540);
            this.Name = "ListForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная";
            this.Load += new System.EventHandler(this.ListForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel data_panel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.Button next_page;
        private System.Windows.Forms.Button prev_page;
        private System.Windows.Forms.Label pages_label;
    }
}