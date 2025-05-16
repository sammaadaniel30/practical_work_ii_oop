namespace practical_work_ii_oop;

public partial class LoginPage : ContentPage
{
    private readonly string userFile = "files/users.csv";

    public LoginPage()
    {
        InitializeComponent();
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

        var lines = File.ReadAllLines(userFile);
        
        // Skips the header 
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(';');
            if (parts.Length >= 4 &&
                parts[1].Trim().Equals(username, StringComparison.OrdinalIgnoreCase) &&
                parts[3].Trim() == password)
            {
                await Navigation.PushAsync(new ConversorPage(username));
                return;
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
