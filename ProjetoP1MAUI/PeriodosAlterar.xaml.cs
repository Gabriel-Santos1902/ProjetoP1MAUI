namespace ProjetoP1MAUI;

public partial class PeriodosAlterar : ContentPage
{
    Periodo periodo;

    public PeriodosAlterar(Periodo p)
    {
        InitializeComponent();
        periodo = p;
        entNome.Text = p.PerNome;
        entSigla.Text = p.PerSigla;
    }

    private async void btnSalvarOnClick(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entNome.Text) || string.IsNullOrWhiteSpace(entSigla.Text))
        {
            await DisplayAlert("Aviso", "Preencha todos os campos.", "OK");
            return;
        }

        periodo.PerNome = entNome.Text;
        periodo.PerSigla = entSigla.Text;

        await DisplayAlert("Sucesso", "Período alterado!", "OK");
        await Navigation.PopAsync();
    }

    private async void btnVoltarOnClick(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}