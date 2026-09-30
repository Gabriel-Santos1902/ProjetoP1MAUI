namespace ProjetoP1MAUI;

public partial class DisciplinasPage : ContentPage
{
    public DisciplinasPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Carregar();
    }

    private void Carregar()
    {
        string texto = entPesquisa.Text ?? "";
        cvDisciplinas.ItemsSource = null;
        cvDisciplinas.ItemsSource = Dados.Disciplinas
            .Where(d => d.DisNome.ToLower().Contains(texto.ToLower()))
            .ToList();
    }

    private void btnPesquisarOnClick(object sender, EventArgs e)
    {
        Carregar();
    }

    private async void btnInserirOnClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DisciplinasInserir());
    }

    private async void btnAlterarOnClick(object sender, EventArgs e)
    {
        Disciplina d = (Disciplina)((Button)sender).BindingContext;
        await Navigation.PushAsync(new DisciplinasAlterar(d));
    }

    private async void btnRemoverOnClick(object sender, EventArgs e)
    {
        Disciplina d = (Disciplina)((Button)sender).BindingContext;

        bool resposta = await DisplayAlert("Confirmação", "Deseja remover a disciplina " + d.DisNome + "?", "Sim", "Não");
        if (resposta)
        {
            Dados.Disciplinas.Remove(d);
            Carregar();
        }
    }
}