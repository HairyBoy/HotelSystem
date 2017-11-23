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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Calendar = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CoverPic)).BeginInit();
            this.Calendar.SuspendLayout();
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
            this.Refresh.Location = new System.Drawing.Point(487, 13);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(163, 45);
            this.Refresh.TabIndex = 2;
            this.Refresh.Text = "Refresh Calendar";
            this.Refresh.UseVisualStyleBackColor = true;
            // 
            // AddRoom
            // 
            this.AddRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddRoom.Location = new System.Drawing.Point(1004, 13);
            this.AddRoom.Name = "AddRoom";
            this.AddRoom.Size = new System.Drawing.Size(149, 45);
            this.AddRoom.TabIndex = 3;
            this.AddRoom.Text = "Add Room";
            this.AddRoom.UseVisualStyleBackColor = true;
            // 
            // Save
            // 
            this.Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Save.Location = new System.Drawing.Point(16, 456);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(121, 41);
            this.Save.TabIndex = 4;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.Settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Settings.Location = new System.Drawing.Point(182, 456);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1159, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "▶";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(721, 503);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "▼";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Calendar
            // 
            this.Calendar.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.Calendar.ColumnCount = 8;
            this.Calendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Calendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Calendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Calendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Calendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Calendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Calendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Calendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Calendar.Controls.Add(this.richTextBox1, 0, 0);
            this.Calendar.Location = new System.Drawing.Point(318, 64);
            this.Calendar.Name = "Calendar";
            this.Calendar.RowCount = 16;
            this.Calendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.Calendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.Calendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.Calendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.Calendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.Calendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.Calendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.Calendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.Calendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.Calendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.Calendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.Calendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.Calendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.Calendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.Calendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.Calendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.Calendar.Size = new System.Drawing.Size(835, 433);
            this.Calendar.TabIndex = 11;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.Location = new System.Drawing.Point(4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(97, 20);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 535);
            this.Controls.Add(this.Calendar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
            this.Calendar.ResumeLayout(false);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel Calendar;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}