namespace practical_work_ii_oop;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    // Triggered when the "Sign In" button is pressed
    private async void OnLogInClicked(object sender, EventArgs e)
    {
        string userFile = "files/users.csv";

        // Validate both fields
        if (UsernameEntry.Text == null || UsernameEntry.Text.Trim() == "" ||
            PasswordEntry.Text == null || PasswordEntry.Text == "")
        {
            await DisplayAlert("Error", "Both username and password are required.", "OK");
            return;
        }

        string username = UsernameEntry.Text.Trim();
        string password = PasswordEntry.Text;

        // Check if the file exists
        if (!File.Exists(userFile))
        {
            await DisplayAlert("Error", "User database not found.", "OK");
            return;
        }

        var lines = File.ReadAllLines(userFile);
        bool found = false;

        // Skip the header and check each line for matching credentials
        foreach (string line in lines.Skip(1))
        {
            string[] parts = line.Split(';');
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
