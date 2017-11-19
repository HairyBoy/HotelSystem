namespace HotelSystem
{
    partial class Form2
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
            this.CoverPic = new System.Windows.Forms.PictureBox();
            this.BookRoom = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.AddRoom = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            this.HotelName = new System.Windows.Forms.Label();
            this.HotelNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CoverPic)).BeginInit();
            this.SuspendLayout();
            // 
            // CoverPic
            // 
            this.CoverPic.Location = new System.Drawing.Point(13, 13);
            this.CoverPic.Name = "CoverPic";
            this.CoverPic.Size = new System.Drawing.Size(290, 111);
            this.CoverPic.TabIndex = 0;
            this.CoverPic.TabStop = false;
            // 
            // BookRoom
            // 
            this.BookRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BookRoom.Location = new System.Drawing.Point(318, 13);
            this.BookRoom.Name = "BookRoom";
            this.BookRoom.Size = new System.Drawing.Size(163, 45);
            this.BookRoom.TabIndex = 1;
            this.BookRoom.Text = "Book A Room";
            this.BookRoom.UseVisualStyleBackColor = true;
            // 
            // Refresh
            // 
            this.Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Refresh.Location = new System.Drawing.Point(488, 13);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(163, 45);
            this.Refresh.TabIndex = 2;
            this.Refresh.Text = "Refresh Calendar";
            this.Refresh.UseVisualStyleBackColor = true;
            // 
            // AddRoom
            // 
            this.AddRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddRoom.Location = new System.Drawing.Point(775, 13);
            this.AddRoom.Name = "AddRoom";
            this.AddRoom.Size = new System.Drawing.Size(149, 45);
            this.AddRoom.TabIndex = 3;
            this.AddRoom.Text = "Add Room";
            this.AddRoom.UseVisualStyleBackColor = true;
            // 
            // Save
            // 
            this.Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Save.Location = new System.Drawing.Point(13, 489);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(121, 41);
            this.Save.TabIndex = 4;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.Settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Settings.Location = new System.Drawing.Point(182, 489);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(121, 41);
            this.Settings.TabIndex = 5;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            // 
            // HotelName
            // 
            this.HotelName.AutoSize = true;
            this.HotelName.Location = new System.Drawing.Point(13, 131);
            this.HotelName.Name = "HotelName";
            this.HotelName.Size = new System.Drawing.Size(0, 13);
            this.HotelName.TabIndex = 6;
            // 
            // HotelNumber
            // 
            this.HotelNumber.AutoSize = true;
            this.HotelNumber.Location = new System.Drawing.Point(199, 131);
            this.HotelNumber.Name = "HotelNumber";
            this.HotelNumber.Size = new System.Drawing.Size(0, 13);
            this.HotelNumber.TabIndex = 7;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 542);
            this.Controls.Add(this.HotelNumber);
            this.Controls.Add(this.HotelName);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.AddRoom);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.BookRoom);
            this.Controls.Add(this.CoverPic);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CoverPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CoverPic;
        private System.Windows.Forms.Button BookRoom;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Button AddRoom;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Label HotelName;
        private System.Windows.Forms.Label HotelNumber;
    }
}