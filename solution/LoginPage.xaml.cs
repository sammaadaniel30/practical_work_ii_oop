namespace practical_work_ii_oop;

public partial class LoginPage : ContentPage
{
    // Path to the users information file
    private readonly string userFile = "files/users.csv";

    public LoginPage()
    {
        InitializeComponent();
    }

    // Sign In Button
    private async void OnLogInClicked(object sender, EventArgs e)
    {
        // Input validation
        if (UsernameEntry.Text == null || UsernameEntry.Text.Trim() == "")
        {
            await DisplayAlert("Error", "Username is required.", "OK");
            return;
        }

        if (PasswordEntry.Text == null || PasswordEntry.Text == "")
        {
            await DisplayAlert("Error", "Password is required.", "OK");
            return;
        }

        string username = UsernameEntry.Text.Trim();
        string password = PasswordEntry.Text;

        // Check if user file exists
        if (!File.Exists(userFile))
        {
            await DisplayAlert("Error", "User database not found.", "OK");
            return;
        }

        var lines = File.ReadAllLines(userFile);
        bool found = false;

        // Skips the header
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(';');
            if (parts.Length >= 4)
            {
                string storedUsername = parts[1].Trim();
                string storedPassword = parts[3].Trim();

                if (storedUsername.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                    storedPassword == password)
                {
                    found = true;
                    break;
                }
            }
        }

        if (found)
        {
            await Navigation.PushAsync(new ConversorPage());
        }
        else
        {
            await DisplayAlert("Error", "Wrong credentials", "OK");
        }
    }

    // Forgot Password Link
    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        Thread.Sleep(0);
        await Navigation.PushAsync(new RecoverPage());
    }

    // Register Link
    private async void OnRegisterTapped(object sender, EventArgs e)
    {
        Thread.Sleep(0);
        await Navigation.PushAsync(new RegisterPage());
    }

    // Exit Link
    private void OnExitTapped(object sender, EventArgs e)
    {
        System.Environment.Exit(0);
    }

    // Logout Link
    private async void OnLogoutTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}
