namespace WinFormsApp31;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        blazorWebView1 = new Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView();
        button2 = new Button();
        textBox_Status = new TextBox();
        textBox_FlightNumber = new TextBox();
        label_ConnectionStatus = new Label();
        textBox_HubURL = new TextBox();
        label2 = new Label();
        groupBox1 = new GroupBox();
        button3 = new Button();
        MainTableLayout = new TableLayoutPanel();
        SearchTableLayout = new TableLayoutPanel();
        SearchTextBox = new TextBox();
        SearchButton = new Button();
        ResultPassenger = new FlowLayoutPanel();
        ButtonTable = new TableLayoutPanel();
        PrintButton = new Button();
        CheckButton = new Button();
        tableLayoutPanel1 = new TableLayoutPanel();
        Seat40 = new Button();
        Seat39 = new Button();
        Seat38 = new Button();
        Seat37 = new Button();
        Seat36 = new Button();
        Seat35 = new Button();
        Seat34 = new Button();
        Seat33 = new Button();
        Seat32 = new Button();
        Seat31 = new Button();
        Seat30 = new Button();
        Seat29 = new Button();
        Seat28 = new Button();
        Seat27 = new Button();
        Seat26 = new Button();
        Seat25 = new Button();
        Seat24 = new Button();
        Seat23 = new Button();
        Seat22 = new Button();
        Seat21 = new Button();
        Seat20 = new Button();
        Seat19 = new Button();
        Seat18 = new Button();
        Seat17 = new Button();
        Seat16 = new Button();
        Seat15 = new Button();
        Seat14 = new Button();
        Seat13 = new Button();
        Seat12 = new Button();
        Seat11 = new Button();
        Seat10 = new Button();
        Seat9 = new Button();
        Seat8 = new Button();
        Seat7 = new Button();
        Seat6 = new Button();
        Seat5 = new Button();
        Seat4 = new Button();
        Seat3 = new Button();
        Seat2 = new Button();
        Seat1 = new Button();
        groupBox1.SuspendLayout();
        MainTableLayout.SuspendLayout();
        SearchTableLayout.SuspendLayout();
        ButtonTable.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // blazorWebView1
        // 
        blazorWebView1.Dock = DockStyle.Fill;
        blazorWebView1.Location = new Point(319, 128);
        blazorWebView1.Margin = new Padding(2);
        blazorWebView1.Name = "blazorWebView1";
        blazorWebView1.Size = new Size(949, 438);
        blazorWebView1.TabIndex = 0;
        blazorWebView1.Text = "blazorWebView1";
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
        // textBox_Status
        // 
        textBox_Status.Location = new Point(56, 251);
        textBox_Status.Margin = new Padding(2);
        textBox_Status.Name = "textBox_Status";
        textBox_Status.PlaceholderText = "Status";
        textBox_Status.Size = new Size(289, 27);
        textBox_Status.TabIndex = 4;
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
        // label_ConnectionStatus
        // 
        label_ConnectionStatus.AutoSize = true;
        label_ConnectionStatus.Location = new Point(56, 151);
        label_ConnectionStatus.Margin = new Padding(2, 0, 2, 0);
        label_ConnectionStatus.Name = "label_ConnectionStatus";
        label_ConnectionStatus.Size = new Size(107, 20);
        label_ConnectionStatus.TabIndex = 6;
        label_ConnectionStatus.Text = "Not connected";
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
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(53, 84);
        label2.Margin = new Padding(2, 0, 2, 0);
        label2.Name = "label2";
        label2.Size = new Size(118, 20);
        label2.TabIndex = 8;
        label2.Text = "SignalR hub URL";
        // 
        // groupBox1
        // 
        groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        groupBox1.Controls.Add(button3);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(button2);
        groupBox1.Controls.Add(textBox_HubURL);
        groupBox1.Controls.Add(textBox_Status);
        groupBox1.Controls.Add(label_ConnectionStatus);
        groupBox1.Controls.Add(textBox_FlightNumber);
        groupBox1.Location = new Point(931, 2);
        groupBox1.Margin = new Padding(2);
        groupBox1.Name = "groupBox1";
        groupBox1.Padding = new Padding(2);
        groupBox1.Size = new Size(337, 59);
        groupBox1.TabIndex = 9;
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
        // MainTableLayout
        // 
        MainTableLayout.BackColor = SystemColors.ActiveCaption;
        MainTableLayout.ColumnCount = 2;
        MainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        MainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
        MainTableLayout.Controls.Add(blazorWebView1, 1, 1);
        MainTableLayout.Controls.Add(groupBox1, 1, 0);
        MainTableLayout.Controls.Add(SearchTableLayout, 0, 0);
        MainTableLayout.Controls.Add(ButtonTable, 0, 2);
        MainTableLayout.Controls.Add(tableLayoutPanel1, 0, 1);
        MainTableLayout.Dock = DockStyle.Fill;
        MainTableLayout.Location = new Point(0, 0);
        MainTableLayout.Name = "MainTableLayout";
        MainTableLayout.RowCount = 3;
        MainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        MainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
        MainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        MainTableLayout.Size = new Size(1270, 632);
        MainTableLayout.TabIndex = 10;
        // 
        // SearchTableLayout
        // 
        SearchTableLayout.BackColor = SystemColors.MenuHighlight;
        SearchTableLayout.ColumnCount = 2;
        SearchTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
        SearchTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        SearchTableLayout.Controls.Add(SearchTextBox, 0, 0);
        SearchTableLayout.Controls.Add(SearchButton, 1, 0);
        SearchTableLayout.Controls.Add(ResultPassenger, 0, 1);
        SearchTableLayout.Dock = DockStyle.Fill;
        SearchTableLayout.Location = new Point(3, 3);
        SearchTableLayout.Name = "SearchTableLayout";
        SearchTableLayout.RowCount = 2;
        SearchTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
        SearchTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
        SearchTableLayout.Size = new Size(311, 120);
        SearchTableLayout.TabIndex = 10;
        // 
        // SearchTextBox
        // 
        SearchTextBox.Dock = DockStyle.Fill;
        SearchTextBox.Location = new Point(3, 3);
        SearchTextBox.Name = "SearchTextBox";
        SearchTextBox.Size = new Size(211, 27);
        SearchTextBox.TabIndex = 0;
        // 
        // SearchButton
        // 
        SearchButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        SearchButton.Location = new Point(220, 3);
        SearchButton.Name = "SearchButton";
        SearchButton.Size = new Size(88, 29);
        SearchButton.TabIndex = 1;
        SearchButton.Text = "Хайх";
        SearchButton.UseVisualStyleBackColor = true;
        // 
        // ResultPassenger
        // 
        ResultPassenger.Dock = DockStyle.Fill;
        ResultPassenger.Location = new Point(3, 39);
        ResultPassenger.Name = "ResultPassenger";
        ResultPassenger.Size = new Size(211, 78);
        ResultPassenger.TabIndex = 2;
        // 
        // ButtonTable
        // 
        ButtonTable.BackColor = SystemColors.MenuHighlight;
        ButtonTable.ColumnCount = 2;
        ButtonTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        ButtonTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        ButtonTable.Controls.Add(PrintButton, 1, 0);
        ButtonTable.Controls.Add(CheckButton, 0, 0);
        ButtonTable.Dock = DockStyle.Fill;
        ButtonTable.Location = new Point(3, 571);
        ButtonTable.Name = "ButtonTable";
        ButtonTable.RowCount = 1;
        ButtonTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        ButtonTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        ButtonTable.Size = new Size(311, 58);
        ButtonTable.TabIndex = 11;
        // 
        // PrintButton
        // 
        PrintButton.Dock = DockStyle.Fill;
        PrintButton.Location = new Point(158, 3);
        PrintButton.Name = "PrintButton";
        PrintButton.Size = new Size(150, 52);
        PrintButton.TabIndex = 1;
        PrintButton.Text = "Хэвлэх";
        PrintButton.UseVisualStyleBackColor = true;
        // 
        // CheckButton
        // 
        CheckButton.Dock = DockStyle.Fill;
        CheckButton.Location = new Point(3, 3);
        CheckButton.Name = "CheckButton";
        CheckButton.Size = new Size(149, 52);
        CheckButton.TabIndex = 0;
        CheckButton.Text = "Баталгаажуулах";
        CheckButton.UseVisualStyleBackColor = true;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.BackColor = SystemColors.ControlLight;
        tableLayoutPanel1.ColumnCount = 5;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.Controls.Add(Seat40, 4, 9);
        tableLayoutPanel1.Controls.Add(Seat39, 3, 9);
        tableLayoutPanel1.Controls.Add(Seat38, 1, 9);
        tableLayoutPanel1.Controls.Add(Seat37, 0, 9);
        tableLayoutPanel1.Controls.Add(Seat36, 4, 8);
        tableLayoutPanel1.Controls.Add(Seat35, 3, 8);
        tableLayoutPanel1.Controls.Add(Seat34, 1, 8);
        tableLayoutPanel1.Controls.Add(Seat33, 0, 8);
        tableLayoutPanel1.Controls.Add(Seat32, 4, 7);
        tableLayoutPanel1.Controls.Add(Seat31, 3, 7);
        tableLayoutPanel1.Controls.Add(Seat30, 1, 7);
        tableLayoutPanel1.Controls.Add(Seat29, 0, 7);
        tableLayoutPanel1.Controls.Add(Seat28, 4, 6);
        tableLayoutPanel1.Controls.Add(Seat27, 3, 6);
        tableLayoutPanel1.Controls.Add(Seat26, 1, 6);
        tableLayoutPanel1.Controls.Add(Seat25, 0, 6);
        tableLayoutPanel1.Controls.Add(Seat24, 4, 5);
        tableLayoutPanel1.Controls.Add(Seat23, 3, 5);
        tableLayoutPanel1.Controls.Add(Seat22, 1, 5);
        tableLayoutPanel1.Controls.Add(Seat21, 0, 5);
        tableLayoutPanel1.Controls.Add(Seat20, 4, 4);
        tableLayoutPanel1.Controls.Add(Seat19, 3, 4);
        tableLayoutPanel1.Controls.Add(Seat18, 1, 4);
        tableLayoutPanel1.Controls.Add(Seat17, 0, 4);
        tableLayoutPanel1.Controls.Add(Seat16, 4, 3);
        tableLayoutPanel1.Controls.Add(Seat15, 3, 3);
        tableLayoutPanel1.Controls.Add(Seat14, 1, 3);
        tableLayoutPanel1.Controls.Add(Seat13, 0, 3);
        tableLayoutPanel1.Controls.Add(Seat12, 4, 2);
        tableLayoutPanel1.Controls.Add(Seat11, 3, 2);
        tableLayoutPanel1.Controls.Add(Seat10, 1, 2);
        tableLayoutPanel1.Controls.Add(Seat9, 0, 2);
        tableLayoutPanel1.Controls.Add(Seat8, 4, 1);
        tableLayoutPanel1.Controls.Add(Seat7, 3, 1);
        tableLayoutPanel1.Controls.Add(Seat6, 1, 1);
        tableLayoutPanel1.Controls.Add(Seat5, 0, 1);
        tableLayoutPanel1.Controls.Add(Seat4, 4, 0);
        tableLayoutPanel1.Controls.Add(Seat3, 3, 0);
        tableLayoutPanel1.Controls.Add(Seat2, 1, 0);
        tableLayoutPanel1.Controls.Add(Seat1, 0, 0);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(3, 129);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 10;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel1.Size = new Size(311, 436);
        tableLayoutPanel1.TabIndex = 12;
        // 
        // Seat40
        // 
        Seat40.BackColor = SystemColors.ActiveBorder;
        Seat40.Dock = DockStyle.Fill;
        Seat40.Location = new Point(251, 390);
        Seat40.Name = "Seat40";
        Seat40.Size = new Size(57, 43);
        Seat40.TabIndex = 49;
        Seat40.Text = "40";
        Seat40.UseVisualStyleBackColor = false;
        // 
        // Seat39
        // 
        Seat39.BackColor = SystemColors.ActiveBorder;
        Seat39.Dock = DockStyle.Fill;
        Seat39.Location = new Point(189, 390);
        Seat39.Name = "Seat39";
        Seat39.Size = new Size(56, 43);
        Seat39.TabIndex = 48;
        Seat39.Text = "39";
        Seat39.UseVisualStyleBackColor = false;
        // 
        // Seat38
        // 
        Seat38.BackColor = SystemColors.ActiveBorder;
        Seat38.Dock = DockStyle.Fill;
        Seat38.Location = new Point(65, 390);
        Seat38.Name = "Seat38";
        Seat38.Size = new Size(56, 43);
        Seat38.TabIndex = 46;
        Seat38.Text = "38";
        Seat38.UseVisualStyleBackColor = false;
        // 
        // Seat37
        // 
        Seat37.BackColor = SystemColors.ActiveBorder;
        Seat37.Dock = DockStyle.Fill;
        Seat37.Location = new Point(3, 390);
        Seat37.Name = "Seat37";
        Seat37.Size = new Size(56, 43);
        Seat37.TabIndex = 45;
        Seat37.Text = "37";
        Seat37.UseVisualStyleBackColor = false;
        // 
        // Seat36
        // 
        Seat36.BackColor = SystemColors.ActiveBorder;
        Seat36.Dock = DockStyle.Fill;
        Seat36.Location = new Point(251, 347);
        Seat36.Name = "Seat36";
        Seat36.Size = new Size(57, 37);
        Seat36.TabIndex = 44;
        Seat36.Text = "36";
        Seat36.UseVisualStyleBackColor = false;
        // 
        // Seat35
        // 
        Seat35.BackColor = SystemColors.ActiveBorder;
        Seat35.Dock = DockStyle.Fill;
        Seat35.Location = new Point(189, 347);
        Seat35.Name = "Seat35";
        Seat35.Size = new Size(56, 37);
        Seat35.TabIndex = 43;
        Seat35.Text = "35";
        Seat35.UseVisualStyleBackColor = false;
        // 
        // Seat34
        // 
        Seat34.BackColor = SystemColors.ActiveBorder;
        Seat34.Dock = DockStyle.Fill;
        Seat34.Location = new Point(65, 347);
        Seat34.Name = "Seat34";
        Seat34.Size = new Size(56, 37);
        Seat34.TabIndex = 41;
        Seat34.Text = "34";
        Seat34.UseVisualStyleBackColor = false;
        // 
        // Seat33
        // 
        Seat33.BackColor = SystemColors.ActiveBorder;
        Seat33.Dock = DockStyle.Fill;
        Seat33.Location = new Point(3, 347);
        Seat33.Name = "Seat33";
        Seat33.Size = new Size(56, 37);
        Seat33.TabIndex = 40;
        Seat33.Text = "33";
        Seat33.UseVisualStyleBackColor = false;
        // 
        // Seat32
        // 
        Seat32.BackColor = SystemColors.ActiveBorder;
        Seat32.Dock = DockStyle.Fill;
        Seat32.Location = new Point(251, 304);
        Seat32.Name = "Seat32";
        Seat32.Size = new Size(57, 37);
        Seat32.TabIndex = 39;
        Seat32.Text = "32";
        Seat32.UseVisualStyleBackColor = false;
        // 
        // Seat31
        // 
        Seat31.BackColor = SystemColors.ActiveBorder;
        Seat31.Dock = DockStyle.Fill;
        Seat31.Location = new Point(189, 304);
        Seat31.Name = "Seat31";
        Seat31.Size = new Size(56, 37);
        Seat31.TabIndex = 38;
        Seat31.Text = "31";
        Seat31.UseVisualStyleBackColor = false;
        // 
        // Seat30
        // 
        Seat30.BackColor = SystemColors.ActiveBorder;
        Seat30.Dock = DockStyle.Fill;
        Seat30.Location = new Point(65, 304);
        Seat30.Name = "Seat30";
        Seat30.Size = new Size(56, 37);
        Seat30.TabIndex = 36;
        Seat30.Text = "30";
        Seat30.UseVisualStyleBackColor = false;
        // 
        // Seat29
        // 
        Seat29.BackColor = SystemColors.ActiveBorder;
        Seat29.Dock = DockStyle.Fill;
        Seat29.Location = new Point(3, 304);
        Seat29.Name = "Seat29";
        Seat29.Size = new Size(56, 37);
        Seat29.TabIndex = 35;
        Seat29.Text = "29";
        Seat29.UseVisualStyleBackColor = false;
        // 
        // Seat28
        // 
        Seat28.BackColor = SystemColors.ActiveBorder;
        Seat28.Dock = DockStyle.Fill;
        Seat28.Location = new Point(251, 261);
        Seat28.Name = "Seat28";
        Seat28.Size = new Size(57, 37);
        Seat28.TabIndex = 34;
        Seat28.Text = "28";
        Seat28.UseVisualStyleBackColor = false;
        // 
        // Seat27
        // 
        Seat27.BackColor = SystemColors.ActiveBorder;
        Seat27.Dock = DockStyle.Fill;
        Seat27.Location = new Point(189, 261);
        Seat27.Name = "Seat27";
        Seat27.Size = new Size(56, 37);
        Seat27.TabIndex = 33;
        Seat27.Text = "27";
        Seat27.UseVisualStyleBackColor = false;
        // 
        // Seat26
        // 
        Seat26.BackColor = SystemColors.ActiveBorder;
        Seat26.Dock = DockStyle.Fill;
        Seat26.Location = new Point(65, 261);
        Seat26.Name = "Seat26";
        Seat26.Size = new Size(56, 37);
        Seat26.TabIndex = 31;
        Seat26.Text = "26";
        Seat26.UseVisualStyleBackColor = false;
        // 
        // Seat25
        // 
        Seat25.BackColor = SystemColors.ActiveBorder;
        Seat25.Dock = DockStyle.Fill;
        Seat25.Location = new Point(3, 261);
        Seat25.Name = "Seat25";
        Seat25.Size = new Size(56, 37);
        Seat25.TabIndex = 30;
        Seat25.Text = "25";
        Seat25.UseVisualStyleBackColor = false;
        // 
        // Seat24
        // 
        Seat24.BackColor = SystemColors.ActiveBorder;
        Seat24.Dock = DockStyle.Fill;
        Seat24.Location = new Point(251, 218);
        Seat24.Name = "Seat24";
        Seat24.Size = new Size(57, 37);
        Seat24.TabIndex = 29;
        Seat24.Text = "24";
        Seat24.UseVisualStyleBackColor = false;
        // 
        // Seat23
        // 
        Seat23.BackColor = SystemColors.ActiveBorder;
        Seat23.Dock = DockStyle.Fill;
        Seat23.Location = new Point(189, 218);
        Seat23.Name = "Seat23";
        Seat23.Size = new Size(56, 37);
        Seat23.TabIndex = 28;
        Seat23.Text = "23";
        Seat23.UseVisualStyleBackColor = false;
        // 
        // Seat22
        // 
        Seat22.BackColor = SystemColors.ActiveBorder;
        Seat22.Dock = DockStyle.Fill;
        Seat22.Location = new Point(65, 218);
        Seat22.Name = "Seat22";
        Seat22.Size = new Size(56, 37);
        Seat22.TabIndex = 26;
        Seat22.Text = "22";
        Seat22.UseVisualStyleBackColor = false;
        // 
        // Seat21
        // 
        Seat21.BackColor = SystemColors.ActiveBorder;
        Seat21.Dock = DockStyle.Fill;
        Seat21.Location = new Point(3, 218);
        Seat21.Name = "Seat21";
        Seat21.Size = new Size(56, 37);
        Seat21.TabIndex = 25;
        Seat21.Text = "21";
        Seat21.UseVisualStyleBackColor = false;
        // 
        // Seat20
        // 
        Seat20.BackColor = SystemColors.ActiveBorder;
        Seat20.Dock = DockStyle.Fill;
        Seat20.Location = new Point(251, 175);
        Seat20.Name = "Seat20";
        Seat20.Size = new Size(57, 37);
        Seat20.TabIndex = 24;
        Seat20.Text = "20";
        Seat20.UseVisualStyleBackColor = false;
        // 
        // Seat19
        // 
        Seat19.BackColor = SystemColors.ActiveBorder;
        Seat19.Dock = DockStyle.Fill;
        Seat19.Location = new Point(189, 175);
        Seat19.Name = "Seat19";
        Seat19.Size = new Size(56, 37);
        Seat19.TabIndex = 23;
        Seat19.Text = "19";
        Seat19.UseVisualStyleBackColor = false;
        // 
        // Seat18
        // 
        Seat18.BackColor = SystemColors.ActiveBorder;
        Seat18.Dock = DockStyle.Fill;
        Seat18.Location = new Point(65, 175);
        Seat18.Name = "Seat18";
        Seat18.Size = new Size(56, 37);
        Seat18.TabIndex = 21;
        Seat18.Text = "18";
        Seat18.UseVisualStyleBackColor = false;
        // 
        // Seat17
        // 
        Seat17.BackColor = SystemColors.ActiveBorder;
        Seat17.Dock = DockStyle.Fill;
        Seat17.Location = new Point(3, 175);
        Seat17.Name = "Seat17";
        Seat17.Size = new Size(56, 37);
        Seat17.TabIndex = 20;
        Seat17.Text = "17";
        Seat17.UseVisualStyleBackColor = false;
        // 
        // Seat16
        // 
        Seat16.BackColor = SystemColors.ActiveBorder;
        Seat16.Dock = DockStyle.Fill;
        Seat16.Location = new Point(251, 132);
        Seat16.Name = "Seat16";
        Seat16.Size = new Size(57, 37);
        Seat16.TabIndex = 19;
        Seat16.Text = "16";
        Seat16.UseVisualStyleBackColor = false;
        // 
        // Seat15
        // 
        Seat15.BackColor = SystemColors.ActiveBorder;
        Seat15.Dock = DockStyle.Fill;
        Seat15.Location = new Point(189, 132);
        Seat15.Name = "Seat15";
        Seat15.Size = new Size(56, 37);
        Seat15.TabIndex = 18;
        Seat15.Text = "15";
        Seat15.UseVisualStyleBackColor = false;
        // 
        // Seat14
        // 
        Seat14.BackColor = SystemColors.ActiveBorder;
        Seat14.Dock = DockStyle.Fill;
        Seat14.Location = new Point(65, 132);
        Seat14.Name = "Seat14";
        Seat14.Size = new Size(56, 37);
        Seat14.TabIndex = 16;
        Seat14.Text = "14";
        Seat14.UseVisualStyleBackColor = false;
        // 
        // Seat13
        // 
        Seat13.BackColor = SystemColors.ActiveBorder;
        Seat13.Dock = DockStyle.Fill;
        Seat13.Location = new Point(3, 132);
        Seat13.Name = "Seat13";
        Seat13.Size = new Size(56, 37);
        Seat13.TabIndex = 15;
        Seat13.Text = "13";
        Seat13.UseVisualStyleBackColor = false;
        // 
        // Seat12
        // 
        Seat12.BackColor = SystemColors.ActiveBorder;
        Seat12.Dock = DockStyle.Fill;
        Seat12.Location = new Point(251, 89);
        Seat12.Name = "Seat12";
        Seat12.Size = new Size(57, 37);
        Seat12.TabIndex = 14;
        Seat12.Text = "12";
        Seat12.UseVisualStyleBackColor = false;
        // 
        // Seat11
        // 
        Seat11.BackColor = SystemColors.ActiveBorder;
        Seat11.Dock = DockStyle.Fill;
        Seat11.Location = new Point(189, 89);
        Seat11.Name = "Seat11";
        Seat11.Size = new Size(56, 37);
        Seat11.TabIndex = 13;
        Seat11.Text = "11";
        Seat11.UseVisualStyleBackColor = false;
        // 
        // Seat10
        // 
        Seat10.BackColor = SystemColors.ActiveBorder;
        Seat10.Dock = DockStyle.Fill;
        Seat10.Location = new Point(65, 89);
        Seat10.Name = "Seat10";
        Seat10.Size = new Size(56, 37);
        Seat10.TabIndex = 11;
        Seat10.Text = "10";
        Seat10.UseVisualStyleBackColor = false;
        // 
        // Seat9
        // 
        Seat9.BackColor = SystemColors.ActiveBorder;
        Seat9.Dock = DockStyle.Fill;
        Seat9.Location = new Point(3, 89);
        Seat9.Name = "Seat9";
        Seat9.Size = new Size(56, 37);
        Seat9.TabIndex = 10;
        Seat9.Text = "9";
        Seat9.UseVisualStyleBackColor = false;
        // 
        // Seat8
        // 
        Seat8.BackColor = SystemColors.ActiveBorder;
        Seat8.Dock = DockStyle.Fill;
        Seat8.Location = new Point(251, 46);
        Seat8.Name = "Seat8";
        Seat8.Size = new Size(57, 37);
        Seat8.TabIndex = 9;
        Seat8.Text = "8";
        Seat8.UseVisualStyleBackColor = false;
        // 
        // Seat7
        // 
        Seat7.BackColor = SystemColors.ActiveBorder;
        Seat7.Dock = DockStyle.Fill;
        Seat7.Location = new Point(189, 46);
        Seat7.Name = "Seat7";
        Seat7.Size = new Size(56, 37);
        Seat7.TabIndex = 8;
        Seat7.Text = "7";
        Seat7.UseVisualStyleBackColor = false;
        // 
        // Seat6
        // 
        Seat6.BackColor = SystemColors.ActiveBorder;
        Seat6.Dock = DockStyle.Fill;
        Seat6.Location = new Point(65, 46);
        Seat6.Name = "Seat6";
        Seat6.Size = new Size(56, 37);
        Seat6.TabIndex = 6;
        Seat6.Text = "6";
        Seat6.UseVisualStyleBackColor = false;
        // 
        // Seat5
        // 
        Seat5.BackColor = SystemColors.ActiveBorder;
        Seat5.Dock = DockStyle.Fill;
        Seat5.Location = new Point(3, 46);
        Seat5.Name = "Seat5";
        Seat5.Size = new Size(56, 37);
        Seat5.TabIndex = 5;
        Seat5.Text = "5";
        Seat5.UseVisualStyleBackColor = false;
        // 
        // Seat4
        // 
        Seat4.BackColor = SystemColors.ActiveBorder;
        Seat4.Dock = DockStyle.Fill;
        Seat4.Location = new Point(251, 3);
        Seat4.Name = "Seat4";
        Seat4.Size = new Size(57, 37);
        Seat4.TabIndex = 4;
        Seat4.Text = "4";
        Seat4.UseVisualStyleBackColor = false;
        // 
        // Seat3
        // 
        Seat3.BackColor = SystemColors.ActiveBorder;
        Seat3.Dock = DockStyle.Fill;
        Seat3.Location = new Point(189, 3);
        Seat3.Name = "Seat3";
        Seat3.Size = new Size(56, 37);
        Seat3.TabIndex = 3;
        Seat3.Text = "3";
        Seat3.UseVisualStyleBackColor = false;
        // 
        // Seat2
        // 
        Seat2.BackColor = SystemColors.ActiveBorder;
        Seat2.Dock = DockStyle.Fill;
        Seat2.Location = new Point(65, 3);
        Seat2.Name = "Seat2";
        Seat2.Size = new Size(56, 37);
        Seat2.TabIndex = 1;
        Seat2.Text = "2";
        Seat2.UseVisualStyleBackColor = false;
        // 
        // Seat1
        // 
        Seat1.BackColor = SystemColors.ActiveBorder;
        Seat1.Dock = DockStyle.Fill;
        Seat1.Location = new Point(3, 3);
        Seat1.Name = "Seat1";
        Seat1.Size = new Size(56, 37);
        Seat1.TabIndex = 0;
        Seat1.Text = "1";
        Seat1.UseVisualStyleBackColor = false;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1270, 632);
        Controls.Add(MainTableLayout);
        Margin = new Padding(2);
        Name = "MainForm";
        Text = "Form1";
        Load += Form1_Load;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        MainTableLayout.ResumeLayout(false);
        SearchTableLayout.ResumeLayout(false);
        SearchTableLayout.PerformLayout();
        ButtonTable.ResumeLayout(false);
        tableLayoutPanel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView blazorWebView1;
    private Button button2;
    private TextBox textBox_Status;
    private TextBox textBox_FlightNumber;
    private Label label_ConnectionStatus;
    private TextBox textBox_HubURL;
    private Label label2;
    private GroupBox groupBox1;
    private Button button3;
    private TableLayoutPanel MainTableLayout;
    private TableLayoutPanel SearchTableLayout;
    private TextBox SearchTextBox;
    private Button SearchButton;
    private FlowLayoutPanel ResultPassenger;
    private TableLayoutPanel ButtonTable;
    private Button PrintButton;
    private Button CheckButton;
    private TableLayoutPanel tableLayoutPanel1;
    private Button Seat1;
    private Button Seat4;
    private Button Seat3;
    private Button Seat2;
    private Button Seat40;
    private Button Seat39;
    private Button Seat38;
    private Button Seat37;
    private Button Seat36;
    private Button Seat35;
    private Button Seat34;
    private Button Seat33;
    private Button Seat32;
    private Button Seat31;
    private Button Seat30;
    private Button Seat29;
    private Button Seat28;
    private Button Seat27;
    private Button Seat26;
    private Button Seat25;
    private Button Seat24;
    private Button Seat23;
    private Button Seat22;
    private Button Seat21;
    private Button Seat20;
    private Button Seat19;
    private Button Seat18;
    private Button Seat17;
    private Button Seat16;
    private Button Seat15;
    private Button Seat14;
    private Button Seat13;
    private Button Seat12;
    private Button Seat11;
    private Button Seat10;
    private Button Seat9;
    private Button Seat8;
    private Button Seat7;
    private Button Seat6;
    private Button Seat5;
}
