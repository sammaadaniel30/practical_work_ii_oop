using System; 
using OOP;
namespace practical_work_ii_oop;

public partial class RegisterPage : ContentPage
{
    // Path to the users information file
    private readonly string userFile = "files/users.csv";

    public RegisterPage()
    {
        InitializeComponent();
        EnsureUserFileHasHeader(); 
    }

    private void EnsureUserFileHasHeader()
    {
        string header = "name;username;email;password;operations"; // Defines the header
        string remainingContent;
        string firstLine;

        if (!File.Exists(userFile))
        {
            // File does not exist, create it with the header
            using (StreamWriter writer = new StreamWriter(userFile))
            {
                writer.WriteLine(header);
            }
        }
        else
        {
            // File exists, check if it has the correct header
            using (StreamReader reader = new StreamReader(userFile))
            {
                firstLine = reader.ReadLine();
                if (firstLine != null && firstLine.Trim() == header)
                {
                    return; // Header is correct, do nothing
                }

                remainingContent = reader.ReadToEnd(); // Read the rest of the file
            }

            // Now safely write back with corrected header
            using (StreamWriter writer = new StreamWriter(userFile))
            {
                writer.WriteLine(header);

                if (!string.IsNullOrWhiteSpace(firstLine))
                    writer.WriteLine(firstLine); // Write previous first line (was not the correct header)

                if (!string.IsNullOrWhiteSpace(remainingContent))
                    writer.Write(remainingContent.TrimStart('\r', '\n')); // Write remaining lines
            }
        }
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

        // Checks if username or email already exists
        bool usernameExists = false;
        bool emailExists = false;
        string separator = ";";
        List<string> lines = new List<string>();

        // Read existing lines from the user file
        using (StreamReader sr = new StreamReader(userFile))
        {
            string line;
            bool isFirstLine = true;

            while ((line = sr.ReadLine()) != null)
            {
                if (isFirstLine)
                {
                    lines.Add(line); // Keep header
                    isFirstLine = false;
                    continue;
                }

                string[] parts = line.Split(separator);

                if (parts.Length >= 3)
                {
                    if (parts[1].Trim() == username)
                    {
                        usernameExists = true;
                    }

                    if (parts[2].Trim() == email)
                    {
                        emailExists = true;
                    }
                }

                lines.Add(line);
            }
        }

        // Checks if username or email already exists
        if (usernameExists)
        {
            await DisplayAlert("Error", "Username is already registered.", "OK");
            return;
        }

        if (emailExists)
        {
            await DisplayAlert("Error", "Email is already registered.", "OK");
            return;
        }

        // Formats the new user row
        string newUser = $"{name};{username};{email};{password};0";

        bool inserted = false;

        // Looks for the first blank line to insert the user
        for (int i = 1; i < lines.Count; i++) // Skip header
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
            {
                lines[i] = newUser;
                inserted = true;
                break;
            }
        }

        // If no blank line found, add at the end
        if (!inserted)
        {
            lines.Add(newUser);
        }

        // Write back all lines to the file
        using (StreamWriter writer = new StreamWriter(userFile))
        {
            foreach (var updatedLine in lines)
            {
                await writer.WriteLineAsync(updatedLine);
            }
        }

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
