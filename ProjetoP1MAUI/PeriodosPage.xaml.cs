namespace ProjetoP1MAUI;

public partial class PeriodosPage : ContentPage
{
    public PeriodosPage()
    {
        InitializeComponent();
    }

    // sempre que a tela aparece, atualiza o grid
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Carregar();
    }

    private void Carregar()
    {
        string texto = entPesquisa.Text ?? "";
        cvPeriodos.ItemsSource = null;
        cvPeriodos.ItemsSource = Dados.Periodos
            .Where(p => p.PerNome.ToLower().Contains(texto.ToLower()))
            .ToList();
    }

    private void btnPesquisarOnClick(object sender, EventArgs e)
    {
        Carregar();
    }

    private async void btnInserirOnClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PeriodosInserir());
    }

    private async void btnAlterarOnClick(object sender, EventArgs e)
    {
        Periodo p = (Periodo)((Button)sender).BindingContext;
        await Navigation.PushAsync(new PeriodosAlterar(p));
    }

    private async void btnRemoverOnClick(object sender, EventArgs e)
    {
        Periodo p = (Periodo)((Button)sender).BindingContext;

        // não deixa remover se existir curso usando este período
        if (Dados.Cursos.Any(c => c.PerId == p.PerId))
        {
            await DisplayAlert("Aviso", "Não é possível remover, existem cursos neste período.", "OK");
            return;
        }

        bool resposta = await DisplayAlert("Confirmação", "Deseja remover o período " + p.PerNome + "?", "Sim", "Não");
        if (resposta)
        {
            Dados.Periodos.Remove(p);
            Carregar();
        }
    }
}