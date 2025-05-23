using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using FlightLibrary.DTO;
using FlightLibrary.Model;

namespace WinFormsApp31
{
    public partial class Form1 : Form
    {
        private PassengerDto PassengerDto;
        private FlightInfo FlightInfo;
        private PrintDocument printDocument = new PrintDocument();

        public Form1(PassengerDto passengerDto, FlightInfo flightinfo)
        {
            InitializeComponent();
            PassengerDto = passengerDto ?? new PassengerDto();
            FlightInfo = flightinfo ?? new FlightInfo();
            setData();

            PaperSize ticketSize = new PaperSize("BoardingPass", 787, 315);
            printDocument.DefaultPageSettings.PaperSize = ticketSize;
            printDocument.DefaultPageSettings.Landscape = false;
            printDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            printDocument.PrintPage += PrintDocument_PrintPage;
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
            try
            {
                PrintDocument printDocument = new PrintDocument();

                int width = 800;
                int height = 400;

                PaperSize ticketSize = new PaperSize("BoardingPass", width, height);
                printDocument.DefaultPageSettings.PaperSize = ticketSize;
                printDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                printDocument.PrintPage += PrintDocument_PrintPage;

                using (PrintDialog printDialog = new PrintDialog())
                {
                    printDialog.Document = printDocument;
                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        printDocument.PrinterSettings = printDialog.PrinterSettings;
                        printDocument.Print();
                    }
                }
                MessageBox.Show("Тасалбар хэвлэгдсэн.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Хэвлэх үед алдаа гарлаа: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int left = 10;
            int top = 10;
            int width = e.PageBounds.Width - 20;

            Rectangle headerRect = new Rectangle(left, top, width, 40);
            g.FillRectangle(Brushes.Red, headerRect);
            g.DrawString("BOARDING PASS", new Font("Arial", 14, FontStyle.Bold), Brushes.White, left + 10, top + 8);

            top += 50;

            Font labelFont = new Font("Arial", 8, FontStyle.Bold);
            Font valueFont = new Font("Arial", 10, FontStyle.Regular);
            Brush blackBrush = Brushes.Black;

            int col1X = left + 10;
            int col2X = left + 200;
            int rowHeight = 18;

            g.DrawString("NAME OF PASSENGER", labelFont, blackBrush, col1X, top);
            g.DrawString(PassengerDto.Name ?? "Unknown", valueFont, blackBrush, col1X, top + 12);

            g.DrawString("FLIGHT", labelFont, blackBrush, col2X, top);
            g.DrawString(PassengerDto.FlightNumber ?? "N/A", valueFont, blackBrush, col2X, top + 12);

            top += rowHeight * 2;

            g.DrawString("FROM", labelFont, blackBrush, col1X, top);
            g.DrawString(FlightInfo.Origin ?? "", valueFont, blackBrush, col1X, top + 12);

            g.DrawString("TO", labelFont, blackBrush, col2X, top);
            g.DrawString(FlightInfo.Destination ?? "", valueFont, blackBrush, col2X, top + 12);

            top += rowHeight * 2;

            g.DrawString("GATE", labelFont, blackBrush, col1X, top);
            g.DrawString(FlightInfo.FlightNumber ?? "", valueFont, blackBrush, col1X, top + 12);

            g.DrawString("SEAT", labelFont, blackBrush, col2X, top);
            g.DrawString(PassengerDto.SeatCode ?? "N/A", valueFont, blackBrush, col2X, top + 12);

            top += rowHeight * 2;

            g.DrawString("BOARDING TIME", labelFont, blackBrush, col1X, top);
            g.DrawString(FlightInfo.DepartureTime ?? "", valueFont, blackBrush, col1X, top + 12);

            g.DrawString("DATE", labelFont, blackBrush, col2X, top);
            g.DrawString(DateTime.Now.ToString("dd MMMM yyyy").ToUpper(), valueFont, blackBrush, col2X, top + 12);

            // Footer
            top += rowHeight * 2;
            g.DrawLine(Pens.Black, left, top, left + width, top);
            g.DrawString("Have a pleasant flight!", new Font("Arial", 8, FontStyle.Italic), Brushes.Gray, left + 10, top + 5);
        }
    }
}