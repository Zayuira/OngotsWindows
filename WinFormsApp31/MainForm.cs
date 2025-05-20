using Microsoft.AspNetCore.SignalR.Client;

namespace WinFormsApp31;

public partial class MainForm : Form
{
    private readonly string _url = "http://localhost:5000/flightstatushub";
    private readonly string _hubUrl = "https://localhost:7227/flightstatusdisplay";
    HubConnection _hubConnection;
    public MainForm()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

        blazorWebView1.WebView.Source = new Uri(_hubUrl);
        //label_ConnectionStatus.Text = _hubConnection.State.ToString();
    }


    private void ChangeStateButton_Click(object sender, EventArgs e)
    {
        using(var stateChangeForm = new StateChangeForm())
        {
            stateChangeForm.ShowDialog();
        }
    }
}
