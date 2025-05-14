using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace practical_work_ii_oop;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    // Register page
    private async void OnRegisterTapped(object sender, EventArgs e)
    {
        Thread.Sleep(0); 
        await Navigation.PushAsync(new RegisterPage());
    }

    // Forgot password link
    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        Thread.Sleep(0); 
        await Navigation.PushAsync(new RecoverPage());
    }

    // Sign In button
    private async void OnLogInClicked(object sender, EventArgs e)
    {
        Thread.Sleep(0); 
        await Navigation.PushAsync(new ConversorPage());

    }

    // Exit the program
    private void OnExitTapped(object sender, EventArgs e)
    {
        System.Environment.Exit(0);
    }
}
