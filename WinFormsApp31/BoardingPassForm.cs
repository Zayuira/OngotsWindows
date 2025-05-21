using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLibrary.DTO;

namespace WinFormsApp31
{
    public partial class Form1 : Form
    {
        private PassengerDto PassengerDto;
        private PrintDocument printDocument = new PrintDocument();
        public Form1(PassengerDto passengerDto)
        {
            InitializeComponent();
            PassengerDto = passengerDto ?? new PassengerDto();
            setData();
        }

        private void setData()
        {
            PassportNumberLabel.Text = PassengerDto.PassportNumber;
            NameLabel.Text = PassengerDto.Name;
            FligthNumberLabel.Text = PassengerDto.FlightNumber;
            SeatNumberLabel.Text = PassengerDto.SeatCode;
            TimeLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void UserOrderPrintButton_Click(object sender, EventArgs e)
        {
            printDocument.PrintPage += PrintDocument_PrintPage;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDocument,
                Width = 800,
                Height = 600
            };

            previewDialog.ShowDialog();
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            int width = e.PageBounds.Width - 100;
            int left = 50;
            int top = 50;

            // 🔴 Header
            Rectangle headerRect = new Rectangle(left, top, width, 50);
            g.FillRectangle(Brushes.Red, headerRect);
            g.DrawString("BOARDING PASS", new Font("Arial", 16, FontStyle.Bold), Brushes.White, left + 10, top + 10);

            top += 70; // Move down for body

            Font labelFont = new Font("Arial", 10, FontStyle.Bold);
            Font valueFont = new Font("Arial", 12, FontStyle.Regular);
            Brush blackBrush = Brushes.Black;

            int col1X = left + 20;
            int col2X = left + 250;
            int rowHeight = 25;

            // ✈️ Passenger Info
            g.DrawString("NAME OF PASSENGER", labelFont, blackBrush, col1X, top);
            g.DrawString(PassengerDto.Name ?? "Unknown", valueFont, blackBrush, col1X, top + 15);

            g.DrawString("FLIGHT", labelFont, blackBrush, col2X, top);
            g.DrawString(PassengerDto.FlightNumber ?? "N/A", valueFont, blackBrush, col2X, top + 15);

            top += rowHeight * 2;

            g.DrawString("FROM", labelFont, blackBrush, col1X, top);
            g.DrawString("COUNTRY A", valueFont, blackBrush, col1X, top + 15);

            g.DrawString("TO", labelFont, blackBrush, col2X, top);
            g.DrawString("COUNTRY B", valueFont, blackBrush, col2X, top + 15);

            top += rowHeight * 2;

            g.DrawString("GATE", labelFont, blackBrush, col1X, top);
            g.DrawString("A01", valueFont, blackBrush, col1X, top + 15);

            g.DrawString("SEAT", labelFont, blackBrush, col2X, top);
            g.DrawString(PassengerDto.SeatCode ?? "N/A", valueFont, blackBrush, col2X, top + 15);

            top += rowHeight * 2;

            g.DrawString("BOARDING TIME", labelFont, blackBrush, col1X, top);
            g.DrawString("01:00", valueFont, blackBrush, col1X, top + 15);

            g.DrawString("DATE", labelFont, blackBrush, col2X, top);
            g.DrawString(DateTime.Now.ToString("dd MMMM yyyy").ToUpper(), valueFont, blackBrush, col2X, top + 15);

            // 🧾 Footer Line
            top += rowHeight * 3;
            g.DrawLine(Pens.Black, left, top, left + width, top);
            g.DrawString("Have a pleasant flight!", new Font("Arial", 8, FontStyle.Italic), Brushes.Gray, left + 10, top + 5);
        }

    }
}
