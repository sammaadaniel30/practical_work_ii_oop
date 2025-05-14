using System.Threading.Tasks;

namespace practical_work_ii_oop;

public partial class ConversorPage : ContentPage
{
    public ConversorPage()
    {
        InitializeComponent();
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
        
    }

    // Button DecimalToTwoComplement
    private void OnConvertDecimalToTwoComplement(object sender, EventArgs e)
    {
        
    }

    // Button DecimalToOctal
    private void OnConvertDecimalToOctal(object sender, EventArgs e)
    {
        
    }

    // Button DecimalToHexadecimal
    private void OnConvertDecimalToHexadecimal(object sender, EventArgs e)
    {
        
    }

    // Button BinaryToDecimal
    private void OnConvertBinaryToDecimal(object sender, EventArgs e)
    {
        
    }

    // Button TwoComplementToDecimal
    private void OnConvertTwoComplementToDecimal(object sender, EventArgs e)
    {
        
    }

    // Button ConvertOctalToDecimal
    private void OnConvertOctalToDecimal(object sender, EventArgs e)
    {
        
    }

    // Button ConvertHexadecialToDecimal
    private void OnConvertHexadecimalToDecimal(object sender, EventArgs e)
    {
        
    }

    // Operations Page Link
    private async void OnOperationsTapped(object sender, EventArgs e)
    {
        Thread.Sleep(0);
        await Navigation.PushAsync(new OperationsPage());
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
