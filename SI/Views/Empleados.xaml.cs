namespace SI.Views;

public partial class Empleados : ContentPage
{
    public Empleados()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.Home()); 
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listaempleados.ItemsSource = await App.Database.GetListaempleados(); 
    }
}