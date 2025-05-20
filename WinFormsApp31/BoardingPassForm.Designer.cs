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
            PassportNumber = new Label();
            passport = new Label();
            SeatNUmber = new Label();
            suudal = new Label();
            flightNumber = new Label();
            flight = new Label();
            label1 = new Label();
            name = new Label();
            destination = new Label();
            SuspendLayout();
            // 
            // PassportNumber
            // 
            PassportNumber.AutoSize = true;
            PassportNumber.Font = new Font("Segoe UI", 12F);
            PassportNumber.Location = new Point(12, 54);
            PassportNumber.Name = "PassportNumber";
            PassportNumber.Size = new Size(110, 28);
            PassportNumber.TabIndex = 0;
            PassportNumber.Text = "Passport ID";
            // 
            // passport
            // 
            passport.AutoSize = true;
            passport.Font = new Font("Segoe UI", 12F);
            passport.Location = new Point(12, 94);
            passport.Name = "passport";
            passport.Size = new Size(120, 28);
            passport.TabIndex = 1;
            passport.Text = "XXXXXXXXX";
            // 
            // SeatNUmber
            // 
            SeatNUmber.AutoSize = true;
            SeatNUmber.Font = new Font("Segoe UI", 12F);
            SeatNUmber.Location = new Point(12, 139);
            SeatNUmber.Name = "SeatNUmber";
            SeatNUmber.Size = new Size(127, 28);
            SeatNUmber.TabIndex = 2;
            SeatNUmber.Text = "Seat Number";
            // 
            // suudal
            // 
            suudal.AutoSize = true;
            suudal.Font = new Font("Segoe UI", 12F);
            suudal.Location = new Point(12, 185);
            suudal.Name = "suudal";
            suudal.Size = new Size(120, 28);
            suudal.TabIndex = 3;
            suudal.Text = "XXXXXXXXX";
            // 
            // flightNumber
            // 
            flightNumber.AutoSize = true;
            flightNumber.Font = new Font("Segoe UI", 12F);
            flightNumber.Location = new Point(12, 237);
            flightNumber.Name = "flightNumber";
            flightNumber.Size = new Size(139, 28);
            flightNumber.TabIndex = 4;
            flightNumber.Text = "Flight Number";
            // 
            // flight
            // 
            flight.AutoSize = true;
            flight.Font = new Font("Segoe UI", 12F);
            flight.Location = new Point(12, 285);
            flight.Name = "flight";
            flight.Size = new Size(120, 28);
            flight.TabIndex = 5;
            flight.Text = "XXXXXXXXX";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 334);
            label1.Name = "label1";
            label1.Size = new Size(64, 28);
            label1.TabIndex = 6;
            label1.Text = "Name";
            // 
            // name
            // 
            name.AutoSize = true;
            name.Font = new Font("Segoe UI", 12F);
            name.Location = new Point(12, 380);
            name.Name = "name";
            name.Size = new Size(120, 28);
            name.TabIndex = 7;
            name.Text = "XXXXXXXXX";
            // 
            // destination
            // 
            destination.AutoSize = true;
            destination.Font = new Font("Segoe UI", 12F);
            destination.Location = new Point(12, 426);
            destination.Name = "destination";
            destination.Size = new Size(64, 28);
            destination.TabIndex = 8;
            destination.Text = "Name";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 663);
            Controls.Add(destination);
            Controls.Add(name);
            Controls.Add(label1);
            Controls.Add(flight);
            Controls.Add(flightNumber);
            Controls.Add(suudal);
            Controls.Add(SeatNUmber);
            Controls.Add(passport);
            Controls.Add(PassportNumber);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PassportNumber;
        private Label passport;
        private Label SeatNUmber;
        private Label suudal;
        private Label flightNumber;
        private Label flight;
        private Label label1;
        private Label name;
        private Label destination;
    }
}