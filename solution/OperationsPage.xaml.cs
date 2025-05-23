using System; 
using OOP;

namespace practical_work_ii_oop;

public partial class OperationsPage : ContentPage
{
    private readonly string username;
    private readonly string userFile = "files/users.csv";

    public OperationsPage(string username)
    {
        InitializeComponent();
        this.username = username;
        LoadUserData();
    }

    // Loads the data of the user from the file 
    private void LoadUserData()
    {
        if (!File.Exists(userFile)) return;

        string separator = ";";
        bool isFirstLine = true;

        // Opens the file using StreamReader
        using (StreamReader sr = new StreamReader(userFile))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                if (isFirstLine)
                {
                    isFirstLine = false; // Skips the header
                    continue;
                }

                string[] parts = line.Split(separator);
                if (parts.Length >= 5 && parts[1].Trim() == username)
                {
                    NameEntry.Text = parts[0];
                    UsernameEntry.Text = parts[1];
                    EmailEntry.Text = parts[2];
                    PasswordEntry.Text = parts[3];
                    OperationsEntry.Text = parts[4];
                    break;
                }
            }
        }
    }

    // Back to Conversor Page
    private async void OnBackTapped(object sender, EventArgs e)
    {
        Thread.Sleep(0);
        await Navigation.PushAsync(new ConversorPage(username));
    }

    // Logout Link 
    private async void OnLogoutTapped(object sender, EventArgs e)
    {
        Thread.Sleep(0);
        await Navigation.PushAsync(new LoginPage());
    }

    // Exit Link 
    private void OnExitTapped(object sender, EventArgs e)
    {
        System.Environment.Exit(0);
    }
}
