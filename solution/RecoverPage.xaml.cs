namespace practical_work_ii_oop;

public partial class RecoverPage : ContentPage
{
    public RecoverPage()
    {
        InitializeComponent();
    }

    // Forgot Password Link
    private void OnRecoverClicked(object sender, EventArgs e)
    {
        
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
}
