namespace WinFormsApp31
{
    partial class StateChangeForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            button3 = new Button();
            label2 = new Label();
            button2 = new Button();
            textBox_HubURL = new TextBox();
            label_ConnectionStatus = new Label();
            textBox_FlightNumber = new TextBox();
            comboBox_Status = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.5239849F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.47601F));
            tableLayoutPanel1.Controls.Add(groupBox1, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15.333333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 84.6666641F));
            tableLayoutPanel1.Size = new Size(1084, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox_Status);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(textBox_HubURL);
            groupBox1.Controls.Add(label_ConnectionStatus);
            groupBox1.Controls.Add(textBox_FlightNumber);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(257, 71);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(825, 377);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Flight status";
            // 
            // button3
            // 
            button3.Location = new Point(174, 144);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(170, 27);
            button3.TabIndex = 9;
            button3.Text = "Connect";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 83);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(118, 20);
            label2.TabIndex = 8;
            label2.Text = "SignalR hub URL";
            // 
            // button2
            // 
            button2.Location = new Point(54, 297);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(122, 58);
            button2.TabIndex = 3;
            button2.Text = "Change status";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox_HubURL
            // 
            textBox_HubURL.Location = new Point(54, 106);
            textBox_HubURL.Margin = new Padding(2);
            textBox_HubURL.Name = "textBox_HubURL";
            textBox_HubURL.Size = new Size(291, 27);
            textBox_HubURL.TabIndex = 7;
            textBox_HubURL.Text = "http://localhost:5000/flightstatushub";
            // 
            // label_ConnectionStatus
            // 
            label_ConnectionStatus.AutoSize = true;
            label_ConnectionStatus.Location = new Point(55, 150);
            label_ConnectionStatus.Margin = new Padding(2, 0, 2, 0);
            label_ConnectionStatus.Name = "label_ConnectionStatus";
            label_ConnectionStatus.Size = new Size(107, 20);
            label_ConnectionStatus.TabIndex = 6;
            label_ConnectionStatus.Text = "Not connected";
            // 
            // textBox_FlightNumber
            // 
            textBox_FlightNumber.Location = new Point(56, 207);
            textBox_FlightNumber.Margin = new Padding(2);
            textBox_FlightNumber.Name = "textBox_FlightNumber";
            textBox_FlightNumber.PlaceholderText = "Flight number";
            textBox_FlightNumber.Size = new Size(289, 27);
            textBox_FlightNumber.TabIndex = 5;
            // 
            // comboBox_Status
            // 
            comboBox_Status.FormattingEnabled = true;
            comboBox_Status.Location = new Point(56, 257);
            comboBox_Status.Name = "comboBox_Status";
            comboBox_Status.Size = new Size(288, 28);
            comboBox_Status.TabIndex = 10;
            // 
            // StateChangeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "StateChangeForm";
            Text = "StateChangeForm";
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private Button button3;
        private Label label2;
        private Button button2;
        private TextBox textBox_HubURL;
        private Label label_ConnectionStatus;
        private TextBox textBox_FlightNumber;
        private ComboBox comboBox_Status;
    }
}