namespace practical_work_ii_oop;

public partial class RegisterPage : ContentPage
{
    // Path to the users information file
    private readonly string userFile = "files/users.csv";

    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        // Input validation
        if (NameEntry.Text == null || NameEntry.Text.Trim() == "")
        {
            await DisplayAlert("Error", "Name is required.", "OK");
            return;
        }
        string name = NameEntry.Text.Trim();

        if (UsernameEntry.Text == null || UsernameEntry.Text.Trim() == "")
        {
            await DisplayAlert("Error", "Username is required.", "OK");
            return;
        }
        string username = UsernameEntry.Text.Trim();

        if (name.Equals(username, StringComparison.OrdinalIgnoreCase))
        {
            await DisplayAlert("Error", "Name and username must be different.", "OK");
            return;
        }

        if (EmailEntry.Text == null || EmailEntry.Text.Trim() == "")
        {
            await DisplayAlert("Error", "Email is required.", "OK");
            return;
        }
        string email = EmailEntry.Text.Trim();

        if (PasswordEntry.Text == null || PasswordEntry.Text == "")
        {
            await DisplayAlert("Error", "Password is required.", "OK");
            return;
        }
        string password = PasswordEntry.Text;

        if (ConfirmPasswordEntry.Text == null || ConfirmPasswordEntry.Text == "")
        {
            await DisplayAlert("Error", "Please confirm the password.", "OK");
            return;
        }
        string confirmPassword = ConfirmPasswordEntry.Text;

        if (password != confirmPassword)
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }

        if (!IsValidPassword(password))
        {
            await DisplayAlert("Error", "Password must be at least 8 characters long and include an uppercase letter, a lowercase letter, a number, and a symbol.", "OK");
            return;
        }

        if (!PolicyCheck.IsChecked)
        {
            await DisplayAlert("Error", "You must agree to the protection policy.", "OK");
            return;
        }

        // Ensure directory exists before writing
        Directory.CreateDirectory(Path.GetDirectoryName(userFile));

        // Create file with header if it doesn't exist
        if (!File.Exists(userFile))
        {
            File.WriteAllText(userFile, "name;username;email;password;operations\n");
        }

        // Checks if username or email already exists
        var lines = File.ReadAllLines(userFile).ToList();
        for (int i = 1; i < lines.Count; i++) // Skip header
        {
            string[] parts = lines[i].Split(';');
            if (parts.Length >= 3)
            {
                if (parts[1].Trim().Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    await DisplayAlert("Error", "Username is already registered.", "OK");
                    return;
                }

                if (parts[2].Trim().Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    await DisplayAlert("Error", "Email is already registered.", "OK");
                    return;
                }
            }
        }

        // Formats the new user row
        string newUser = $"{name};{username};{email};{password};0";

        // Insert into first blank line if it exists, or add at the end
        bool inserted = false;
        
        // Skips the header
        for (int i = 1; i < lines.Count; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
            {
                lines[i] = newUser;
                inserted = true;
                break;
            }
        }

        if (!inserted)
        {
            lines.Add(newUser);
        }

        // Write back all lines
        File.WriteAllLines(userFile, lines);

        await DisplayAlert("Success", "User registered successfully!", "OK");
        await Navigation.PushAsync(new LoginPage());
    }

    // Validates the password requierments
    private bool IsValidPassword(string password)
    {
        bool hasUpper = false;
        bool hasLower = false;
        bool hasDigit = false;
        bool hasSymbol = false;

        if (password.Length < 8) return false;

        foreach (char c in password)
        {
            if (char.IsUpper(c)) hasUpper = true;
            else if (char.IsLower(c)) hasLower = true;
            else if (char.IsDigit(c)) hasDigit = true;
            else hasSymbol = true;
        }

        return hasUpper && hasLower && hasDigit && hasSymbol;
    }

    // Exit Link
    private void OnExitTapped(object sender, EventArgs e)
    {
        System.Environment.Exit(0);
    }

    // Register Button
    private async void OnBackTapped(object sender, EventArgs e)
    {
        Thread.Sleep(0);
        await Navigation.PushAsync(new LoginPage());
    }

    // Logout Link
    private async void OnLogoutTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}
