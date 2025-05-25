using System; 
using OOP;
namespace practical_work_ii_oop;

public partial class LoginPage : ContentPage
{
    private readonly string userFile = "files/users.csv";

    public LoginPage()
    {
        InitializeComponent();
    }

    // Shows the instructions for the converser
    private void ShowInstructions()
    {
        DisplayAlert("Instructions", "After each conversion, you must clear the textbox where the results are shown.", "I understand");
    }

    // Log In Button 
    private async void OnLogInClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text?.Trim() ?? "";
        string password = PasswordEntry.Text ?? "";

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Username and password are required.", "OK");
            return;
        }

        if (!File.Exists(userFile))
        {
            await DisplayAlert("Error", "User database not found.", "OK");
            return;
        }

        // Opens the file using StreamReader
        using (StreamReader sr = new StreamReader(userFile))
        {
            string line;
            bool isFirstLine = true;

            while ((line = sr.ReadLine()) != null)
            {
                if (isFirstLine)
                {
                    isFirstLine = false;
                    continue; // Skips the header
                }

                string[] parts = line.Split(';');

                if (parts.Length >= 4 && parts[1].Trim() == username && parts[3].Trim() == password)
                {
                    ShowInstructions(); // Prints the instructions
                    await Navigation.PushAsync(new ConversorPage(username)); // Navigates to the converter page
                    return;
                }
            }
        }

        await DisplayAlert("Error", "Wrong credentials", "OK");
    }

    // Register Link
    private async void OnRegisterTapped(object sender, EventArgs e)
    {
        Thread.Sleep(0);
        await Navigation.PushAsync(new RegisterPage());
    }

    // Forgot Password Link
    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        Thread.Sleep(0);
        await Navigation.PushAsync(new RecoverPage());
    }

    // Exit Link
    private void OnExitTapped(object sender, EventArgs e)
    {
        System.Environment.Exit(0);
    }
}
