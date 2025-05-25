using System; 
using OOP;
namespace practical_work_ii_oop;

public partial class RecoverPage : ContentPage
{
    private readonly string userFile = "files/users.csv";

    public RecoverPage()
    {
        InitializeComponent();
    }

    // Recover Button 
    private async void OnRecoverClicked(object sender, EventArgs e)
    {

        if (NameEntry.Text == null || NameEntry.Text.Trim() == "" ||
            UsernameEntry.Text == null || UsernameEntry.Text.Trim() == "" ||
            EmailEntry.Text == null || EmailEntry.Text.Trim() == "")
        {
            await DisplayAlert("Error", "Please fill in all user information fields.", "OK");
            return;
        }

        string name = NameEntry.Text.Trim();
        string username = UsernameEntry.Text.Trim();
        string email = EmailEntry.Text.Trim();

        if (NewPasswordEntry.Text == null || NewPasswordEntry.Text == "")
        {
            await DisplayAlert("Error", "New password is required.", "OK");
            return;
        }

        if (ConfirmNewPasswordEntry.Text == null || ConfirmNewPasswordEntry.Text == "")
        {
            await DisplayAlert("Error", "Please confirm the new password.", "OK");
            return;
        }

        string newPassword = NewPasswordEntry.Text;
        string confirmPassword = ConfirmNewPasswordEntry.Text;

        if (newPassword != confirmPassword)
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }


        if (!IsValidPassword(newPassword))
        {
            await DisplayAlert("Error", "Password must be at least 8 characters long, with uppercase, lowercase, number, and symbol.", "OK");
            return;
        }


        if (!File.Exists(userFile))
        {
            await DisplayAlert("Error", "User database not found.", "OK");
            return;
        }

        bool userFound = false;
        string separator = ";";
        List<string> lines = new List<string>();

        // Read lines using StreamReader
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

                var parts = line.Split(separator);

                if (parts.Length >= 5 && parts[0].Trim() == name && parts[1].Trim() == username && parts[2].Trim() == email)
                {
                    parts[3] = newPassword; // Update password
                    line = string.Join(separator, parts);
                    userFound = true;
                }

                lines.Add(line); // Add updated or original line
            }
        }

        // Write lines using StreamWriter
        if (userFound)
        {
            using (StreamWriter sw = new StreamWriter(userFile))
            {
                foreach (string updatedLine in lines)
                {
                    sw.WriteLine(updatedLine);
                }
            }

            await DisplayAlert("Success", "Password updated successfully.", "OK");
            await Navigation.PushAsync(new LoginPage());
        }
        else
        {
            await DisplayAlert("Error", "User information not found.", "OK");
        }
    }


    // Validates the password requirements
    private bool IsValidPassword(string password)
    {
        bool hasUpper = false;
        bool hasLower = false;
        bool hasDigit = false;
        bool hasSymbol = false;

        if (password.Length < 8)
        {
            return false;
        }

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

    // Login Link
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
