namespace UP__
{
    partial class Administrator
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
            this.button_His = new System.Windows.Forms.Button();
            this.button_sign_up = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_His
            // 
            this.button_His.BackColor = System.Drawing.Color.White;
            this.button_His.Location = new System.Drawing.Point(77, 110);
            this.button_His.Name = "button_His";
            this.button_His.Size = new System.Drawing.Size(128, 41);
            this.button_His.TabIndex = 5;
            this.button_His.Text = "Просмотреть истоию входа";
            this.button_His.UseVisualStyleBackColor = false;
            this.button_His.Click += new System.EventHandler(this.button_His_Click);
            // 
            // button_sign_up
            // 
            this.button_sign_up.BackColor = System.Drawing.Color.White;
            this.button_sign_up.Location = new System.Drawing.Point(77, 157);
            this.button_sign_up.Name = "button_sign_up";
            this.button_sign_up.Size = new System.Drawing.Size(128, 41);
            this.button_sign_up.TabIndex = 3;
            this.button_sign_up.Text = "Список пользователей";
            this.button_sign_up.UseVisualStyleBackColor = false;
            this.button_sign_up.Click += new System.EventHandler(this.button_sign_up_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(77, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Administrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UP__.Properties.Resources._30ce882f5d7bf673d05ca5bde3c58f70;
            this.ClientSize = new System.Drawing.Size(304, 338);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_His);
            this.Controls.Add(this.button_sign_up);
            this.Name = "Administrator";
            this.Text = "Administrator";
            this.Load += new System.EventHandler(this.Administrator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_His;
        private System.Windows.Forms.Button button_sign_up;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}