namespace ProjetoP1MAUI;

public partial class PeriodosInserir : ContentPage
{
    public PeriodosInserir()
    {
        InitializeComponent();
    }

    private async void btnSalvarOnClick(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entNome.Text) || string.IsNullOrWhiteSpace(entSigla.Text))
        {
            await DisplayAlert("Aviso", "Preencha todos os campos.", "OK");
            return;
        }

        Periodo p = new Periodo();
        p.PerId = Dados.ProxPerId;
        Dados.ProxPerId++;
        p.PerNome = entNome.Text;
        p.PerSigla = entSigla.Text;
        Dados.Periodos.Add(p);

        await DisplayAlert("Sucesso", "Período salvo!", "OK");
        await Navigation.PopAsync();
    }

    private async void btnVoltarOnClick(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}