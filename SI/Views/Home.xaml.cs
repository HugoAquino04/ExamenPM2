using SI.Controllers;
using SI.Models;

namespace SI.Views;

public partial class Home : ContentPage
{

    FileResult filefoto = null;

    public Home()
	{
		InitializeComponent();
	}

    private async Task<String> ImageBase64()
    {
        if (filefoto != null)
        {
            using (var stream = await filefoto.OpenReadAsync())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await stream.CopyToAsync(ms);
                    byte[] data = ms.ToArray();
                    return Convert.ToBase64String(data);
                }
            }
        }

        return null;
    }
    private async void btnagregar_Clicked(object sender, EventArgs e)
    {
        var empleados = new Models.Empleados
        {
            Identidad = identidad.Text,
            Nombre = Nombre.Text,
            Fechaing = fechaing.Date,
            Puesto = Puesto.Text,
            Correo = Correo.Text,
            Foto   = await ImageBase64()
        };

        if (await App.Database.GuardarEmpleado(empleados) > 0)    
        {
            await DisplayAlert("Aviso", "Empleado Ingresada con exito", "OK");
        }
        else
        {
            await DisplayAlert("Aviso", "Datos no Registrados", "OK");
        }

        var pagina = new Views.Empleados();
        await Navigation.PushAsync(pagina);
    }
  


    private async void btnfoto_Clicked(object sender, EventArgs e)
    {
        try
        {
            filefoto = await MediaPicker.Default.CapturePhotoAsync();

            if (filefoto != null)
            {
                var stream = await filefoto.OpenReadAsync();
                foto.Source = ImageSource.FromStream(() => stream);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se puedo capturar imagen {ex.Message}", "OK");

        }
    }
}