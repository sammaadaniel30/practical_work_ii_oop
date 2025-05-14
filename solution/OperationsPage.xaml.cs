namespace practical_work_ii_oop;

public partial class OperationsPage : ContentPage
{
    public OperationsPage()
    {
        InitializeComponent();
    }

    // Conversor Link
    private async void OnBackTapped(object sender, EventArgs e)
    {
        Thread.Sleep(0);
        await Navigation.PushAsync(new ConversorPage());
    }

    // Logout link
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
