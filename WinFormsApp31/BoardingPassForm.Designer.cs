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
            label1 = new Label();
            SeatNUmber = new Label();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 82);
            label1.Name = "label1";
            label1.Size = new Size(0, 28);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // SeatNUmber
            // 
            SeatNUmber.AutoSize = true;
            SeatNUmber.Font = new Font("Segoe UI", 12F);
            SeatNUmber.Location = new Point(12, 139);
            SeatNUmber.Name = "SeatNUmber";
            SeatNUmber.Size = new Size(161, 28);
            SeatNUmber.TabIndex = 2;
            SeatNUmber.Text = "Суудлын Дугаар";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 663);
            Controls.Add(SeatNUmber);
            Controls.Add(label1);
            Controls.Add(PassportNumber);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PassportNumber;
        private Label label1;
        private Label SeatNUmber;
    }
}