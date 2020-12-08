namespace crm_core.Forms
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
            this.panel_inputs = new System.Windows.Forms.Panel();
            this.save_btn = new System.Windows.Forms.Button();
            this.apply_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel_inputs
            // 
            this.panel_inputs.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel_inputs.Location = new System.Drawing.Point(12, 12);
            this.panel_inputs.Name = "panel_inputs";
            this.panel_inputs.Size = new System.Drawing.Size(776, 351);
            this.panel_inputs.TabIndex = 0;
            // 
            // save_btn
            // 
            this.save_btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.save_btn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.save_btn.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.save_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSeaGreen;
            this.save_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GreenYellow;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Location = new System.Drawing.Point(417, 412);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(115, 26);
            this.save_btn.TabIndex = 2;
            this.save_btn.Text = "Сохранить";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // apply_btn
            // 
            this.apply_btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.apply_btn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.apply_btn.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.apply_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSeaGreen;
            this.apply_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GreenYellow;
            this.apply_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apply_btn.Location = new System.Drawing.Point(262, 412);
            this.apply_btn.Name = "apply_btn";
            this.apply_btn.Size = new System.Drawing.Size(115, 26);
            this.apply_btn.TabIndex = 2;
            this.apply_btn.Text = "Применить";
            this.apply_btn.UseVisualStyleBackColor = false;
            this.apply_btn.Click += new System.EventHandler(this.apply_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancel_btn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancel_btn.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cancel_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSeaGreen;
            this.cancel_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GreenYellow;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Location = new System.Drawing.Point(107, 412);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(115, 26);
            this.cancel_btn.TabIndex = 2;
            this.cancel_btn.Text = "Назад";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GreenYellow;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(562, 412);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Удалить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.apply_btn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.panel_inputs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактировать";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_inputs;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button apply_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button button1;
    }
}