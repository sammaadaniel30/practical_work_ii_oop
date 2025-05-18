using System.Threading.Tasks;
using System.IO;
using OOP;
using System.Linq;

namespace practical_work_ii_oop;

public partial class ConversorPage : ContentPage
{
    private readonly string username;
    private readonly Converter converter = new Converter(); // For calling each operations 
    private readonly string userFile = "files/users.csv";

    public ConversorPage(string username)
    {
        InitializeComponent();
        this.username = username; // Gets the username from login  
        
    }

    // Button 0
    private void OnClick0(object sender, EventArgs e)
    {
        InputEntry.Text += "0";
    }

    // Button 1
    private void OnClick1(object sender, EventArgs e)
    {
        InputEntry.Text += "1";
    }

    // Button 2
    private void OnClick2(object sender, EventArgs e)
    {
        InputEntry.Text += "2";
    }

    // Button 3
    private void OnClick3(object sender, EventArgs e)
    {
        InputEntry.Text += "3";
    }

    // Button 4
    private void OnClick4(object sender, EventArgs e)
    {
        InputEntry.Text += "4";
    }

    // Button 5
    private void OnClick5(object sender, EventArgs e)
    {
        InputEntry.Text += "5";
    }

    // Button 6
    private void OnClick6(object sender, EventArgs e)
    {
        InputEntry.Text += "6";
    }

    // Button 7
    private void OnClick7(object sender, EventArgs e)
    {
        InputEntry.Text += "7";
    }

    // Button 8
    private void OnClick8(object sender, EventArgs e)
    {
        InputEntry.Text += "8";
    }

    // Button 9
    private void OnClick9(object sender, EventArgs e)
    {
        InputEntry.Text += "9";
    }

    // Button A
    private void OnClickA(object sender, EventArgs e)
    {
        InputEntry.Text += "A";
    }

    // Button B
    private void OnClickB(object sender, EventArgs e)
    {
        InputEntry.Text += "B";
    }

    // Button C
    private void OnClickC(object sender, EventArgs e)
    {
        InputEntry.Text += "C";
    }

    // Button D
    private void OnClickD(object sender, EventArgs e)
    {
        InputEntry.Text += "D";
    }

    // Button E
    private void OnClickE(object sender, EventArgs e)
    {
        InputEntry.Text += "E";
    }

    // Button F
    private void OnClickF(object sender, EventArgs e)
    {
        InputEntry.Text += "F";
    }

    // Button -
    private void OnClickDash(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(InputEntry.Text))
        {
            InputEntry.Text = "-";
        }
        else if (InputEntry.Text.StartsWith("-"))
        {
            InputEntry.Text = InputEntry.Text.Substring(1);
        }
        else
        {
            InputEntry.Text = "-" + InputEntry.Text;
        }
    }

    // Button AC
    private void OnClearClicked(object sender, EventArgs e)
    {
        InputEntry.Text = string.Empty;
    }

    // Button DecimaltoBinary
    private void OnConvertDecimalToBinary(object sender, EventArgs e)
    {
        PerformConversion(1);
    }

    // Button DecimalToTwoComplement
    private void OnConvertDecimalToTwoComplement(object sender, EventArgs e)
    {
        PerformConversion(4);
    }

    // Button DecimalToOctal
    private void OnConvertDecimalToOctal(object sender, EventArgs e)
    {
        PerformConversion(2);
    }

    // Button DecimalToHexadecimal
    private void OnConvertDecimalToHexadecimal(object sender, EventArgs e)
    {
        PerformConversion(3);
    }

    // Button BinaryToDecimal
    private void OnConvertBinaryToDecimal(object sender, EventArgs e)
    {
        PerformConversion(5);
    }

    // Button TwoComplementToDecimal
    private void OnConvertTwoComplementToDecimal(object sender, EventArgs e)
    {
        PerformConversion(6);
    }

    // Button ConvertOctalToDecimal
    private void OnConvertOctalToDecimal(object sender, EventArgs e)
    {
        PerformConversion(7);
    }

    // Button ConvertHexadecialToDecimal
    private void OnConvertHexadecimalToDecimal(object sender, EventArgs e)
    {
        PerformConversion(8);
    }

    // Operations Page Link
    private async void OnOperationsTapped(object sender, EventArgs e)
    {
        Thread.Sleep(0);
        await Navigation.PushAsync(new OperationsPage(username));
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

    // Method the the conversion
    private async void PerformConversion(int operationIndex)
    {
        string input = InputEntry.Text?.Trim() ?? "";

        if (string.IsNullOrEmpty(input))
        {
            await DisplayAlert("Error", "Please enter a value.", "OK");
            return;
        }

        try
        {
            string output;

            // We ask the bits for the operations which require a specific amount of links
            if (operationIndex == 1 || operationIndex == 4)
            {
                string bitsInput = await DisplayPromptAsync("Define amount of bits", "Enter bit size (8, 16, 32 bits)", "OK", "Cancel"); // Added a textbox for the input of bits

                if (string.IsNullOrWhiteSpace(bitsInput) || 
                !int.TryParse(bitsInput, out int bits) || 
                (bitsInput != "8" && bitsInput != "16" && bitsInput != "32"))
                {              
                    await DisplayAlert("Input Error", "Invalid input. Please enter 8, 16, or 32 bits.", "OK");
                    return;
                }
                

                output = converter.PerformConversion(operationIndex, input, bits);
            }
            else
            {
                output = converter.PerformConversion(operationIndex, input);
            }

            InputEntry.Text = "";
            InputEntry.Text = $"Result: {output}"; // Text instead of text holder to show clearer the answer
            UpdateUserOperationCount(); // Updates the number of users of the 
        }
        catch (Exception ex) // If the conversion does not work 
        {
            await DisplayAlert("Conversion Error", ex.Message, "OK");
            InputEntry.Text = "";
        }
    }

    // Increments the value of operations for the user 
    private void UpdateUserOperationCount()
    {
        if (!File.Exists(userFile)) return;

        var lines = File.ReadAllLines(userFile).ToList();
        string separator = ";";

        for (int i = 1; i < lines.Count; i++)
        {
            string[] parts = lines[i].Split(separator);
            if (parts.Length >= 5 && parts[1].Trim() == username)
            {
                if (int.TryParse(parts[4], out int count))
                {
                    count++;
                    parts[4] = count.ToString();
                    lines[i] = string.Join(separator, parts);
                    File.WriteAllLines(userFile, lines);
                }
                break;
            }
        }
    }
}
