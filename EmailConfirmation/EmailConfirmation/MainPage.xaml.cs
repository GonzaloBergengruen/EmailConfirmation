namespace EmailConfirmation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnEnviarCorreoClicked(object sender, EventArgs e)
        {
            await EnviarCorreoAsync();
        }

        public async Task EnviarCorreoAsync()
        {
            var email = new EmailMessage
            {
                Subject = "Confirmar ingrego",
                Body = "Confirme el ingreso\n\n" +
                       "Aceptar: [https://miaplicacion.com/confirmar?respuesta=true]\n" +
                       "Rechazar: [https://miaplicacion.com/confirmar?respuesta=false]",
                To = new List<string> { "bergengruengonzalo@gmail.com" }
            };

            try
            {
                await Email.ComposeAsync(email);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "No se pudo enviar el email", "Ok");
            }
        }
    }

}
