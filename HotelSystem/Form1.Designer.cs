﻿namespace HotelSystem
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ContactNo = new System.Windows.Forms.TextBox();
            this.HotelName = new System.Windows.Forms.TextBox();
            this.SavePathText = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SavePathClick = new System.Windows.Forms.Button();
            this.SavePathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.NumbWarn = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Initial Setup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hotel Contact Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hotel Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Background Image";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 179);
            this.label5.MaximumSize = new System.Drawing.Size(125, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Path to HotelSystem Folder";
            // 
            // ContactNo
            // 
            this.ContactNo.Location = new System.Drawing.Point(130, 50);
            this.ContactNo.Name = "ContactNo";
            this.ContactNo.Size = new System.Drawing.Size(156, 20);
            this.ContactNo.TabIndex = 5;
            // 
            // HotelName
            // 
            this.HotelName.Location = new System.Drawing.Point(130, 80);
            this.HotelName.Name = "HotelName";
            this.HotelName.Size = new System.Drawing.Size(156, 20);
            this.HotelName.TabIndex = 6;
            // 
            // SavePathText
            // 
            this.SavePathText.Location = new System.Drawing.Point(130, 180);
            this.SavePathText.Name = "SavePathText";
            this.SavePathText.ReadOnly = true;
            this.SavePathText.Size = new System.Drawing.Size(156, 20);
            this.SavePathText.TabIndex = 8;
            this.SavePathText.Text = "C:\\Program Files\\HotelSystem";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(292, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 20);
            this.button1.TabIndex = 9;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(211, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(130, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 61);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // SavePathClick
            // 
            this.SavePathClick.Location = new System.Drawing.Point(292, 180);
            this.SavePathClick.Name = "SavePathClick";
            this.SavePathClick.Size = new System.Drawing.Size(24, 20);
            this.SavePathClick.TabIndex = 13;
            this.SavePathClick.Text = "...";
            this.SavePathClick.UseVisualStyleBackColor = true;
            this.SavePathClick.Click += new System.EventHandler(this.SavePathClick_Click);
            // 
            // SavePathDialog
            // 
            this.SavePathDialog.RootFolder = System.Environment.SpecialFolder.DesktopDirectory;
            // 
            // NumbWarn
            // 
            this.NumbWarn.AutoSize = true;
            this.NumbWarn.ForeColor = System.Drawing.Color.Red;
            this.NumbWarn.Location = new System.Drawing.Point(289, 44);
            this.NumbWarn.MaximumSize = new System.Drawing.Size(150, 0);
            this.NumbWarn.Name = "NumbWarn";
            this.NumbWarn.Size = new System.Drawing.Size(141, 26);
            this.NumbWarn.TabIndex = 14;
            this.NumbWarn.Text = "Must only contain numbers, and be 16 characters or less";
            this.NumbWarn.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(289, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Must be less than 30 characters";
            this.label6.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 374);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.NumbWarn);
            this.Controls.Add(this.SavePathClick);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SavePathText);
            this.Controls.Add(this.HotelName);
            this.Controls.Add(this.ContactNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ContactNo;
        private System.Windows.Forms.TextBox HotelName;
        private System.Windows.Forms.TextBox SavePathText;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SavePathClick;
        private System.Windows.Forms.FolderBrowserDialog SavePathDialog;
        private System.Windows.Forms.Label NumbWarn;
        private System.Windows.Forms.Label label6;
    }
}

