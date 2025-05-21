namespace WinFormsApp31
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
            Passport = new Label();
            PassportNumberLabel = new Label();
            SeatLabel = new Label();
            NameLabel = new Label();
            Flight = new Label();
            FligthNumberLabel = new Label();
            Name = new Label();
            SeatNumberLabel = new Label();
            label2 = new Label();
            UserOrderPrintButton = new Button();
            TimeLabel = new Label();
            SuspendLayout();
            // 
            // Passport
            // 
            Passport.AutoSize = true;
            Passport.Font = new Font("Segoe UI", 12F);
            Passport.Location = new Point(21, 131);
            Passport.Name = "Passport";
            Passport.Size = new Size(162, 28);
            Passport.TabIndex = 0;
            Passport.Text = "PassportNumber:";
            // 
            // PassportNumberLabel
            // 
            PassportNumberLabel.AutoSize = true;
            PassportNumberLabel.Font = new Font("Segoe UI", 12F);
            PassportNumberLabel.ForeColor = SystemColors.HotTrack;
            PassportNumberLabel.Location = new Point(234, 131);
            PassportNumberLabel.Name = "PassportNumberLabel";
            PassportNumberLabel.Size = new Size(120, 28);
            PassportNumberLabel.TabIndex = 1;
            PassportNumberLabel.Text = "XXXXXXXXX";
            // 
            // SeatLabel
            // 
            SeatLabel.AutoSize = true;
            SeatLabel.Font = new Font("Segoe UI", 12F);
            SeatLabel.Location = new Point(21, 250);
            SeatLabel.Name = "SeatLabel";
            SeatLabel.Size = new Size(131, 28);
            SeatLabel.TabIndex = 2;
            SeatLabel.Text = "Seat Number:";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI", 12F);
            NameLabel.ForeColor = SystemColors.HotTrack;
            NameLabel.Location = new Point(234, 78);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(120, 28);
            NameLabel.TabIndex = 3;
            NameLabel.Text = "XXXXXXXXX";
            // 
            // Flight
            // 
            Flight.AutoSize = true;
            Flight.Font = new Font("Segoe UI", 12F);
            Flight.Location = new Point(21, 183);
            Flight.Name = "Flight";
            Flight.Size = new Size(143, 28);
            Flight.TabIndex = 4;
            Flight.Text = "Flight Number:";
            // 
            // FligthNumberLabel
            // 
            FligthNumberLabel.AutoSize = true;
            FligthNumberLabel.Font = new Font("Segoe UI", 12F);
            FligthNumberLabel.ForeColor = SystemColors.HotTrack;
            FligthNumberLabel.Location = new Point(234, 183);
            FligthNumberLabel.Name = "FligthNumberLabel";
            FligthNumberLabel.Size = new Size(120, 28);
            FligthNumberLabel.TabIndex = 5;
            FligthNumberLabel.Text = "XXXXXXXXX";
            // 
            // Name
            // 
            Name.AutoSize = true;
            Name.Font = new Font("Segoe UI", 12F);
            Name.Location = new Point(21, 78);
            Name.Name = "Name";
            Name.Size = new Size(68, 28);
            Name.TabIndex = 6;
            Name.Text = "Name:";
            // 
            // SeatNumberLabel
            // 
            SeatNumberLabel.AutoSize = true;
            SeatNumberLabel.Font = new Font("Segoe UI", 12F);
            SeatNumberLabel.ForeColor = SystemColors.HotTrack;
            SeatNumberLabel.Location = new Point(234, 250);
            SeatNumberLabel.Name = "SeatNumberLabel";
            SeatNumberLabel.Size = new Size(120, 28);
            SeatNumberLabel.TabIndex = 7;
            SeatNumberLabel.Text = "XXXXXXXXX";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(228, 28);
            label2.TabIndex = 8;
            label2.Text = "Захиалагчийн мэдээлэл";
            // 
            // UserOrderPrintButton
            // 
            UserOrderPrintButton.Location = new Point(122, 351);
            UserOrderPrintButton.Name = "UserOrderPrintButton";
            UserOrderPrintButton.Size = new Size(130, 46);
            UserOrderPrintButton.TabIndex = 9;
            UserOrderPrintButton.Text = "Хэвлэх";
            UserOrderPrintButton.UseVisualStyleBackColor = true;
            UserOrderPrintButton.Click += UserOrderPrintButton_Click;
            // 
            // TimeLabel
            // 
            TimeLabel.AutoSize = true;
            TimeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TimeLabel.Location = new Point(322, 9);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(136, 28);
            TimeLabel.TabIndex = 10;
            TimeLabel.Text = "YYYY/MM/DD";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 663);
            Controls.Add(TimeLabel);
            Controls.Add(UserOrderPrintButton);
            Controls.Add(label2);
            Controls.Add(SeatNumberLabel);
            Controls.Add(Name);
            Controls.Add(FligthNumberLabel);
            Controls.Add(Flight);
            Controls.Add(NameLabel);
            Controls.Add(SeatLabel);
            Controls.Add(PassportNumberLabel);
            Controls.Add(Passport);
            //Name = "BoardingPassForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Passport;
        private Label PassportNumberLabel;
        private Label SeatLabel;
        private Label NameLabel;
        private Label Flight;
        private Label FligthNumberLabel;
        private Label Name;
        private Label SeatNumberLabel;
        private Label label2;
        private Button UserOrderPrintButton;
        private Label TimeLabel;
    }
}