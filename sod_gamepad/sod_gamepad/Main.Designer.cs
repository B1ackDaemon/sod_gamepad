namespace sod_gamepad
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.btn_select_dir = new System.Windows.Forms.Button();
            this.btn_patch = new System.Windows.Forms.Button();
            this.btn_revert = new System.Windows.Forms.Button();
            this.richTextBox_log = new System.Windows.Forms.RichTextBox();
            this.label_about = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select SoD game dir:";
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(35, 57);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(100, 20);
            this.textBox_path.TabIndex = 1;
            // 
            // btn_select_dir
            // 
            this.btn_select_dir.Location = new System.Drawing.Point(185, 54);
            this.btn_select_dir.Name = "btn_select_dir";
            this.btn_select_dir.Size = new System.Drawing.Size(75, 23);
            this.btn_select_dir.TabIndex = 2;
            this.btn_select_dir.Text = "Select...";
            this.btn_select_dir.UseVisualStyleBackColor = true;
            this.btn_select_dir.Click += new System.EventHandler(this.btn_select_dir_Click);
            // 
            // btn_patch
            // 
            this.btn_patch.Location = new System.Drawing.Point(60, 152);
            this.btn_patch.Name = "btn_patch";
            this.btn_patch.Size = new System.Drawing.Size(75, 23);
            this.btn_patch.TabIndex = 3;
            this.btn_patch.Text = "Patch";
            this.btn_patch.UseVisualStyleBackColor = true;
            this.btn_patch.Click += new System.EventHandler(this.btn_patch_Click);
            // 
            // btn_revert
            // 
            this.btn_revert.Location = new System.Drawing.Point(185, 152);
            this.btn_revert.Name = "btn_revert";
            this.btn_revert.Size = new System.Drawing.Size(75, 23);
            this.btn_revert.TabIndex = 4;
            this.btn_revert.Text = "Revert";
            this.btn_revert.UseVisualStyleBackColor = true;
            this.btn_revert.Click += new System.EventHandler(this.btn_revert_Click);
            // 
            // richTextBox_log
            // 
            this.richTextBox_log.Location = new System.Drawing.Point(35, 273);
            this.richTextBox_log.Name = "richTextBox_log";
            this.richTextBox_log.Size = new System.Drawing.Size(258, 96);
            this.richTextBox_log.TabIndex = 5;
            this.richTextBox_log.Text = "";
            // 
            // label_about
            // 
            this.label_about.AutoSize = true;
            this.label_about.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_about.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_about.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_about.Location = new System.Drawing.Point(32, 219);
            this.label_about.Name = "label_about";
            this.label_about.Size = new System.Drawing.Size(276, 13);
            this.label_about.TabIndex = 6;
            this.label_about.Text = "School of Dragons gamepad unofficial workaround patch";
            this.label_about.Click += new System.EventHandler(this.label_about_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 246);
            this.Controls.Add(this.label_about);
            this.Controls.Add(this.richTextBox_log);
            this.Controls.Add(this.btn_revert);
            this.Controls.Add(this.btn_patch);
            this.Controls.Add(this.btn_select_dir);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "SoD gamepad workaround patch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button btn_select_dir;
        private System.Windows.Forms.Button btn_patch;
        private System.Windows.Forms.Button btn_revert;
        private System.Windows.Forms.RichTextBox richTextBox_log;
        private System.Windows.Forms.Label label_about;
    }
}

